using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Stragalar.Dados
{
    internal class Conexao
    {
        private const string StringConexao =
            "Server=localhost;Port=3306;Database=db_stragalar;" +
            "Uid=root;Pwd=root;";

        public static MySqlConnection ObterConexao()
        {
            var conexao = new MySqlConnection(StringConexao);
            try
            {
                conexao.Open();
                return conexao;
            }
            catch
            {
                conexao.Dispose();
                throw;
            }
        }

        public static bool TestarConexao(out string mensagem)
        {
            try
            {
                using (var conexao = ObterConexao())
                {
                    mensagem = $"Conectado! MySQL {conexao.ServerVersion}";
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                mensagem = $"Falha {ex.Number}: {ex.Message}";
                return false;
            }
        }
    }
}
