using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLEstoqueMovimentacao
    {
        public int EstoqueMovimentacaoId { get; set; }
        public string TipoMovimentacao { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public Nullable<bool> MovimentoCancelado { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public int FornecedorId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }

        public virtual MLFornecedor Fornecedor { get; set; }
        public virtual MLEmpresa Empresa { get; set; }
        public virtual MLPedido Pedido { get; set; }
        public virtual MLProduto Produto { get; set; }
    }
}
