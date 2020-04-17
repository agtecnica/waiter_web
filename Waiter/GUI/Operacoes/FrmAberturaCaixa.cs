using Dados;
using GUI.Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Operacoes
{
    public partial class FrmAberturaCaixa : Form
    {
        #region *** PROPRIEDADES ***
        public FrmPrincipalNovo frmPrincipal { get; set; }

        private MLUsuario usuario;

        private List<MLUsuario> listaUsuario { get; set; }
        private bool CaixaAberto { get; set; }

        #endregion

        #region *** CONSTRUTORES ***

        public FrmAberturaCaixa()
        {
            InitializeComponent();
        }

        #endregion

        #region *** Eventos ***

        private void FrmAberturaCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                this.CarregarCampos();
            }
            catch (Exception)
            {
                ssStatus.Text = "Falha ao carregar a tela! ";
            }
        }

        #region *** BOTÕES ***

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<FrmVendaBalcao>().Count() > 0)
                {
                    MessageBoxEx.Show("Já existe uma tela de venda aberta!", "Atenção", MessageIcon.Information, MessageButton.OK);
                    Application.OpenForms.OfType<FrmVendaBalcao>().First().WindowState = FormWindowState.Maximized;
                }
                else
                {
                    int usuarioid = 0;
                    int.TryParse(txtOperadorMatricula.Text, out usuarioid);
                    if (Sessao.Instance.Usuario.UsuarioId == usuarioid)
                        AbrirFecharCaixa(true, CaixaAberto);
                    else
                    {
                        MessageBoxEx.Show("Usuário deve ser o mesmo usuário logado no sistema!", "Atenção", MessageIcon.Information, MessageButton.OK);
                        txtOperadorMatricula.Focus();
                        txtOperadorMatricula.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                ssStatus.Text = ex.Message;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AbrirFecharCaixa(false, CaixaAberto);
            }
            catch (Exception ex)
            {
                ssStatus.Text = ex.Message;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Sair();
            }
            catch (Exception ex)
            {
                ssStatus.Text = ex.Message;
            }
        }

        #endregion

        #region *** CAMPOS ***

        private void txtOperadorMatricula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.CarregarOperador();
            }
            catch (Exception ex)
            {
                ssStatus.Text = ex.Message;
            }
        }

        private void txtTroco_TextChanged(object sender, EventArgs e)
        {
            //////pega o metodo de moeda
            Moeda(ref txtTroco);

            for (int i = 0; i < dgvPrincipal.Rows.Count; i++)
            {
                if (dgvPrincipal.Rows[i].Cells[0].Value.ToString() == cmbCaixa.Text)
                {
                    var status = dgvPrincipal.Rows[i].Cells[1].Value.ToString();

                    if (status.Equals("Aberto"))//Se Caixa Aberto
                    {
                        if (txtTroco.Text.Length == 0 || txtTroco.Text == "0" || txtTroco.Text == "00" || txtTroco.Text == "000")
                            btnFechar.Enabled = false;
                        else
                            btnFechar.Enabled = true;

                        if (dgvPrincipal.Rows[i].Cells[1].Value.ToString().ToUpper() == "ABERTO" && Convert.ToDouble(txtTroco.Text) == 0)
                        {
                            btnAbrir.Enabled = true;
                            break;
                        }
                        else
                            btnAbrir.Enabled = false;
                    }
                    else
                    {
                        if (txtTroco.Text.Length > 0)
                        {
                            if (txtTroco.Text.Length == 0 || txtTroco.Text == "0" || txtTroco.Text == "00" || txtTroco.Text == "000")
                                btnAbrir.Enabled = false;
                            else
                                btnAbrir.Enabled = true;
                        }
                    }
                }
            }
        }

        private void cmbCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCaixa.SelectedIndex == 0)
                {
                    btnAbrir.Enabled = false;
                    btnFechar.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < dgvPrincipal.Rows.Count; i++)
                    {
                        if (dgvPrincipal.Rows[i].Cells[0].Value.ToString() == cmbCaixa.Text)
                        {
                            var status = Convert.ToString(dgvPrincipal.Rows[i].Cells[1].Value);
                            if (status == "Aberto")//Se Caixa Aberto
                            {
                                CaixaAberto = true;
                                btnAbrir.Enabled = true;

                                bool CaixaEstaAberto = (status == "Aberto");
                                btnFechar.Enabled = CaixaEstaAberto;
                            }
                            else
                            {
                                CaixaAberto = false;
                                btnAbrir.Enabled = true;

                                bool CaixaEstaFechado = (status == "Aberto");
                                btnFechar.Enabled = CaixaEstaFechado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        #endregion

        #endregion

        #region *** Métodos ***

        private void CarregarOperador()
        {
            Int32 matricula;
            listaUsuario = new List<MLUsuario>();

            if (Int32.TryParse(txtOperadorMatricula.Text, out matricula))
            {
                usuario = new MLUsuario()
                {
                    UsuarioId = matricula
                };
                usuario = new DLUsuario().Listar(usuario).FirstOrDefault();
                if (usuario != null && usuario.UsuarioId > 0)
                {
                    lblOperadorNome.Text = usuario.Nome;
                }
                else
                {
                    lblOperadorNome.Text = "Usuário Inexistente";
                }

                ssStatus.Text = "";
            }
            else
            {
                if (!String.IsNullOrEmpty(txtOperadorMatricula.Text))
                    ssStatus.Text = "Informe somente números";
                if (lblOperadorNome.Text == "Usuário Inexistente")
                    lblOperadorNome.Text = "";
            }
        }

        private void AbrirFecharCaixa(bool isAbrirCaixa, bool CaixaAberto)
        {
            MLCaixa objMlCaixa = new MLCaixa();
            try
            {
                if (ValidarCampos(isAbrirCaixa))
                {
                    if (usuario.UsuarioId > 0)
                    {
                        objMlCaixa.Status = isAbrirCaixa;
                        objMlCaixa.CaixaDescricao = cmbCaixa.Text.ToString();

                        if (cmbCaixa.Text != "Selecione") objMlCaixa.CaixaId = Convert.ToInt32(cmbCaixa.SelectedValue);
                        objMlCaixa.Usuario.UsuarioId = usuario.UsuarioId;


                        if (isAbrirCaixa)//Se for Abrir
                        {
                            //Carrega Log do caixa: se é abertura ou acesso a caixa já aberto
                            for (int i = 0; i < dgvPrincipal.Rows.Count; i++)
                            {
                                if (dgvPrincipal.Rows[i].Cells[0].Value.ToString() == cmbCaixa.Text)
                                {
                                    CaixaAberto = (dgvPrincipal.Rows[i].Cells[1].Value.ToString().ToUpper() == "ABERTO");

                                    if (Convert.ToBoolean(CaixaAberto))//Se Caixa Aberto
                                    {
                                        Sessao.Instance.Caixa = objMlCaixa;
                                        objMlCaixa.CaixaStatusLogId = (int)MLCaixa.CaixaStatusLog.Login;
                                    }
                                    else
                                    {
                                        objMlCaixa.CaixaStatusLogId = (int)MLCaixa.CaixaStatusLog.Aberto;
                                        Sessao.Instance.Caixa = objMlCaixa;
                                        objMlCaixa.DataHoraAbertura = DateTime.Now;
                                    }
                                }
                            }
                            if (!CaixaAberto)
                            {
                                objMlCaixa.DataHoraAbertura = DateTime.Now;

                                if (!String.IsNullOrEmpty(txtTroco.Text))
                                    objMlCaixa.SaldoInicial = Convert.ToDouble(txtTroco.Text);
                                else
                                    objMlCaixa.SaldoInicial = 0;

                            }

                            int ControleMovimentoCaixaId = new DLCaixa().AbrirFecharCaixa(objMlCaixa, isAbrirCaixa);

                            if (ControleMovimentoCaixaId > 0)
                                Sessao.Instance.Caixa.ControleMovimentoCaixaId = ControleMovimentoCaixaId;

                            objMlCaixa.Usuario = usuario;
                            objMlCaixa.FuncionarioNome = lblOperadorNome.Text;

                            if (objMlCaixa.CaixaDescricao.Contains("CAIXA"))
                            {
                                //FrmVendaBalcao frmVendaBalcao = new FrmVendaBalcao(objMlCaixa, this);
                                FrmPDV frmVendaBalcao = new FrmPDV(objMlCaixa, this);
                                frmVendaBalcao.ShowDialog();
                                txtOperadorMatricula.Focus();
                            }
                            else if (objMlCaixa.CaixaDescricao.Contains("BALCÃO"))
                            {
                                FrmVendaPadrao frmVendaPadrao = new FrmVendaPadrao();
                                frmVendaPadrao.ShowDialog();
                                txtOperadorMatricula.Focus();
                            }
                        }
                        else //Encerrar caixa
                        {
                            if (objMlCaixa.DataHoraFechamento == null)
                                objMlCaixa.DataHoraFechamento = DateTime.Now;
                            if (!String.IsNullOrEmpty(txtTroco.Text)) objMlCaixa.SaldoFinal = Convert.ToDouble(txtTroco.Text);
                            else objMlCaixa.SaldoInicial = 0;

                            objMlCaixa.CaixaStatusLogId = (int)MLCaixa.CaixaStatusLog.Fechado;
                            Sessao.Instance.Caixa = new MLCaixa();

                            //new DLCaixa().AbrirFecharCaixa(objMlCaixa, isAbrirCaixa);
                            if (Sessao.Instance.Caixa.ControleMovimentoCaixaId == 0)
                            {
                                objMlCaixa.ControleMovimentoCaixaId = new DLCaixa().BuscarMovimentoAtivo(objMlCaixa.CaixaId);
                                Sessao.Instance.Caixa.ControleMovimentoCaixaId = objMlCaixa.ControleMovimentoCaixaId;
                            }
                            FrmEncerramentoCaixa frmEncerramentoCaixa = new FrmEncerramentoCaixa(this, objMlCaixa, isAbrirCaixa, frmPrincipal);
                            //frmEncerramentoCaixa.MdiParent = frmPrincipal;
                            frmEncerramentoCaixa.ShowDialog();
                            txtOperadorMatricula.Focus();
                        }

                        this.CarregarGrid(objMlCaixa.CaixaId);
                        this.MontarGrid();
                        this.LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                ssStatus.Text = "Erro: " + ex.Message;
            }
        }

        private void Sair()
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                ssStatus.Text = "Erro ao sair!";
            }
        }

        private void CarregarCampos()
        {
            List<MLCaixa> lstMlCaixa = new List<MLCaixa>();

            try
            {
                lstMlCaixa = new DLCaixa().ListarCaixa();
                //lstMlCaixa.Insert(0, new MLCaixa() { CaixaDescricao = "Selecione" });

                cmbCaixa.DataSource = lstMlCaixa;
                cmbCaixa.DisplayMember = "CaixaDescricao";
                cmbCaixa.ValueMember = "CaixaId";

                btnAbrir.Enabled = false;
                btnFechar.Enabled = false;

                CarregarGrid();
                MontarGrid();

                if (lstMlCaixa.Count == 1)
                    cmbCaixa.SelectedIndex = 0;
                else if (lstMlCaixa.Count > 1)
                {
                    if (frmPrincipal.tipoVenda == FrmPrincipalNovo.FrenteCaixa)
                        cmbCaixa.SelectedValue = lstMlCaixa.Where(cx => cx.CaixaDescricao.Contains("CAIXA")).First().CaixaId;
                    else
                        cmbCaixa.SelectedValue = lstMlCaixa.Where(cx => cx.CaixaDescricao.Contains("BALCÃO")).First().CaixaId;
                }

                ssStatus.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarCampos(bool isAbrirCaixa)
        {
            try
            {
                #region *** //Matricula  ***
                if (txtOperadorMatricula.Text == "")
                {
                    ssStatus.Text = "Informe a Matrícula!";
                    txtOperadorMatricula.Focus();
                    return false;
                }
                #endregion

                #region *** //Nome Operador  ***
                if (lblOperadorNome.Text == "")
                {
                    ssStatus.Text = "Informe uma Matrícula Válida!";
                    lblOperadorNome.Focus();
                    return false;
                }
                #endregion

                #region *** //Senha  ***
                if (txtSenha.Text == "")
                {
                    ssStatus.Text = "Informe a Senha!";
                    txtSenha.Focus();
                    return false;
                }
                else
                {
                    if (txtSenha.Text != usuario.Senha)
                    {
                        ssStatus.Text = "Senha Inválida!";
                        txtSenha.Focus();
                        txtSenha.SelectAll();
                        return false;
                    }
                }
                #endregion

                #region *** //Caixa  ***
                if (cmbCaixa.Text == "Selecione")
                {
                    ssStatus.Text = "Informe o Caixa!";
                    cmbCaixa.Focus();
                    return false;
                }
                #endregion

                #region *** //Troco  ***

                if (!CaixaAberto || !isAbrirCaixa)
                {
                    if (txtTroco.Text.Equals("") || txtTroco.Text.Equals("0,00"))
                    {

                        bool temCaixaAberto = false;
                        for (int i = 0; i < dgvPrincipal.RowCount; i++)
                        {
                            if (dgvPrincipal.Rows[i].Cells[0].Value.ToString().ToUpper() == cmbCaixa.Text.ToUpper())
                            {
                                if (dgvPrincipal.Rows[i].Cells[1].Value.ToString().ToUpper() == "ABERTO")
                                {
                                    temCaixaAberto = true;
                                    break;
                                }
                            }
                        }

                        if (!temCaixaAberto)
                        {
                            DialogResult dr = MessageBoxEx.Show("Atenção, não foi informado um valor de troco para iniciar o caixa!\n\nDeseja continuar?", "Atenção", MessageIcon.Question, MessageButton.YesNo);
                            if (dr == DialogResult.No)
                            {
                                txtTroco.Focus();
                                txtTroco.SelectAll();
                                return false;
                            }
                        }
                    }
                }
                #endregion
                ssStatus.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CarregarGrid(int caixaId = 0)
        {
            try
            {
                List<MLCaixa> lstMlCaixa = new List<MLCaixa>();
                lstMlCaixa = new DLCaixa().ListarCaixa();
                int index = -1;
                foreach (var caixa in lstMlCaixa)
                {
                    if (caixa.Status.Equals(true))
                        caixa.StatusDescricao = "Aberto";
                    else
                        caixa.StatusDescricao = "Fechado";

                    if (caixa.CaixaId == caixaId)
                    {
                        index = lstMlCaixa.IndexOf(caixa);
                        dgvPrincipal.Rows[index].Selected = true;
                    }
                }

                var newList = lstMlCaixa.Select(c => new
                {
                    CaixaDescricao = c.CaixaDescricao,
                    StatusDescricao = c.StatusDescricao,
                    FuncionarioNome = c.Usuario.Nome
                }).ToList();

                dgvPrincipal.DataSource = newList;

                this.MontarGrid();
                this.LimparCampos();
            }
            catch (Exception)
            {
                ssStatus.Text = "Falha ao listar os Caixas!";
            }
        }

        public void MontarGrid()
        {
            dgvPrincipal.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            ControleGrid objBL_ControleGrid = new ControleGrid(dgvPrincipal);

            //Define quais colunas serão visíveis
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "CaixaDescricao", "StatusDescricao", "FuncionarioNome" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "Caixa", "Status", "Funcionário" });

            //Define quais as larguras respectivas das colunas 
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 30, 25, 45 }, dgvPrincipal.Width);

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "centro", "centro", "centro" });

            //Define a altura das linhas respectivas da Grid 
            objBL_ControleGrid.DefinirAlturaLinha(50);
        }

        private void LimparCampos()
        {
            try
            {
                txtOperadorMatricula.Text = "";
                lblOperadorNome.Text = "";
                txtSenha.Text = "";
                cmbCaixa.SelectedIndex = 0;
                txtTroco.Text = "";
                ssStatus.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void txtOperadorMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtOperadorMatricula.Text) && lblOperadorNome.Text != "Usuário Inexistente")
                {
                    txtSenha.Focus();
                    txtSenha.SelectAll();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cmbCaixa_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtTroco_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (!String.IsNullOrEmpty(txtSenha.Text))
                {
                    cmbCaixa.Focus();
                    cmbCaixa.SelectAll();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            ssStatus.Text = "";
        }

        private void cmbCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTroco.Focus();
                txtTroco.SelectAll();
            }
        }

        private void txtTroco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnAbrir.Enabled)
                {
                    btnAbrir.Focus();
                    btnAbrir.Select();
                }
                else if (btnFechar.Enabled)
                {
                    btnFechar.Focus();
                    btnFechar.Select();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnAbrir_KeyDown(object sender, KeyEventArgs e)
        {

        }
        /// <summary>
        /// </summary>
        /// <param name="texto de numeros"></param>
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(",", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtSenha.Text))
            {
                for (int i = 0; i < dgvPrincipal.RowCount; i++)
                {
                    if (dgvPrincipal.Rows[i].Cells[1].Value.ToString().ToUpper() == "ABERTO" && Convert.ToDouble(txtTroco.Text) == 0)
                    {
                        btnAbrir.Enabled = true;
                        break;
                    }
                    else
                        btnAbrir.Enabled = false;
                }
            }
            ssStatus.Text = "";
        }
    }
}
