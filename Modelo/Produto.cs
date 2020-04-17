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
    
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            this.EstoqueMovimentacao = new HashSet<EstoqueMovimentacao>();
            this.PedidoItem = new HashSet<PedidoItem>();
        }
    
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> ValorCompra { get; set; }
        public int CategoriaId { get; set; }
        public Nullable<int> SubCategoriaId { get; set; }
        public Nullable<decimal> ValorVenda { get; set; }
        public string CodigoBarras { get; set; }
        public Nullable<int> UnidMedidaId { get; set; }
        public Nullable<int> QtdeUnitaria { get; set; }
        public Nullable<int> QtdeMaster { get; set; }
        public Nullable<int> MarcaId { get; set; }
        public Nullable<int> FornecedorId { get; set; }
        public Nullable<decimal> Lucro { get; set; }
        public Nullable<int> QtdeMinEstoque { get; set; }
        public Nullable<int> QtdeMaxEstoque { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public string Observacao { get; set; }
        public byte[] Foto { get; set; }
        public Nullable<bool> Excluido { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Estoque Estoque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstoqueMovimentacao> EstoqueMovimentacao { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Marca Marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
    }
}
