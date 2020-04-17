using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo;
using System.Drawing;
using Dados;
using GUI.Ferramentas;
using System.Linq;
using GUI.Operacoes;
using Apresentacao.Operacoes;

namespace GUI.Operacoes
{
    public partial class FrmVendaBalcao : Form
    {
        #region *** PROPRIEDADES ***

        FrmAberturaCaixa frmAberturaCaixa { get; set; }
        MLProduto objMLProdutos = new MLProduto();
        public MLPedido _objMLPedido { get; set; }
        public MLPedidoItem _objMLPedidoItem { get; set; }
        internal List<MLPedidoItem> _lstMLPedidoItem { get; set; }
        //Image button_image = Resources.botao2;
        Int32 _codigoItem;
        String _codigoBarras;
        Double _total = 0;
        public int controlaEnter = 0;
        public MLUsuario _usuario;
        public MLCaixa _caixa;
        private int ItemNr;
        private object obj;
        private KeyEventArgs ea;
        private object lblAviso;

        public enum enumFuncoes
        {
            pedidoFechado = 1,
            pedidoAberto = 2
        }

        #endregion

        #region *** CONSTRUTORES ***

        public FrmVendaBalcao()
        {
            InitializeComponent();
            this.CarregarGridCliente();
            this.HabiltaBtnExcluirItem(false);

            txtCodigo.Focus();
            txtCodigo.Select();
        }

        public FrmVendaBalcao(MLCaixa caixa, FrmAberturaCaixa frmAberturaCaixa)
        {
            this._usuario = caixa.Usuario;
            this._caixa = caixa;
            this.frmAberturaCaixa = frmAberturaCaixa;

            InitializeComponent();
            this.CarregarGridCliente();
            this.HabiltaBtnExcluirItem(false);

            txtCodigo.Focus();
            txtCodigo.Select();
            if (_usuario != null)
            {
                if (!String.IsNullOrEmpty(_usuario.Nome))
                {
                    lblClienteId.Text = _usuario.UsuarioId.ToString();
                    lblOperadorNome.Text = _usuario.Nome.ToString();
                    lblNumeroCaixa.Text = caixa.CaixaDescricao.ToString();
                }
            }
        }

        #endregion

        #region *** Eventos ***

        #region *** FORMULÁRIO ***

