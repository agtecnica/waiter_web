using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLEstoqueAjuste
    {
        public int EstoqueAjusteId { get; set; }
        public string Tipo { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public Nullable<bool> MovimentoCancelado { get; set; }
        public Nullable<DateTime> Data { get; set; }
        public int UsuarioId { get; set; }
        public string Justificativa { get; set; }

        public virtual MLProduto Produto { get; set; }
    }
}
