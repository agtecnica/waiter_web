using Dados;
using GUI.Ferramentas;
using GUI.Operacoes;
using GUI.Relatorios;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace GUI.Operacoes
{
    public partial class FrmFinalizaVenda : Form
    {
        #region *** PROPRIEDADES ***

        private FrmVendaBalcao frmVendaBalcao { get; set; }
        private FrmPDV frmPDV { get; set; }
        private MLPedido _objMLPedido { get; set; }
        private MLPedidoItem _objMLPedidoItem { get; set; }
        private List<MLPedidoItem> _lstMlPedidoItem { get; set; }
        public int pressEnter { get; set; }
        private bool pressBtnNao { get; set; }
        private bool pressBtnSim { get; set; }

        dynamic pdv;



        bool isAdcionanado { get; set; }
        public MLEstoqueMovimentacao EstoqueMovimentacao { get; private set; }

        #region *** Impressão ***
        SizeF dimensaoItenNr { get; set; }
        SizeF dimensaoItem { get; set; }
        SizeF dimensaoCodigo { get; set; }
        SizeF dimensaoValorUnit { get; set; }
        SizeF dimensaoQtde { get; set; }
        SizeF dimensaoUnMedida { get; set; }
        SizeF dimensaoValorTotal { get; set; }
        SizeF dimensaoOperador { get; set; }
        SizeF dimensaoX { get; set; }
        KeyEventArgs kea { get; set; }
        //ImprimeVenda imprimeVenda { get; set; }

        int largura;
        int altura;

        Font fonte;
        SolidBrush cor;
        int y = 50;
        int x = 0;
        int num_frase = 1;
        int pagina = 0;
        int paginas_criadas = 0;

        #endregion

        #endregion

        #region *** CONSTRUTORES ***

        public FrmFinalizaVenda()
        {
            InitializeComponent();
        }

        public FrmFinalizaVenda(FrmVendaBalcao frmVendaBalcao)
        {
            // TODO: Complete member initialization
            this.frmVendaBalcao = frmVendaBalcao;
            InitializeComponent();
        }

        public FrmFinalizaVenda(FrmPDV frmPDV)
        {
            // TODO: Complete member initialization
            this.frmPDV = frmPDV;
            InitializeComponent();
        }

        #endregion

        #region *** EVENTOS ***

        private void FrmFinalizaVenda_Load(object sender, EventArgs e)
        {
            try
            {
                //if (frmVendaBalcao != null)
                //{
                //    pdv = frmVendaBalcao;
                //}
                //else if (frmPDV != null)
                //{
                // }
                #region *** Abre o Pedido ***
                _objMLPedido = new MLPedido();

                //#region *** Carrega Pedido Padrão***

                //_objMLPedido.Cliente = new MLCliente();
                //_objMLPedido.ClienteId = 6 ; //Destinatário Geral - Consumidor sempre com id '1'

                //_objMLPedido.Usuario = new MLUsuario();
                //_objMLPedido.UsuarioId = frmVendaBalcao._usuario.UsuarioId;

                //_objMLPedido.DataEmissao = DateTime.Now;

                //_objMLPedido.Tipo = "V".ToString();//VENDA

                //_objMLPedido.Caixa = new MLCaixa();
                //_objMLPedido.Caixa.CaixaId = this.frmVendaBalcao._caixa.CaixaId;


                ////_objMLPedido.Emitente = new MlCliente();
                ////_objMLPedido.Emitente.Id = 14;//AMS
                //_objMLPedido.ValorTotal = Convert.ToDecimal(this.frmVendaBalcao.lblValorTotal.Text.Replace("R$ ", ""));


                ////#endregion

                ////#region *** Carrega Itens do Pedido  ***
                //_lstMlPedidoItem = new List<MLPedidoItem>();

                //for (int i = 0; i < this.frmVendaBalcao.dgvGeral.RowCount; i++) //Carrega Itens o Pedido
                //{

                //    _objMLPedidoItem = new MLPedidoItem();
                //    _objMLPedidoItem.Pedido = _objMLPedido;
                //    _objMLPedidoItem.PedidoId = _objMLPedido.PedidoId;
                //    _objMLPedidoItem.Produto = new MLProduto();

                //    _objMLPedidoItem.Produto.UnidadeMedida = new MLUnidadeMedida();
                //    Decimal qtde = 0;
                //    if (this.frmVendaBalcao.dgvGeral.Rows[i].Cells[1].Value != null)
                //    {
                //        _objMLPedidoItem.ProdutoId = (Int32)this.frmVendaBalcao.dgvGeral.Rows[i].Cells[1].Value;

                //        bool isDecimal = Decimal.TryParse(this.frmVendaBalcao.dgvGeral.Rows[i].Cells[3].Value.ToString(), out qtde);
                //        if (isDecimal)
                //            _objMLPedidoItem.Quantidade = Convert.ToInt32(qtde);

                //        _lstMlPedidoItem.Add(_objMLPedidoItem);

                //        _objMLPedido.ValorTotal += (_objMLPedidoItem.Produto.ValorVenda * _objMLPedidoItem.Quantidade);



                //    }
                //}

                //_objMLPedido.PedidoItem = _lstMlPedidoItem;

                //_objMLPedido.PedidoId = new DLPedido().Adicionar(_objMLPedido);

                //#endregion
                #endregion

                pressBtnNao = false;
                pressBtnSim = false;

                isAdcionanado = false;


                #region *** Carrega Combo Forma de Pagamento ***

                List<MLCondicaoPagamento> condPgto = new DLCondicaoPagamento().ListarFormaPagamentoEntrada();

                cmbFormaPgto.ValueMember = "FormaPgtoEntradaId";
                cmbFormaPgto.DisplayMember = "FormaPgtoEntradaDesc";

                cmbFormaPgto.DataSource = condPgto;
                cmbFormaPgto.SelectedIndex = 0;

                #endregion

                ShowPanelFinalizar(true);

                #region *** Reposiciona PainelFinaliza ***
                pnlFinalizarCancelar.Location = new Point(13, 432);
                pnlFinalizarCancelar.BringToFront();
                #endregion
                pressEnter = 0;

                txtValorPago_TextChanged(null, null);
                this.MontarGrid();

                this.frmPDV.CarregarItensPedido(false);
                lblTotalVendaValor.Text = ((double)frmPDV._objMLPedido.ValorTotal).ToString("c");
                lblTotalReceberValor.Text = ((double)frmPDV._objMLPedido.ValorTotal).ToString("c");
                lblSaldoRestanteValor.Text = ((double)frmPDV._objMLPedido.ValorTotal).ToString("c");

                cmbFormaPgto.Focus();
                //txtValorPago.Focus();
                txtValorPago.SelectAll();

                pnlMensagem.BringToFront();


                lblMensagem.Text = "INFORME O VALOR      |      [F4] para FORMA DE PAGAMENTO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            Utils.Moeda(ref txtValorPago);
            try
            {
                if (!String.IsNullOrEmpty(txtValorPago.Text) && txtValorPago.Text != "0,00")
                {
                    //   CalcularValoresVenda();

                    #endregion
                }
                //else
                //{
                //    lblSaldoRestanteValor.Text = lblTotalVendaValor.Text;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CalcularValoresVenda()
        {
            decimal valorPago = 0;
            decimal valorTotal = 0;
            decimal valorTotalReceber = 0;
            decimal valorTotalPago = 0;
            decimal valorUnit = 0;
            decimal valorRecebido = 0;
            decimal saldoRestante = 0;
            decimal desconto = 0;
            decimal acrescimo = 0;

            #region *** CARREGA O DESCONTO DA VENDA EM UMA VARIAVEL ***
            if (lblDescontoValor.Text.Contains("R$"))
                desconto = Convert.ToDecimal(Utils.RemoveCifrao(lblDescontoValor.Text).Trim());
            else
                desconto = Convert.ToDecimal(lblDescontoValor.Text.Trim());
            #endregion

            #region *** CARREGA O ACRESCIMO DA VENDA EM UMA VARIAVEL ***
            if (lblAcrescimoValor.Text.Contains("R$"))
                acrescimo = Convert.ToDecimal(Utils.RemoveCifrao(lblAcrescimoValor.Text).Trim());
            else
                acrescimo = Convert.ToDecimal(lblAcrescimoValor.Text.Trim());
            #endregion

            #region *** CARREGA O VALOR TOTAL DA VENDA EM UMA VARIAVEL ***
            if (lblTotalVendaValor.Text.Contains("R$"))
                valorTotal = Convert.ToDecimal(Utils.RemoveCifrao(lblTotalVendaValor.Text).Trim());
            else
                valorTotal = Convert.ToDecimal(lblTotalVendaValor.Text.Trim());
            #endregion

            #region *** CARREGA O VALOR TOTAL A RECEBER DA VENDA EM UMA VARIAVEL ***
            if (lblTotalReceberValor.Text.Contains("R$"))
                valorTotalReceber = valorTotal - desconto + acrescimo;
            else
                valorTotalReceber = valorTotal - desconto + acrescimo;

            lblTotalReceberValor.Text = valorTotalReceber.ToString("F");
            #endregion

            #region *** LOOP - Carrega o total pago ***
            for (int i = 0; i < dgvGeral.RowCount; i++)
            {
                Decimal.TryParse(dgvGeral.Rows[i].Cells[2].Value.ToString(), out valorUnit);
                valorTotalPago += valorUnit;
            }
            #endregion

            lblValorRecebidoValor.Text = valorTotalPago.ToString("c");

            bool haveSaldoRestante = Decimal.TryParse(lblSaldoRestanteValor.Text.ToString().Replace("R$ ", "").Trim(), out saldoRestante);
            bool haveValorRecebido = Decimal.TryParse(lblValorRecebidoValor.Text.ToString().Replace("R$ ", "").Trim(), out valorRecebido);

            saldoRestante = valorTotal - desconto + acrescimo - valorTotalPago;

            if (saldoRestante >= 0)
            {
                #region *** VERIFICA SE VALOR PAGO É MENOR QUE TOTAL, SE MENOR TEXTBOX TROCO == 0, SENÃO SALDO TEXTBOX SALDO RESTANTE == 0 **
                if ((valorTotalPago - valorTotal) < 0)
                {
                    lblTrocoValor.Text = 0.ToString("c");
                }
                else
                {
                    if ((valorTotalPago - valorTotalReceber) >= 0)
                        lblTrocoValor.Text = (valorTotalPago - valorTotalReceber).ToString("c");
                    else
                        lblTrocoValor.Text = (0).ToString("c");
                    lblSaldoRestanteValor.Text = "R$ 0,00";
                }
                #endregion

                lblSaldoRestanteValor.Text = (saldoRestante).ToString("c");
            }
            else
                lblTrocoValor.Text = Math.Abs(saldoRestante).ToString("C");

            #region *** CARREGA O VALOR DO CAMPO VALOR PAGO EM UMA VARIAVEL***
            if (txtValorPago.Text.Contains("R$") || txtValorPago.Text.Contains("R"))
            {
                if (txtValorPago.Text.Contains("R$"))
                {
                    if (!String.IsNullOrEmpty(Utils.RemoveCifrao(txtValorPago.Text).Trim()))
                        valorPago = Convert.ToDecimal(Utils.RemoveCifrao(txtValorPago.Text).Trim());
                }
                else if (txtValorPago.Text.Contains("R"))
                {
                    if (!String.IsNullOrEmpty(txtValorPago.Text.Replace("R", "").Trim()))
                        valorPago = Convert.ToDecimal(Utils.RemoveCifrao(txtValorPago.Text).Trim());
                }

            }
            else
            {

                if (!String.IsNullOrEmpty(txtValorPago.Text.Trim()))
                    valorPago = Convert.ToDecimal(txtValorPago.Text.Trim());
            }
            #endregion

            #region *** RECARREGA NO FORMATO DE MOEDA O VALOR TOTAL A RECEBER NO LABEL ***
            if (lblTotalReceberValor.Text.Contains("R$"))
                lblTotalReceberValor.Text = Convert.ToDecimal(Utils.RemoveCifrao(lblTotalReceberValor.Text).Trim()).ToString("c");
            else
                lblTotalReceberValor.Text = Convert.ToDecimal(lblTotalReceberValor.Text.Trim()).ToString("c");
            #endregion


        }

        private void cmbFormaPgto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFormaPgto.Select();
                cmbFormaPgto.Focus();
                return;
            }
        }

        private void txtValorPago_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                VerificarTecla(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorPago_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void VerificarTecla(object sender, KeyEventArgs e)
        {
            Decimal valorPago = 0;
            if (e != null)
            {

                switch (e.KeyCode)
                {
                    case (Keys.F4):
                        {
                            cmbFormaPgto.SelectAll();
                            cmbFormaPgto.Focus();
                            lblMensagem.Text = "[F5] DINHEIRO - [F6] DÉBITO - [F7] CRÉDITO - [F8] BOLETO - [F9] CHEQUE";
                        }
                        break;
                    case (Keys.F10)://desconto
                        {
                            ExibirFormularioDesconto(ref e);// chama botao de descontos
                        }
                        break;
                    case (Keys.F11)://acrescimo
                        {
                            ExibirFormularioAcrescimo(ref e);// chama botao de acrescimento
                        }
                        break;
                    case (Keys.F12)://finaliza venda
                        {
                            FinalizarVenda();
                        }
                        break;
                    case (Keys.Enter):
                        {
                            #region *** ENTER ***
                            if (txtValorPago.Text.Contains("R$"))
                            {
                                if (!String.IsNullOrEmpty(Utils.RemoveCifrao(txtValorPago.Text).Trim()))
                                    valorPago = Convert.ToDecimal(Utils.RemoveCifrao(txtValorPago.Text).Trim());
                            }
                            else
                                valorPago = Convert.ToDecimal(txtValorPago.Text.Trim());

                            if (pressEnter == 0)
                            {
                                if (txtValorPago.Text == "R$ 0,00" || txtValorPago.Text == "0,00")
                                {
                                    if (!pressBtnSim)
                                    {

                                        ShowPanelFinalizar(true);
                                        txtValorPago.Focus();
                                        txtValorPago.SelectAll();
                                        pressEnter++;
                                        //MessageBox.Show("Informe unm valor para o pagamento!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    pressBtnSim = false;
                                }
                                else
                                {
                                    txtValorPago.Text = valorPago.ToString();
                                    if (!pressBtnNao)
                                    {
                                        ShowPanelFinalizar(false);
                                        btnSim.Focus();
                                        pressEnter = 0;
                                    }
                                    pressBtnNao = false;
                                }
                            }
                            else
                            {
                                pressEnter = 0;
                            }
                            e = null;
                            #endregion
                        }
                        break;
                    case (Keys.Escape):
                        {
                            if (MessageBox.Show("Deseja voltar para a venda? ", "AMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.Close();
                                this.Dispose();
                            }
                        }
                        break;
                }
            }
            e = null;
            sender = null;
        }

        private void ExibirFormularioAcrescimo(ref KeyEventArgs e)
        {
            FrmAcrescimo frmAcrescimo = new FrmAcrescimo(this);
            frmAcrescimo.ShowDialog();
            e = null;
        }

        private void cmbFormaPgto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        {
                            txtValorPago.Focus();
                            txtValorPago.SelectAll();
                        }
                        break;

                    case Keys.F5:
                        {
                            cmbFormaPgto.SelectedIndex = 0;
                            txtValorPago.SelectAll();
                            txtValorPago.Focus();
                        }
                        break;

                    case Keys.F6:
                        {
                            cmbFormaPgto.SelectedIndex = 1;
                            txtValorPago.SelectAll();
                            txtValorPago.Focus();
                        }
                        break;

                    case Keys.F7:
                        {
                            cmbFormaPgto.SelectedIndex = 2;
                            txtValorPago.SelectAll();
                            txtValorPago.Focus();
                        }
                        break;

                    case Keys.F8:
                        {
                            cmbFormaPgto.SelectedIndex = 3; ;
                            txtValorPago.SelectAll();
                            txtValorPago.Focus();
                        }
                        break;

                    case Keys.F9:
                        {
                            cmbFormaPgto.SelectedIndex = 4; ;
                            txtValorPago.SelectAll();
                            txtValorPago.Focus();
                        }
                        break;

                    case Keys.F12:
                        this.FinalizarVenda();
                        break;
                }
                if (!cmbFormaPgto.Focused)
                {
                    if (Convert.ToDecimal(lblSaldoRestanteValor.Text.Replace("R$", "").Replace("R$ ", "")) == 0)
                        lblMensagem.Text = "AMS SOFT - Sistemas para Automação Comercial";
                    else
                        lblMensagem.Text = "INFORME O VALOR      |      [F4] para FORMA DE PAGAMENTO";
                }

                e = null;
                sender = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorPago_OnGotFocus(object sender, System.EventArgs e)
        {
            //txtValorPago.SelectAll();
        }

        private void cmbFormaPgto_OnGotFocus(object sender, System.EventArgs e)
        {

        }

        private void ShowPanelFinalizar(bool showPanelFinalizar)
        {
            try
            {
                if (showPanelFinalizar)
                {
                    pnlAddFormaEValor.Visible = !showPanelFinalizar;
                    pnlFinalizarCancelar.Visible = showPanelFinalizar;
                    cmbFormaPgto.Focus();
                    cmbFormaPgto.SelectAll();
                }
                else
                {
                    pnlAddFormaEValor.Visible = !showPanelFinalizar;
                    pnlFinalizarCancelar.Visible = showPanelFinalizar;
                    btnSim.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesconto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAcrescimo frmAcrescimo = new FrmAcrescimo(this);
                frmAcrescimo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAcrescimo_Click(object sender, EventArgs e)
        {
            try
            {
                KeyEventArgs keyEventArgs = null;
                ExibirFormularioDesconto(ref keyEventArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //FrmAcrescimo frmAcrescimo = new FrmAcrescimo();
            //frmAcrescimo.ShowDialog();
        }

        private void ExibirFormularioDesconto(ref KeyEventArgs e)
        {
            FrmDesconto frmDescconto = new FrmDesconto(this);
            frmDescconto.ShowDialog();

            e = null;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.FinalizarVenda();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
                //MessageBox.Show("Erro ao finalizar a venda!\n\nDetalhe técnico: " + ex.Message, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal valorPago;
                string item = cmbFormaPgto.Text;
                Int32 itemId = Convert.ToInt32(cmbFormaPgto.SelectedValue);

                if (!txtValorPago.Text.Contains("R$"))
                    valorPago = Convert.ToDecimal(txtValorPago.Text.Trim());
                else
                    valorPago = Convert.ToDecimal(txtValorPago.Text.Replace("R$", "").Trim().Replace("R$ ", ""));

                if (valorPago != 0)
                {
                    dgvGeral.Rows.Add(itemId, item, valorPago);

                    dgvGeral.Columns[2].DefaultCellStyle.Format = "c"; //Formata o campo como moeda Brasileira (R$)
                    txtValorPago.Text = "0,00";
                    ShowPanelFinalizar(true);
                    txtValorPago.Focus();
                    //cmbFormaPgto.Focus();
                    cmbFormaPgto.SelectAll();
                    CalcularValoresVenda();

                    if (Convert.ToDecimal(lblValorRecebidoValor.Text.Replace("R$", "").Replace("R$ ", "")) >= Convert.ToDecimal(lblTotalVendaValor.Text.Replace("R$", "").Replace("R$ ", "")))
                        lblMensagem.Text = "AMS SOFT - Sistemas para Automação Comercial";
                }
                else
                {
                    MessageBox.Show("Informe o Valor pago!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValorPago.Focus();
                    txtValorPago.SelectAll();
                    pressEnter++;
                }

                this.MontarGrid();
                pressBtnSim = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            this.ShowPanelFinalizar(true);
            pressBtnNao = true;
        }

        private void documento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                //define as dimensões da página
                largura = documento.DefaultPageSettings.Bounds.Width;
                altura = documento.DefaultPageSettings.Bounds.Height;

                //DEFINE O ESTILO DA LINHA TRACEJADA
                float[] dashValues = { 2, 2 };
                Pen blackPen = new Pen(Color.Black, 1);
                blackPen.DashPattern = dashValues;

                #region CUPOM ANDRE

                #region DEFINIÇÃO DE FONTES
                var fonteLucidaSans10Regular = new Font("Lucida Sans Unicode", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial10Regular = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial12Regular = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial10Negrito = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);
                #endregion

                var corPreta = new SolidBrush(Color.Black);
                var posicao = new Rectangle(0, 50, largura, 30);

                var ponto = " . ";
                //Busca as dimensões da string '.' para calculo da largura de uma linha pontilhada
                SizeF dimensaoPonto = e.Graphics.MeasureString(ponto, fonteLucidaSans10Regular);

                var traco = "-";
                SizeF dimensaoTraco = e.Graphics.MeasureString(traco, fonteArial12Regular);

                //DEFINE ESTILO DE ALINHAMENTO
                var alinhamnetoCentro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var alinhamnetoEsquerda = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                };

                var alinhamnetoDireita = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Far
                };

                //CARREGA OBJETO ESTABELECIMENTO
                var estabelecimento = new DLEmpresa().Listar(new MLEmpresa()).First();

                if (estabelecimento == null) throw new Exception("Erro ao consultar dados do Estabelecimento!\n\n Consulte o Administrador do sistema.");


                #region *** MontaCabecalhoCupom ***

                #region Carrega variáveis

                var razaoSocial = estabelecimento.NomeRazaoSocial;
                var endereco = estabelecimento.Logradouro + ", " + estabelecimento.Numero;
                var bairro = estabelecimento.Bairro;

                var cidadeid = estabelecimento.CidadeId;
                var ufid = estabelecimento.EstadoId;

                //CARREGA OBJETO CIDADE
                var cidades = new DLCidade().Listar(new MLCidade() { EstadoId = (int)ufid });
                //CARREGA OBJETO ESTADO
                var estados = new DLEstado().Listar(new MLEstado());

                var cidade = cidades.First(c => c.CidadeId == cidadeid).Nome; //carrega o nome da cidade com base no codigo da cidade do objeto estabelecimento
                var uf = estados.First(es => es.EstadoId == ufid).Nome; //carrega o nome do estado com base no codigo do estado do objeto estabelecimento

                var cep = estabelecimento.Cep;
                var cnpj = estabelecimento.CNPJ;
                var ie = estabelecimento.IE;
                var im = estabelecimento.IM;

                #endregion
                //DEFINE A DISTANCIA EM RELAÇÂO A COORDENADA X (HORIZONTAL) E EM RELAÇÂO AO ALINHAMENTO DETERMINADO
                posicao.X = -120;
                //DEFINE LARGURA DA PÁGINA
                posicao.Width = 527;
                e.Graphics.DrawString(razaoSocial.ToUpper(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoCentro);//X = -120 e relação ao centro da página

                posicao.Y += 13;//soma mais 13 Pixels para baixo (VERTICAL)
                e.Graphics.DrawString(endereco.ToUpper(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 13;
                var enderecoComplemento = (bairro == null) ? "" : bairro.ToUpper() + " - " + cidade.ToUpper() + " - " + uf.ToUpper() + " - " + ((cep == null) ? "" : Formatacao.FormatarCEP(cep));
                e.Graphics.DrawString(enderecoComplemento, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 20;
                posicao.X = 5;
                e.Graphics.DrawString("CNPJ: " + Formatacao.FormatarCpfCnpj(cnpj), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME CNPJ COM MASCARA FORMATADA
                posicao.Y += 13;
                e.Graphics.DrawString("IE: " + Formatacao.FormatarInscricaoEstadual(ie), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA
                posicao.Y += 13;
                e.Graphics.DrawString("IM: " + im, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 15;
                posicao.X = 5;
                #endregion

                #region ESTRUTURA SUPERIOR CUPOM 

                //REDEFINE TAMANHO DA PAGINA
                posicao.Width = 527;

                //VARIVEL PROVISÓRIA, FUTURAMENTE SERÁ UTILIZADA VARIAVAL CALCULADA DE ACORDO COM O TAMANHO DEFINIDO PARA A PÁGINA
                //string linhaTracejada = "----------------------------------------------------------------------------";
                string linhaTracejada = "------------------------------------------------";
                //string linhaTracejada = "";
                //for (decimal i = 0; i < posicao.Width; i = i + Convert.ToDecimal(dimensaoTraco.Width))
                //    linhaTracejada += traco;

                var tamLinha = e.Graphics.MeasureString(linhaTracejada, fonteArial10Regular);
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                /*  ------ CONFIGURAÇÂO ANTIGA ------
                 *  
                posicao.Y += 10; //desce 17 pixels
                posicao.X = 5; // margim de 0 pixels
                e.Graphics.DrawString(DateTime.Now.ToString(CultureInfo.CurrentCulture), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y -= 10;
                posicao.X = -110;
                e.Graphics.DrawString("CCF: 123456", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);//VALOR DO CCF FICTÍCIO

                posicao.Y -= 9;
                posicao.X -= 130;
                e.Graphics.DrawString("Pedido Nº: " + this.frmPDV._objMLPedido.PedidoId.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoDireita);
                */

                posicao.Y += 5;
                posicao.X = 5;
                e.Graphics.DrawString("Pedido: " + this.frmPDV._objMLPedido.PedidoId.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.X = -50;
                e.Graphics.DrawString("CCF: 123456", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);//VALOR DO CCF FICTÍCIO

                posicao.X = -130; // margim de 0 pixels
                e.Graphics.DrawString(DateTime.Now.ToString(CultureInfo.CurrentCulture), fonteArial10Regular, corPreta, posicao, alinhamnetoDireita);

                //--------------------------------------------------------------------------------- LInha Tracejada
                posicao.Y += 25;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 5;
                posicao.X = -60;

                e.Graphics.DrawString("CUPOM NÃO FISCAL", fonteArial10Negrito, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 23;
                posicao.X = 5;
                fonteLucidaSans10Regular = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                string cabecalhoCupom = "ITEM          CODIGO          DESCRICAO ";
                var tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.X = 5;
                posicao.Y += 10;
                tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                cabecalhoCupom = "QTD    UN    VL. UNITARIO (R$)    VL. ITEM (R$)";
                e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //--------------------------------------------------------------------------------- LInha Tracejada
                posicao.Y += 7;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                #endregion

                //Monta pedido
                MLPedido pedido = this.frmPDV._objMLPedido;
                int codigoPedido = frmPDV._objMLPedido.PedidoId;
                pedido.PedidoId = codigoPedido;
                _objMLPedido = (new DLPedido().Consultar(pedido));// Carrega objeto Pedido para montar cupom
                var lstItem = _objMLPedido.listaPedidoItem;
                _objMLPedido.ValorTotal = 0;

                #region *** MontaItensCupom ***
                posicao.Y += 15;
                for (int i = 0; i < lstItem.Count; i++)
                {
                    posicao.X = 5;//MARGEM ESQUERDA DE 5 
                                  //Carrega o produto dentro da lista de itens do pedido
                    lstItem[i].Produto = new DLProduto().Listar(lstItem[i].Produto)
                        .Find(p => p.ProdutoId == lstItem[i].Produto.ProdutoId);

                    var tamI = i.ToString().Length;
                    string itemNr = "";

                    //Formata código com 4 digitos
                    itemNr = Formatacao.ZerosEsquerda((i + 1).ToString(), 4);

                    string item = lstItem[i].Produto.Descricao.ToString();
                    string codigo = (lstItem[i].Produto.CodigoBarras == null) ? "" : lstItem[i].Produto.CodigoBarras.ToString();
                    string valorUnit = lstItem[i].Produto.ValorVenda.ToString();
                    string Qtde = lstItem[i].Quantidade.ToString();
                    string UnMedida = lstItem[i].Produto.UnidadeMedida.Descricao;
                    string valorTotal = (lstItem[i].Quantidade * lstItem[i].Produto.ValorVenda).ToString();
                    string strMultiplicador = "X ";

                    //Busca as dimensões das strings 
                    dimensaoItenNr = e.Graphics.MeasureString(itemNr, fonteArial10Regular);
                    dimensaoItem = e.Graphics.MeasureString(item, fonteArial10Regular);
                    dimensaoCodigo = e.Graphics.MeasureString(codigo, fonteArial10Regular);
                    dimensaoValorUnit = e.Graphics.MeasureString(valorUnit, fonteArial10Regular);
                    dimensaoQtde = e.Graphics.MeasureString(Qtde, fonteArial10Regular);
                    dimensaoUnMedida = e.Graphics.MeasureString(UnMedida, fonteArial10Regular);
                    dimensaoX = e.Graphics.MeasureString(strMultiplicador, fonteArial10Regular);
                    dimensaoValorTotal = e.Graphics.MeasureString(valorTotal.ToString(CultureInfo.CurrentCulture), fonteArial10Negrito);

                    //IMPRIME AS VARIAVEIS
                    e.Graphics.DrawString(itemNr, fonteArial10Regular, corPreta, posicao);

                    posicao.X = 70;
                    e.Graphics.DrawString(codigo, fonteArial10Regular, corPreta, posicao);

                    posicao.X += Convert.ToInt32(dimensaoCodigo.Width) + 80;
                    if (Qtde == "0,0000")
                        e.Graphics.DrawString(" ***ITEM CANCELADO*** ".ToUpper(), fonteArial10Regular, corPreta, posicao);
                    else
                        e.Graphics.DrawString(item.ToUpper(), fonteArial10Regular, corPreta, posicao);

                    //posicao.X += Convert.ToInt32(dimensaoItem.Width) + 20;

                    posicao.Y += 10;
                    posicao.X = 5;
                    e.Graphics.DrawString(Qtde, fonteArial10Regular, corPreta, posicao);

                    posicao.X += Convert.ToInt32(dimensaoQtde.Width) + 15;
                    e.Graphics.DrawString(UnMedida, fonteArial10Regular, corPreta, posicao);

                    posicao.X += Convert.ToInt32(dimensaoUnMedida.Width) + 15;
                    e.Graphics.DrawString(strMultiplicador, fonteArial10Regular, corPreta, posicao);

                    posicao.X += Convert.ToInt32(dimensaoX.Width) + 25;
                    if (Qtde == "0,0000")
                        e.Graphics.DrawString("0,00", fonteArial10Regular, corPreta, posicao);
                    else
                        e.Graphics.DrawString(valorUnit, fonteArial10Regular, corPreta, posicao);
                    SizeF tamValorSubTotal = e.Graphics.MeasureString(Convert.ToDouble(valorTotal).ToString("F"), fonteArial10Regular);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorSubTotal.Width + 35;
                    e.Graphics.DrawString(Convert.ToDouble(valorTotal).ToString("F"), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                    _objMLPedido.ValorTotal += Convert.ToDecimal(valorTotal);

                    posicao.Y += 15;
                    posicao.X = 145;
                }
                #endregion


                #region *** MontaRodapeCupom ***
                //var formapgto = 
                //var lstFormaPgto = new DLFormaPgto().Listar();

                string operador = _objMLPedido.Usuario.Nome;
                dimensaoOperador = e.Graphics.MeasureString(operador, fonteArial10Regular);

                ///////////////////////////valor total///////////////////////////
                posicao.Y += 5;
                posicao.X = 5; //Margem de0 pixels
                e.Graphics.DrawString("TOTAL R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                var tamValorTotal = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F"), fonteArial10Regular);
                posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorTotal.Width + 15;
                var valorPedido = Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F");
                e.Graphics.DrawString(valorPedido.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                /////////////////////////valor pago//////////////////////////////
                posicao.Y += 15;
                posicao.X = 5; //Margem de0 pixels
                e.Graphics.DrawString("PAGO R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                var tamValorPago = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F"), fonteArial10Regular);
                posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorPago.Width + 15;
                var pago = lblValorRecebidoValor.Text.Replace("R$", "").Replace("R$ ", "");
                var valorpago = Convert.ToDouble(pago).ToString("F");
                e.Graphics.DrawString(valorpago.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);


                /////////////////////////////ACRESCIMO//////////////////////////////////
                if (_objMLPedido.Acrescimo > 0)
                {
                    posicao.Y += 15;
                    posicao.X = 5; //Margem de0 pixels
                    e.Graphics.DrawString("ACRÉSCIMO R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                    var tamAcrescimo = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.Acrescimo).ToString("F"), fonteArial10Regular);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamAcrescimo.Width + 15;
                    var acrescimo = Convert.ToDouble(_objMLPedido.Acrescimo).ToString("F");
                    e.Graphics.DrawString(acrescimo.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                }

                /////////////////////////////DESCONTO//////////////////////////////////
                if (_objMLPedido.Desconto > 0)
                {
                    posicao.Y += 15;
                    posicao.X = 5; //Margem de0 pixels
                    e.Graphics.DrawString("DESCONTO R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                    var tamDesconto = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.Desconto).ToString("F"), fonteArial10Regular);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamDesconto.Width + 15;
                    var desconto = Convert.ToDouble(_objMLPedido.Desconto).ToString("F");
                    e.Graphics.DrawString(desconto.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                }


                /////////////////////////////TROCO//////////////////////////////////
                posicao.Y += 20;
                posicao.X = 5; //Margem de0 pixels
                e.Graphics.DrawString("TROCO R$", fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //var tamanhoTroco = e.Graphics.MeasureString((_objMLPedido.ValorTotal - _objMLPedido.ValorTotal);
                posicao.X = Convert.ToInt32(tamLinha.Width) - 10;
                var troco = lblTrocoValor.Text.Replace("R$", "").Replace("R$ ", "");
                var valortroco = Convert.ToDouble(troco).ToString("F");
                e.Graphics.DrawString(valortroco.ToString(), fonteArial10Negrito, corPreta, posicao, alinhamnetoEsquerda);

                //AAA


                #region Forma de Pagamento nao imprementado
                //FORMAS DE PAGAMENTO
                var lstFormaPgto = new DLPedido().ListarFormaPgtoPedido(pedido.PedidoId);

                for (int i = 0; i < lstFormaPgto.Count; i++)
                {
                    if (lstFormaPgto[i].FormaPgtoId == 1 && lstFormaPgto[i].Valor > 0)
                    {
                        posicao.Y += 20;//20Pixels para baixo
                        posicao.X = 5; //Margem de 5 pixels
                        e.Graphics.DrawString("DINHEIRO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                        continue;
                    }
                    if (lstFormaPgto[i].FormaPgtoId == 2 && lstFormaPgto[i].Valor > 0)
                    {
                        posicao.Y += 15;//15Pixels para baixo
                        posicao.X = 5; //Margem de0 pixels
                        e.Graphics.DrawString("DÉBITO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                        continue;
                    }
                    if (lstFormaPgto[i].FormaPgtoId == 3 && lstFormaPgto[i].Valor > 0)
                    {
                        posicao.Y += 15;//15Pixels para baixo
                        posicao.X = 5; //Margem de 5 pixels
                        e.Graphics.DrawString("CRÉDITO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                        continue;
                    }
                    if (lstFormaPgto[i].FormaPgtoId == 4 && lstFormaPgto[i].Valor > 0)
                    {
                        posicao.Y += 15;//15Pixels para baixo
                        posicao.X = 5; //Margem de 5 pixels
                        e.Graphics.DrawString("BOLETO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                        continue;
                    }
                    if (lstFormaPgto[i].FormaPgtoId == 5 && lstFormaPgto[i].Valor > 0)
                    {
                        posicao.Y += 15;//15Pixels para baixo
                        posicao.X = 5; //Margem de0 pixels
                        e.Graphics.DrawString("CHEQUE: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                        continue;
                    }
                }



                ////REDEFINE LARGURA DA PÁGINA
                //posicao.Width = 527;
                //posicao.X = -115;
                //posicao.Y += 5;
                ////posicao.X = 5; //Margem de0 pixels
                //e.Graphics.DrawString("Obrigado pela preferência!", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);

                ////--------------------------------------------------------------------------------- LInha Tracejada
                #endregion


                posicao.Y += 15;
                posicao.X = 5; //Margem de0 pixels
                var usuario = new DLUsuario().Listar(new MLUsuario() { UsuarioId = pedido.UsuarioId }).FirstOrDefault();
                e.Graphics.DrawString("Oper.: " + usuario.Nome, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                usuario = null;

                posicao.Y += 15;
                posicao.X = 5; //Margem de0 pixels
                var cliente = new DLCliente().Consultar(new MLCliente() { ClienteId = (int)pedido.ClienteId, Ativo = true });
                string cpfCnpj = "";
                if (Sessao.Instance.Cliente.CNPJ != null)
                    cpfCnpj = " - " + Sessao.Instance.Cliente.CNPJ;
                else if (Sessao.Instance.Cliente.CPF != null)
                    cpfCnpj = " - " + Sessao.Instance.Cliente.CPF;
                if (cliente.ClienteId > 1)
                    e.Graphics.DrawString("Cliente: " + cliente.NomeRazaoSocial + cpfCnpj, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                else
                    e.Graphics.DrawString("Cliente: Consumidor Final" + cpfCnpj, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                usuario = null;
                //--------------------------------------------------------------------------------- LInha Tracejada
                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 20;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 15;
                posicao.X = -115;
                e.Graphics.DrawString("<< DOCUMENTO NAO FISCAL >>", fonteArial12Regular, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 20;
                //posicao.X = 5; //Margem de0 pixels
                e.Graphics.DrawString("<< NAO SERVE COMO GARANTIA >>", fonteArial12Regular, corPreta, posicao, alinhamnetoCentro);
                posicao.Y += 5;
                e.Graphics.DrawString("", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //qrcod com chave de acesso
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(frmPDV._objMLPedido.PedidoId.ToString()), 150, 150);
                posicao.Y += 25;

                posicao.X = Convert.ToInt32(263 - bm.Width - 40);
                posicao.Width = 150;//largura do qrcode
                posicao.Height = 150;//altura do qrcode
                e.Graphics.DrawImage(bm, posicao);



                #endregion

                //y = new ImprimeCupomNaoFiscal(pdv, e, y).MontaCupom();



                ///----------------------------------------------------------------------------------
                ///
                //DEFINE O ESTILO DA LINHA TRACEJADA

                y += 30;
                num_frase++;

                if (y < altura - 50)
                    return;
                y = 50;// Seta no inicio da página com uma margim superior de 50 pixels
                e.HasMorePages = true; //informa que o documento necessita ser impresso em outra página e irá iniciar novamente esse evento
                paginas_criadas++;
                _objMLPedido.ValorTotal = 0;
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //IMPRESSAO FORMATO 2
            //new ImprimeVenda(this.frmPDV._objMLPedido, this.frmPDV._lstMlPedidoItem).Print();

        }


        #region *** MÉTODOS ***

        private void FinalizarVenda()
        {
            try
            {

                if (MessageBoxEx.Show("Deseja Finalizar o Pedido?", "Pedido", MessageIcon.Information, MessageButton.YesNo) == DialogResult.Yes)
                {

                    Decimal valorPago = 0, valorTotal = 0, desconto = 0, acrescimo = 0;
                    _objMLPedido.StatusPedidoId = 2;
                    _objMLPedido.PedidoId = frmPDV._objMLPedido.PedidoId;
                    _objMLPedido.Tipo = "V";
                    this.frmPDV.CarregarItensPedido(false, true);
                    _objMLPedido.listaPedidoItem = frmPDV._objMLPedido.listaPedidoItem;
                    //new DLPedido().Atualizar(frmPDV._objMLPedido);

                    //_objMLPedidoItem.PedidoId = _objMLPedido.PedidoId;
                    //new dl().inserir(_lstMlPedidoItem);

                    #region *** Carrega Variaveis valorPago, valorTotal e TotalReceber ***

                    if (lblTotalVendaValor.Text.Contains("R$"))//Se contém Cifrão remove e atribui removendo os espaços à variável
                        valorTotal = Convert.ToDecimal(Utils.RemoveCifrao(lblTotalVendaValor.Text).Trim());
                    else
                        valorTotal = Convert.ToDecimal(lblTotalVendaValor.Text.Trim());

                    if (lblValorRecebidoValor.Text.Contains("R$"))
                        valorPago = Convert.ToDecimal(Utils.RemoveCifrao(lblValorRecebidoValor.Text).Trim());
                    else
                        valorPago = Convert.ToDecimal(lblValorRecebidoValor.Text.Trim());

                    if (lblTotalReceberValor.Text.Contains("R$"))
                        lblTotalReceberValor.Text = Convert.ToDecimal(Utils.RemoveCifrao(lblTotalReceberValor.Text).Trim()).ToString("c");
                    else
                        lblTotalReceberValor.Text = Convert.ToDecimal(lblTotalReceberValor.Text.Trim()).ToString("c");

                    if (lblDescontoValor.Text.Contains("R$"))
                        desconto = Convert.ToDecimal(Utils.RemoveCifrao(lblDescontoValor.Text).Trim());
                    else
                        desconto = Convert.ToDecimal(lblDescontoValor.Text.Trim());

                    if (lblAcrescimoValor.Text.Contains("R$"))
                        acrescimo = Convert.ToDecimal(Utils.RemoveCifrao(lblAcrescimoValor.Text).Trim());
                    else
                        acrescimo = Convert.ToDecimal(lblAcrescimoValor.Text.Trim());

                    #endregion
                    if (valorPago < (valorTotal + acrescimo - desconto))
                    {
                        if (MessageBoxEx.Show("Valor recebido insuficiente!!\n\nInforme a forma de pagamento e o valor restante!", "Venda", MessageIcon.Information, MessageButton.OK) == DialogResult.OK)
                            return;

                        txtValorPago.Focus();
                        txtValorPago.SelectAll();
                    }

                    //this.frmPDV._objMLPedido.ValorTotalPago = valorPago;
                    frmPDV._objMLPedido.StatusPedidoId = (int)MLStatusPedido.StatusPedido.FINALIZADO; // Pedido Finalizado
                    frmPDV._objMLPedido.Desconto = desconto;
                    frmPDV._objMLPedido.Acrescimo = acrescimo;

                    frmPDV._objMLPedido.lstMLPgtoEntrada = new List<MLPgtoEntrada>();

                    for (int i = 0; i < dgvGeral.RowCount; i++)//Carrega formas de pagamento
                    {
                        MLPgtoEntrada pgtoEntrada = new MLPgtoEntrada();
                        pgtoEntrada.PedidoId = this.frmPDV._objMLPedido.PedidoId;
                        pgtoEntrada.FormaPgtoId = Convert.ToInt32(dgvGeral.Rows[i].Cells[0].Value);

                        decimal troco = Convert.ToDecimal(lblTrocoValor.Text.Replace("R$", ""));
                        if (pgtoEntrada.FormaPgtoId == 1 && troco > 0)//igual dinheiro
                            pgtoEntrada.Valor = Convert.ToDecimal(dgvGeral.Rows[i].Cells[2].Value) - troco;
                        else
                            pgtoEntrada.Valor = Convert.ToDecimal(dgvGeral.Rows[i].Cells[2].Value);

                        if (frmPDV._objMLPedido.lstMLPgtoEntrada.Count > 0)
                        {
                            for (int j = 0; j < frmPDV._objMLPedido.lstMLPgtoEntrada.Count; j++)
                            {
                                if (frmPDV._objMLPedido.lstMLPgtoEntrada[j].FormaPgtoId == pgtoEntrada.FormaPgtoId)
                                {
                                    frmPDV._objMLPedido.lstMLPgtoEntrada[j].Valor += pgtoEntrada.Valor;
                                    break;
                                }
                                else
                                {
                                    frmPDV._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);
                                    isAdcionanado = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            frmPDV._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);
                            isAdcionanado = true;
                        }

                    }
                    if (frmPDV._objMLPedido.Usuario == null) frmPDV._objMLPedido.Usuario = new MLUsuario();
                    frmPDV._objMLPedido.Usuario.Nome = frmPDV._caixa.FuncionarioNome.Trim();
                    frmPDV._objMLPedido.Usuario.UsuarioId = frmPDV._caixa.Usuario.UsuarioId;


                    ///atualizado valor total////////////////
                    frmPDV._objMLPedido.ValorTotal = valorTotal;
                    frmPDV._objMLPedido.CaixaId = Sessao.Instance.Caixa.CaixaId;

                    if (Sessao.Instance.Cliente.ClienteId > 0)
                        frmPDV._objMLPedido.ClienteId = Sessao.Instance.Cliente.ClienteId;
                    else
                        frmPDV._objMLPedido.ClienteId = 1;//Consumidor final

                    frmPDV._objMLPedido.CpfCnpj = (Sessao.Instance.Cliente.CPF == null) ? Sessao.Instance.Cliente.CNPJ : Sessao.Instance.Cliente.CPF;

                    //////desconto e acrescimo
                    frmPDV._objMLPedido.Desconto = Convert.ToDecimal(lblDescontoValor.Text.Replace("R$", "").Replace("R$ ", ""));
                    frmPDV._objMLPedido.Acrescimo = Convert.ToDecimal(lblAcrescimoValor.Text.Replace("R$", "").Replace("R$ ", ""));

                    if (isAdcionanado)
                        new DLPedido().InserirFormaPgtoPedido(frmPDV._objMLPedido.lstMLPgtoEntrada);
                    frmPDV._objMLPedido.ControleMovimentoCaixaId = Sessao.Instance.Caixa.ControleMovimentoCaixaId;
                    frmPDV._objMLPedido.DataPagto = DateTime.Now;

                    new DLPedido().Atualizar(frmPDV._objMLPedido);
                    CarregarMovimentacaoEstoque(frmPDV._objMLPedido.PedidoId);//Saída do estoque dos itens do pedido

                    ///imprementar estoque

                    this.frmPDV.dgvGeral.Rows.Clear();
                    dgvGeral.Rows.Clear();
                    //frmPDV.lblClienteId.Text = "";

                    lblTotalVendaValor.Text = Convert.ToDouble(0.00).ToString("C");

                    frmPDV.lblValorTotal.Text = "0,00";

                    if (MessageBoxEx.Show("Imprimir Recibo?", "Venda", MessageIcon.Question, MessageButton.YesNo) == DialogResult.Yes)
                    {
                        //define as dimensões da página
                        largura = documento.DefaultPageSettings.Bounds.Width;
                        altura = documento.DefaultPageSettings.Bounds.Height;

                        fonte = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                        cor = new SolidBrush(Color.Black);
                        y = 50;
                        num_frase = 1;
                        pagina = 0;

                        #region *** Impressão com caixa selecionadora de impressora ***

                        //IMPRESSÂO MODELO 1


                        switch (Sessao.Instance.Configuracao.tipoImpressoraPDV)
                        {
                            case MLConfiguracaoGeral.TipoImpressao.NaoFiscal:
                                {
                                    for (int i = 0; i < Sessao.Instance.Configuracao.QtdeCopiasImpressaoPDV; i++)
                                    {
                                        documento.DocumentName = "Pedido " + frmPDV._objMLPedido.PedidoId.ToString();
                                        documento.Print();
                                    }
                                }
                                break;
                            case MLConfiguracaoGeral.TipoImpressao.PadraoA4:
                                {
                                    FrmRelatorioPedidoItens frmRelatorioPedidoItens = new FrmRelatorioPedidoItens(frmPDV._objMLPedido.PedidoId);
                                    frmRelatorioPedidoItens.ShowDialog();
                                }
                                break;
                        }

                        #endregion
                    }

                    this.frmPDV.HabiltarCampos(false);
                    this.frmPDV.ControlarFuncoes(FrmPDV.enumFuncoes.pedidoFechado);
                    this.LimparCampos();

                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Venda", MessageIcon.Information, MessageButton.OK);
            }

        }
        private void CarregarMovimentacaoEstoque(int pedidoId)
        {
            int id = 0;
            try
            {
                var pedido = new DLPedido().Listar(new MLPedido() { PedidoId = pedidoId, Tipo = "V" }).FirstOrDefault();

                for (int i = 0; i < pedido.listaPedidoItem.Count; i++)
                {
                    EstoqueMovimentacao = new MLEstoqueMovimentacao();

                    EstoqueMovimentacao.PedidoId = pedidoId;
                    EstoqueMovimentacao.UsuarioId = (Sessao.Instance.Usuario == null) ? 1/*Usuário Administrador*/ : Sessao.Instance.Usuario.UsuarioId /*Senão, usuario logado*/;
                    EstoqueMovimentacao.TipoMovimentacao = "S";
                    EstoqueMovimentacao.ProdutoId = pedido.listaPedidoItem[i].ProdutoId;
                    EstoqueMovimentacao.Quantidade = pedido.listaPedidoItem[i].Quantidade;
                    EstoqueMovimentacao.MovimentoCancelado = false;
                    EstoqueMovimentacao.DataMovimentacao = DateTime.Now;
                    EstoqueMovimentacao.ClienteId = (int)pedido.ClienteId;
                    EstoqueMovimentacao.EmpresaId = Sessao.Instance.Empresa.EmpresaId;
                    //insere a movimentacao do estoque
                    new DLEstoqueMovimentacao().Adicionar(EstoqueMovimentacao);


                    if (i == pedido.listaPedidoItem.Count - 1)
                        MessageBoxEx.Show("Saída realizada com sucesso!!", "Informação", MessageIcon.Information, MessageButton.OK);
                }
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        /// <summary>
        /// Remove os dois primeiros caracteres de uma String (Exemplo 'R$')
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>


        private void LimparCampos(bool limpaCodigo = true)
        {
            if (limpaCodigo)
                lblAcrescimoValor.Text = "0,00";

            lblDescontoValor.Text = "0,00";
            lblSaldoRestanteValor.Text = "0,00";
            lblTotalReceberValor.Text = "0,00";
            txtValorPago.Text = "0,00";
            lblTrocoValor.Text = "0,00";
            lblValorRecebidoValor.Text = "0,00";
            lblTotalVendaValor.Text = "0,00";

        }

        public void MontarGrid()
        {

            dgvGeral.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            ControleGrid objBL_ControleGrid = new ControleGrid(dgvGeral);

            ////Define quais colunas serão visíveis
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "item", "valorPago" });

            ////Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "Item", "Valor Pago" });

            //Define quais as larguras respectivas das colunas 
            //Int32 larg = lblTopVendasBalcao.Width;
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 60, 40 }, dgvGeral.Width);

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "esquerdo", "esquerdo" });

            //Define a altura das linhas respectivas da Grid 
            //objBL_ControleGrid.DefinirAlturaLinha(40);

        }

        #endregion



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFinalizaVenda_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                VerificarTecla(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
