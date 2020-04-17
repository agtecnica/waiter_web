using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLPgtoEntrada
    {
        public int PgtoEntradaId { get; set; }
        public int PedidoId { get; set; }
        public int FormaPgtoId { get; set; }
        public decimal Valor { get; set; }

        public enum FormaPagto
        {
            DINHEIRO = 1,
            DEBITO = 2,
            CREDITO = 3,
            BOLETO = 4,
            CHEQUE = 5
        }
    }
}
