using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Stragalar.Modelos;

namespace Stragalar.Dados
{
    internal class VendaDAO
    {
        public int FinalizarVenda(int idCaixa, int idUsuario, List<ItemVenda> itens, Dictionary<string, decimal> pagamentos)
        {
            decimal total;
            int idVenda;

            total = itens.Sum(item => item.Subtotal);
            if (total <= 0m || itens.Any(item => item.Quantidade <= 0m || item.PrecoUnitario < 0m) ||
                pagamentos.Values.Any(valor => valor <= 0m) || pagamentos.Values.Sum() != total)
            {
                throw new InvalidOperationException("Confira os itens e a soma dos pagamentos da venda.");
            }

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                CaixaDAO.BloquearCaixa(conexao, transacao, idCaixa);
                idVenda = InserirVenda(conexao, transacao, idCaixa, idUsuario, total);

                foreach (ItemVenda item in itens.OrderBy(item => item.IdProduto))
                {
                    AlterarEstoque(conexao, transacao, idUsuario, idVenda, item, false);
                    InserirItem(conexao, transacao, idVenda, item);
                }

                RegistrarPagamentos(conexao, transacao, idCaixa, idUsuario, idVenda,
                    pagamentos, "Entrada", "Venda", $"Pagamento da venda #{idVenda}");

                transacao.Commit();
            }

