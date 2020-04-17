using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLPedido
    {

        public int PedidoId { get; set; }
        public string Tipo { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> FornecedorId { get; set; }
        public int UsuarioId { get; set; }
        public string NumeroNf { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public int StatusPedidoId { get; set; }
        public Nullable<int> NrParcelas { get; set; }
        public Nullable<System.DateTime> DataCancelamento { get; set; }
        public string NrOrcamentoFornecedor { get; set; }
        public Nullable<System.DateTime> ValidadeProposta { get; set; }
        public string Frete { get; set; }
        public Nullable<int> TransportadorId { get; set; }
        public decimal ValorFrete { get; set; }
        public bool IsCotacao { get; set; }
        public DateTime DataInicioPgto { get; set; }
        public string Observacao { get; set; }
        public Nullable<decimal> Desconto { get; set; }
        public Nullable<decimal> Acrescimo { get; set; }
        public string Lote { get; set; }
        public int CondicaoPgtoId { get; set; }
        public int TipoPagamentoId { get; set; }
        public DateTime? DataVencimento { get; set; }
        public String NotaFiscal { get; set; }

        public string UsuarioNome { get; set; }
        public string FornecedorNome { get; set; }
        public string TransportadorNome { get; set; }
        public string CondicaoPgtoDescricao { get; set; }
        public int CaixaId { get; set; }
        public int ControleMovimentoCaixaId { get; set; }

        public List<MLPedidoItem> listaPedidoItem;
        public MLUsuario Usuario { get; set; }
        public MLCondicaoPagamento CondicaoPagamento { get; set; }
        public virtual MLCliente Cliente { get; set; }
        public virtual ICollection<MLEstoqueMovimentacao> EstoqueMovimentacao { get; set; }
        public virtual MLFornecedor Fornecedor { get; set; }
        public virtual MLStatusPedido StatusPedido { get; set; }
        public virtual MLTransportador Transportador { get; set; }
        public List<MLPgtoEntrada> lstMLPgtoEntrada { get; set; }
        public virtual MLCaixa Caixa { get; set; }
        public string CpfCnpj { get; set; }
        public decimal ValorParcelas { get; set; }
        public DateTime DataPagto { get; set; }
        public decimal ValorTotalPago { get; set; }
        public decimal ValorTroco { get; set; }

        public enum TipoPedido
        {
            COMPRA = 1,
            VENDA = 2,
            COMPRA_VENDA = 3
        }
    }
}
