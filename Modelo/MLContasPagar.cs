using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLContasPagar
    {
        public int ContaPagarId { get; set; }
        public int TipoContaId { get; set; }
        public int ContaId { get; set; }
        public bool Cancelado { get; set; }
        public string TipoConta { get; set; }

        public virtual MLPedido Pedido { get; set; }
        public virtual MLConta Conta { get; set; }
    }
}
