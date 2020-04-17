using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public class MLEmpresa
    {

        public MLEmpresa()
        {
            this.EstoqueMovimentacao = new HashSet<MLEstoqueMovimentacao>();
        }

        public int EmpresaId { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TipoPessoa { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        public string Logradouro { get; set; }
        public Nullable<int> Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public Nullable<int> CidadeId { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public Nullable<bool> Excluido { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string CNPJ { get; set; }
        public byte[] foto { get; set; }
        public virtual MLCidade Cidade { get; set; }
        public virtual MLEstado Estado { get; set; }

        public virtual ICollection<MLEstoqueMovimentacao> EstoqueMovimentacao { get; set; }

        public void CarregaImagem(String imgCaminho, PictureBox pbImagem)
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho) && pbImagem.Image == null)
                    throw new Exception("Falha ao procurar caminho da imagem!");

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
                {
                    imagem = (Bitmap)((new ImageConverter()).ConvertFrom(foto));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao carregar imagem!");
            }
            return imagem;
        }
    }
}
