using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Stragalar.Modelos;

namespace Stragalar.Dados
{
    internal class ProdutoDAO
    {
        public int ContarProdutos()
        {
            const string sql = "SELECT COUNT(*) FROM produto";
            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public List<Produto> Listar(bool incluirInativos = false)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                return LerProdutos(conexao, null, incluirInativos);
            }
        }

        internal static List<Produto> LerProdutos(MySqlConnection conexao,
            MySqlTransaction transacao, bool incluirInativos = false)
        {
            const string sql =
                "SELECT idProduto, nomeProduto, categoria, unidadeMedida, preco, " +
                "quantidadeEstoque, dataValidade, dataEntrada, ativo FROM produto " +
                "WHERE ativo = TRUE OR @incluirInativos = TRUE ORDER BY nomeProduto, idProduto";
            var produtos = new List<Produto>();

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@incluirInativos", incluirInativos);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        produtos.Add(new Produto
                        {
                            Id = leitor.GetInt32("idProduto"),
                            Nome = leitor.GetString("nomeProduto"),
                            Categoria = leitor.GetString("categoria"),
                            UnidadeMedida = leitor.GetString("unidadeMedida"),
                            Preco = leitor.GetDecimal("preco"),
                            QuantidadeEstoque = leitor.GetDecimal("quantidadeEstoque"),
                            DataValidade = leitor.IsDBNull(leitor.GetOrdinal("dataValidade"))
                                ? (DateTime?)null : leitor.GetDateTime("dataValidade"),
                            DataEntrada = leitor.IsDBNull(leitor.GetOrdinal("dataEntrada"))
                                ? (DateTime?)null : leitor.GetDateTime("dataEntrada"),
                            Ativo = leitor.GetBoolean(leitor.GetOrdinal("ativo"))
                        });
                    }
                }
            }

            return produtos;
        }

        public int Inserir(Produto produto, int idUsuario)
        {
            const string sql =
                "INSERT INTO produto (nomeProduto, categoria, unidadeMedida, preco, " +
                "quantidadeEstoque, dataValidade, dataEntrada) " +
                "VALUES (@nome, @categoria, @unidade, @preco, @quantidade, @validade, @entrada)";
            int idProduto;

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                using (var comando = new MySqlCommand(sql, conexao, transacao))
                {
                    PreencherParametros(comando, produto);
                    comando.ExecuteNonQuery();
                    idProduto = checked((int)comando.LastInsertedId);
                }

                RegistrarMovimentacao(conexao, transacao, idProduto, idUsuario,
                    produto.QuantidadeEstoque, "Estoque inicial do cadastro");
                transacao.Commit();
            }

            produto.Id = idProduto;
            return produto.Id;
        }

        public void Atualizar(Produto produto, int idUsuario,
            decimal quantidadeAnterior, string motivo)
        {
            const string sqlEstoque =
                "SELECT quantidadeEstoque FROM produto WHERE idProduto = @idProduto FOR UPDATE";
            const string sql =
                "UPDATE produto SET nomeProduto = @nome, categoria = @categoria, " +
                "unidadeMedida = @unidade, preco = @preco, quantidadeEstoque = @quantidade, " +
                "dataValidade = @validade, dataEntrada = @entrada WHERE idProduto = @idProduto";

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                using (var comando = new MySqlCommand(sqlEstoque, conexao, transacao))
                {
                    comando.Parameters.AddWithValue("@idProduto", produto.Id);
                    object resultado = comando.ExecuteScalar();
                    if (resultado == null)
                    {
                        throw new InvalidOperationException("Produto não encontrado. Recarregue a lista.");
                    }

                    if (Convert.ToDecimal(resultado) != quantidadeAnterior)
                    {
                        throw new InvalidOperationException(
                            "O estoque deste produto mudou. Recarregue a lista e selecione o produto novamente.");
                    }
                }

                using (var comando = new MySqlCommand(sql, conexao, transacao))
                {
                    PreencherParametros(comando, produto);
                    comando.Parameters.AddWithValue("@idProduto", produto.Id);
                    comando.ExecuteNonQuery();
                }

                RegistrarMovimentacao(conexao, transacao, produto.Id, idUsuario,
                    produto.QuantidadeEstoque - quantidadeAnterior, motivo);
                transacao.Commit();
            }
        }

        public bool AlterarSituacao(int idProduto, bool ativo)
        {
            const string sql = "UPDATE produto SET ativo = @ativo WHERE idProduto = @idProduto";
            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@idProduto", idProduto);
                comando.Parameters.AddWithValue("@ativo", ativo);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        private static void PreencherParametros(MySqlCommand comando, Produto produto)
        {
            comando.Parameters.AddWithValue("@nome", produto.Nome);
            comando.Parameters.AddWithValue("@categoria", produto.Categoria);
            comando.Parameters.AddWithValue("@unidade", produto.UnidadeMedida);
            comando.Parameters.AddWithValue("@preco", produto.Preco);
            comando.Parameters.AddWithValue("@quantidade", produto.QuantidadeEstoque);
            comando.Parameters.AddWithValue("@validade", (object)produto.DataValidade ?? DBNull.Value);
            comando.Parameters.AddWithValue("@entrada", (object)produto.DataEntrada ?? DBNull.Value);
        }

        private static void RegistrarMovimentacao(MySqlConnection conexao,
            MySqlTransaction transacao, int idProduto, int idUsuario, decimal diferenca, string motivo)
        {
            if (diferenca == 0m)
            {
                return;
            }

            const string sql =
                "INSERT INTO movimentacaoEstoque (idProduto, idUsuario, tipo, quantidade, motivo) " +
                "VALUES (@idProduto, @idUsuario, @tipo, @quantidade, @motivo)";

            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@idProduto", idProduto);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@tipo", diferenca > 0m ? "Entrada" : "Saída");
                comando.Parameters.AddWithValue("@quantidade", Math.Abs(diferenca));
                comando.Parameters.AddWithValue("@motivo", motivo);
                comando.ExecuteNonQuery();
            }
        }
    }
}
