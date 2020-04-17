using Dados;
using GUI;
using GUI.Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Operacoes
{
    public partial class FrmPDV : Form
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

        public FrmPDV()
        {
            InitializeComponent();
            this.CarregarGridCliente();
            this.HabiltaBtnExcluirItem(false);

            txtCodigo.Focus();
            txtCodigo.Select();
        }
        public FrmPDV(MLCaixa caixa, FrmAberturaCaixa frmAberturaCaixa)
        {
            this._usuario = caixa.Usuario;
            this._caixa = caixa;
            this.frmAberturaCaixa = frmAberturaCaixa;

            InitializeComponent();
            this.CarregarGridCliente();
            this.HabiltaBtnExcluirItem(false);

            txtCodigo.Focus();
            txtCodigo.Select();
            //if (_usuario != null)
            //{
            //    if (!String.IsNullOrEmpty(_usuario.Nome))
            //    {
            //        lblClienteId.Text = _usuario.UsuarioId.ToString();
            //        lblOperadorNome.Text = _usuario.Nome.ToString();
            //        lblNumeroCaixa.Text = caixa.CaixaDescricao.ToString();
            //    }
            //}
        }

        #endregion
        #region Instâncias

        //readonly ProdutosNegocios produtosNegocios = new ProdutosNegocios();
        //readonly UsuariosNegocios usuariosNegocios = new UsuariosNegocios();
        //readonly Cryptografia cryptografia = new Cryptografia();
        //readonly CaixaNegocios caixaNegocios = new CaixaNegocios();


        #endregion

        #region Veriáveis

        bool encerrouVenda = false;
        bool novaVenda = false;
        bool desconto = false;
        int produtosId = 0;
        int clientesId = 0;
        string cliente = string.Empty;
        string cpfCnpj = string.Empty;
        int senhaCorreta = 0;
        string motivoDesconto = string.Empty;

        #endregion

        #region Métodos

        private void CalcularTotalGeral()
        {
            try
            {
                //if (grid.Rows.Count > 0)
                //{
                //    decimal totalGeral = 0;
                //    foreach (DataGridViewRow r in grid.Rows)
                //    {
                //        totalGeral += Convert.ToDecimal(r.Cells["ValorTotal"].Value);
                //    }

                //    txtTotalGeral.Text = totalGeral.ToString("N2");
                //}
                //else
                //    txtTotalGeral.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cálcular o Total Geral!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Limpar()
        {
            //txtCodigo.Clear();
            //txtQuantidade.Text = "1";
            //txtUnitario.Text = "0,00";
            //txtSubtotal.Text = "0,00";
            //txtTotal.Text = "0,00";
            //txtLancarValor.Text = "0,00";

            if (encerrouVenda)
                dgvGeral.Rows.Clear();
            else if (novaVenda)
                dgvGeral.Rows.Clear();

            encerrouVenda = false;
            novaVenda = false;
        }

        #endregion


        private void FrmPDV_Load(object sender, EventArgs e)
        {
            lblOperador.Text = "Operador: " + Sessao.Instance.Usuario.Nome;
            lblTerminal.Text = "Terminal: " + Sessao.Instance.Caixa.CaixaDescricao; //Environment.MachineName.ToUpper();
            lblStatusCaixa.Text = "CAIXA DISPONÍVEL";

            try
            {
                this.btnFinalizarVenda.Enabled = false;

                ItemNr = 0;
                lblProduto.Text = "";

                this.HabiltarCampos(false);
                //btnRecuperarPedido.Enabled = false;

                //RedimensionarGrid();
                CarregarGridCliente();

                ControlarFuncoes(enumFuncoes.pedidoFechado);


                btnNovaVenda.Focus();
                btnNovaVenda.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPDV_KeyDown(object sender, KeyEventArgs e)
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
                else if (e.KeyCode == Keys.F1)
                {
                    #region *** F1 - NOVO PEDIDO***
                    AbrirPedido();
                    #endregion
                }
                else if (e.KeyCode == Keys.F2)
                {
                    #region *** F2 - CANCELAR VENDA ***
                    CancelarPedido();
                    #endregion
                }
                else if (e.KeyCode == Keys.F3)
                {
                    #region *** F3 - EXCLUIR ITEM  ***
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
                else if (e.KeyCode == Keys.F4)
                {
                    #region *** F4 - PESQUISAR ITEM  ***
                    try
                    {
                        btnProdutos_Click(obj, ea);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.F5)
                {
                    InserirCliente();
                }
                else if (e.KeyCode == Keys.F7)
                {
                    #region *** F7 - FINALIZAR VENDA ***
                    if (dgvGeral.Rows.Count > 0)//Verifica se Existe itens na grid
                    {
                        this.FinalizarVenda(obj, ea, e);
                    }
                    else
                    {
                        MessageBox.Show("Não há itens na venda!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.F8)
                {
                    #region *** F8 - ALTERAR QUANTIDADE***
                    AlterarQuantidadeItem();
                    #endregion
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
                    if (btnNovaVenda.Focused)
                    {
                        if (e.KeyCode == Keys.F6)
                        {
                            this.AbrirPedido();
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

            #region COdigo Pablo 
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
            //else if (e.KeyCode == Keys.F1)
            //{
            //    novaVenda = true;
            //    Limpar();
            //    lblDescricaoProduto.Text = "";
            //    txtTotalGeral.Text = "0,00";
            //    lblStatusCaixa.Text = "CAIXA DISPONÍVEL";
            //    txtCodigo.Focus();
            //}
            //else if (e.KeyCode == Keys.F2)
            //{
            //    try
            //    {
            //        if (grid.Rows.Count > 0)
            //        {
            //            FrmPermissao frmPermitirDesconto = new FrmPermissao();
            //            frmPermitirDesconto.ShowInTaskbar = false;
            //            frmPermitirDesconto.ShowDialog();

            //            if (!string.IsNullOrEmpty(frmPermitirDesconto._Senha))
            //            {
            //                senhaCorreta = usuariosNegocios.PesquisarUsuarioSenha(cryptografia.Crypto(frmPermitirDesconto._Senha, true));
            //                if (senhaCorreta.Equals(0))
            //                {
            //                    MessageBox.Show("Senha inválida!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    return;
            //                }
            //                else
            //                {
            //                    motivoDesconto = frmPermitirDesconto._Motivo;

            //                    FrmCancelarItem frmCancelarItem = new FrmCancelarItem();
            //                    frmCancelarItem.ShowInTaskbar = false;
            //                    frmCancelarItem.ShowDialog();

            //                    if (frmCancelarItem._Item > 0)
            //                    {
            //                        bool encontrouItem = false;
            //                        DataGridViewRow row = new DataGridViewRow();
            //                        for (int i = 0; i < grid.Rows.Count; i++)
            //                        {
            //                            row = grid.Rows[i];
            //                            if (row.Cells["numeroItem"].Value.Equals(frmCancelarItem._Item))
            //                            {
            //                                grid.FirstDisplayedScrollingRowIndex = i;
            //                                grid.CurrentCell = row.Cells["numeroItem"];
            //                                row.Selected = true;
            //                                encontrouItem = true;
            //                                break;
            //                            }
            //                        }

            //                        if (encontrouItem)
            //                        {
            //                            grid.Rows.Remove(grid.Rows[grid.CurrentRow.Index]);
            //                            grid.Refresh();

            //                            CalcularTotalGeral();
            //                            Limpar();
            //                        }
            //                        else
            //                        {
            //                            MessageBox.Show("Item não encontrado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                            return;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Senha não informada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                return;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro ao cancelar o item!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else if (e.KeyCode == Keys.F3) //CANCELAR A VENDA
            //{


            //}
            //else if (e.KeyCode == Keys.F4) //CRIAR RELATÓRIO DE ORÇAMENTO
            //{

            //}
            //else if (e.KeyCode == Keys.F5) //PRODUTOS
            //{
            //    FrmPesquisarProdutos frmPesquisarProdutos = new FrmPesquisarProdutos();
            //    frmPesquisarProdutos.ShowInTaskbar = false;
            //    frmPesquisarProdutos.ShowDialog();

            //    if (frmPesquisarProdutos._ProdutosId > 0)
            //    {
            //        txtCodigo.Text = frmPesquisarProdutos._ProdutosId.ToString();
            //        txtCodigo_Leave(sender, e);

            //        //lblDescricaoProduto.Text = frmPesquisarProdutos._Descricao;
            //        //txtCodigo.Text = frmPesquisarProdutos._ProdutosId.ToString();
            //        //txtQuantidade.Text = "1";
            //        //txtUnitario.Text = Convert.ToDecimal(frmPesquisarProdutos._ValorUnitario).ToString("N2");
            //        //txtSubtotal.Text = (Convert.ToDecimal(txtQuantidade.Text) * Convert.ToDecimal(txtUnitario.Text)).ToString("N2");

            //        //txtCodigo.Select();
            //        //txtCodigo.Focus();
            //    }
            //}
            //else if (e.KeyCode == Keys.F6) //CLIENTES
            //{
            //    FrmClientesCadastrados frmClientesCadastrados = new FrmClientesCadastrados();
            //    frmClientesCadastrados.ShowInTaskbar = false;
            //    frmClientesCadastrados._PDV = true;
            //    frmClientesCadastrados.ShowDialog();

            //    if (frmClientesCadastrados._ClientesId > 0)
            //    {
            //        clientesId = frmClientesCadastrados._ClientesId;
            //        cliente = frmClientesCadastrados._Cliente;
            //        cpfCnpj = frmClientesCadastrados._CpfCnpj;
            //    }
            //}
            //else if (e.KeyCode == Keys.F7) //FINALIZAR VENDA
            //{
            //    try
            //    {
            //        if (grid.Rows.Count > 0)
            //        {
            //            // Verifica se o caixa está aberto!
            //            int UltimoCaixaAberto = caixaNegocios.VerificarSeCaixaEstaAberto();
            //            if (UltimoCaixaAberto == 0)
            //            {
            //                MessageBox.Show("Por favor, efetue a abertura do caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                return;
            //            }
            //            else //Se o caixa já estiver aberto, verifica se é o mesmo operador que está fazendo a venda!
            //            {
            //                int UsuarioAbriuCaixa = caixaNegocios.VerificarUsuarioAbriuCaixa(UltimoCaixaAberto);
            //                if (FrmLogin.usuarioId != UsuarioAbriuCaixa)
            //                {
            //                    MessageBox.Show("Não é possivel realizar a venda, pois o operador logado não é o mesmo que abriu o caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                    return;
            //                }
            //            }









            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (e.Control && e.KeyCode == Keys.Q)
            //{
            //    txtQuantidade.ReadOnly = false;
            //    txtQuantidade.SelectAll();
            //    txtQuantidade.Focus();
            //}
            #endregion
        }

        #region Eventos - KeyDowns e Leave / Código ou Código de Barras

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

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = txtCodigo.Text.Replace("'", "");
                if (txtCodigo.Text.Trim().Length > 0 && txtCodigo.Focused)
                {
                    lblStatusCaixa.Text = "CAIXA OCUPADO";

                    DataTable dtProduto = new DataTable();
                    //dtProduto = produtosNegocios.PesquisarPorCodigoOuCodigoBarras(txtCodigo.Text.ToUpper());

                    if (dtProduto.Rows.Count > 0)
                    {
                        produtosId = Convert.ToInt32(dtProduto.Rows[0]["ProdutosId"]);

                        if (dtProduto.Rows[0]["Ativo"].ToString().Equals("False"))
                        {
                            MessageBox.Show("Produto inativo, verifique o cadastro!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();
                            txtCodigo.Clear();
                            txtCodigo.Focus();
                            return;
                        }

                        //grid.Rows.Add(grid.Rows.Count + 1, !string.IsNullOrEmpty(dtProduto.Rows[0]["CodigoBarras"].ToString()) ? dtProduto.Rows[0]["CodigoBarras"].ToString() : produtosId.ToString(), dtProduto.Rows[0]["Descricao"].ToString(), txtQuantidade.Text,
                        //              Convert.ToDecimal(dtProduto.Rows[0]["ValorUnitario"]).ToString("N2"),
                        //              (Convert.ToInt32(txtQuantidade.Text)) * Convert.ToDecimal(dtProduto.Rows[0]["ValorUnitario"])).ToString("N2");

                        //grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count - 1;
                        //grid.Refresh();
                        //grid.ClearSelection();
                        //grid.Rows[grid.Rows.Count - 1].Selected = true;

                        //CalcularTotalGeral();

                        //grid.Refresh();
                        //Limpar();
                        //txtCodigo.Select();
                        //txtCodigo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar o produto!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos - Enter e Leave / Quantidade


        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            //    if (txtQuantidade.Text.Length > 0)
            //    {
            //        txtQuantidade.SelectAll();
            //        txtQuantidade.Focus();
            //    }
            //    else
            //        txtQuantidade.Focus();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            try
            {
                ////CalcularTotal();
                //txtQuantidade.ReadOnly = true;
                //txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cálcular o total do produto!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGeral.Rows.Count > 0)
            {
                //lblProduto.Text = dgvGeral.Rows[dgvGeral.CurrentRow.Index].Cells["Descricao"].Value.ToString().ToUpper();
                //txtCodigo.Text = dgvGeral.Rows[dgvGeral.CurrentRow.Index].Cells["ProdutosId_"].Value.ToString();
                //txtQuantidade.Text = grid.Rows[grid.CurrentRow.Index].Cells["Quantidade"].Value.ToString();
                //txtUnitario.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorUnitario"].Value.ToString();
                //txtSubtotal.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorTotal"].Value.ToString();
                //txtTotal.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorTotal"].Value.ToString();
            }
        }

        #region *** Eventos ***

        #region *** FORMULÁRIO ***

        private void FrmVendaBalcao_Load(object sender, EventArgs e)
        {
            #region Dados Empresa CUPOM

            //labNomeEmpresa.Text = "Empresa: " + Sessao.Instance.Empresa.NomeFantasia;
            //labEnderecoEmpresa.Text = "Endereço: " + Sessao.Instance.Empresa.Logradouro + " " + Sessao.Instance.Empresa.Bairro + " " + "Cep: " + Sessao.Instance.Empresa.Cep + " " + "N°: " + Sessao.Instance.Empresa.Numero;
            //labIEempresa.Text = "IE: " + Sessao.Instance.Empresa.IE;
            //labIMempresa.Text = "IM: " + Sessao.Instance.Empresa.IM;
            //labCNPJempresa.Text = Sessao.Instance.Empresa.CNPJ;
            //labCNPJempresa.ForeColor = Color.White;

            #endregion
            try
            {
                this.btnFinalizarVenda.Enabled = false;

                ItemNr = 0;
                lblProduto.Text = "";

                this.HabiltarCampos(false);
                //btnRecuperarPedido.Enabled = false;

                RedimensionarGrid();
                CarregarGridCliente();

                ControlarFuncoes(enumFuncoes.pedidoFechado);


                btnNovaVenda.Focus();
                btnNovaVenda.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedimensionarGrid()
        {
            //    panel3.Size = new System.Drawing.Size((Width / 10) * 4, panel3.Height);
            //    panel3.Location = new System.Drawing.Point((Width / 1000) * 935, lblProduto.Location.Y + lblProduto.Height + 10);

            //    dgvGeral.Size = new System.Drawing.Size((Width / 10) * 4, dgvGeral.Height);
            //    dgvGeral.Location = new System.Drawing.Point((Width / 1000) * 935, panel3.Location.Y + panel3.Height + 5);
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
                            //PressionarTecla(e);
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
                this.AbrirPedido();
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

        private void btnProdutos_Click(object sender, EventArgs e)
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
                FinalizarVenda(obj, ea, null);
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

                if (true)
                {

                }

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
                                    dgvGeral.Rows[i].Cells[1].Value = "0000";
                                    dgvGeral.Rows[i].Cells[2].Value = " ***  ITEM CANCELADO *** ";
                                    dgvGeral.Rows[i].Cells[3].Value = string.Format("{0:0.000}", 0);
                                    dgvGeral.Rows[i].Cells[4].Value = string.Format("{0:0.00}", 10);
                                    dgvGeral.Rows[i].Cells[5].Value = string.Format("{0:0.00}", 0);
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
                Close();
                Dispose();
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

        private void FinalizarVenda(object obj, EventArgs ea, KeyEventArgs e)
        {
            try
            {
                if (dgvGeral.Rows.Count > 0)
                {
                    if (e != null)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    FrmFinalizaVenda objFrmFinalizaVenda = new FrmFinalizaVenda(this);
                    objFrmFinalizaVenda.ShowDialog();

                    _objMLPedido = new DLPedido().Consultar(_objMLPedido);


                    if (_objMLPedido.StatusPedidoId == (int)MLStatusPedido.StatusPedido.FINALIZADO)//pedido finalizado
                        ControlarFuncoes(enumFuncoes.pedidoFechado);
                    else
                        txtCodigo.Focus();
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
            {
                txtCodigo.Text = "";
                txtQtde.Text = "1,000";
            }
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
                        valor += Convert.ToDouble(dgvGeral.Rows[i].Cells[4].Value) * Convert.ToDouble(dgvGeral.Rows[i].Cells[3].Value);
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
                        this.btnProdutos_Click(obj, ea);
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
                        this.FinalizarVenda(obj, ea, e);
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
                    if (btnNovaVenda.Focused)
                    {
                        if (e.KeyCode == Keys.F6)
                        {
                            this.AbrirPedido();
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
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "numeroItem", "ProdutosId_", "Descricao", "Quantidade", "ValorUnitario", "ValorTotal" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "NºItem", "Código", "Descrição", "Qtde", "Valor", "Total" });

            //Define quais as larguras respectivas das colunas 
            //Int32 larg = lblStatusCaixa.Width;
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 10, 15, 35, 10, 15, 15 }, dgvGeral.Width);

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
                //"item", "ProdutoId","Descricao", "Quantidade", "ValorUnit", "ValorTotal"
                dgvGeral.Rows.Add(
                    Formatacao.ZerosEsquerda(ItemNr.ToString(), 3),
                    objMLProdutos.ProdutoId,
                    objMLProdutos.Descricao,
                    txtQtde.Text,
                    //(objMLProdutos.UnidadeMedida == null) ? "" : objMLProdutos.UnidadeMedida.Descricao,
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

        private void AbrirPedido()
        {
            GerarNovoPedido();
            HabiltarCampos(true);
            Sessao.Instance.Cliente.ClienteId = 1;
            Sessao.Instance.Cliente.CPF = null;
            Sessao.Instance.Cliente.CNPJ = null;
            txtCodigo.Focus();
            txtCodigo.SelectAll();
            txtQtde.Text = String.Format("{0:0.000}", 1);
            btnNovaVenda.Enabled = false;
            ControlarFuncoes(enumFuncoes.pedidoAberto);

            lblCliente.Text = "Cliente: Consumidor Final";
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

            btnNovaVenda.Enabled = !habiltaCampos;
            //btnRecuperarPedido.Enabled = !habiltaCampos;

            //btnAlterarQtde.Enabled = habiltaCampos;
            btnProdutos.Enabled = habiltaCampos;
            btnExcluirItem.Enabled = habiltaCampos;
            btnFinalizarVenda.Enabled = habiltaCampos;
            btnCancelarVenda.Enabled = habiltaCampos;
            ////btnSair.Enabled = !habiltaCampos;

            if (habiltaCampos)
            {
                txtCodigo.Focus();
                txtCodigo.SelectAll();
            }
            else
            {
                btnNovaVenda.Focus();
                btnNovaVenda.Select();
            }
            ItemNr = 1;
        }

        public MLPedido CarregarItensPedido(bool isUpdate, bool ChamarBD = false)
        {
            try
            {

                if (dgvGeral.RowCount > 0)
                {
                    #region *** Carrega Itens do Pedido  ***

                    _lstMLPedidoItem = new List<MLPedidoItem>();
                    if (_objMLPedido == null) _objMLPedido = new MLPedido();
                    _objMLPedido.ValorTotal = 0;

                    for (int i = 0; i < this.dgvGeral.RowCount; i++) //Carrega Itens o Pedido
                    {
                        //if (dgvGeral.Rows[i].Cells["Descricao"].Value.ToString() == " ***  ITEM CANCELADO *** ")
                        //    continue;

                        _objMLPedidoItem = new MLPedidoItem();
                        _objMLPedidoItem.Pedido = _objMLPedido;
                        _objMLPedidoItem.Produto = new MLProduto();
                        var produtos = new MLProduto() { ProdutoId = Convert.ToInt32(dgvGeral.Rows[i].Cells["ProdutosId_"].Value) };
                        var lst = new DLProduto().Listar(produtos);
                        if (lst != null)
                            _objMLPedidoItem.Produto = lst.FirstOrDefault();
                        else
                            _objMLPedidoItem.Produto = produtos;
                        if (_objMLPedidoItem.Produto != null)
                            _objMLPedidoItem.Produto.UnidadeMedida = new MLUnidadeMedida();
                        Decimal qtde = 0;
                        if (this.dgvGeral.Rows[i].Cells[1].Value.ToString() != "0000" && this.dgvGeral.Rows[i].Cells[2].Value.ToString() != " ***  ITEM CANCELADO *** ")
                        {
                            _objMLPedidoItem.ProdutoId = (Int32)this.dgvGeral.Rows[i].Cells["ProdutosId_"].Value;

                            bool isDecimal = Decimal.TryParse(this.dgvGeral.Rows[i].Cells["Quantidade"].Value.ToString(), out qtde);
                            if (isDecimal)
                            {
                                _objMLPedidoItem.Quantidade = Convert.ToDecimal(qtde);
                                _objMLPedidoItem.SubTotal = Convert.ToDecimal(qtde) * Convert.ToDecimal(dgvGeral.Rows[i].Cells["ValorUnitario"].Value);
                            }


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
                        btnNovaVenda.Enabled = true;
                        btnNovaVenda.Enabled = true;
                        //btnAlterarQtde.Enabled = false;
                        btnProdutos.Enabled = false;
                        btnExcluirItem.Enabled = false;
                        btnFinalizarVenda.Enabled = false;
                        btnCancelarVenda.Enabled = false;
                        //btnRecuperarPedido.Enabled = false; //implementar
                        ////btnSair.Enabled = true;
                        btnClientes.Enabled = false;
                        //btnSair.Enabled = true;
                        lblStatusCaixa.Text = "CAIXA LIVRE";
                        lblCliente.Text = "";
                        txtCodigo.Clear();
                        lblProduto.Text = "";
                        txtCodigo.Enabled = false;
                        btnNovaVenda.Focus();
                        btnNovaVenda.Select();
                        dgvGeral.Rows.Clear();
                    }
                    break;
                case enumFuncoes.pedidoAberto:
                    {
                        btnNovaVenda.Enabled = false;
                        //btnAlterarQtde.Enabled = true;
                        btnProdutos.Enabled = true;
                        btnExcluirItem.Enabled = true;
                        btnFinalizarVenda.Enabled = true;
                        btnCancelarVenda.Enabled = true;
                        //btnRecuperarPedido.Enabled = false;
                        //btnSair.Enabled = false;
                        btnClientes.Enabled = true;
                        lblStatusCaixa.Text = "Venda em andamento...";
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

        private void btnClientes_Click(object sender, EventArgs e)
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
                lblCliente.Text = "Cliente: " + Sessao.Instance.Cliente.NomeRazaoSocial + ((Sessao.Instance.Cliente.CPF != null) ? " - " + Formatacao.FormatarCpfCnpj(Sessao.Instance.Cliente.CPF) : "");
            }
            else
            {
                MessageBoxEx.Show("Nenhuma venda em andamento", "Venda", MessageIcon.Warning, MessageButton.OK);
            }
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                #region *** F1 - NOVO PEDIDO***
                AbrirPedido();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelValores_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            #region *** F2 - CANCELAR VENDA ***
            CancelarPedido();
            #endregion
        }

        private void btnExcluirItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
