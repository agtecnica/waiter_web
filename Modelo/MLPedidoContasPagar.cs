using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLPedidoContasPagar
    {
        public int PedidoId { get; set; }
        public string Fornecedor { get; set; }
        public string Tipo { get; set; }
        public DateTime DataEmissao { get; set; }
        public int NrParcelas { get; set; }
        public DateTime UltimoVencimento { get; set; }
        public DateTime? UltimoVencimentoPago { get; set; }
        public DateTime UltimoPagamento { get; set; }
        public DateTime ProximoVencimento { get; set; }
        public int TotalParcVencidas { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public decimal ValorTotalPago { get; set; }
        public decimal ValorTotalAPagar { get; set; }
        public int TotalParcPagas { get; set; }
    }
}
