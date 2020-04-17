using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLEstoque
    {
        public int ProdutoId { get; set; }
        public Nullable<DateTime> DataUltEntrada { get; set; }
        public Nullable<DateTime> DataUltSaida { get; set; }
        public Nullable<decimal> QtdeUltEntrada { get; set; }
        public Nullable<decimal> QtdeUltSaida { get; set; }
        public Nullable<decimal> EstoqueReservado { get; set; }
        public decimal EstoqueReal { get; set; }
        public decimal EstoqueDisponivel { get; set; }
        public Nullable<int> EmpresaId { get; set; }
    }
}