        private void FrmVendaBalcao_Load(object sender, EventArgs e)
        {
            #region Dados Empresa CUPOM

            labNomeEmpresa.Text = "Empresa: " + Sessao.Instance.Empresa.NomeFantasia;
            labEnderecoEmpresa.Text = "Endereço: " + Sessao.Instance.Empresa.Logradouro + " " + Sessao.Instance.Empresa.Bairro + " " + "Cep: " + Sessao.Instance.Empresa.Cep + " " + "N°: " + Sessao.Instance.Empresa.Numero;
            labIEempresa.Text = "IE: " + Sessao.Instance.Empresa.IE;
            labIMempresa.Text = "IM: " + Sessao.Instance.Empresa.IM;
            labCNPJempresa.Text = Sessao.Instance.Empresa.CNPJ;
            labCNPJempresa.ForeColor = Color.White;

            #endregion
            try
            {
                this.btnFinalizarVenda.Enabled = false;

                ItemNr = 0;
                lblProduto.Text = "";

                this.HabiltarCampos(false);
                btnRecuperarPedido.Enabled = false;

                RedimensionarGrid();
                CarregarGridCliente();

                ControlarFuncoes(enumFuncoes.pedidoFechado);


                btnNovoPedido.Focus();
                btnNovoPedido.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedimensionarGrid()
        {
            panel3.Size = new System.Drawing.Size((Width / 10) * 4, panel3.Height);
            panel3.Location = new System.Drawing.Point((Width / 1000) * 935, lblProduto.Location.Y + lblProduto.Height + 10);

            dgvGeral.Size = new System.Drawing.Size((Width / 10) * 4, dgvGeral.Height);
            dgvGeral.Location = new System.Drawing.Point((Width / 1000) * 935, panel3.Location.Y + panel3.Height + 5);
        }

        //Eventos de tecla
        private void FrmVendaBalcao_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void FrmVendaBalcao_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.frmAberturaCaixa.txtOperadorMatricula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** CAMPOS ***

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int64 codigo = 0;
                bool isNumber = Int64.TryParse(txtCodigo.Text.Replace("\r\n", ""), out codigo);
                if (isNumber)
                {
                    if (codigo.ToString().Length == 13)
                    {
                        _codigoBarras = codigo.ToString();
                        objMLProdutos = new DLProduto().Consultar(new MLProduto() { CodigoBarras = _codigoBarras });
                    }
                    else
                    {
                        try
                        {
                            _codigoItem = Convert.ToInt32(codigo);
                            objMLProdutos = new DLProduto().Consultar(new MLProduto() { ProdutoId = _codigoItem });
                        }
                        catch
                        {
                            objMLProdutos = new MLProduto();
                        }
                    }


                    if (objMLProdutos.ProdutoId != 0)
                    {
                        lblProduto.Text = objMLProdutos.Descricao.ToString();
                        txtPrecoUnit.Text = Convert.ToDouble(objMLProdutos.ValorVenda).ToString("F");
                        if (!String.IsNullOrEmpty(txtQtde.Text))
                            txtPrecoTotal.Text = (Convert.ToDouble(objMLProdutos.ValorVenda) * Convert.ToDouble(txtQtde.Text)).ToString("F");
                    }
                    else
                    {
                        this.LimparCampos(false);
                    }
                }
                else
                {
                    txtPrecoUnit.Text = 0.ToString("F");
                    txtPrecoTotal.Text = 0.ToString("F");
                }
                this.lblProduto.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtQtde_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    #region *** PRESSIONA ENTER ***
                    if (!String.IsNullOrEmpty(txtQtde.Text))
                    {
                        Double Number;
                        txtQtde.Text = txtQtde.Text.Replace("\r\n", "").Replace(".", ",");
                        bool isNumber = Double.TryParse(txtQtde.Text, out Number);
                        if (isNumber)
                        {
                            txtCodigo.Focus();
                            txtCodigo.SelectAll();
                            this.HabiltaBtnExcluirItem(true);

                            if (!String.IsNullOrEmpty(txtCodigo.Text))
                                if (txtPrecoUnit.Text.Contains("R$"))
                                    txtPrecoTotal.Text = (Convert.ToDouble(txtPrecoUnit.Text.Replace("R$", "").Replace("R$ ", "")) * Convert.ToDouble(txtQtde.Text)).ToString("F");
                                else
                                    txtPrecoTotal.Text = (Convert.ToDouble(txtPrecoUnit.Text) * Convert.ToDouble(txtQtde.Text)).ToString("F");
                            txtQtde.Text = String.Format("{0:0.000}", Number);

                            lblProduto.Text = "";
                        }
                        else
                        {
                            lblProduto.Text = "Informe uma Quantidade válida!";
                        }
                    }
                    else
                    {
                        lblProduto.Text = "Informe uma Quantidade!";
                    }
                    #endregion
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** BOTÕES ***

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                this.AbrePedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecuperarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                this.RecuperarPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPesquisaProduto frmPesquisarProduto = new FrmPesquisaProduto(this);
                frmPesquisarProduto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                FinalizarVenda_Click(obj, ea, null);
                this.ControlarFuncoes(enumFuncoes.pedidoFechado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            try
            {

                int Item;
                bool excluir = false;

                bool isNumber = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Informe o Número do Item a ser Excluído", "Excluir", ""), out Item);
                while (!isNumber)
                {
                    MessageBox.Show("Número inválido!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    string ret = Microsoft.VisualBasic.Interaction.InputBox("Informe o Número do Item a ser Excluído", "Excluir", "");
                    if (!String.IsNullOrEmpty(ret))
                        isNumber = Int32.TryParse(ret, out Item);
                    else
                        break;
                }
                if (isNumber)
                {
                    for (int i = 0; i < dgvGeral.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgvGeral.Rows[i].Cells[0].Value) == Item)
                        {
                            if (dgvGeral.Rows[i].Cells[2].Value.ToString() != " ***  ITEM CANCELADO *** ")
                            {
                                string unid = "";
                                switch (dgvGeral.Rows[i].Cells[4].Value.ToString())
                                {
                                    case "UND": if (Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value) == 1) unid = "unidade"; else unid = "unidades"; break;
                                    case "KG": if (Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value) == 1) unid = "kilo"; else unid = "kilos"; break;
                                    case "PC": if (Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value) == 1) unid = "peça"; else unid = "peças"; break;
                                    case "LT": if (Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value) == 1) unid = "litro"; else unid = "litros"; break;
                                }
                                excluir = MessageBox.Show("Deseja realmente excluir o Item "
                                                            + dgvGeral.Rows[i].Cells[0].Value.ToString() + " - " //Nome do Item
                                                            + dgvGeral.Rows[i].Cells[2].Value.ToString() + "  "  // Quantidade do item
                                                            + Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value).ToString() + " " // unidade no singular ou plural
                                                            + unid
                                                            + "?",
                                                            "AMS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes;

                                if (excluir)
                                {
                                    dgvGeral.Rows[i].Cells[2].Value = " ***  ITEM CANCELADO *** ";
                                    dgvGeral.Rows[i].Cells[3].Value = string.Format("{0:0.000}", 0);
                                    dgvGeral.Rows[i].Cells[4].Value = string.Empty;
                                    dgvGeral.Rows[i].Cells[5].Value = string.Format("{0:0.00}", 10);
                                    dgvGeral.Rows[i].Cells[6].Value = string.Format("{0:0.00}", 0);
                                    // new BlPedidoItem().CancelarItem()
                                }
                                CalcularValorTotal(true);//RECALCULA O VALOR TOTAL
                                if (dgvGeral.Rows.Count == 0)
                                {
                                    this.HabiltaBtnExcluirItem(false);
                                    this.btnFinalizarVenda.Enabled = false;
                                }
                                dgvGeral.CurrentCell = dgvGeral.Rows[i].Cells[0];  //Seleciona a linha para posterior exclusão
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Item já excluído!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    //foreach (DataGridViewRow row in dgvGeral.Rows)
                    //{
                    //    if (dgvGeral.Rows.Count > 0) //Verifica se Existe itens na grid. OBS: A GRID SEMPRE POSSUIRÁ NO MINIMO 1 LINHA
                    //    {
                    //        if (excluir)
                    //        {
                    //            if ((bool)row.Selected)  //Se EXISTIR LINHA SELECIONADA
                    //            {
                    //                if (row.Index != (dgvGeral.Rows.Count - 1)) //SE A LINHA SELECIONADA NÂO FOR A ULTIMA LINHA (SEM VALOR)
                    //                {
                    //                    //dgvGeral.Rows.Remove(row);//
                    //                    dgvGeral.CurrentCell = null;
                    //                    CalcularValorTotal(true);//RECALCULA O VALOR TOTAL
                    //                    //lblValorTotal.Text = "R$ 0,00";
                    //                }
                    //                else
                    //                {
                    //                    MessageBox.Show("Selecione a linha do Item a ser excluído!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                }
                    //            }
                    //        }

                    //        if (dgvGeral.Rows.Count == 1)
                    //        {
                    //            this.HabiltaBtnExcluirItem(false);
                    //            this.btnFinalizarVenda.Enabled = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Não existem itens a serem excluídos!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    }
                    //}
                }
                dgvGeral.Refresh();
                this.LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterarQtde_Click(object sender, EventArgs e)
        {
            try
            {
                this.AlterarQuantidadeItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                PressionarTecla(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinalizarVenda_Click(object obj, EventArgs ea, KeyEventArgs e)
        {
            try
            {
                if (dgvGeral.Rows.Count > 0)
                {
                    if (MessageBoxEx.Show("Finalizar Venda?", "Venda", MessageIcon.Question, MessageButton.YesNo).Equals(DialogResult.Yes))
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        FrmFinalizaVenda objFrmFinalizaVenda = new FrmFinalizaVenda(this);
                        objFrmFinalizaVenda.Show();
                    }
                }
                else
                {
                    MessageBoxEx.Show("A Venda não possui itens!!", "Venda", MessageIcon.Information, MessageButton.OK);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show("Erro: " + ex.InnerException.InnerException.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Erro: " + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** LABELS ***
        #endregion

        #region *** GRID ***

        private void dgvGeral_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                this.btnFinalizarVenda.Enabled = true;
                this.btnExcluirItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGeral_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (dgvGeral.Rows.Count == 0)
                {
                    this.btnFinalizarVenda.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region *** Métodos ***

        #region *** CAMPOS ***

        public void LimparCampos(bool limpaCodigo = true)
        {
            if (limpaCodigo)
                txtCodigo.Text = "";

            txtQtde.Text = "1,000";
            txtPrecoTotal.Text = "0,00";
            txtPrecoUnit.Text = "0,00";
            lblProduto.Text = "";
            txtCodigo.Focus();
            txtCodigo.Select();
            _codigoItem = 0;
        }

        private void LimparCampoCodigo()
        {
            txtCodigo.Focus();
            txtCodigo.SelectAll();
            txtCodigo.Text = String.Empty;
        }

        private void CalcularValorTotal(bool limparCampos = false)
        {
            if (dgvGeral.Rows.Count > 0)
            {
                Double valor = 0;
                Double qtde = 0;
                for (int i = 0; i < dgvGeral.Rows.Count; i++)
                {
                    if (!String.IsNullOrEmpty(dgvGeral.Rows[i].Cells[5].Value.ToString()))
                    {
                        valor += Convert.ToDouble(dgvGeral.Rows[i].Cells[5].Value) * Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value);
                        lblValorTotal.Text = (valor).ToString("F");
                    }

                    if (limparCampos)
                        this.LimparCampos();

                    #region *** ITEM SEM SALDO ***
                    //qtde = Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value);
                    //qtdeSolicitada += qtde;
                    //if (Convert.ToDouble(objMLProdutos.Estoque) < qtdeSolicitada)
                    //{
                    //    if (objMLProdutos.Estoque == 0)
                    //        MessageBox.Show("Item sem saldo!!", "Atenção", MessageBoxButtons.OK);
                    //    else
                    //        MessageBox.Show("Saldo Insuficiente!\n\nEstoque: " + objMLProdutos.Estoque, "Atenção", MessageBoxButtons.OK);

                    //    dgvGeral.Rows.Remove(dgvGeral.Rows[i]);
                    //    qtdeSolicitada -= qtde;
                    //    this.LimparCampos();
                    //    break;
                    //}
                    #endregion
                }
            }
        }

        public void CarregarCodigoPesquisado(int codigo)
        {
            txtCodigo.Text = codigo.ToString();
        }

        private void AlterarQuantidadeItem()
        {
            txtQtde.Enabled = true;
            txtQtde.Focus();
            txtQtde.SelectAll();
        }

        private void PressionarTecla(KeyEventArgs e)
        {
            Double qtdeSolicitada = 0;
            Double ValorVenda = Convert.ToDouble(objMLProdutos.ValorVenda);
            if (!String.IsNullOrEmpty(txtQtde.Text))
                qtdeSolicitada = Convert.ToDouble(txtQtde.Text);
            Double subTotal = qtdeSolicitada * ValorVenda;
            object obj = null;
            EventArgs ea = null;
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    #region *** PRESSIONA ENTER ***
                    txtCodigo.Text = txtCodigo.Text.Replace("\r\n", "");

                    if (!String.IsNullOrEmpty(txtCodigo.Text) || _codigoItem > 0)
                    {
                        Double Number;
                        bool isNumber = Double.TryParse(txtQtde.Text, out Number);// Verifica se é um numero válido
                        if (isNumber)
                        {
                            DLProduto objBlProduto = new DLProduto();
                            if (!String.IsNullOrEmpty(txtCodigo.Text))
                            {
                                bool CodigoIsNumber = Double.TryParse(txtCodigo.Text, out Number);// Verifica se é um numero válido
                                if (Number.ToString().Length == 13)
                                {
                                    _codigoBarras = Number.ToString();
                                    objMLProdutos = new DLProduto().Consultar(new MLProduto() { CodigoBarras = _codigoBarras });
                                }
                                else
                                {
                                    try
                                    {
                                        _codigoItem = Convert.ToInt32(Number);
                                        objMLProdutos = new DLProduto().Consultar(new MLProduto() { ProdutoId = _codigoItem });
                                    }
                                    catch
                                    {
                                        objMLProdutos = new MLProduto();
                                    }
                                }


                            }
                            if (objMLProdutos.ProdutoId != 0)
                            {
                                ValorVenda = Convert.ToDouble(objMLProdutos.ValorVenda);
                                subTotal = qtdeSolicitada * ValorVenda;

                                if (!String.IsNullOrEmpty(objMLProdutos.Descricao))
                                {
                                    lblProduto.Text = objMLProdutos.Descricao.ToString();

                                    this.AdcionarProduto(objMLProdutos, subTotal);
                                    //this.LimparCampos();
                                    this.CalcularValorTotal();
                                    txtQtde.Text = "1,000";
                                    this.LimparCampos();
                                }
                                else
                                {
                                    this.LimparCampoCodigo();
                                    MessageBox.Show("Produto Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                this.lblProduto.ForeColor = Color.White;
                            }
                            else
                            {
                                this.LimparCampoCodigo();

                                lblProduto.Text = "Código Inválido!";
                                lblProduto.ForeColor = Color.Red;
                                //MessageBox.Show("Código Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            this.LimparCampoCodigo();
                            MessageBox.Show("Informe um código Válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        this.LimparCampoCodigo();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    #endregion
                }
                else if (e.KeyCode == Keys.F2)
                {
                    #region *** F2 - ALTERAR QUANTIDADE ***
                    this.AlterarQuantidadeItem();
                    #endregion
                }
                else if (e.KeyCode == Keys.F3)
                {
                    #region *** F3 - PESQUISAR ITEM  ***
                    try
                    {
                        this.btnPesquisar_Click(obj, ea);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.F4)
                {
                    #region *** F4 - EXCLUIR ITEM  ***
                    if (dgvGeral.Rows.Count > 0)//Verifica se Existe itens na grid
                    {
                        this.btnExcluirItem_Click(obj, ea);
                    }
                    else
                    {
                        MessageBox.Show("Sem itens a serem excluídos!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.F5)
                {
                    #region *** F5 - FINALIZAR VENDA ***
                    if (dgvGeral.Rows.Count > 0)//Verifica se Existe itens na grid
                    {
                        this.FinalizarVenda_Click(obj, ea, e);
                    }
                    else
                    {
                        MessageBox.Show("Não há itens na venda!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.F8)
                {
                    CancelarPedido();
                }
                else if (e.KeyCode == Keys.F9)
                {
                    InserirCliente();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    #region *** ESC - SAIR ***
                    if (dgvGeral.Rows.Count > 0)//Verifica se Existe itens na grid
                    {
                        MessageBox.Show("Venda em Andamento!\n\nPara sair, primeiro cancele ou finalize a venda!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                    }
                    #endregion
                }
                else
                {
                    if (btnNovoPedido.Focused)
                    {
                        if (e.KeyCode == Keys.F6)
                        {
                            this.AbrePedido();
                            return;
                        }
                    }
                    #region *** Carrega Produto ***
                    //Veririfca se o valor do código é numérico
                    //Caso sim, se o campo código não estiver vazio, Pequisa produto
                    //Senão utiliza o código já carregado anteriormente
                    int codigo = 0;
                    bool isNumber = Int32.TryParse(txtCodigo.Text.Replace("\r\n", ""), out codigo);
                    if (isNumber)
                    {
                        if (!String.IsNullOrEmpty(txtCodigo.Text.Replace("\r\n", "")))
                            _codigoItem = Convert.ToInt32(txtCodigo.Text);
                        objMLProdutos = new DLProduto().Consultar(new MLProduto() { ProdutoId = _codigoItem });
                        if (objMLProdutos.ProdutoId != 0)
                        {
                            lblProduto.Text = objMLProdutos.Descricao.ToString();
                            txtPrecoUnit.Text = Convert.ToDouble(objMLProdutos.ValorVenda).ToString("F");
                            txtPrecoTotal.Text = (Convert.ToDouble(objMLProdutos.ValorVenda) * Convert.ToDouble(txtQtde.Text)).ToString("F");
                        }
                    }
                    #endregion
                }

                e = null;
            }
            catch (Exception ex)
            {
                txtCodigo.Text = String.Empty;
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** BOTÕES ***
        #endregion

        #region *** LABELS ***
        #endregion

        #region *** GRID ***

        protected void CarregarGridCliente()
        {
            dgvGeral.DataSource = null;

            try
            {
                //ListaVenda = objBLVendas.ListarVenda(objMLVenda);
                dgvGeral.DataSource = null;
                this.MontarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //if (objBLVendas != null)
                //    objBLVendas = null;
            }
        }

        public void MontarGrid()
        {

            dgvGeral.DefaultCellStyle.Font = new Font("Lucida Sans Unicode", 16F, GraphicsUnit.Pixel);

            ControleGrid objBL_ControleGrid = new ControleGrid(dgvGeral);

            //Define quais colunas serão visíveis
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "item", "Descricao", "Quantidade", "UnidMedida", "ValorUnit", "ValorTotal" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "Nº", "Descrição", "Qtde", "Unid", "Valor", "Total" });

            //Define quais as larguras respectivas das colunas 
            //Int32 larg = lblTopVendasBalcao.Width;
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 10, 35, 15, 10, 15, 15 }, dgvGeral.Width);

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda", "direita", "direita", "direita" });

            //Define a altura das linhas respectivas da Grid 
            //objBL_ControleGrid.DefinirAlturaLinha(40);

        }

        #endregion

        /// <summary>
        /// Remove os dois primeiros caracteres de uma String (Exemplo 'R$')
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private String RemoveCifrao(String valor)
        {
            String Novovalor = valor.Remove(0, 2);
            return Novovalor;
        }

        private bool HabiltaBtnExcluirItem(bool habilita)
        {
            if (habilita)
                btnExcluirItem.Enabled = true;
            else
                btnExcluirItem.Enabled = false;

            return habilita;
        }

        private void AdcionarProduto(MLProduto objMLProdutos, Double subTotal)
        {
            try
            {
                dgvGeral.Rows.Add(
                    Formatacao.ZerosEsquerda(ItemNr.ToString(), 3),
                    objMLProdutos.ProdutoId,
                    objMLProdutos.Descricao,
                    txtQtde.Text,
                    (objMLProdutos.UnidadeMedida == null) ? "" : objMLProdutos.UnidadeMedida.Descricao,
                    objMLProdutos.ValorVenda.ToString("n2"),
                    (Convert.ToDecimal(txtQtde.Text) * Convert.ToDecimal(objMLProdutos.ValorVenda)).ToString("n2"));
                ItemNr++;

                #region *** Atributos da Grid ***

                MontarGrid();

                #endregion

                btnFinalizarVenda.Enabled = true;
                btnExcluirItem.Enabled = true;
                _total += Convert.ToDouble(subTotal);
                txtCodigo.Text = "";
                objMLProdutos = null;

                dgvGeral.CurrentCell = null;
            }
            catch
            {
                this.btnFinalizarVenda.Enabled = false;
                this.btnExcluirItem.Enabled = false;
            }
        }

        private void AbrePedido()
        {
            this.GerarNovoPedido();
            this.HabiltarCampos(true);
            Sessao.Instance.Cliente.ClienteId = 1;
            Sessao.Instance.Cliente.CPF = null;
            Sessao.Instance.Cliente.CNPJ = null;
            txtCodigo.Focus();
            txtCodigo.SelectAll();
            txtQtde.Text = String.Format("{0:0.000}", 1);
            btnNovoPedido.Enabled = false;
            this.ControlarFuncoes(enumFuncoes.pedidoAberto);
        }

        private void GerarNovoPedido()
        {
            _objMLPedido = new MLPedido();

            #region *** Carrega Pedido Padrão***

            _objMLPedido.Cliente = new MLCliente();
            _objMLPedido.Cliente.ClienteId = 1; //Destinatário Geral - Consumidor

            _objMLPedido.Usuario = new MLUsuario();
            _objMLPedido.UsuarioId = this._usuario.UsuarioId;

            _objMLPedido.DataEmissao = DateTime.Now;
            _objMLPedido.Tipo = "V";//VENDA
            _objMLPedido.StatusPedidoId = 1;//Aberto
                                            // _objMLPedido.CaixaId = this._caixa.CaixaId;


            _objMLPedido.ValorTotal = 0; // Convert.ToDecimal(this.lblValorTotal.Text.Replace("R$ ", "").Replace("R$", ""));
            _objMLPedido.Desconto = 0;
            _objMLPedido.Acrescimo = 0;

            #endregion

            _objMLPedido.PedidoId = new DLPedido().Adicionar(_objMLPedido);
        }

        private void RecuperarPedido()
        {
            if (!String.IsNullOrEmpty(txtCodigo.Text))
                _objMLPedido.PedidoId = Convert.ToInt32(txtCodigo.Text);

            if (_objMLPedido != null)
            {
                if (_objMLPedido.Usuario != null)
                {
                    _objMLPedido.Usuario = new MLUsuario();
                }
            }
            else
            {
                _objMLPedido = new MLPedido();
                _objMLPedido.Usuario = new MLUsuario();
            }
            _objMLPedido.Usuario.UsuarioId = _usuario.UsuarioId;
            //FrmRecuperarPedido frmRecuperarPedido = new FrmRecuperarPedido(_objMLPedido, this);
            //frmRecuperarPedido.ShowDialog();
        }

        internal void HabiltarCampos(bool habiltaCampos)
        {
            txtCodigo.Enabled = habiltaCampos;
            txtQtde.Enabled = habiltaCampos;
            txtPrecoUnit.Enabled = habiltaCampos;
            //txtPrecoTotal.Enabled = habiltaCampos;

            dgvGeral.Enabled = habiltaCampos;

            btnNovoPedido.Enabled = !habiltaCampos;
            btnRecuperarPedido.Enabled = !habiltaCampos;

            btnAlterarQtde.Enabled = habiltaCampos;
            btnPesquisar.Enabled = habiltaCampos;
            btnExcluirItem.Enabled = habiltaCampos;
            btnFinalizarVenda.Enabled = habiltaCampos;
            btnCancelar.Enabled = habiltaCampos;
            btnSair.Enabled = !habiltaCampos;

            if (habiltaCampos)
            {
                txtCodigo.Focus();
                txtCodigo.SelectAll();
            }
            else
            {
                btnNovoPedido.Focus();
                btnNovoPedido.Select();
            }
            ItemNr = 1;
        }

        internal MLPedido CarregarItensPedido(bool isUpdate, bool ChamarBD = false)
        {
            try
            {

                if (dgvGeral.RowCount > 0)
                {
                    #region *** Carrega Itens do Pedido  ***

                    _lstMLPedidoItem = new List<MLPedidoItem>();
                    _objMLPedido.ValorTotal = 0;

                    for (int i = 0; i < this.dgvGeral.RowCount; i++) //Carrega Itens o Pedido
                    {
                        //if (dgvGeral.Rows[i].Cells["Descricao"].Value.ToString() == " ***  ITEM CANCELADO *** ")
                        //    continue;

                        _objMLPedidoItem = new MLPedidoItem();
                        _objMLPedidoItem.Pedido = _objMLPedido;
                        _objMLPedidoItem.Produto = new MLProduto();
                        var produtos = new MLProduto() { Descricao = dgvGeral.Rows[i].Cells["Descricao"].Value.ToString() };
                        var lst = new DLProduto().Listar(produtos);
                        if (lst != null)
                            _objMLPedidoItem.Produto = lst.FirstOrDefault();
                        else
                            _objMLPedidoItem.Produto = produtos;
                        if (_objMLPedidoItem.Produto != null)
                            _objMLPedidoItem.Produto.UnidadeMedida = new MLUnidadeMedida();
                        Decimal qtde = 0;
                        if (this.dgvGeral.Rows[i].Cells[1].Value != null/* && this.dgvGeral.Rows[i].Cells[1].Value.ToString() != " ***  ITEM CANCELADO *** "*/)
                        {
                            _objMLPedidoItem.ProdutoId = (Int32)this.dgvGeral.Rows[i].Cells["ProdutoId"].Value;

                            bool isDecimal = Decimal.TryParse(this.dgvGeral.Rows[i].Cells["Quantidade"].Value.ToString(), out qtde);
                            if (isDecimal)
                                _objMLPedidoItem.Quantidade = Convert.ToDecimal(qtde);


                            _lstMLPedidoItem.Add(_objMLPedidoItem);
                            if (_objMLPedidoItem.Produto != null)
                                _objMLPedido.ValorTotal += _objMLPedidoItem.Produto.ValorVenda * _objMLPedidoItem.Quantidade;

                        }
                    }

                    #endregion

                    _objMLPedidoItem.PedidoId = _objMLPedido.PedidoId;
                    _objMLPedido.listaPedidoItem = _lstMLPedidoItem;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _objMLPedido;
        }

        internal void CarregarPedido(int pedidoId)
        {
            try
            {
                var pedidos = new DLPedido().Listar(new MLPedido() { PedidoId = pedidoId });
                List<MLPedidoItem> objMLPedidoItem = pedidos.First().listaPedidoItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void ControlarFuncoes(enumFuncoes funcao)
        {
            switch (funcao)
            {
                case enumFuncoes.pedidoFechado:
                    {
                        btnNovoPedido.Enabled = true;
                        btnNovoPedido.Enabled = true;
                        btnAlterarQtde.Enabled = false;
                        btnPesquisar.Enabled = false;
                        btnExcluirItem.Enabled = false;
                        btnFinalizarVenda.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnRecuperarPedido.Enabled = false; //implementar
                        btnSair.Enabled = true;
                        btnIncluirCliente.Enabled = false;
                        btnSair.Enabled = true;
                        lblTopVendasBalcao.Text = "CAIXA LIVRE";
                        txtCodigo.Enabled = false;
                        btnNovoPedido.Focus();
                        btnNovoPedido.Select();
                        dgvGeral.Rows.Clear();
                    }
                    break;
                case enumFuncoes.pedidoAberto:
                    {
                        btnNovoPedido.Enabled = false;
                        btnAlterarQtde.Enabled = true;
                        btnPesquisar.Enabled = true;
                        btnExcluirItem.Enabled = true;
                        btnFinalizarVenda.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnRecuperarPedido.Enabled = false;
                        btnSair.Enabled = false;
                        btnIncluirCliente.Enabled = true;
                        lblTopVendasBalcao.Text = "Venda em andamento...";
                        txtCodigo.Enabled = true;
                        txtCodigo.Focus();
                        txtCodigo.Select();
                    }
                    break;
            }
        }

        private void CancelarPedido()
        {
            try
            {
                if (dgvGeral.RowCount < 1)
                {
                    CarregarItensPedido(true);

                    _objMLPedido.StatusPedidoId = 3;
                    new DLPedido().Atualizar(_objMLPedido);
                    this.ControlarFuncoes(enumFuncoes.pedidoFechado);
                }
                else
                {
                    if (MessageBox.Show("Venda em andamento!\n\nDeseja realmente cancelar a venda?", "Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        _objMLPedido.StatusPedidoId = 3;
                        new DLPedido().Atualizar(_objMLPedido);
                        ControlarFuncoes(enumFuncoes.pedidoFechado);
                        lblValorTotal.Text = "0,00";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Forma de Botao Personalizado
        protected override void OnPaint(PaintEventArgs e)
        {
            //GraphicsPath Venda = new GraphicsPath();
            //Venda.AddEllipse(0, 0, lblProduto.Width, lblProduto.Height);
            //lblProduto.Region = new Region(Venda);


        }

        #endregion

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGeral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                PressionarTecla(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmVendaBalcao_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                PressionarTecla(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                PressionarTecla(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                InserirCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InserirCliente()
        {
            if (txtCodigo.Enabled)
            {
                FrmInsercaoClientePedido frmInsercaoClientePedido = new FrmInsercaoClientePedido(this);
                frmInsercaoClientePedido.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("Nenhuma venda em andamento", "Venda", MessageIcon.Warning, MessageButton.OK);
            }
        }
    }
}
