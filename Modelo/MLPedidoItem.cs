using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLPedidoItem
    {
        public MLPedidoItem()
        {
            Pedido = new MLPedido();
            Produto = new MLProduto();
        }
        public int PedidoItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public Nullable<decimal> PerctDesconto { get; set; }
        public Nullable<decimal> PerctAcrescimo { get; set; }
        public Nullable<decimal> ValorDesconto { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<short> DiasPrevisaoEntrega { get; set; }
        public Nullable<System.DateTime> DataEntrega { get; set; }
        public string ObservacaoItem { get; set; }

        public virtual MLPedido Pedido { get; set; }
        public virtual MLProduto Produto { get; set; }
    }
}
