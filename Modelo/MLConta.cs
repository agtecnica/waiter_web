using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLConta
    {
        public int ContaId { get; set; }
        public int FornecedorId { get; set; }
        public int TipoContaId { get; set; }
        public decimal Valor { get; set; }
        public int NrParcelas { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal Juros { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Desconto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataUltimoPgto { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime DataCancelamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Banco { get; set; }

        public MLFornecedor Fornecedor { get; set; }
    }
}
