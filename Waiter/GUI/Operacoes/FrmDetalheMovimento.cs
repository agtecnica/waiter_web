using Dados;
using GUI.Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GUI.Operacoes.FrmEncerramentoCaixa;

namespace GUI.Operacoes
{
    public partial class FrmDetalheMovimento : Form
    {
        private FrmEncerramentoCaixa.Detalhe tipo;
        private int controleMovimentoCaixaId;

        public FrmDetalheMovimento()
        {
            InitializeComponent();
        }

        public FrmDetalheMovimento(FrmEncerramentoCaixa.Detalhe tipo, int controleMovimentoCaixaId)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.controleMovimentoCaixaId = controleMovimentoCaixaId;
        }

        private void FrmDetalheMovimento_Load(object sender, EventArgs e)
        {
            try
            {
                List<MLDetalheMovimento> listMLResumoMovimento = new List<MLDetalheMovimento>();
                if (tipo.Equals(Detalhe.BOLETO) || tipo.Equals(Detalhe.CHEQUE) || tipo.Equals(Detalhe.CREDITO) || tipo.Equals(Detalhe.DEBITO) || tipo.Equals(Detalhe.DINHEIRO))
                    listMLResumoMovimento = new DLPedido().ListarDetalheMovimento((int)tipo, Sessao.Instance.Caixa.ControleMovimentoCaixaId);
                else if (tipo.Equals(Detalhe.FATURAMENTOREAL))
                {
                    var pedidos = new DLPedido().Listar(new MLPedido()
                    {
                        ControleMovimentoCaixaId = Sessao.Instance.Caixa.ControleMovimentoCaixaId,
                        Tipo = "V"
                    });
                    foreach (var pedido in pedidos)
                    {
                        var detalheMoviemtno = new MLDetalheMovimento() { PedidoId = pedido.PedidoId, DataEmissao = pedido.DataEmissao, Valor = (decimal)pedido.ValorTotal };
                        listMLResumoMovimento.Add(detalheMoviemtno);
                    }
                }

                switch (tipo)
                {
                    case Detalhe.DINHEIRO: lblTipo.Text = "DINHEIRO"; break;
                    case Detalhe.DEBITO: lblTipo.Text = "DÉBITO"; break;
                    case Detalhe.CREDITO: lblTipo.Text = "CRÉDITO"; break;
                    case Detalhe.BOLETO: lblTipo.Text = "BOLETO"; break;
                    case Detalhe.CHEQUE: lblTipo.Text = "CHEQUE"; break;
                    case Detalhe.FATURAMENTO: lblTipo.Text = "FATURAMENTO EM CAIXA"; break;
                    case Detalhe.FATURAMENTOREAL: lblTipo.Text = "FATURAMENTO REAL"; break;
                }
                if (tipo.Equals(Detalhe.FATURAMENTOREAL) || tipo.Equals(Detalhe.DINHEIRO))
                    lblTrocoInicial.Text = "R$ " + new DLControleMovimento().Consultar(controleMovimentoCaixaId).ValorInicial.ToString("F");
                else
                    lblTrocoInicial.Text = "";
                decimal total = 0;

                foreach (var resumo in listMLResumoMovimento)
                    total += resumo.Valor;

                dgvPrincipal.DataSource = listMLResumoMovimento;
                lblTotal.Text = "R$ " + total.ToString();

                MontarGrid();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MontarGrid()
        {

            dgvPrincipal.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            ControleGrid objBL_ControleGrid = new ControleGrid(dgvPrincipal);

            ////Define quais colunas serão visíveis
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "PedidoId", "Valor", "DataEmissao" });

            ////Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "PedidoId", "Valor", "DataEmissao" });

            //Define quais as larguras respectivas das colunas 
            //Int32 larg = lblTopVendasBalcao.Width;
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 33, 33, 34 }, dgvPrincipal.Width);

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "esquerdo", "esquerdo", "esquerdo" });

            //Define a altura das linhas respectivas da Grid 
            //objBL_ControleGrid.DefinirAlturaLinha(40);

        }
    }
}
