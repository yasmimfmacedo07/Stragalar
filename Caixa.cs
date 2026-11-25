using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stragalar.Modelos
{
    public class Caixa
    {
        public int IdCaixa { get; set; }
        public int IdUsuarioAbertura { get; set; }
        public int? IdUsuarioFechamento { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal? ValorContadoFechamento { get; set; }

        public Caixa()
        {
            IdCaixa = 0;
            IdUsuarioAbertura = 0;
            IdUsuarioFechamento = null;
            DataAbertura = DateTime.Now;
            DataFechamento = null;
            ValorAbertura = 0;
            ValorContadoFechamento = null;
        }

        public bool Aberto => !DataFechamento.HasValue;
    }
}
