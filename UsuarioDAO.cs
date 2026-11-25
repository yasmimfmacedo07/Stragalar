using System;
using System.Data;
using MySql.Data.MySqlClient;
using Stragalar.Modelos;

namespace Stragalar.Dados
{
    internal class UsuarioDAO
    {
        public Usuario ValidarLogin(string login, string senha)
        {
            const string sql =
                "SELECT idUsuario, nomeUsuario, funcao, senha FROM usuario " +
                "WHERE login = @login AND ativo = TRUE LIMIT 1";

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@login", login);

                using (var leitor = comando.ExecuteReader())
                {
                    if (!leitor.Read() || !string.Equals(leitor.GetString("senha"), senha, StringComparison.Ordinal))
                    {
                        return null;
                    }

                    return new Usuario
                    {
                        IdUsuario = leitor.GetInt32("idUsuario"),
                        NomeUsuario = leitor.GetString("nomeUsuario"),
                        Funcao = leitor.GetString("funcao")
                    };
                }
            }
        }

        public int Inserir(Usuario usuario)
        {
            const string sql = @"INSERT INTO usuario 
                (nomeUsuario, login, senha, funcao, ativo) 
                VALUES (@nome, @login, @senha, @funcao, @ativo)";

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@nome", usuario.NomeUsuario);
                comando.Parameters.AddWithValue("@login", usuario.Login);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@funcao", usuario.Funcao);
                comando.Parameters.AddWithValue("@ativo", usuario.Ativo ? 1 : 0);

                if (comando.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException("Nenhuma linha gravada.");
                }

                usuario.IdUsuario = (int)comando.LastInsertedId;
                return usuario.IdUsuario;
            }
        }

        public bool Atualizar(Usuario usuario)
        {
            string sql = string.IsNullOrWhiteSpace(usuario.Senha)
                ? @"UPDATE usuario SET nomeUsuario=@nome, login=@login, funcao=@funcao, ativo=@ativo 
                    WHERE idUsuario=@id"
                : @"UPDATE usuario SET nomeUsuario=@nome, login=@login, senha=@senha, funcao=@funcao, ativo=@ativo 
                    WHERE idUsuario=@id";

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                if (!usuario.Ativo || usuario.Funcao != "Admin")
                {
                    ExigirOutroAdmin(conexao, transacao, usuario.IdUsuario);
                }
                comando.Parameters.AddWithValue("@nome", usuario.NomeUsuario);
                comando.Parameters.AddWithValue("@login", usuario.Login);
                comando.Parameters.AddWithValue("@funcao", usuario.Funcao);
                comando.Parameters.AddWithValue("@ativo", usuario.Ativo ? 1 : 0);
                comando.Parameters.AddWithValue("@id", usuario.IdUsuario);

                if (!string.IsNullOrWhiteSpace(usuario.Senha))
                {
                    comando.Parameters.AddWithValue("@senha", usuario.Senha);
                }

                bool alterado = comando.ExecuteNonQuery() > 0;
                transacao.Commit();
                return alterado;
            }
        }

        public bool Desativar(int idUsuario)
        {
            const string sql = "UPDATE usuario SET ativo = 0 WHERE idUsuario = @id";
            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                ExigirOutroAdmin(conexao, transacao, idUsuario);
                comando.Parameters.AddWithValue("@id", idUsuario);
                bool alterado = comando.ExecuteNonQuery() > 0;
                transacao.Commit();
                return alterado;
            }
        }

        public bool Excluir(int idUsuario)
        {
            const string sql = "DELETE FROM usuario WHERE idUsuario = @id";
            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted))
            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                ExigirOutroAdmin(conexao, transacao, idUsuario);
                comando.Parameters.AddWithValue("@id", idUsuario);
                bool alterado = comando.ExecuteNonQuery() > 0;
                transacao.Commit();
                return alterado;
            }
        }

        public DataTable Listar(string filtro = "")
        {
            string sql = @"SELECT 
                              idUsuario AS Código, 
                              nomeUsuario AS Nome, 
                              login AS Login, 
                              funcao AS Função, 
                              CASE WHEN ativo = 1 THEN 'Ativo' ELSE 'Inativo' END AS Status,
                              dataCadastro AS Cadastro
                           FROM usuario";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql += " WHERE nomeUsuario LIKE @filtro OR login LIKE @filtro OR funcao LIKE @filtro";
            }

            sql += " ORDER BY nomeUsuario";

            using (var conexao = Conexao.ObterConexao())
            using (var adaptador = new MySqlDataAdapter(sql, conexao))
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                }

                var tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
        }

        public Usuario BuscarPorId(int id)
        {
            const string sql = @"SELECT idUsuario, nomeUsuario, login, senha, funcao, ativo, dataCadastro 
                                 FROM usuario WHERE idUsuario = @id";

            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = Convert.ToInt32(leitor["idUsuario"]),
                            NomeUsuario = leitor["nomeUsuario"].ToString(),
                            Login = leitor["login"].ToString(),
                            Senha = leitor["senha"].ToString(),
                            Funcao = leitor["funcao"].ToString(),
                            Ativo = Convert.ToBoolean(leitor["ativo"]),
                            DataCadastro = Convert.ToDateTime(leitor["dataCadastro"])
                        };
                    }
                }
            }
            return null;
        }

        public bool LoginExiste(string login, int idIgnorar = 0)
        {
            const string sql = "SELECT COUNT(*) FROM usuario WHERE login = @login AND idUsuario <> @id";
            using (var conexao = Conexao.ObterConexao())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@login", login);
                comando.Parameters.AddWithValue("@id", idIgnorar);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private static void ExigirOutroAdmin(MySqlConnection conexao,
            MySqlTransaction transacao, int idUsuario)
        {
            const string sql = "SELECT idUsuario FROM usuario WHERE ativo = TRUE " +
                "AND funcao = 'Admin' ORDER BY idUsuario FOR UPDATE";
            int quantidade = 0;
            bool usuarioAdmin = false;
            using (var comando = new MySqlCommand(sql, conexao, transacao))
            using (var leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    quantidade++;
                    if (leitor.GetInt32("idUsuario") == idUsuario)
                    {
                        usuarioAdmin = true;
                    }
                }
            }
            if (usuarioAdmin && quantidade == 1)
            {
                throw new InvalidOperationException("Mantenha pelo menos um Admin ativo no sistema.");
            }
        }
    }
}
