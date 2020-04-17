using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLDetalheMovimento
    {
        public int PedidoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
    }
}
