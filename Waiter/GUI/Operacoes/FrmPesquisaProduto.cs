
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
    public partial class FrmPesquisaProduto : Form
    {

        #region *** PROPRIEDADES ***

        private FrmVendaBalcao frmVendaBalcao;
        private FrmPDV frmPDV;

        #endregion

        #region *** CONSTRUTORES ***

        public FrmPesquisaProduto()
        {
            InitializeComponent();
        }

        public FrmPesquisaProduto(FrmVendaBalcao frmVendaBalcao)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.frmVendaBalcao = frmVendaBalcao;
            txtPesquisarProduto.Focus();
        }
        public FrmPesquisaProduto(FrmPDV frmPDV)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.frmPDV = frmPDV;
            txtPesquisarProduto.Focus();
        }

        #endregion

        #region *** EVENTOS ***

        #region *** FORMULARIO ***

        private void FrmPesquisarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                this.PesquisarProduto();
                txtPesquisarProduto.Focus();
                dgvPrincipal.CurrentCell = null;
                ssStatus.Text = "";
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        #endregion

        #region *** CAMPOS ***

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PesquisarProduto();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        #endregion

        #region *** BOTÕES ***

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CarregarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar o produto!!\n\nErro: " + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region *** GRID ***

        private void dgvPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    this.CarregarProduto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar o produto!!\n\nErro: " + ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region *** MÉTODOS ***

        private void PesquisarProduto()
        {
            DLProduto objBLProduto = new DLProduto();
            List<MLProduto> lstMlProduto = new List<MLProduto>();

            try
            {
                var produto = new MLProduto();

                lstMlProduto = objBLProduto.Listar(produto);

                if (int.TryParse(txtPesquisarProduto.Text, out int id))
                    produto.ProdutoId = id;
                produto.Descricao = txtPesquisarProduto.Text;

                lstMlProduto = lstMlProduto.Where(p => p.ProdutoId == produto.ProdutoId || p.Descricao.ToUpper().Contains(produto.Descricao.ToUpper())).ToList();

                var newList = lstMlProduto.Select(p => new
                {
                    ProdutoId = p.ProdutoId,
                    Descricao = p.Descricao,
                    ValorVenda = p.ValorVenda,
                    Estoque = p.Estoque.EstoqueReal
                }).ToList();

                dgvPrincipal.DataSource = newList;

                //dgvPrincipal.Columns[5].DefaultCellStyle.Format = "c";
                //dgvPrincipal.Columns[6].DefaultCellStyle.Format = "c";

                this.MontarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CarregarProduto()
        {
            if (dgvPrincipal.CurrentCell == null)
            {
                MessageBox.Show("Pesquise um Produto!", "AMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(frmVendaBalcao != null)
            {
                this.frmVendaBalcao.CarregarCodigoPesquisado(Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value));
                this.frmVendaBalcao.txtCodigo.Select();
                this.frmVendaBalcao.txtCodigo.Focus();
            }else if (frmPDV != null)
            {
                this.frmPDV.CarregarCodigoPesquisado(Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value));
                this.frmPDV.txtCodigo.Select();
                this.frmPDV.txtCodigo.Focus();
            }
            this.Close();
            this.Dispose();
        }

        public void MontarGrid()
        {

            dgvPrincipal.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            ControleGrid objBL_ControleGrid = new ControleGrid(dgvPrincipal);

            ////Define quais colunas serão visíveis
            objBL_ControleGrid.DefinirVisibilidade(new List<string>() { "ProdutoId", "Descricao", "ValorVenda", "Estoque" });

            ////Define quais os cabeçalhos respectivos das colunas 
            objBL_ControleGrid.DefinirCabecalhos(new List<string>() { "Código", "Produto", "Valor", "Estoque" });

            //Define quais as larguras respectivas das colunas 
            //Int32 larg = lblTopVendasBalcao.Width;
            objBL_ControleGrid.DefinirLarguras(new List<int>() { 15, 45, 25, 15 }, dgvPrincipal.Width);

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBL_ControleGrid.DefinirAlinhamento(new List<string>() { "esquerdo", "esquerdo", "esquerdo", "esquerdo" });

            //Define a altura das linhas respectivas da Grid 
            //objBL_ControleGrid.DefinirAlturaLinha(40);

        }

        #endregion

        private void btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPesquisarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                VerificarTecla(e);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void VerificarTecla(KeyEventArgs e)
        {
            try
            {
                #region *** ENTER  ***
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    return;
                }
                #endregion

                #region *** TAB - FOCO NA GRID  ***
                if (e.KeyCode == Keys.Tab)
                {
                    try
                    {
                        this.dgvPrincipal.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                #endregion

                #region *** F11 - PESQUISAR ITEM  ***
                if (e.KeyCode == Keys.F11)
                {
                    try
                    {
                        this.CarregarProduto();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "AMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                #endregion

                #region *** ESC - SAIR  ***
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmPesquisaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                VerificarTecla(e);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }
    }
}
