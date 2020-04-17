using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLServico
    {
        public int ServicoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public int PrevisaoDias { get; set; }
        public string Observacao { get; set; }
    }
}
