using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stragalar.Modelos
{
    public class ItemVenda
    {
        public int IdItemVenda { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal => CalcularSubtotal();

        public ItemVenda()
        {
            IdItemVenda = 0;
            IdVenda = 0;
            IdProduto = 0;
            NomeProduto = string.Empty;
            Quantidade = 0;
            PrecoUnitario = 0;
        }

        public decimal CalcularSubtotal()
        {
            return Math.Round(Quantidade * PrecoUnitario, 2, MidpointRounding.AwayFromZero);
        }


    }
}
