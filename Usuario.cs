using System;

namespace Stragalar.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Usuario()
        {
            IdUsuario = 0;
            NomeUsuario = string.Empty;
            Login = string.Empty;
            Senha = string.Empty;
            Funcao = string.Empty;
            Ativo = true;
            DataCadastro = default(DateTime);
        }
    }
}
