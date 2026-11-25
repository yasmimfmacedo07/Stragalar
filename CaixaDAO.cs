using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Stragalar.Modelos;

namespace Stragalar.Dados
{
    internal class CaixaDAO
    {
        public int AbrirCaixa(Caixa caixa)
        {
            return AbrirCaixaComDados(caixa, out _, out _, out _, out _);
        }

        public int AbrirCaixaComDados(Caixa caixa, out List<Produto> produtos,
            out List<Venda> vendas, out DataTable movimentacoes, out decimal saldo)
        {
            const string sqlUsuario =
                "SELECT idUsuario FROM usuario WHERE idUsuario = @idUsuarioAbertura " +
                "AND ativo = TRUE AND funcao IN ('Admin', 'Operador de Caixa') FOR UPDATE";
            const string sqlCaixaAberto =
                "SELECT idCaixa FROM caixa WHERE idUsuarioAbertura = @idUsuarioAbertura " +
                "AND dataFechamento IS NULL LIMIT 1";
            const string sql =
                "INSERT INTO caixa (idUsuarioAbertura, valorAbertura) " +
                "VALUES (@idUsuarioAbertura, @valorAbertura)";
            int idCaixa;

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                using (var comando = new MySqlCommand(sqlUsuario, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idUsuarioAbertura", caixa.IdUsuarioAbertura);
                    if (comando.ExecuteScalar() == null)
                    {
                        throw new InvalidOperationException("O usuário precisa estar ativo e autorizado a operar o caixa.");
                    }
                }

                using (var comando = new MySqlCommand(sqlCaixaAberto, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idUsuarioAbertura", caixa.IdUsuarioAbertura);
                    if (comando.ExecuteScalar() != null)
                    {
                        throw new InvalidOperationException("Já existe um caixa aberto para este usuário.");
                    }
                }

                using (var comando = new MySqlCommand(sql, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idUsuarioAbertura", caixa.IdUsuarioAbertura);
                    comando.Parameters.AddWithValue("@valorAbertura", caixa.ValorAbertura);
                    comando.ExecuteNonQuery();
                    idCaixa = checked((int)comando.LastInsertedId);
                }

                produtos = ProdutoDAO.LerProdutos(conexao, transacao);
                vendas = VendaDAO.LerVendasDoCaixa(conexao, transacao, idCaixa);
                movimentacoes = LerMovimentacoes(conexao, transacao, idCaixa);
                saldo = LerSaldo(conexao, transacao, idCaixa);

                transacao.Commit();
                caixa.IdCaixa = idCaixa;
            }

            return caixa.IdCaixa;
        }

        public List<Caixa> ListarCaixas()
        {
            const string sql = "SELECT * FROM caixa " +
                "ORDER BY dataAbertura DESC, idCaixa DESC";
            var caixas = new List<Caixa>();

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            using (var leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    caixas.Add(MapearCaixas(leitor));
                }
            }

            return caixas;
        }
        public Caixa BuscarCaixaAberto(int idUsuario)
        {
            const string sql =
                "SELECT idCaixa, idUsuarioAbertura, idUsuarioFechamento, " +
                "dataAbertura, dataFechamento, valorAbertura, valorContadoFechamento " +
                "FROM caixa WHERE idUsuarioAbertura = @idUsuario " +
                "AND dataFechamento IS NULL " +
                "ORDER BY dataAbertura DESC, idCaixa DESC LIMIT 1";

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                using (var leitor = comando.ExecuteReader())
                {
                    return leitor.Read() ? MapearCaixas(leitor) : null;
                }
            }
        }
        private static Caixa MapearCaixas(MySqlDataReader leitor)
        {
            int usuarioFechamento, dataFechamento, valorContado;

            usuarioFechamento = leitor.GetOrdinal("idUsuarioFechamento");
            dataFechamento = leitor.GetOrdinal("dataFechamento");
            valorContado = leitor.GetOrdinal("valorContadoFechamento");

            return new Caixa
            {
                IdCaixa = leitor.GetInt32("idCaixa"),
                IdUsuarioAbertura = leitor.GetInt32("idUsuarioAbertura"),
                IdUsuarioFechamento = leitor.IsDBNull(usuarioFechamento) ? (int?)null
                : leitor.GetInt32(usuarioFechamento),
                DataAbertura = leitor.GetDateTime("dataAbertura"),
                DataFechamento = leitor.IsDBNull(dataFechamento) ? (DateTime?)null
                : leitor.GetDateTime("dataFechamento"),
                ValorAbertura = leitor.GetDecimal("valorAbertura"),
                ValorContadoFechamento = leitor.IsDBNull(valorContado) ? (decimal?)null
                : leitor.GetDecimal("valorContadoFechamento")
            };
        }

