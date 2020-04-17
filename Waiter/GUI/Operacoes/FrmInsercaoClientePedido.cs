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
    public partial class FrmInsercaoClientePedido : Form
    {
        #region *** PROPRIEDADES ***
        private FrmVendaBalcao frmVendaBalcao;
        private MLCliente cliente;
        private int id;
        private decimal idcnpj;
        private FrmPDV frmPDV;

        #endregion

        #region *** CONSTRUTORES ***

        public FrmInsercaoClientePedido(FrmVendaBalcao frmVendaBalcao)
        {
            InitializeComponent();
            this.frmVendaBalcao = frmVendaBalcao;
        }

        public FrmInsercaoClientePedido(FrmPDV frmPDV)
        {
            InitializeComponent();
            this.frmPDV = frmPDV;
        }

        #endregion

        #region *** Eventos ***

        private void FrmInsercaoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                txtCliente.Text = "Consumidor Final";
                lblInformacao.Text = "Nenhum CPF ou CNPJ válido informado";
            }
            catch (Exception)
            {
                lblInformacao.Text = "Falha ao carregar a tela! ";
            }
        }

        #region *** BOTÕES ***

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                Sair();
            }
            catch (Exception ex)
            {
                lblInformacao.Text = ex.Message;
            }
        }

        #endregion

        #endregion

        #region *** Métodos ***
        private void Sair()
        {
            Close();
            Dispose();
        }

        public void CarregarGrid(int caixaId = 0)
        {
            try
            {

            }
            catch (Exception)
            {
                lblInformacao.Text = "Falha ao listar os Caixas!";
            }
        }

        public void MontarGrid()
        {
            //    dgvPrincipal.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            //    ControleGrid objBL_ControleGrid = new ControleGrid(dgvPrincipal);

            //    //Define quais colunas serão visíveis
            //    objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "ClienteId", "NomeRazaoSocial", "Cnpj" });

            //    //Define quais os cabeçalhos respectivos das colunas 
            //    objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "CÓDIGO", "NOME / RAZ. SOCIAL", "CNPJ" });

            //    //Define quais as larguras respectivas das colunas 
            //    objBL_ControleGrid.DefinirLarguras(new List<int>() { 15, 50, 35 }, dgvPrincipal.Width);

            //    //Define quais os alinhamentos respectivos do componentes das colunas 
            //    objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "centro", "centro", "centro" });

            //    //Define a altura das linhas respectivas da Grid 
            //    objBL_ControleGrid.DefinirAlturaLinha(50);
        }

        private void LimparCampos()
        {
            try
            {
                txtIdCnpj.Text = "";
                txtCliente.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void txtIdCnpj_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIdCnpj.Text.Length > 10)
                {
                    string IdCnpj = "";

                    cliente = new MLCliente();
                    id = 0;

                    if (decimal.TryParse(txtIdCnpj.Text, out decimal idcnpj))
                    {
                        if (txtIdCnpj.Text.Length == 11)
                        {
                            if (Utils.IsCpf(idcnpj.ToString()))
                                cliente.CPF = idcnpj.ToString();
                            else
                            {
                                lblInformacao.Text = "CPF INVÁLIDO!";
                                return;
                            }

                        }
                        else if (txtIdCnpj.Text.Length == 14)
                        {
                            if (Utils.IsCnpj(idcnpj.ToString()))
                                cliente.CNPJ = idcnpj.ToString();
                            else
                            {
                                lblInformacao.Text = "CNPJ INVÁLIDO!";
                                return;
                            }
                        }
                        else
                        {
                            lblInformacao.Text = "Nenhum CPF ou CNPJ válido informado";
                            txtCliente.ForeColor = Color.Red;
                            return;
                        }

                        cliente.Ativo = true;
                    }
                    else
                    {
                        lblInformacao.Text = "Informe somente números!";
                        txtCliente.Text = "Consumidor Final";
                        txtIdCnpj.Clear();
                        txtIdCnpj.Focus();
                        return;
                    }
                    cliente = new DLCliente().Listar(cliente).Where(c => c.CPF == idcnpj.ToString() || c.CNPJ == idcnpj.ToString()).FirstOrDefault();
                    if (cliente != null)
                    {
                        txtCliente.Text = cliente.NomeRazaoSocial;
                        txtCliente.ForeColor = Color.Blue;

                        Sessao.Instance.Cliente.ClienteId = cliente.ClienteId;
                        Sessao.Instance.Cliente.NomeRazaoSocial = cliente.NomeRazaoSocial;

                    }
                    else
                    {
                        txtCliente.Text = "Consumidor Final";
                        if (Utils.IsCnpj(idcnpj.ToString()) || Utils.IsCpf(idcnpj.ToString()))
                            txtCliente.ForeColor = Color.Blue;
                        else
                            txtCliente.ForeColor = Color.Red;

                        Sessao.Instance.Cliente.ClienteId = 1;
                        Sessao.Instance.Cliente.NomeRazaoSocial = "Consumidor Final";
                    }

                    if (idcnpj.ToString().Length == 11)
                    {
                        lblInformacao.Text = "CPF Válido - Pressione a tecla ENTER para incluir";
                        Sessao.Instance.Cliente.CPF = idcnpj.ToString();
                    }
                    else if (idcnpj.ToString().Length == 14)
                    {
                        lblInformacao.Text = "CNPJ Válido - Pressione a tecla ENTER para incluir";
                        Sessao.Instance.Cliente.CNPJ = idcnpj.ToString();
                    }
                }
                else
                {
                    txtCliente.Text = "Consumidor Final";
                    lblInformacao.Text = "Nenhum CPF ou CNPJ válido informado";
                    txtCliente.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void txtIdCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (Utils.IsCnpj(txtIdCnpj.Text.ToString()) || Utils.IsCpf(txtIdCnpj.Text.ToString()))
                {
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBoxEx.Show("Nenhum CPF ou CNPJ válido informado!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                Dispose();
            }
        }
    }
}