            return idVenda;
        }
        private static int InserirVenda(MySqlConnection conexao, MySqlTransaction transacao,
            int idCaixa, int idUsuario, decimal total)
        {
            const string sql =
                "INSERT INTO venda (idCaixa, idUsuario, valorTotal, status) " +
                "VALUES (@idCaixa, @idUsuario, @total, TRUE)";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@total", total);
                comando.ExecuteNonQuery();
                return checked((int)comando.LastInsertedId);
            }
        }
        private static void InserirItem(MySqlConnection conexao, MySqlTransaction transacao,
            int idVenda, ItemVenda item)
        {
            const string sql =
                "INSERT INTO itemVenda " +
                "(idVenda, idProduto, quantidade, precoUnitario, subtotal) " +
                "VALUES (@idVenda, @idProduto, @quantidade, @preco, @subtotal)";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idVenda", idVenda);
                comando.Parameters.AddWithValue("@idProduto", item.IdProduto);
                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.Parameters.AddWithValue("@preco", item.PrecoUnitario);
                comando.Parameters.AddWithValue("@subtotal", item.Subtotal);
                comando.ExecuteNonQuery();
            }
        }
        private static void AlterarEstoque(MySqlConnection conexao, MySqlTransaction transacao, int idUsuario, int idVenda, ItemVenda item, bool estorno)
        {
            const string sqlProduto =
                "UPDATE produto SET quantidadeEstoque = quantidadeEstoque + @alteracao " +
                "WHERE idProduto = @idProduto " +
                "AND quantidadeEstoque + @alteracao BETWEEN 0 AND 9999999.999 " +
                "AND (@estorno = TRUE OR (preco = @preco AND ativo = TRUE))";

            using (var comando = new MySqlCommand(sqlProduto, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idProduto", item.IdProduto);
                comando.Parameters.AddWithValue("@alteracao", estorno ? item.Quantidade : -item.Quantidade);
                comando.Parameters.AddWithValue("@estorno", estorno);
                comando.Parameters.AddWithValue("@preco", item.PrecoUnitario);

                if (comando.ExecuteNonQuery() != 1)
                {
                    string mensagem = estorno
                    ? $"O estoque não recebeu a devolução do produto #{item.IdProduto}."
                    : $"Confira o preço e o estoque do produto #{item.IdProduto}.";
                    throw new InvalidOperationException(mensagem);
                }
            }

            const string sqlMovimento =
                "INSERT INTO movimentacaoEstoque (idUsuario, idProduto, tipo, quantidade, motivo) " +
                "VALUES (@idUsuario, @idProduto, @tipo, @quantidade, @motivo)";

            using (var comando = new MySqlCommand(sqlMovimento, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@idProduto", item.IdProduto);
                comando.Parameters.AddWithValue("@tipo", estorno ? "Entrada" : "Saída");
                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.Parameters.AddWithValue("@motivo", (estorno ? "Estorno da venda #" : "Venda #") + idVenda);

                comando.ExecuteNonQuery();
            }
        }

        private static void RegistrarPagamentos(MySqlConnection conexao, MySqlTransaction transacao, int idCaixa, int idUsuario, int idVenda, 
            Dictionary<string, decimal> pagamentos, string tipo, string origem, string descricao)
        {
            foreach (var pagamento in pagamentos)
            {
                CaixaDAO.InserirMovimentacao(conexao, transacao, idCaixa, idUsuario,
                    idVenda, tipo, origem, pagamento.Key, descricao, pagamento.Value);
            }
        }

        public List<Venda> ListarPorCaixa(int idCaixa)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                return LerVendasDoCaixa(conexao, null, idCaixa);
            }
        }

        internal static List<Venda> LerVendasDoCaixa(MySqlConnection conexao,
            MySqlTransaction transacao, int idCaixa)
        {
            const string sql =
                "SELECT venda.idVenda, venda.idCaixa, venda.idUsuario, venda.dataVenda, " +
                "venda.valorTotal, venda.status, " +
                "COALESCE((SELECT GROUP_CONCAT(DISTINCT movimentacaoCaixa.formaPagamento " +
                "ORDER BY movimentacaoCaixa.formaPagamento SEPARATOR ' + ') FROM movimentacaoCaixa " +
                "WHERE movimentacaoCaixa.idVenda = venda.idVenda AND movimentacaoCaixa.origem = 'Venda' " +
                "AND movimentacaoCaixa.tipo = 'Entrada'), " +
                "'') AS pagamento FROM venda WHERE venda.idCaixa = @idCaixa " +
                "ORDER BY venda.dataVenda DESC, venda.idVenda DESC";
            var vendas = new List<Venda>();

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        vendas.Add(new Venda
                        {
                            IdVenda = leitor.GetInt32("idVenda"),
                            IdCaixa = leitor.GetInt32("idCaixa"),
                            IdUsuario = leitor.GetInt32("idUsuario"),
                            DataVenda = leitor.GetDateTime("dataVenda"),
                            ValorTotal = leitor.GetDecimal("valorTotal"),
                            Status = leitor.GetBoolean(leitor.GetOrdinal("status")),
                            Pagamento = leitor.GetString("pagamento")
                        });
                    }
                }
            }

            return vendas;
        }

        public void EstornarVenda(int idCaixa, int idUsuario, int idVenda, string motivo)
        {
            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                ExigirAdmin(conexao, transacao, idUsuario);
                CaixaDAO.BloquearCaixa(conexao, transacao, idCaixa);
                decimal total = LerVendaParaEstorno(conexao, transacao, idCaixa, idVenda);
                List<ItemVenda> itens = LerItens(conexao, transacao, idVenda);
                Dictionary<string, decimal> parcelas =
                    LerPagamentos(conexao, transacao, idVenda);

                if (itens.Count == 0 || itens.Any(item => item.Quantidade <= 0m) ||
                    parcelas.Count == 0 || parcelas.Values.Any(valor => valor <= 0m) ||
                    parcelas.Values.Sum() != total)
                {
                    throw new InvalidOperationException(
                        "Confira os itens e os pagamentos gravados nesta venda.");
                }

                decimal valorDinheiro;
                if (parcelas.TryGetValue("Dinheiro", out valorDinheiro))
                {
                    decimal saldo = CaixaDAO.LerSaldo(conexao, transacao, idCaixa);

                    if (valorDinheiro > saldo)
                    {
                        throw new InvalidOperationException(
                            "Saldo em dinheiro insuficiente para o estorno.");
                    }
                }

                foreach (ItemVenda item in itens)
                {
                    AlterarEstoque(conexao, transacao, idUsuario, idVenda, item, true);
                }

                RegistrarPagamentos(conexao, transacao, idCaixa, idUsuario, idVenda,
                    parcelas, "Saída", "Estorno", motivo);

                const string sql = "UPDATE venda SET status = FALSE WHERE idVenda = @idVenda";
                using (var comando = new MySqlCommand(sql, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idVenda", idVenda);
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        private static void ExigirAdmin(MySqlConnection conexao,
            MySqlTransaction transacao, int idUsuario)
        {
            const string sql =
                "SELECT idUsuario FROM usuario WHERE idUsuario = @idUsuario " +
                "AND ativo = TRUE AND funcao = 'Admin' LOCK IN SHARE MODE";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                if (comando.ExecuteScalar() == null)
                {
                    throw new InvalidOperationException("O estorno exige um Admin ativo.");
                }
            }
        }

        private static decimal LerVendaParaEstorno(MySqlConnection conexao,
            MySqlTransaction transacao, int idCaixa, int idVenda)
        {
            const string sql =
                "SELECT valorTotal FROM venda WHERE idVenda = @idVenda " +
                "AND idCaixa = @idCaixa AND status = TRUE FOR UPDATE";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idVenda", idVenda);
                comando.Parameters.AddWithValue("@idCaixa", idCaixa);
                object total = comando.ExecuteScalar();

                if (total == null)
                {
                    throw new InvalidOperationException(
                        "Selecione uma venda finalizada da sessão aberta.");
                }

                return Convert.ToDecimal(total);
            }
        }

        private static List<ItemVenda> LerItens(MySqlConnection conexao,
            MySqlTransaction transacao, int idVenda)
        {
            const string sql =
                "SELECT idProduto, quantidade, precoUnitario FROM itemVenda " +
                "WHERE idVenda = @idVenda ORDER BY idProduto, idItemVenda";
            var itens = new List<ItemVenda>();

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idVenda", idVenda);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        itens.Add(new ItemVenda
                        {
                            IdProduto = leitor.GetInt32("idProduto"),
                            Quantidade = leitor.GetDecimal("quantidade"),
                            PrecoUnitario = leitor.GetDecimal("precoUnitario")
                        });
                    }
                }
            }

            return itens;
        }

        private static Dictionary<string, decimal> LerPagamentos(MySqlConnection conexao,
            MySqlTransaction transacao, int idVenda)
        {
            const string sql =
                "SELECT formaPagamento, SUM(valor) AS valor FROM movimentacaoCaixa " +
                "WHERE idVenda = @idVenda AND origem = 'Venda' AND tipo = 'Entrada' " +
                "GROUP BY formaPagamento";
            var pagamentos = new Dictionary<string, decimal>();

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idVenda", idVenda);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        pagamentos.Add(leitor.GetString("formaPagamento"),
                            leitor.GetDecimal("valor"));
                    }
                }
            }

            return pagamentos;
        }
    }
}
