using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stragalar.Modelos
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int IdCaixa { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Status { get; set; }
        public string Pagamento { get; set; }

        public Venda()
        {
            IdVenda = 0;
            IdCaixa = 0;
            IdUsuario = 0;
            DataVenda = DateTime.Now;
            ValorTotal = 0;
            Status = false;
            Pagamento = string.Empty;
        }

        public string Situacao => Status ? "Finalizada" : "Estornada";
    }
}
