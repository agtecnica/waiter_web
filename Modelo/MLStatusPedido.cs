using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLStatusPedido
    {
        public MLStatusPedido()
        {
            this.Pedido = new HashSet<MLPedido>();
        }

        public int StatusPedidoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<MLPedido> Pedido { get; set; }

        public virtual StatusPedido Status { get; set; }
        public enum StatusPedido
        {
            ABERTO = 1,
            FINALIZADO = 2,
            ENTRADAOK = 3,
            SAIDAOK = 4,
            CANCELADO = 5
        }

    }
}
