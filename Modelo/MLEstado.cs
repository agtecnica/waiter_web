using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLEstado
    {
        public MLEstado()
        {
            this.Cidade = new HashSet<MLCidade>();
        }

        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Regiao { get; set; }

        public virtual ICollection<MLCidade> Cidade { get; set; }
    }
}
