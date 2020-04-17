using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLCondicaoPagamento
    {
        public int CondicaoPgtoId { get; set; }
        public string FormaPgtoEntradaDesc { get; set; }


        public Int32 NrParcelas { get; set; }
        public Int32 DiasParaEntrada { get; set; }
        public Int32 Intervalo { get; set; }
        public DateTime Dia1Vencimento { get; set; }

        /// <summary>
        /// 1 - Dinheiro
        /// 2 - Cheque 
        /// 3 - Cartão Débito
        /// 4 - Cartão Crédito
        /// </summary>
        public Int32 FormaPgtoEntradaId { get; set; }
        public String CondicaoPgtoDescricao { get; set; }
        public MLPedido.TipoPedido Tipopedido { get; set; }
    }
}
