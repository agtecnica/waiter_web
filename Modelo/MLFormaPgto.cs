using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLFormaPgto
    {
        public int FormaPgtoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<MLCondicaoPagamento> CondicaoPgto { get; set; }
    }
}
