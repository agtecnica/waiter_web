using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLParcelasConta
    {
        public int ContaId { get; set; }
        public int ParcelaNr { get; set; }
        public int TotalParcelas { get; set; }
        public DateTime DataVencimento { get; set; }
        public int IntervaloId { get; set; }
        public int FormaPagtoId { get; set; }
        public DateTime? DataPagto { get; set; }
        public bool Cancelado { get; set; }
        public int CondicaoPgtoId { get; set; }
    }
}
