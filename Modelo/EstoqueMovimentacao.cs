//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstoqueMovimentacao
    {
        public int EstoqueMovimentacaoId { get; set; }
        public string TipoMovimentacao { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public Nullable<bool> MovimentoCancelado { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