        public decimal ConsultarSaldo(int idCaixa)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                return LerSaldo(conexao, null, idCaixa);
            }
        }

        internal static decimal LerSaldo(MySqlConnection conexao,
            MySqlTransaction transacao, int idCaixa)
        {
            const string sql =
                "SELECT caixa.valorAbertura + COALESCE((" +
                "    SELECT SUM(CASE movimentacaoCaixa.tipo " +
                "        WHEN 'Entrada' THEN movimentacaoCaixa.valor " +
                "        WHEN 'Saída' THEN -movimentacaoCaixa.valor " +
                "        ELSE 0 END) " +
                "    FROM movimentacaoCaixa " +
                "    WHERE movimentacaoCaixa.idCaixa = caixa.idCaixa " +
                "      AND movimentacaoCaixa.formaPagamento = 'Dinheiro'" +
                "), 0) FROM caixa WHERE caixa.idCaixa = @idCaixa";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                object resultado = comando.ExecuteScalar();

                if (resultado == null)
                {
                    throw new InvalidOperationException("Caixa não encontrado.");
                }

                return Convert.ToDecimal(resultado);
            }
        }
        public decimal ConsultarVendas(int idCaixa)
        {
            const string sql =
                "SELECT COALESCE(SUM(valorTotal), 0) FROM venda " +
                "WHERE idCaixa = @idCaixa AND status = TRUE";

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                return Convert.ToDecimal(comando.ExecuteScalar());
            }
        }
        public decimal FecharCaixa(Caixa caixa, int idUsuario, decimal valorContado)
        {
            decimal saldoEsperado;
            DateTime dataFechamento;

            const string sqlFechar =
                "UPDATE caixa SET idUsuarioFechamento = @idUsuario, " +
                "valorContadoFechamento = @valor, dataFechamento = CURRENT_TIMESTAMP " +
                "WHERE idCaixa = @idCaixa AND dataFechamento IS NULL";
            const string sqlData =
                "SELECT dataFechamento FROM caixa WHERE idCaixa = @idCaixa";

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                BloquearCaixa(conexao, transacao, caixa.IdCaixa);
                saldoEsperado = LerSaldo(conexao, transacao, caixa.IdCaixa);

                using (var comando = new MySqlCommand(sqlFechar, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@valor", valorContado);
                    comando.Parameters.AddWithValue("@idCaixa", caixa.IdCaixa);
                    comando.ExecuteNonQuery();
                }

                using (var comando = new MySqlCommand(sqlData, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idCaixa", caixa.IdCaixa);
                    dataFechamento = (DateTime)comando.ExecuteScalar();
                }

                transacao.Commit();
            }

            caixa.IdUsuarioFechamento = idUsuario;
            caixa.DataFechamento = dataFechamento;
            caixa.ValorContadoFechamento = valorContado;
            return saldoEsperado;
        }
        internal static void BloquearCaixa(MySqlConnection conexao,
            MySqlTransaction transacao, int idCaixa)
        {
            const string sql =
                "SELECT idCaixa FROM caixa " +
                "WHERE idCaixa = @idCaixa AND dataFechamento IS NULL FOR UPDATE";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);

                if (comando.ExecuteScalar() == null)
                {
                    throw new InvalidOperationException(
                        "Caixa já fechado ou não foi encontrado.");
                }
            }
        }
        internal static int InserirMovimentacao(MySqlConnection conexao, MySqlTransaction transacao, int idCaixa, int idUsuario,
            int? idVenda, string tipo, string origem, string formaPagamento, string descricao, decimal valor)
        {
            const string sql =
        "INSERT INTO movimentacaoCaixa (idCaixa, idUsuario, idVenda, tipo, origem, formaPagamento, descricao, valor) " +
        "VALUES (@idCaixa, @idUsuario, @idVenda, @tipo, @origem, @formaPagamento, @descricao, @valor)";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@idVenda", (object)idVenda ?? DBNull.Value);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@origem", origem);
                comando.Parameters.AddWithValue("@formaPagamento", formaPagamento);
                comando.Parameters.AddWithValue("@descricao", descricao);
                comando.Parameters.AddWithValue("@valor", valor);

                comando.ExecuteNonQuery();
                return checked((int)comando.LastInsertedId);

            }
        }

        public int RegistrarSangria(int idCaixa, int idUsuario, decimal valor,
            string motivo)
        {
            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                BloquearCaixa(conexao, transacao, idCaixa);
                decimal saldo = LerSaldo(conexao, transacao, idCaixa);

                if (valor > saldo)
                {
                    throw new InvalidOperationException("Saldo em dinheiro insuficiente.");
                }

                int id = InserirMovimentacao(conexao, transacao, idCaixa, idUsuario,
                    null, "Saída", "Sangria", "Dinheiro", motivo, valor);
                transacao.Commit();
                return id;
            }
        }

        public DataTable ListarMovimentacoes(int idCaixa)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                return LerMovimentacoes(conexao, null, idCaixa);
            }
        }

        private static DataTable LerMovimentacoes(MySqlConnection conexao,
            MySqlTransaction transacao, int idCaixa)
        {
            const string sql =
                "SELECT dataMovimentacao AS DataMovimentacao, origem AS Origem, " +
                "tipo AS Tipo, formaPagamento AS FormaPagamento, descricao AS Descricao, " +
                "valor AS Valor FROM movimentacaoCaixa WHERE idCaixa = @idCaixa " +
                "ORDER BY dataMovimentacao DESC, idMovimentacaoCaixa DESC";
            var tabela = new DataTable();

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                using (var leitor = comando.ExecuteReader())
                {
                    tabela.Load(leitor);
                }
            }

            return tabela;
        }
    }
}
