using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLFornecedor
    {
        
        public MLFornecedor()
        {
            this.Cidade = new MLCidade();
            this.Estado = new MLEstado();
        }

        public int FornecedorId { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TipoPessoa { get; set; }
        public string Observacao { get; set; }
        public bool? Ativo { get; set; }
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
        public string CNPJ { get; set; }
        public string IM { get; set; }

        public virtual MLCidade Cidade { get; set; }
        public virtual MLEstado Estado { get; set; }
        
        public virtual ICollection<MLPedido> Pedido { get; set; }
        
        public virtual ICollection<MLProduto> Produto { get; set; }
    }
}
