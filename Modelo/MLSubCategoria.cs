using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLSubCategoria
    {
        public MLSubCategoria()
        {
            this.Categoria = new MLCategoria();
        }

        public int SubCategoriaId { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }

        public virtual MLCategoria Categoria { get; set; }
        public virtual ICollection<MLProduto> Produto { get; set; }
    }
}
