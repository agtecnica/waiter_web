using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Modelo
{
    public class MLProduto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorCompra { get; set; }
        public int CategoriaId { get; set; }
        public Nullable<int> SubCategoriaId { get; set; }
        public decimal ValorVenda { get; set; }
        public string CodigoBarras { get; set; }
        public Nullable<int> UnidMedidaId { get; set; }
        public Nullable<Int32> QtdeUnitaria { get; set; }
        public Nullable<Int32> QtdeMaster { get; set; }
        public Nullable<int> MarcaId { get; set; }
        public int FornecedorId { get; set; }
        public Nullable<decimal> Lucro { get; set; }
        public Nullable<Int32> QtdeMinEstoque { get; set; }
        public Nullable<Int32> QtdeMaxEstoque { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public string Observacao { get; set; }
        public byte[] foto { get; set; }

        public virtual MLCategoria Categoria { get; set; }
        public virtual MLEstoqueMovimentacao EstoqueMovimentacao { get; set; }
        public virtual MLFornecedor Fornecedor { get; set; }
        public virtual MLMarca Marca { get; set; }
        public virtual MLPedidoItem PedidoItem { get; set; }
        public virtual MLEstoque Estoque { get; set; }
        public virtual MLSubCategoria SubCategoria { get; set; }
        public virtual MLUnidadeMedida UnidadeMedida { get; set; }

        //foto
        public void CarregaImagem(String imgCaminho, PictureBox pbImagem)
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho) && pbImagem.Image == null)
                    throw new Exception("Falha ao procurar caminho da imagem!");

                if (pbImagem.Image != null)
                {
                    if (!string.IsNullOrEmpty(imgCaminho))
                    {
                        FileInfo arqImagem = new FileInfo(imgCaminho);
                        FileStream fd = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
                        this.foto = new byte[Convert.ToInt32(arqImagem.Length)];
                        int iBytesRead = fd.Read(this.foto, 0, Convert.ToInt32(arqImagem.Length));
                    }
                    else
                    {
                        ImageConverter converter = new ImageConverter();
                        this.foto = (byte[])converter.ConvertTo(pbImagem.Image, typeof(byte[]));
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Drawing.Image BuscarImagem()
        {
            System.Drawing.Image imagem = null;
            try
            {
                if (foto != null)
                    imagem = (Bitmap)((new ImageConverter()).ConvertFrom(foto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return imagem;
        }
    }
}
