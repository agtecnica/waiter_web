using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLCidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Nullable<int> CodigoIbge { get; set; }
        public Nullable<decimal> DensidadeDemo { get; set; }
        public string Gentilico { get; set; }
        public Nullable<decimal> Area { get; set; }

        public virtual MLEstado Estado { get; set; }
    }
}
