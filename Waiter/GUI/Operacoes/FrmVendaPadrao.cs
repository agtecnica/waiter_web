using System;
using System.Windows.Forms;
using Modelo;
using GUI.Cadastro;
using GUI.Ferramentas;
using GUI.Inicio;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Dados;
using GUI.Relatorios;
using ZXing;

namespace GUI.Operacoes
{
    public partial class FrmVendaPadrao : Form
    {
        #region *** PROPRIEDADES ***

        private string[] _tipoEmissao = new string[] { "Venda", "Orçamento" };
        private string[] _tipoFrete = new string[] { "FOB", "CIF" };
        public MLCliente _objMLCliente { get; set; }
        public MLPedido _objMLPedido { get; set; }
        public MLProduto _objMlProduto { get; set; }
        public MLParcelaPedido objParcelaPedido { get; set; }
        public List<MLParcelaPedido> listaParcelaPedido { get; set; }
        public MLUsuario _objMlUsuario { get; set; }
        public MLTransportador _objMLTransportadora { get; set; }
        public MLCondicaoPagamento _objMLCondicaoPagamento { get; set; }
        List<MLPedidoItem> lstCompraItem { get; set; }
        public EnumTipo tipo { get; set; }
        public EnumBotoes botoes { get; set; }
        public bool isAdicionaProduto { get; set; }
        public MLEstoqueMovimentacao EstoqueMovimentacao { get; private set; }

        #region IMPRESSAO PDV
        SizeF dimensaoItenNr { get; set; }
        SizeF dimensaoItem { get; set; }
        SizeF dimensaoCodigo { get; set; }
        SizeF dimensaoValorUnit { get; set; }
        SizeF dimensaoQtde { get; set; }
        SizeF dimensaoUnMedida { get; set; }
        SizeF dimensaoValorTotal { get; set; }
        SizeF dimensaoOperador { get; set; }
        SizeF dimensaoX { get; set; }

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

        public bool isAlteracao = false;

        int _totalItens = 0;
        decimal _valorTotal = 0;
        private bool isGravar;

        #endregion

        #region *** CONSTRUTORES ***

        public FrmVendaPadrao()
        {
            InitializeComponent();
        }

        #endregion

        #region *** EVENTOS ***

        private void FrmOrdCompra_Load(object sender, EventArgs e)
        {

            isAdicionaProduto = false;
            isGravar = false;
            try
            {
                CarregarTela();

                if (_objMLPedido != null)
                {
                    CarregarCampos();
                }
                else
                {
                    txtStatusDocumento.Text = "";
                }
                switch (txtStatusDocumento.Text)
                {
                    case "FINALIZADA":
                        {
                            HabilitaBotoes(EnumBotoes.Finalizado);
                            btnCancelarOC.Visible = true;
                        }
                        break;
                    case "ENTRADA NO ESTOQUE OK":
                    case "SAÍDA NO ESTOQUE OK":
                    case "CANCELADA":
                        {
                            HabilitaBotoes(EnumBotoes.Cancelado);
                            btnCancelarOC.Visible = false;
                        }
                        break;
                    case "EM DIGITAÇÃO":
                        {
                            HabilitaBotoes(EnumBotoes.Salvar);
                            btnCancelarOC.Visible = false;
                        }
                        break;
                }

                HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
                txtStatusDocumento.ForeColor = Color.Red;
                btnGravar.Text = "Novo";
                dtpData1Pgto.Value = DateTime.Now;
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void FrmOrdCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtNrOrcamCliente.Enabled)
            {
                if (MessageBox.Show("Deseja realmente fechar a janela? \n\nAo fechar todos os dados serão perdidos.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
                else
                    this.Dispose();
            }
            else
                this.Dispose();

        }

        #region CAMPOS


        private void txtObsItemPopup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CarregarObsItem();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    CancelarObsItem();
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtDiasPrevisaoEntrega_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dias = 0;
                if (int.TryParse(txtDiasPrevisaoEntrega.Text, out dias))
                {
                    txtDataPrevisaoEntrega.Text = DateTime.Now.AddDays(dias).ToShortDateString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDiasPrevisaoEntrega.Text))
                        MessageBox.Show("Informe somente números!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtTotalProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnRemover.Visible = Convert.ToInt32(txtTotalProduto.Text) > 0;
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtValorFrete_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Formatacao.Moeda(ref txtValorFrete);
                decimal valorFrete = 0;
                if (!decimal.TryParse(txtValorFrete.Text, out valorFrete))
                {
                    string[] desconto = txtValorFrete.Text.ToCharArray().Select(c => c.ToString()).ToArray();//transforma string em array de string
                    for (int i = 0; i < desconto.Length; i++)
                    {
                        if (!int.TryParse(desconto[i], out int caracter))
                        {
                            txtValorFrete.Text = txtValorFrete.Text.Remove(i, 1);
                        }
                    }
                    txtValorFrete.Select(txtValorFrete.Text.Length, 0);//posiciona cursor no final do texto
                    txtValorFrete.Text = string.Format("{0:c2}", txtValorFrete.Text);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }


        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Formatacao.Moeda(ref txtDesconto);
                if (!decimal.TryParse(txtDesconto.Text, out decimal valorDesconto))
                {
                    string[] desconto = txtDesconto.Text.ToCharArray().Select(c => c.ToString()).ToArray();//transforma string em array de string
                    for (int i = 0; i < desconto.Length; i++)
                    {
                        if (!int.TryParse(desconto[i], out int caracter))
                        {
                            txtDesconto.Text = txtDesconto.Text.Remove(i, 1);
                        }
                    }
                    txtDesconto.Select(txtDesconto.Text.Length, 0);//posiciona cursor no final do texto
                    txtDesconto.Text = string.Format("{0:c2}", txtDesconto.Text);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valorFrete = 0;
                decimal.TryParse(txtValorFrete.Text, out valorFrete);
                decimal valorDesconto = 0;
                decimal.TryParse(txtValorFrete.Text, out valorFrete);

                if (decimal.TryParse(txtDesconto.Text, out valorDesconto))
                {
                    if (string.IsNullOrEmpty(txtValorTotal.Text))
                    {
                        txtValorTotal.Text = (0 - valorDesconto + valorFrete).ToString(CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        txtValorTotal.Text = Convert.ToDecimal(_valorTotal - valorDesconto + valorFrete).ToString(CultureInfo.CurrentCulture);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtDesconto.Text))
                    {
                        if (string.IsNullOrEmpty(txtValorTotal.Text))
                        {
                            txtValorTotal.Text = (0 + valorFrete).ToString(CultureInfo.CurrentCulture);
                        }
                        else
                        {
                            txtValorTotal.Text = (_valorTotal - 0 + valorFrete).ToString(CultureInfo.CurrentCulture);
                        }
                    }
                }
                txtDesconto.Text = string.Format("{0:F}", valorDesconto);
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtValorFrete_Leave(object sender, EventArgs e)
        {
            try
            {
                AlterarValorFrete();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void AlterarValorFrete()
        {
            decimal desconto = 0;
            decimal.TryParse(txtDesconto.Text, out desconto);


            if (decimal.TryParse(txtValorFrete.Text, out decimal valorFrete))
            {
                if (string.IsNullOrEmpty(txtValorTotal.Text))
                {
                    txtValorTotal.Text = (0 + valorFrete - desconto).ToString(CultureInfo.CurrentCulture);
                }
                else
                {
                    txtValorTotal.Text = (_valorTotal + valorFrete - desconto).ToString(CultureInfo.CurrentCulture);
                }
                txtValorFrete.Text = string.Format("{0:F}", valorFrete);
            }
            else
            {
                if (string.IsNullOrEmpty(txtValorFrete.Text))
                {
                    if (string.IsNullOrEmpty(txtValorTotal.Text))
                    {
                        txtValorTotal.Text = (0 - desconto).ToString(CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        txtValorTotal.Text = (_valorTotal + 0 - desconto).ToString(CultureInfo.CurrentCulture);
                    }
                }
            }
            txtValorFrete.Text = string.Format("{0:F}", valorFrete);
        }

        private void txtDiasValidadeProp_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int dias = 0;
                if (int.TryParse(txtDiasValidadeProp.Text, out dias))
                {
                    txtDataValidadeProp.Text = DateTime.Now.AddDays(dias).ToShortDateString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDiasValidadeProp.Text))
                        MessageBox.Show("Informe somente números!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtQtde.Text, out decimal qtde))
                {
                    txtSubtotal.Text = (qtde * Convert.ToDecimal(txtValorUnit.Text)).ToString(CultureInfo.CurrentCulture);
                }
                else if (!string.IsNullOrEmpty(txtQtde.Text))
                {
                    txtQtde.Text = txtQtde.Text.Remove(txtQtde.Text.Length - 1);
                    txtQtde.Select(txtQtde.Text.Length, 0);//posiciona cursor no final do texto

                    if (decimal.TryParse(txtQtde.Text, out qtde))
                    {
                        txtSubtotal.Text = (qtde * Convert.ToDecimal(txtValorUnit.Text)).ToString(CultureInfo.CurrentCulture);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtQtde.Text))
                        txtSubtotal.Text = (0 * Convert.ToDecimal(txtValorUnit.Text)).ToString(CultureInfo.CurrentCulture);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoVendedor.Text, out int id))
                {
                    if (_objMlUsuario == null)
                        _objMlUsuario = new MLUsuario();

                    _objMlUsuario = new DLUsuario().Listar(new MLUsuario() { UsuarioId = id }).FirstOrDefault();
                    if (_objMlUsuario != null)
                    {
                        txtVendedor.ForeColor = Color.Black;
                        this.CarregarCamposUsuario(_objMlUsuario);
                    }
                    else
                    {
                        txtVendedor.Text = "Vendedor inexistente";
                        txtVendedor.ForeColor = Color.Red;
                    }
                }
                else
                    LimparCamposVendedor();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoCliente.Text, out int id))
                {
                    if (_objMLCliente == null)
                        _objMLCliente = new MLCliente();

                    _objMLCliente.ClienteId = id;
                    _objMLCliente.Ativo = true;
                    _objMLCliente = new DLCliente().Consultar(_objMLCliente);
                    if (_objMLCliente != null)
                    {
                        this.CarregarCamposCliente();
                        txtCliente.ForeColor = Color.Black;
                    }
                    else
                    {
                        LimparCamposCliente(false);
                        txtCodigoCliente.SelectAll();
                        txtCliente.Text = "Cliente inexistente";
                        txtCliente.ForeColor = Color.Red;
                    }
                }
                else
                    LimparCamposCliente();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtCodigoCondPgto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (int.TryParse(txtCodigoCondicaoPgto.Text, out int id))
                    {
                        if (_objMLCondicaoPagamento == null)
                            _objMLCondicaoPagamento = new MLCondicaoPagamento();


                        _objMLCondicaoPagamento.CondicaoPgtoId = id;
                        this.CarregarGridCondicaoPgto(id);
                    }
                    else
                        LimparCamposCondPgto();
                }
                else
                {
                    if (txtCodigoCondicaoPgto.Text != "")
                        MessageBox.Show("Informe primeiro os produtos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl1.SelectedTab = tbpProdutos;
                    txtCodigoCondicaoPgto.Clear();
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtCodigoTransportador_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoTransportador.Text, out int id))
                {
                    if (_objMLTransportadora == null)
                        _objMLTransportadora = new MLTransportador();


                    _objMLTransportadora.TransportadorId = id;
                    _objMLTransportadora = new DLTransportador().Listar(_objMLTransportadora).FirstOrDefault();
                    if (_objMLTransportadora != null)
                    {
                        this.CarregarCamposTransportadora(_objMLTransportadora);
                        txtTransportador.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtCodigoTransportador.SelectAll();
                        txtTransportador.Text = "Transportador inexistente";
                        txtTransportador.ForeColor = Color.Red;
                    }
                }
                else
                    LimparCamposTransportadora();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtCodigoProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoProduto.Text, out int id))
                {
                    if (_objMlProduto == null)
                        _objMlProduto = new MLProduto();

                    _objMlProduto.ProdutoId = id;
                    if (id > 0)
                        _objMlProduto = new DLProduto().Consultar(new MLProduto() { ProdutoId = id });
                    if (_objMlProduto != null && _objMlProduto.ProdutoId > 0)
                    {
                        if (txtCodigoProduto.Text == "")
                            txtCodigoProduto.Text = _objMlProduto.ProdutoId.ToString();
                        txtDescricaoProduto.Text = _objMlProduto.Descricao;
                        txtValorUnit.Text = _objMlProduto.ValorVenda.ToString(CultureInfo.CurrentCulture);
                        if (txtQtde.Text.Equals(""))
                            txtQtde.Text = "1";
                        txtSubtotal.Text = (_objMlProduto.ValorVenda * Convert.ToDecimal(txtQtde.Text)).ToString(CultureInfo.CurrentCulture);
                        txtEstoque.Text = _objMlProduto.Estoque.EstoqueReal.ToString();
                        txtTransportador.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtDescricaoProduto.Text = "Produto inexistente";
                        txtDescricaoProduto.ForeColor = Color.Red;
                    }
                }
                else
                {
                    LimparCamposProduto();
                }
                txtCodigoProduto.Focus();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        #endregion

