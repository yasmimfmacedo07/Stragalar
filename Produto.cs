using System;

namespace Stragalar.Modelos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public DateTime? DataValidade { get; set; }
        public DateTime? DataEntrada { get; set; }
        public bool Ativo { get; set; }
        public decimal ValorTotal => QuantidadeEstoque * Preco;

        public Produto()
        {
            Id = 0;
            Nome = string.Empty;
            Categoria = string.Empty;
            UnidadeMedida = string.Empty;
            Preco = 0m;
            QuantidadeEstoque = 0m;
            DataValidade = null;
            DataEntrada = null;
            Ativo = true;
        }
    }
}