        #region BOTÕES

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarAdicionarProduto();
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void ValidarAdicionarProduto()
        {
            try
            {
                decimal qtde = 0, estoque = 0;

                decimal.TryParse(txtQtde.Text, out qtde);
                decimal.TryParse(txtEstoque.Text, out estoque);

                if ((estoque - qtde) >= 0)
                {
                    isAdicionaProduto = true;
                    AdicionarProduto();
                }
                else
                {
                    MessageBoxEx.Show("Item com Saldo Insuficiente!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                    txtCodigoProduto.Focus();
                    txtCodigoProduto.SelectAll();
                    return;
                }

                if (dgvProdutos.RowCount > 0)
                {
                    cbRepetirItens.Enabled = true;
                    dgvProdutos.ClearSelection();
                }
                else
                {
                    cbRepetirItens.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarObsItem();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void btnCancelarObsItem_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarObsItem();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Gravar();
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void Gravar()
        {
            if (btnGravar.Text == "Salvar")
            {

                if (OrdemIsValida())
                {
                    if (txtCodigoCondicaoPgto.Text.Equals("1"))
                    {
                        FrmFinalizaVendaBalcao frmFinalizaVendaBalcao = new FrmFinalizaVendaBalcao(this);
                        frmFinalizaVendaBalcao.ShowDialog();
                    }

                    LerCampos();
                    int id = Salvar();

                    if (id > 0)
                    {
                        SalvarParcelasPedido(id);
                        _objMLPedido.PedidoId = id;
                    }

                    if (cmbTipoEmissao.SelectedIndex == 0)
                    {
                        if (_objMLPedido.PedidoId == 0)
                            MessageBoxEx.Show("Venda [ " + _objMLPedido.PedidoId.ToString() + " ] cadastrada com sucesso!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                        else
                            MessageBoxEx.Show("Venda atualizada com sucesso!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                    }
                    else
                    {
                        if (_objMLPedido.PedidoId == 0)
                            MessageBoxEx.Show("Orçamento [ " + _objMLPedido.PedidoId.ToString() + " ] cadastrada com sucesso!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                        else
                            MessageBoxEx.Show("Orçamento atualizada com sucesso!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                    }

                    if (MessageBoxEx.Show("Deseja imprimir o recibo de venda?", "SuppSys", MessageIcon.Information, MessageButton.YesNo) == DialogResult.Yes)
                    {
                        switch (Sessao.Instance.Configuracao.tipoImpressoraVendaPadrao)
                        {
                            case MLConfiguracaoGeral.TipoImpressao.NaoFiscal:
                                {
                                    //documento.PrinterSettings.Copies = Convert.ToInt16(Sessao.Instance.Configuracao.QtdeCopiasImpressaoPDV);//numero de cópias na impressão
                                    for (int i = 0; i < Sessao.Instance.Configuracao.QtdeCopiasImpressaoVendaPadrao; i++)
                                    {
                                        documento.DocumentName = "Pedido " + _objMLPedido.PedidoId;
                                        documento.Print();
                                    }
                                }
                                break;
                            case MLConfiguracaoGeral.TipoImpressao.PadraoA4:
                                {
                                    FrmRelatorioPedidoItens frmRelatorioPedidoItens = new FrmRelatorioPedidoItens(_objMLPedido.PedidoId);
                                    frmRelatorioPedidoItens.ShowDialog();
                                }
                                break;
                        }
                    }

                    LimparCampos();
                    HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
                    btnGravar.Text = "Novo";
                    this.btnGravar.Image = global::GUI.Properties.Resources.icon_plus;


                    if (isAlteracao)
                    {
                        Close();
                        Dispose();
                    }
                    isGravar = false;
                }
            }
            else
            {
                isGravar = true;
                HabilitaCampos(true, EnumTipo.HabiliaTodosCampos);
                HabilitaBotoes(EnumBotoes.Salvar);
                btnGravar.Text = "Salvar";
                dtpData1Pgto.Value = DateTime.Now;
                txtStatusDocumento.Text = "EM DIGITAÇÃO";
                this.btnGravar.Image = global::GUI.Properties.Resources.confirm;
                txtCodigoCliente.Focus();
            }
        }

        private void SalvarParcelasPedido(int id)
        {
            try
            {
                //new DLParcelaPedido().Excluir(id);

                for (int i = 0; i < dgvCondicaoPgto.RowCount; i++)
                {
                    objParcelaPedido = new MLParcelaPedido();

                    objParcelaPedido.PedidoId = id;
                    objParcelaPedido.ParcelaNr = Convert.ToInt32(dgvCondicaoPgto.Rows[i].Cells[0].Value);
                    objParcelaPedido.TotalParcelas = dgvCondicaoPgto.RowCount;
                    objParcelaPedido.Valor = Convert.ToDecimal(dgvCondicaoPgto.Rows[i].Cells[1].Value.ToString().Replace("R$", ""));
                    objParcelaPedido.DataVencimento = Convert.ToDateTime(dgvCondicaoPgto.Rows[i].Cells[2].Value);
                    objParcelaPedido.CondicaoPgtoId = Convert.ToInt32(txtCodigoCondicaoPgto.Text);
                    objParcelaPedido.Cancelado = false;

                    var condPagto = new DLCondicaoPagamento().ConsultarCondicaoPagamento(objParcelaPedido.CondicaoPgtoId);

                    if (dgvCondicaoPgto.RowCount == 1 && condPagto.DiasParaEntrada == 0 && Convert.ToDateTime(dgvCondicaoPgto.Rows[i].Cells[2].Value).Date == DateTime.Now.Date)
                        objParcelaPedido.DataPagto = Convert.ToDateTime(dgvCondicaoPgto.Rows[i].Cells[2].Value);

                    new DLParcelaPedido().Adicionar(objParcelaPedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarObjetoParcelas()
        {
            try
            {
                for (int i = 0; i < dgvCondicaoPgto.RowCount; i++)
                {
                    objParcelaPedido = new MLParcelaPedido();

                    objParcelaPedido.PedidoId = _objMLPedido.PedidoId;
                    objParcelaPedido.ParcelaNr = Convert.ToInt32(dgvCondicaoPgto.Rows[i].Cells[0].Value);
                    objParcelaPedido.TotalParcelas = dgvCondicaoPgto.RowCount;
                    objParcelaPedido.DataVencimento = Convert.ToDateTime(dgvCondicaoPgto.Rows[i].Cells[2].Value);
                    objParcelaPedido.Cancelado = false;

                    listaParcelaPedido.Add(objParcelaPedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoCliente.Enabled || txtNrOrcamCliente.Enabled)
                {
                    if (MessageBoxEx.Show("Deseja realmente cancelar a operação? \n\nAo cancelar todos os dados serão perdidos.", "Atenção", MessageIcon.Question, MessageButton.YesNo) == DialogResult.Yes)
                    {
                        LimparCampos();
                        HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
                        HabilitaBotoes(EnumBotoes.Cancelar);
                    }
                }
                else
                {
                    if (MessageBoxEx.Show("Deseja realmente fechar a janela? \n\nAo fechar todos os dados serão perdidos.", "Atenção", MessageIcon.Question, MessageButton.YesNo) == DialogResult.Yes)
                    {
                        LimparCampos();
                        HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
                        HabilitaBotoes(EnumBotoes.Cancelar);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatusDocumento.Text != "CANCELADA")
                {
                    if (string.IsNullOrEmpty(txtNrDocumento.Text))
                    {
                        //FrmControleDeCompra frm = new FrmControleDeCompra();
                        //frm.ShowDialog();
                    }

                    if (!string.IsNullOrEmpty(txtNrDocumento.Text))
                    {
                        btnCancelarOC.Visible = true;
                        btnCancelar.Text = "Cancelar Alterações";

                        MessageBox.Show("Em uma Vendafinalizada só é permitido alterar os seguintes atributos: " +
                                            "\n\n- Nota Fiscal;" +
                                            "\n\n- Orçamento de Cliente;" +
                                            ((cmbTipoEmissao.SelectedIndex == 1) ? "\n\n- Validade da Proposta;" : "") +
                                            // "\n\n- Valor do Frete;" +
                                            "\n\n- Observação;",
                                            "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        btnCancelarOC.Visible = false;
                        btnCancelar.Text = "Cancelar";
                    }
                    HabilitaCampos(true, EnumTipo.AlteraOC);
                    HabilitaBotoes(EnumBotoes.Alterar);
                }
                else
                {
                    MessageBoxEx.Show("Não é possível alterar uma Vendacancelada!", "AMS SISTEMAS", MessageIcon.Information, MessageButton.OK);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    var res = dgvProdutos.SelectedRows.Count;
                    if (res == 1)
                    {
                        if (MessageBox.Show("Deseja realamente excluir o produto '" + dgvProdutos.CurrentRow.Cells[1].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            this.RemoverProduto();
                            dgvProdutos.ClearSelection();
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Nenhum Produto selecionado!", "Atenção", MessageIcon.Information, MessageButton.OK);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Nenhum Produto selecionado!", "Atenção", MessageIcon.Information, MessageButton.OK);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
            dgvProdutos.ClearSelection();
        }

        private void btnRecalcularParcelas_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCodigoCondicaoPgto.Text, out int CondicaoPgtoId))
                    CarregarGridCondicaoPgto(CondicaoPgtoId);
                else
                {
                    MessageBoxEx.Show("Nenhuma Condição de Pagamento selecionada!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    txtCodigoCondPgto_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        #endregion

        private void cmbTipoEmissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Text = cmbTipoEmissao.Text;
                lblTitulo.Text = (cmbTipoEmissao.Text != "Venda") ? cmbTipoEmissao.Text + " de Venda" : cmbTipoEmissao.Text;

                bool isCotacao = cmbTipoEmissao.SelectedIndex == 1;//Orçamento;

                txtDiasValidadeProp.Visible = isCotacao;
                lblValidadeProposta.Visible = isCotacao;
                lblDias.Visible = isCotacao;
                txtDataValidadeProp.Visible = isCotacao;

                if (isCotacao)
                {
                    txtDiasValidadeProp.Focus();
                    txtDiasValidadeProp.SelectAll();
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void cmbFrete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFrete.SelectedIndex == 1)
                {
                    txtValorFrete.Enabled = false;
                    txtValorFrete.Text = 0.ToString("F");
                    AlterarValorFrete();
                }
                else
                    txtValorFrete.Enabled = true;

            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void txtPercentSt_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //decimal subtotal = Convert.ToDecimal(txtValorUnit.Text) * Convert.ToDecimal(txtQtde.Text);

                //if (decimal.TryParse(txtPercentSt.Text, out decimal pctSt))
                //{

                //    txtValorSt.Text = (subtotal * (pctSt / 100)).ToString("F");
                //    txtSubtotal.Text = (subtotal + Convert.ToDecimal(txtValorSt.Text) + Convert.ToDecimal(txtValorIpi.Text)).ToString("F");
                //    ssMensagem.Text = "";
                //}
                //else
                //{
                //    if (txtPercentSt.Text != "")
                //        ssMensagem.Text = "Informe somente números!";
                //    else
                //        ssMensagem.Text = "";

                //    txtSubtotal.Text = (subtotal + Convert.ToDecimal(txtValorIpi.Text)).ToString("F");
                //    txtValorSt.Text = (0).ToString("F");
                //}
            }
            catch
            {
                ssMensagem.Text = "Produto não Informado!";
            }
        }

        private void txtPercentIpi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal subtotal = Convert.ToDecimal(txtValorUnit.Text) * Convert.ToDecimal(txtQtde.Text);

                //if (decimal.TryParse(txtPercentIpi.Text, out decimal pctIpi))
                //{

                //    txtValorIpi.Text = (subtotal * (pctIpi / 100)).ToString("F");
                //    txtSubtotal.Text = (subtotal + Convert.ToDecimal(txtValorIpi.Text) + Convert.ToDecimal(txtValorSt.Text)).ToString("F");
                //    ssMensagem.Text = "";
                //}
                //else
                //{
                //    if (txtPercentIpi.Text != "")
                //        ssMensagem.Text = "Informe somente números!";
                //    else
                //        ssMensagem.Text = "";

                //    txtSubtotal.Text = (subtotal + Convert.ToDecimal(txtValorSt.Text)).ToString("F");
                //    txtValorIpi.Text = (0).ToString("F");
                //}
            }
            catch
            {
                ssMensagem.Text = "Produto não Informado!";
            }

        }

        #endregion

        #region *** MÉTODOS ***

        private void ExibirMenssagemException(Exception exception)
        {
            if (exception != null)
            {
                if (exception.InnerException != null)
                {
                    if (exception.InnerException.InnerException != null)
                    {
                        MessageBox.Show(@"Erro: " + exception.InnerException.InnerException.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(@"Erro: " + exception.InnerException.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(@"Erro: " + exception.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        #region CARREGAR CAMPOS E GRID

        private void CarregarTela()
        {
            //pnlObsItem.Visible = false;
            if (_objMLPedido == null)
            {
                CarregaCombos();
                txtValorFrete.Text = 0.ToString("F");
                txtDesconto.Text = 0.ToString("F");
                txtValorTotal.Text = 0.ToString("F");
                txtTotalProduto.Text = 0.ToString();
                txtDataDocumento.Text = DateTime.Now.ToShortDateString();
                txtDiasValidadeProp.Text = "30";

                cmbFrete.SelectedIndex = 0;

                btnCancelarOC.Visible = false;
                cbRepetirItens.Enabled = false;
                HabilitaCampos(true, EnumTipo.HabiliaTodosCampos);
            }
            else
            {
                HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
            }

            //Seta posição do painel de Observação do Item
            //this.pnlObsItem.Location = new System.Drawing.Point(338, 4);
            dtpData1Pgto.Value = DateTime.Now;
            dgvProdutos.ClearSelection();
        }

        internal void CarregarCampos()
        {
            //CarregarTela();

            _objMLCliente = _objMLPedido.Cliente;
            _objMLCliente.ClienteId = (int)_objMLPedido.ClienteId;
            CarregarCamposCliente();

            switch (_objMLPedido.StatusPedidoId)
            {
                case (int)MLStatusPedido.StatusPedido.FINALIZADO: txtStatusDocumento.Text = "FINALIZADA"; break;
                case (int)MLStatusPedido.StatusPedido.ENTRADAOK: txtStatusDocumento.Text = "ENTRADA NO ESTOQUE OK"; break;
                case (int)MLStatusPedido.StatusPedido.SAIDAOK: txtStatusDocumento.Text = "SAÍDA NO ESTOQUE OK"; break;
                case (int)MLStatusPedido.StatusPedido.CANCELADO: txtStatusDocumento.Text = "CANCELADA"; break;
                default: txtStatusDocumento.Text = "EM DIGITAÇÃO"; break;
            }
            if (_objMLPedido == null)
                txtStatusDocumento.Text = "";
            txtDataDocumento.Text = _objMLPedido.DataEmissao.ToString();
            txtNumeroNF.Text = (_objMLPedido.NotaFiscal == null) ? "" : _objMLPedido.NotaFiscal;
            _objMlUsuario = _objMLPedido.Usuario;
            CarregaCombos();
            CarregarCamposUsuario(_objMlUsuario);
            cmbTipoEmissao.SelectedIndex = 0;
            txtValorFrete.Text = _objMLPedido.ValorFrete.ToString("F");
            txtDesconto.Text = ((decimal)_objMLPedido.Desconto).ToString("F");
            txtValorFrete.Text = _objMLPedido.ValorFrete.ToString("F");
            txtObservacao.Text = _objMLPedido.Observacao;
            if (cmbFrete.Items.Count > 0)
                cmbFrete.SelectedIndex = (_objMLPedido.Frete == "FOB") ? 0 : 1;

            txtNrDocumento.Text = _objMLPedido.PedidoId.ToString();
            if (!string.IsNullOrEmpty(_objMLPedido.NrOrcamentoFornecedor))
                txtNrOrcamCliente.Text = _objMLPedido.NrOrcamentoFornecedor.ToString();

            txtValorTotal.Text = Convert.ToDecimal(_objMLPedido.ValorTotal).ToString("F");
            CarregarGridCondicaoPgto(_objMLPedido.CondicaoPgtoId);
            if (_objMLPedido.TransportadorId != null)
            {
                _objMLPedido.Transportador.TransportadorId = (int)_objMLPedido.TransportadorId;
                CarregarCamposTransportadora(_objMLPedido.Transportador);
            }
            _valorTotal = (decimal)_objMLPedido.ValorTotal;

            if (cmbTipoEmissao.Items.Count > 0)
                cmbTipoEmissao.SelectedIndex = Convert.ToInt32(_objMLPedido.IsCotacao);
            if (_objMLPedido.ValidadeProposta != null)
                txtDiasValidadeProp.Text = (_objMLPedido.ValidadeProposta - DateTime.Now).Value.Days.ToString();
            if (_objMLPedido.ValidadeProposta != null)
                txtDataValidadeProp.Text = Convert.ToDateTime(_objMLPedido.ValidadeProposta).ToShortDateString();
            CarregarGRidProdutos();


        }

        public void CarregarCamposCliente()
        {
            //_objMLCliente = new DLCliente().Consultar(_objMLCliente);
            txtCodigoCliente.Text = _objMLCliente.ClienteId.ToString();
            txtCliente.Text = _objMLCliente.NomeRazaoSocial;
            txtEndereco.Text = _objMLCliente.Logradouro;
            //txtBairro.Text = _objMLCliente.Bairro;
            var cidade = (_objMLCliente.Cidade == null) ? "" : _objMLCliente.Cidade.Nome;
            var estado = (_objMLCliente.Estado == null) ? "" : _objMLCliente.Estado.Nome;
            if (String.IsNullOrEmpty(cidade) && String.IsNullOrEmpty(estado))
                txtCidadeUf.Text = " N/A";
            else
                txtCidadeUf.Text = cidade + " / " + estado;
        }

        private void CarregaCombos()
        {
            try
            {
                cmbFrete.DataSource = _tipoFrete;
                cmbTipoEmissao.DataSource = _tipoEmissao;
                if (_objMLPedido != null)
                {
                    if (!_objMLPedido.IsCotacao) cmbTipoEmissao.SelectedIndex = 0; else cmbTipoEmissao.SelectedIndex = 1;
                    if (_objMLPedido.Frete == "FOB") cmbFrete.SelectedIndex = 0; else cmbFrete.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CarregarCamposProduto()
        {

        }

        private void CarregarObsItem()
        {
            try
            {
                //txtObsItem.Text = txtObsItemPopup.Text;
                //txtObsItemPopup.Text = "";
                //pnlObsItem.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CancelarObsItem()
        {
            try
            {
                //    txtObsItemPopup.Text = txtObsItem.Text;
                //    pnlObsItem.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CarregarCamposUsuario(MLUsuario usuario)
        {
            txtCodigoVendedor.Text = usuario.UsuarioId.ToString();
            txtVendedor.Text = usuario.Nome;
        }

        internal void CarregarCamposTransportadora(MLTransportador transportadora)
        {
            if (transportadora.TransportadorId > 0)
            {
                txtCodigoTransportador.Text = transportadora.TransportadorId.ToString();
                txtTransportador.Text = (string.IsNullOrEmpty(transportadora.NomeFantasia)) ? ((string.IsNullOrEmpty(transportadora.NomeRazaoSocial)) ? transportadora.NomeFantasia : transportadora.NomeRazaoSocial) : transportadora.NomeFantasia;
            }
        }

        public void CarregarGridCondicaoPgto(int CondicaoPgtoId)
        {
            try
            {
                var CondicaoPgto = new DLCondicaoPagamento().ListarCondicaoPgto(MLPedido.TipoPedido.VENDA).Where(c => c.CondicaoPgtoId == CondicaoPgtoId).FirstOrDefault();

                if (CondicaoPgto == null || CondicaoPgto.CondicaoPgtoId <= 0)
                {
                    dtpData1Pgto.Value = DateTime.Now;
                    txtCodigoCondicaoPgto.SelectAll();
                    txtCondPgto.Text = "Condição de Pagamento inexistente";
                    dgvCondicaoPgto.DataSource = null;
                    dgvCondicaoPgto.Rows.Clear();
                    dgvCondicaoPgto.Refresh();
                    txtCondPgto.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    txtCodigoCondicaoPgto.Text = CondicaoPgto.CondicaoPgtoId.ToString();
                    txtCondPgto.Text = CondicaoPgto.CondicaoPgtoDescricao.ToString();
                    txtCondPgto.ForeColor = Color.Black;
                }

                dgvCondicaoPgto.Rows.Clear();
                int parcelas = CondicaoPgto.NrParcelas;
                Decimal totallocal = Convert.ToDecimal(txtValorTotal.Text);
                Decimal valor = totallocal / parcelas;
                DateTime dt = new DateTime();

                dt = dtpData1Pgto.Value;

                int diaParcela = dt.Day;
                int mesParcela = dt.Month;

                if (CondicaoPgto.DiasParaEntrada > 0)
                    if (CondicaoPgto.DiasParaEntrada == 30)
                        dt = dt.AddMonths(1);
                    else
                        dt = dt.AddDays(CondicaoPgto.DiasParaEntrada);

                if (dt.Month != 2)//se não for fevereiro
                {
                    int mesParcelaVigente = dt.Month;
                    int anoParcelaVigente = dt.Year;

                    if (dt.Day != diaParcela)
                    {
                        int dia = 0;

                        //verificar se mes tem 31 dias
                        if (mesParcelaVigente != 4 && mesParcelaVigente != 6 && mesParcelaVigente != 9 && mesParcelaVigente != 11) dia = diaParcela; else dia = 30;

                        if (dt.Month != 2)//diferente de fevereiro
                            dt = new DateTime(anoParcelaVigente, mesParcelaVigente, dia);
                        else
                            //monta data verificando se mes é diferente de janeiro, pois se diminuir 1 do mes de janeiro dá exception
                            dt = new DateTime(anoParcelaVigente, mesParcelaVigente != 1 ? mesParcelaVigente - 1 : mesParcelaVigente, dia);
                    }
                }

                if (CondicaoPgto.Intervalo == 2)//Mensal
                {
                    for (int i = 1; i <= parcelas; i++)
                    {
                        if (dgvCondicaoPgto.Columns.Count == 0)
                            this.dgvCondicaoPgto.Columns.AddRange(new DataGridViewColumn[] { this.ParcelaNr, this.Valor, this.DataVencimento });
                        String[] parcela = new String[] { i.ToString(), valor.ToString("C"), dt.ToShortDateString() };
                        this.dgvCondicaoPgto.Rows.Add(parcela);

                        dt = dt.AddMonths(1);
                    }
                }
                else
                {
                    for (int i = 1; i <= parcelas; i++)
                    {

                        dt = dt.AddDays(15);

                        if (dt.Day < 16)
                        {
                            if (i > 2)
                            {
                                if (dt.Day != (Convert.ToDateTime(dgvCondicaoPgto.Rows[i - 2].Cells[2].Value).AddDays(-15).Day))//mes de 31 dias
                                {
                                    int diaMesAnterior = Convert.ToDateTime(dgvCondicaoPgto.Rows[i - 2].Cells[2].Value).AddDays(-15).Day;
                                    int diferencaDias = 0;

                                    diferencaDias = diaMesAnterior - dt.Day;
                                    dt = dt.AddDays(diferencaDias);
                                }
                            }
                        }


                        String[] parcela = new String[] { i.ToString(), valor.ToString("C"), dt.ToShortDateString() };
                        this.dgvCondicaoPgto.Rows.Add(parcela);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarGRidProdutos()
        {
            if (lstCompraItem == null)
                lstCompraItem = _objMLPedido.listaPedidoItem;
            if (lstCompraItem.Count > 0)
            {

                var newList = lstCompraItem.Select(ci => new
                {
                    Codigo = ci.ProdutoId,
                    Descricao = ci.Produto.Descricao,
                    Quantidade = ci.Quantidade,
                    ValorUnitario = ci.Produto.ValorVenda,
                    SubTotal = ci.SubTotal,
                    PrevisaoEntrega = ci.DataEntrega
                }).ToList();
                //if (txtTotalProduto.Text == "0")
                //    for (int i = 0; i < newList.Count; i++)
                //        _totalItens += (int)newList[i].Quantidade;

                if (!isAdicionaProduto)
                {
                    foreach (var item in newList)
                        _totalItens += (int)item.Quantidade;
                }

                txtTotalProduto.Text = _totalItens.ToString();

                dgvProdutos.DataSource = newList;
                MontarGrid(dgvProdutos);
            }
            else
            {
                dgvProdutos.DataSource = null;
            }
        }

        #endregion

        #region LIMPAR CAMPOS E GRID

        public void LimparCampos()
        {
            //--------DAdos da Orçamento---------
            LimparCamposCliente();
            txtNumeroNF.Clear();
            txtNrDocumento.Clear();
            txtDataDocumento.Text = DateTime.Now.ToShortDateString();
            txtStatusDocumento.Clear();
            LimparCamposVendedor();
            LimparCamposCondPgto();
            txtNrOrcamCliente.Clear();
            cmbFrete.SelectedIndex = 1;
            txtValorFrete.Text = 0.ToString("F");
            txtDesconto.Text = 0.ToString("F");
            LimparCamposTransportadora();
            cmbTipoEmissao.SelectedIndex = 0;
            txtDiasValidadeProp.Text = 0.ToString();
            txtDataValidadeProp.Text = DateTime.Now.ToShortDateString();
            dtpData1Pgto.Value = DateTime.Now;
            txtObservacao.Clear();
            txtTotalProduto.Text = "0";
            txtValorTotal.Text = 0.ToString("F");
            dgvCondicaoPgto.Rows.Clear();
            dgvProdutos.DataSource = null;
            dgvProdutos.Refresh();
            _objMLPedido = new MLPedido();
            lstCompraItem = new List<MLPedidoItem>();
            dtpData1Pgto.Value = DateTime.Now;

            txtValorPago.Text = 0.ToString("F");
            txtTroco.Text = 0.ToString("F");

            btnCancelarOC.Visible = false;
            btnCancelar.Text = "Cancelar";

            _totalItens = 0;
            _valorTotal = 0;

            //--------Produtos---------
            LimparCamposProduto();
        }
        private void LimparCamposTransportadora()
        {
            txtCodigoTransportador.Clear();
            txtTransportador.Clear();
        }

        private void LimparCamposCliente(bool limpaCodigo = true)
        {
            if (limpaCodigo)
                txtCodigoCliente.Clear();
            txtCliente.Clear();
            txtEndereco.Clear();
            //txtBairro.Clear();
            txtCidadeUf.Clear();
        }

        private void LimparCamposVendedor()
        {
            txtCodigoVendedor.Clear();
            txtVendedor.Clear();
        }

        private void LimparCamposCondPgto()
        {
            txtCodigoCondicaoPgto.Clear();
            txtCondPgto.Clear();
        }

        private void LimparCamposProduto()
        {
            try
            {
                txtCodigoProduto.Clear();
                txtQtde.Text = 0.ToString();
                txtDescricaoProduto.Clear();
                txtObsItem.Clear();
                //txtPercentSt.Clear();
                //txtValorSt.Text = 0.ToString("F");
                //txtPercentIpi.Clear();
                //txtValorIpi.Text = 0.ToString("F");
                txtQtde.Text = 1.ToString();
                txtValorUnit.Text = 0.ToString("F");
                txtSubtotal.Text = 0.ToString("F");
                txtDiasPrevisaoEntrega.Clear();
                txtDataPrevisaoEntrega.Clear();
                txtEstoque.Clear();
                //txtObsItemPopup.Clear();
                cbRepetirItens.Checked = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void AdicionarProduto()
        {
            try
            {
                //MLPedidoItem ci = new MLPedidoItem();

                var pedidoItem = new MLPedidoItem();
                if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
                    pedidoItem.ProdutoId = Convert.ToInt32(txtCodigoProduto.Text);
                else
                {
                    MessageBox.Show("Selecione o produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoProduto_DoubleClick(null, null);
                    return;
                }
                pedidoItem.Produto.Descricao = txtDescricaoProduto.Text;
                pedidoItem.ObservacaoItem = txtObsItem.Text;

                if (!string.IsNullOrEmpty(txtQtde.Text))
                    pedidoItem.Quantidade = Convert.ToDecimal(txtQtde.Text);
                else
                {
                    MessageBox.Show("Informe a quantidade!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQtde.Focus();
                    return;
                }
                pedidoItem.Produto.ValorVenda = Convert.ToDecimal(txtValorUnit.Text);
                pedidoItem.SubTotal = Convert.ToDecimal(txtSubtotal.Text);

                if (!string.IsNullOrEmpty(txtDiasPrevisaoEntrega.Text))
                    pedidoItem.DiasPrevisaoEntrega = Convert.ToInt16(txtDiasPrevisaoEntrega.Text);

                if (!string.IsNullOrEmpty(txtDataPrevisaoEntrega.Text.Replace("  /  /", "")))
                    pedidoItem.DataEntrega = Convert.ToDateTime(txtDataPrevisaoEntrega.Text);
                if (_objMLPedido == null)
                    _objMLPedido = new MLPedido();

                if (_objMLPedido.listaPedidoItem == null)
                    _objMLPedido.listaPedidoItem = new List<MLPedidoItem>();

                _totalItens += Convert.ToInt32(txtQtde.Text);
                _valorTotal += (decimal)pedidoItem.SubTotal;

                txtTotalProduto.Text = _totalItens.ToString();
                txtValorTotal.Text = _valorTotal.ToString(CultureInfo.CurrentUICulture);

                bool jaExistente = false;
                if (lstCompraItem == null)
                    lstCompraItem = new List<MLPedidoItem>();
                if (dgvProdutos.RowCount == 0)

                {
                    lstCompraItem.Add(pedidoItem);
                    jaExistente = true;
                }

                var it = lstCompraItem.FindIndex(ci => ci.ProdutoId == pedidoItem.ProdutoId);

                if (cbRepetirItens.Checked)
                {
                    lstCompraItem.Add(pedidoItem);
                    jaExistente = true;
                }
                else
                {
                    for (int i = 0; i < dgvProdutos.RowCount; i++)
                    {
                        if (pedidoItem.ProdutoId == Convert.ToInt32(dgvProdutos.Rows[i].Cells[0].Value))
                        {
                            if (!cbRepetirItens.Checked && it != -1)
                            {
                                lstCompraItem[it].Produto = pedidoItem.Produto;
                                lstCompraItem[it].Quantidade += pedidoItem.Quantidade;
                                lstCompraItem[it].SubTotal += pedidoItem.SubTotal;
                                jaExistente = true;
                                break;
                            }
                        }
                    }
                }

                if (!jaExistente)
                    lstCompraItem.Add(pedidoItem);

                CarregarGRidProdutos();
                LimparCamposProduto();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MontarGrid(DataGridView grid)
        {
            grid.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);

            var objBlControleGrid = new ControleGrid(grid);

            if (grid.Name == "dgvCondicaoPgto")
            {
                //Define quais colunas serão visíveis
                objBlControleGrid.DefinirVisibilidade(new List<string>() { "Parcela Nrº", "VAlor", "Data" });

                //Define quais os cabeçalhos respectivos das colunas 
                objBlControleGrid.DefinirCabecalhos(new List<string>() { "ProdutoId", "Descrição", "NrParcelas" });

                //Define quais as larguras respectivas das colunas 
                objBlControleGrid.DefinirLarguras(new List<int>() { 10, 80, 20 }, grid.Width);

                //Define quais os alinhamentos respectivos do componentes das colunas 
                objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda" });
            }
            else if (grid.Name == "dgvProdutos")
            {
                //Define quais colunas serão visíveis
                objBlControleGrid.DefinirVisibilidade(new List<string>() { "Codigo", "Descricao", "Quantidade", "ValorUnitario", "SubTotal", "PrevisaoEntrega" });

                //Define quais os cabeçalhos respectivos das colunas 
                objBlControleGrid.DefinirCabecalhos(new List<string>() { "Codigo", "Descrição", "Quantidade", "Valor Unitário", "Sub Total", "Previsao de Entrega" });

                //Define quais as larguras respectivas das colunas 
                objBlControleGrid.DefinirLarguras(new List<int>() { 15, 25, 10, 15, 15, 20 }, grid.Width);

                //Define quais os alinhamentos respectivos do componentes das colunas 
                objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "direita", "direita", "direita", "direita" });
            }


            //Define a altura das linhas respectivas da Grid 
            objBlControleGrid.DefinirAlturaLinha(30);

        }

        private void RemoverProduto()
        {
            try
            {
                MLPedidoItem produto = lstCompraItem.Where(prod => prod.ProdutoId == Convert.ToInt32(dgvProdutos.Rows[dgvProdutos.CurrentRow.Index].Cells[0].Value)
                                                                && prod.Quantidade == Convert.ToInt32(dgvProdutos.Rows[dgvProdutos.CurrentRow.Index].Cells[2].Value)).FirstOrDefault();

                lstCompraItem.Remove(produto);
                _totalItens -= Convert.ToInt32(dgvProdutos.Rows[dgvProdutos.CurrentRow.Index].Cells[2].Value);
                _valorTotal -= Convert.ToDecimal(dgvProdutos.Rows[dgvProdutos.CurrentRow.Index].Cells[4].Value);
                CarregarGRidProdutos();

                txtTotalProduto.Text = _totalItens.ToString(CultureInfo.CurrentCulture);
                txtValorTotal.Text = _valorTotal.ToString(CultureInfo.CurrentCulture);
                if (txtCondPgto.Text.Trim() != "")
                {
                    CarregarGridCondicaoPgto(Convert.ToInt32(txtCodigoCondicaoPgto.Text));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool OrdemIsValida()
        {
            if (txtCodigoCliente.Text == "" || txtCliente.Text == "  inexistente")
            {
                MessageBox.Show("Informe o Cliente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                tabControl1.SelectedTab = tbpDadosCompras;
                return false;
            }
            if (txtCodigoVendedor.Text == "" || txtVendedor.Text == "Vendedor inexistente")
            {
                MessageBox.Show("Informe o Vendedor!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoVendedor.Focus();
                tabControl1.SelectedTab = tbpDadosCompras;
                return false;
            }
            if (txtCodigoCondicaoPgto.Text == "" || txtCondPgto.Text == "Transportador inexistente")
            {
                MessageBox.Show("Informe a Condição de Pagamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedTab = tbpDadosCompras;
                txtCodigoCondicaoPgto.Focus();
                return false;
            }
            if (dgvProdutos.RowCount == 0)
            {
                MessageBox.Show("Nenhum produto selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProduto.Focus();
                tabControl1.SelectedTab = tbpProdutos;
                return false;
            }
            return true;
        }

        private void LerCampos()
        {
            try
            {
                if (_objMLPedido == null)
                    _objMLPedido = new MLPedido();


                //--------------------Dados---------------

                if (int.TryParse(txtNrDocumento.Text, out int compraid))
                    _objMLPedido.PedidoId = compraid;

                _objMLPedido.DataEmissao = DateTime.Now;
                _objMLPedido.NotaFiscal = (txtNumeroNF.Text != "") ? txtNumeroNF.Text : "0";
                if (txtStatusDocumento.Text.ToUpper() == "FINALIZADA" || txtStatusDocumento.Text.ToUpper() == "EM DIGITAÇÃO")
                    _objMLPedido.StatusPedidoId = (int)MLStatusPedido.StatusPedido.FINALIZADO;//FInalizado
                else if (txtStatusDocumento.Text.ToUpper() == "CANCELADA")
                    _objMLPedido.StatusPedidoId = 2;//FINALIZADA
                _objMLPedido.ClienteId = Convert.ToInt32(txtCodigoCliente.Text);
                //_objMLPedido.TipoPagamentoId = Convert.ToInt32(txtCodigoCliente.Text);
                _objMLPedido.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);
                //_objMLPedido.DataCancelamento = Convert.ToDateTime(txtCodigoCliente.Text);
                _objMLPedido.UsuarioId = Convert.ToInt32(txtCodigoVendedor.Text);
                _objMLPedido.NrOrcamentoFornecedor = Convert.ToString(txtNrOrcamCliente.Text);
                if (cmbTipoEmissao.Text == "Orçamento")
                    _objMLPedido.ValidadeProposta = Convert.ToDateTime(txtDataValidadeProp.Text);
                _objMLPedido.Frete = Convert.ToString(cmbFrete.Text);
                if (txtCodigoTransportador.Text != "")
                    _objMLPedido.TransportadorId = Convert.ToInt32(txtCodigoTransportador.Text);
                _objMLPedido.ValorFrete = Convert.ToDecimal(txtValorFrete.Text);
                _objMLPedido.Desconto = Convert.ToDecimal(txtDesconto.Text);
                _objMLPedido.IsCotacao = cmbTipoEmissao.Text == "Orçamento";
                _objMLPedido.CondicaoPgtoId = Convert.ToInt32(txtCodigoCondicaoPgto.Text);
                _objMLPedido.DataInicioPgto = Convert.ToDateTime(dtpData1Pgto.Value);
                _objMLPedido.Observacao = Convert.ToString(txtObservacao.Text);
                _objMLPedido.Tipo = "V"; //VENDA


                //--------------------Produtos---------------

                //codigo, quantidade, previsão de entrega
                _objMLPedido.listaPedidoItem = new List<MLPedidoItem>();

                for (int i = 0; i < lstCompraItem.Count; i++)
                {

                    MLPedidoItem item = new MLPedidoItem();

                    item.PedidoItemId = lstCompraItem[i].PedidoItemId;
                    item.ProdutoId = lstCompraItem[i].ProdutoId;
                    item.Quantidade = lstCompraItem[i].Quantidade;
                    item.SubTotal = lstCompraItem[i].Produto.ValorVenda * lstCompraItem[i].Quantidade;
                    item.DiasPrevisaoEntrega = lstCompraItem[i].DiasPrevisaoEntrega;
                    item.DataEntrega = lstCompraItem[i].DataEntrega;
                    item.ObservacaoItem = lstCompraItem[i].ObservacaoItem;

                    _objMLPedido.listaPedidoItem.Add(item);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int Salvar()
        {
            int id = 0;
            try
            {
                DLPedido bl = new DLPedido();

                _objMLPedido.CaixaId = Sessao.Instance.Caixa.CaixaId;
                _objMLPedido.ControleMovimentoCaixaId = Sessao.Instance.Caixa.ControleMovimentoCaixaId;

                if (_objMLPedido.PedidoId > 0)
                    bl.Atualizar(_objMLPedido);
                else
                {
                    _objMLPedido.ValorParcelas = Convert.ToDecimal(dgvCondicaoPgto.Rows[0].Cells[1].Value.ToString().Replace("R$", ""));

                    _objMLPedido.PedidoId = id = bl.Adicionar(_objMLPedido);

                    #region FORMA DE PAGTO

                    var condicaoPagto = new DLCondicaoPagamento().ConsultarCondicaoPagamento(_objMLPedido.CondicaoPgtoId);

                    if (_objMLPedido.lstMLPgtoEntrada == null)
                        _objMLPedido.lstMLPgtoEntrada = new List<MLPgtoEntrada>();

                    if (_objMLPedido.lstMLPgtoEntrada.Count > 0)
                    {
                        foreach (var pgtoEntrada in _objMLPedido.lstMLPgtoEntrada)
                            pgtoEntrada.PedidoId = _objMLPedido.PedidoId;
                        new DLPedido().InserirFormaPgtoPedido(_objMLPedido.lstMLPgtoEntrada);
                    }
                    else if (condicaoPagto.DiasParaEntrada == 0)
                    {
                        MLPgtoEntrada pgtoEntrada = new MLPgtoEntrada();
                        pgtoEntrada.PedidoId = _objMLPedido.PedidoId;
                        var valorEntrada = (decimal)_objMLPedido.ValorTotal / (decimal)condicaoPagto.NrParcelas;
                        pgtoEntrada.FormaPgtoId = condicaoPagto.FormaPgtoEntradaId;
                        pgtoEntrada.Valor = Convert.ToDecimal(valorEntrada);

                        _objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);
                        new DLPedido().InserirFormaPgtoPedido(_objMLPedido.lstMLPgtoEntrada);
                    }

                    #endregion
                    CarregarMovimentacaoEstoque(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
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

                    EstoqueMovimentacao.PedidoId = pedido.PedidoId;
                    EstoqueMovimentacao.UsuarioId = (Sessao.Instance.Usuario == null) ? 1/*Usuário Administrador*/ : Sessao.Instance.Usuario.UsuarioId /*Senão, usuario logado*/;
                    EstoqueMovimentacao.TipoMovimentacao = "S";
                    EstoqueMovimentacao.ProdutoId = pedido.listaPedidoItem[i].ProdutoId;
                    EstoqueMovimentacao.Quantidade = pedido.listaPedidoItem[i].Quantidade;
                    EstoqueMovimentacao.MovimentoCancelado = false;
                    EstoqueMovimentacao.DataMovimentacao = DateTime.Now;
                    EstoqueMovimentacao.ClienteId = (int)pedido.ClienteId;
                    if (Sessao.Instance.Empresa.EmpresaId > 0)
                        EstoqueMovimentacao.EmpresaId = Sessao.Instance.Empresa.EmpresaId;
                    else
                        EstoqueMovimentacao.EmpresaId = new DLEmpresa().Consultar(new MLEmpresa() { Ativo = true }).EmpresaId;
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
        #endregion

        private void txtValorFrete_GotFocus(object sender, EventArgs e)
        {
            txtValorFrete.SelectAll();
        }

        private void txtDesconto_GotFocus(object sender, EventArgs e)
        {
            txtDesconto.SelectAll();
        }

        private void txtDesconto_Click(object sender, EventArgs e)
        {
            txtDesconto.SelectAll();
        }

        private void txtValorFrete_Click(object sender, EventArgs e)
        {
            txtValorFrete.SelectAll();
        }

        private void HabilitaCampos(bool habilita, EnumTipo tipo)
        {
            if (tipo == EnumTipo.HabiliaTodosCampos)
            {
                //DADOS 
                txtNumeroNF.Enabled = habilita;
                txtCodigoCliente.Enabled = habilita;
                txtCliente.Enabled = habilita;
                txtCodigoVendedor.Enabled = habilita;
                txtCodigoCondicaoPgto.Enabled = habilita;
                txtNrOrcamCliente.Enabled = habilita;
                cmbFrete.Enabled = habilita;
                txtValorFrete.Enabled = habilita;
                txtDesconto.Enabled = habilita;
                txtCodigoTransportador.Enabled = habilita;
                cmbTipoEmissao.Enabled = habilita;
                txtDiasValidadeProp.Enabled = habilita;
                txtDataValidadeProp.Enabled = habilita;
                btnRecalcularParcelas.Enabled = habilita;

                //PRODUTOS
                txtCodigoProduto.Enabled = habilita;
                txtQtde.Enabled = habilita;
                txtDiasPrevisaoEntrega.Enabled = habilita;
                txtDataPrevisaoEntrega.Enabled = habilita;
                cbRepetirItens.Enabled = habilita;
                txtObsItem.Enabled = habilita;
                //txtObsItemPopup.Enabled = habilita;
                //txtPercentSt.Enabled = habilita;
                //txtPercentIpi.Enabled = habilita;
                txtObservacao.Enabled = habilita;
                btnAdicionarProduto.Enabled = habilita;

            }

            if (tipo == EnumTipo.AlteraOC)
            {
                txtNumeroNF.Enabled = habilita;
                txtNrOrcamCliente.Enabled = habilita;
                //cmbFrete.Enabled = habilita;
                //txtValorFrete.Enabled = habilita;
                txtDiasValidadeProp.Enabled = habilita;
                txtDataValidadeProp.Enabled = habilita;
                txtObservacao.Enabled = habilita;
                cmbTipoEmissao.Enabled = habilita;
                //btnRecalcularParcelas.Enabled = habilita;
                if (cmbTipoEmissao.SelectedIndex == 1)
                    cmbTipoEmissao.Enabled = true;
                else
                    cmbTipoEmissao.Enabled = false;
            }

            if (tipo == EnumTipo.CancelaOC)
            {
            }
        }

        private void HabilitaBotoes(EnumBotoes botoes)
        {
            switch (botoes)
            {
                case EnumBotoes.Salvar:
                    {
                        btnGravar.Enabled = true;
                        btnAlterar.Enabled = false;
                        txtFechar.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnCancelarOC.Enabled = false;
                        btnAdicionarProduto.Enabled = true;
                        btnRemover.Enabled = true;
                        btnGravar.Image = global::GUI.Properties.Resources.icon_plus;
                        if (txtNrOrcamCliente.Enabled)
                        {
                            btnGravar.Text = "Salvar";
                        }
                    }
                    break;
                case EnumBotoes.Alterar:
                    {
                        btnGravar.Enabled = true;
                        btnAlterar.Enabled = false;
                        txtFechar.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnCancelarOC.Enabled = false;
                        btnCancelarOC.Visible = false;
                        btnAdicionarProduto.Enabled = false;
                        btnRemover.Enabled = false;
                        btnGravar.Image = global::GUI.Properties.Resources.confirm;
                        if (txtNrOrcamCliente.Enabled)
                        {
                            btnGravar.Text = "Salvar";
                        }
                    }
                    break;
                case EnumBotoes.Finalizado:
                    {
                        btnGravar.Enabled = false;
                        btnAlterar.Enabled = true;
                        txtFechar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnCancelarOC.Enabled = true;
                        btnAdicionarProduto.Enabled = false;
                        btnRemover.Enabled = false;
                        if (txtNrOrcamCliente.Enabled)
                        {
                            btnGravar.Text = "Salvar";
                        }
                    }
                    break;
                case EnumBotoes.Cancelar:
                    {
                        btnGravar.Enabled = true;
                        btnAlterar.Enabled = false;
                        txtFechar.Enabled = true;
                        btnCancelar.Enabled = false;
                        btnCancelarOC.Enabled = false;
                        btnAdicionarProduto.Enabled = false;
                        btnRemover.Enabled = false;
                        btnGravar.Focus();
                        btnGravar.Image = global::GUI.Properties.Resources.icon_plus;
                        btnGravar.Text = "Novo";
                    }
                    break;
                case EnumBotoes.Cancelado:
                    {
                        btnGravar.Enabled = false;
                        btnAlterar.Enabled = false;
                        txtFechar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnCancelarOC.Enabled = false;
                        btnAdicionarProduto.Enabled = false;
                        btnRemover.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }
        public enum EnumBotoes
        {
            Salvar,
            Alterar,
            Cancelar,
            Cancelado,
            Finalizado
        }
        public enum EnumTipo
        {
            CancelaOC,
            HabiliaTodosCampos,
            AlteraOC
        }

        private void txtCodigoProduto_Click(object sender, EventArgs e)
        {
            txtCodigoProduto.SelectAll();
        }

        private void txtCodigoProduto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCadastroProduto frmCadastroProduto = new FrmCadastroProduto(this);
                frmCadastroProduto.ShowDialog();
                if (txtQtde.Text == "")
                    txtQtde.Text = "1";

                ssMensagem.Text = "";
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtCodigoCliente_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.SelectAll();
        }

        private void txtCodigoCliente_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente(this);
                frmCadastroCliente.ShowDialog();
                //CarregarCamposCliente();
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtCodigoVendedor_Click(object sender, EventArgs e)
        {
            txtCodigoVendedor.SelectAll();
        }

        private void txtCodigoVendedor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCadastroUsuario frmCadastroUsuario = new FrmCadastroUsuario(this);
                frmCadastroUsuario.ShowDialog();
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtCodigoCondPgto_Click(object sender, EventArgs e)
        {
            txtCodigoCondicaoPgto.SelectAll();
        }

        private void txtCodigoCondicaoPgto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalProduto.Text != "" && txtTotalProduto.Text != "0")
                {
                    FrmCadastroCondcaoPgto frmConsultaCondPgto = new FrmCadastroCondcaoPgto(this, MLPedido.TipoPedido.VENDA);
                    frmConsultaCondPgto.Show();
                }
                else
                {
                    MessageBox.Show("Informe primeiro os produtos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl1.SelectedTab = tbpProdutos;
                }
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtCodigoTransportador_Click(object sender, EventArgs e)
        {
            txtCodigoTransportador.SelectAll();
        }

        private void txtCodigoTransportador_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCadastroTransportador frmConsultaTransportadora = new FrmCadastroTransportador(this);
                frmConsultaTransportadora.ShowDialog();
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtObsItem_Click(object sender, EventArgs e)
        {
            txtObsItem.SelectAll();
        }

        private void txtObsItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //pnlObsItem.Visible = true;
                //txtObsItemPopup.Text = txtObsItem.Text;
                //txtObsItemPopup.Focus();
            }
            catch (Exception exception)
            {
                ExibirMenssagemException(exception);
            }
        }

        private void txtNumeroNF_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnCancelarOC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatusDocumento.Text != "CANCELADA")
                {
                    if (MessageBox.Show("Deseja relamente cancelar a Vendanrº " + txtNrDocumento.Text + "?\n\nO cancelamento não poderá ser desfeito!", "AMS Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CancelarOC(Convert.ToInt32(txtNrDocumento.Text));
                        MessageBox.Show("Venda Cancelada com sucesso!", "AMS Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        HabilitaCampos(false, EnumTipo.HabiliaTodosCampos);
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível alterar uma Vendacancelada!", "AMS SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ExibirMenssagemException(ex);
            }
        }

        private void CancelarOC(int compraid)
        {
            try
            {
                _objMLPedido.PedidoId = compraid;
                _objMLPedido.StatusPedidoId = (int)MLStatusPedido.StatusPedido.CANCELADO;//Cancelada
                _objMLPedido.DataCancelamento = DateTime.Now;
                _objMLPedido.Observacao = txtObservacao.Text;

                DLPedido bl = new DLPedido();

                if (_objMLPedido.PedidoId > 0)
                    bl.Atualizar(_objMLPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

            if (btnGravar.Text.ToUpper().Equals("Salvar"))
            {
                if (MessageBoxEx.Show("Deseja realmente sair?\n\nAo sair todos os daods não salvos serão perdidos!", "Informação", MessageIcon.Question, MessageButton.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {

        }

        private void InserirDicaTexCodigo()
        {
            ssMensagem.Text = "Digite o código ou duplo clique para pesquisar.";
        }

        private void RemoverDicaTextCodigo()
        {
            ssMensagem.Text = "";
        }

        #region Mouse Hover e Leave

        private void txtCodigoVendedor_MouseHover(object sender, EventArgs e)
        {
            InserirDicaTexCodigo();
        }

        private void txtCodigoVendedor_MouseLeave(object sender, EventArgs e)
        {
            RemoverDicaTextCodigo();
        }

        private void txtCodigoCondicaoPgto_MouseHover(object sender, EventArgs e)
        {
            InserirDicaTexCodigo();
        }

        private void txtCodigoCondicaoPgto_MouseLeave(object sender, EventArgs e)
        {
            RemoverDicaTextCodigo();
        }

        private void txtCodigoCliente_MouseHover(object sender, EventArgs e)
        {
            InserirDicaTexCodigo();
        }

        private void txtCodigoCliente_MouseLeave(object sender, EventArgs e)
        {
            RemoverDicaTextCodigo();
        }

        private void txtCodigoTransportador_MouseHover(object sender, EventArgs e)
        {
            InserirDicaTexCodigo();
        }

        private void txtCodigoTransportador_MouseLeave(object sender, EventArgs e)
        {
            RemoverDicaTextCodigo();
        }
        #endregion

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            FrmFinalizaVendaBalcao frmFinalizaVendaBalcao = new FrmFinalizaVendaBalcao(this);
            frmFinalizaVendaBalcao.ShowDialog();
            txtCodigoCondicaoPgto.Text = "1";
        }

        private void VerificarTecla(object sender, KeyEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    switch (e.KeyCode)
                    {
                        case (Keys.Enter):
                            {
                                if (sender is TextBox)
                                {
                                    var campo = sender as TextBox;

                                    if (campo.Name.ToUpper().Equals("TXTNUMERONF"))
                                        txtCodigoVendedor.Focus();
                                    else if (!campo.Name.ToUpper().Equals("TXTCODIGOPRODUTO"))
                                        SendKeys.Send("{TAB}");

                                    if (campo.Name.ToUpper().Equals("TXTCODIGOPRODUTO"))
                                        ValidarAdicionarProduto();

                                    if (campo.Name.ToUpper().Equals("TXTQTDE"))
                                        ValidarAdicionarProduto();
                                }
                            }
                            break;
                        case Keys.F6:
                            {
                                if (sender is FrmVendaPadrao)
                                {
                                    Gravar();
                                }
                            }
                            break;
                        case Keys.F9:
                            {
                                if (sender is TextBox)
                                {
                                    if (tabControl1.SelectedTab == tbpProdutos)
                                        tabControl1.SelectedTab = tbpDadosCompras;
                                    else
                                        tabControl1.SelectedTab = tbpProdutos;
                                }
                            }
                            break;
                    }
                }
                e = null;
                sender = null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #region EVENTOS KEYDOWN

        private void FrmVendaPadrao_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtNumeroNF_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtCodigoCondicaoPgto_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtNrOrcamCliente_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtCodigoTransportador_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtCodigoProduto_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtQtde_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void cmbFrete_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtValorFrete_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void cmbTipoEmissao_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtDiasValidadeProp_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtDataValidadeProp_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }
        #endregion


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
                var bairro = (estabelecimento.Bairro == null) ? "" : estabelecimento.Bairro;

                var cidadeid = estabelecimento.CidadeId;
                var ufid = estabelecimento.EstadoId;

                //CARREGA OBJETO CIDADE
                var cidades = new DLCidade().Listar(new MLCidade() { EstadoId = (int)ufid });
                //CARREGA OBJETO ESTADO
                var estados = new DLEstado().Listar(new MLEstado());

                var cidade = cidades.First(c => c.CidadeId == cidadeid).Nome; //carrega o nome da cidade com base no codigo da cidade do objeto estabelecimento
                var uf = estados.First(es => es.EstadoId == ufid).Nome; //carrega o nome do estado com base no codigo do estado do objeto estabelecimento

                var cep = (estabelecimento.Cep == null) ? "" : estabelecimento.Cep;
                var cnpj = (estabelecimento.CNPJ == null) ? "" : estabelecimento.CNPJ;
                var ie = (estabelecimento.IE == null) ? "" : estabelecimento.IE;
                var im = (estabelecimento.IM == null) ? "" : estabelecimento.IM;

                #endregion
                //DEFINE A DISTANCIA EM RELAÇÂO A COORDENADA X (HORIZONTAL) E EM RELAÇÂO AO ALINHAMENTO DETERMINADO
                posicao.X = -120;
                //DEFINE LARGURA DA PÁGINA
                posicao.Width = 527;
                e.Graphics.DrawString(razaoSocial.ToUpper(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoCentro);//X = -120 e relação ao centro da página

                posicao.Y += 13;//soma mais 13 Pixels para baixo (VERTICAL)
                e.Graphics.DrawString(endereco.ToUpper(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 13;
                var enderecoComplemento = bairro.ToUpper() + " - " + cidade.ToUpper() + " - " + uf.ToUpper() + " - " + Formatacao.FormatarCEP(cep);
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
                string linhaTracejada = "----------------------------------------------------------------------------";
                //string linhaTracejada = "";
                //for (decimal i = 0; i < posicao.Width; i = i + Convert.ToDecimal(dimensaoTraco.Width))
                //    linhaTracejada += traco;

                var tamLinha = e.Graphics.MeasureString(linhaTracejada, fonteArial10Regular);
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 10; //desce 17 pixels
                posicao.X = 5; // margim de 0 pixels
                e.Graphics.DrawString(DateTime.Now.ToString(CultureInfo.CurrentCulture), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y -= 10;
                posicao.X = -110;
                e.Graphics.DrawString("CCF: 123456", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);//VALOR DO CCF FICTÍCIO

                posicao.Y -= 9;
                posicao.X -= 130;
                e.Graphics.DrawString("Pedido Nº: " + _objMLPedido.PedidoId.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoDireita);

                //--------------------------------------------------------------------------------- LInha Tracejada
                posicao.Y += 25;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 5;
                posicao.X = -110;

                e.Graphics.DrawString("CUPOM NÃO FISCAL", fonteArial10Negrito, corPreta, posicao, alinhamnetoCentro);

                posicao.Y += 23;
                posicao.X = 5;
                fonteLucidaSans10Regular = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                string cabecalhoCupom = "ITEM          CÓDIGO          DESCRIÇÃO ";
                var tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.X = 5;
                posicao.Y += 10;
                tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                cabecalhoCupom = "QTD             UN          VL. UNITÁRIO (R$)         VL. ITEM (R$)";
                e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //--------------------------------------------------------------------------------- LInha Tracejada
                posicao.Y += 7;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                #endregion

                //Monta pedido
                MLPedido pedido = _objMLPedido;
                int codigoPedido = _objMLPedido.PedidoId;
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
                    string UnMedida = (lstItem[i].Produto.UnidadeMedida == null) ? "" : lstItem[i].Produto.UnidadeMedida.Descricao;
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
                    posicao.X = 30;

                    e.Graphics.DrawString(codigo, fonteArial10Regular, corPreta, posicao);
                    posicao.X += Convert.ToInt32(dimensaoCodigo.Width) + 5;

                    if (Qtde == "0,0000")
                        e.Graphics.DrawString(" ***ITEM CANCELADO*** ".ToUpper(), fonteArial10Regular, corPreta, posicao);
                    else
                        e.Graphics.DrawString(item.ToUpper(), fonteArial10Regular, corPreta, posicao);
                    posicao.X += Convert.ToInt32(dimensaoItem.Width);

                    posicao.Y += 10;
                    posicao.X = 30;

                    e.Graphics.DrawString(Qtde, fonteArial10Regular, corPreta, posicao);
                    posicao.X += Convert.ToInt32(dimensaoQtde.Width) + 5;

                    e.Graphics.DrawString(UnMedida, fonteArial10Regular, corPreta, posicao);
                    posicao.X += Convert.ToInt32(dimensaoUnMedida.Width) + 5;

                    e.Graphics.DrawString(strMultiplicador, fonteArial10Regular, corPreta, posicao);
                    posicao.X += Convert.ToInt32(dimensaoX.Width) + 5;

                    if (Qtde == "0,0000")
                        e.Graphics.DrawString("0", fonteArial10Regular, corPreta, posicao);
                    else
                        e.Graphics.DrawString(valorUnit, fonteArial10Regular, corPreta, posicao);
                    SizeF tamValorSubTotal = e.Graphics.MeasureString(Convert.ToDouble(valorTotal).ToString("F"), fonteArial10Regular);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorSubTotal.Width + 15;
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

                if (_objMLPedido.CondicaoPgtoId > 1)
                {
                    posicao.Y += 20;
                    posicao.X = 5; //Margem de0 pixels
                    e.Graphics.DrawString("PAGTO: " + _objMLPedido.CondicaoPgtoDescricao, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                }
                else
                {
                    /////////////////////////valor pago//////////////////////////////
                    posicao.Y += 15;
                    posicao.X = 5; //Margem de0 pixels
                    e.Graphics.DrawString("PAGO R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                    var tamValorPago = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F"), fonteArial10Regular);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorPago.Width + 15;
                    var pago = txtValorPago.Text;
                    var valorpago = Convert.ToDouble(pago).ToString("F");
                    e.Graphics.DrawString(valorpago.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                    /////////////////////////////TROCO//////////////////////////////////
                    posicao.Y += 20;
                    posicao.X = 5; //Margem de0 pixels
                    e.Graphics.DrawString("TROCO R$", fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                    //var tamanhoTroco = e.Graphics.MeasureString((_objMLPedido.ValorTotal - _objMLPedido.ValorTotal);
                    posicao.X = Convert.ToInt32(tamLinha.Width) - 10;
                    var troco = txtTroco.Text.Replace("R$", "");
                    var valortroco = Convert.ToDouble(troco).ToString("F");
                    e.Graphics.DrawString(valortroco.ToString(), fonteArial10Negrito, corPreta, posicao, alinhamnetoEsquerda);
                }



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
                Bitmap bm = new Bitmap(br.Write(_objMLPedido.PedidoId.ToString()), 150, 150);
                posicao.Y += 25;

                posicao.X = Convert.ToInt32(263 - bm.Width - 40);
                posicao.Width = 150;//largura do qrcode
                posicao.Height = 150;//altura do qrcode
                e.Graphics.DrawImage(bm, posicao);



                #endregion

                //y = new ImprimeCupomNaoFiscal(frmVendaBalcao, e, y).MontaCupom();



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
            //new ImprimeVenda(_objMLPedido, _lstMlPedidoItem).Print();

        }
    }
}
