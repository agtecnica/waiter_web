using Dados;
using GUI.Base;
using GUI.Ferramentas;
using GUI.Relatorios;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Operacoes
{
    public partial class FrmOrdemServico : Form
    {
        private bool isFiltro;
        MLOrdemServico OrdemServico;
        List<MLCliente> listaCliente;
        List<MLServico> listaServico;
        List<MLProduto> listaProduto;
        List<MLFormaPgto> listaMLFormaPgto;

        public FrmOrdemServico()
        {
            InitializeComponent();
        }

        private void FrmOrdemServico_Load(object sender, EventArgs e)
        {
            try
            {
                listaServico = new List<MLServico>();
                listaProduto = new List<MLProduto>();
                CarregarCombos();
                HabilitarCampos(false, Utils.Operacao.Cancelar);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void HabilitarCampos(bool habilita, Utils.Operacao operacao)
        {
            cmbCliente.Enabled = habilita;
            txtCodigo2.Enabled = habilita;
            txtDescricao.Enabled = habilita;
            //dtpDataAbertura2.Enabled = habilita;
            dtpDataExecucao2.Enabled = habilita;
            cmbStatus2.Enabled = habilita;
            cmbFormaPgto2.Enabled = habilita;
            txtNrParcelas2.Enabled = habilita;
            txtObservacao2.Enabled = habilita;
            cmbServico2.Enabled = habilita;
            cmbProduto2.Enabled = habilita;
            txtQtdeProduto.Enabled = habilita;
            //txtTotal2.Enabled = habilita;

            btnAddServico.Enabled = habilita;
            btnAddProduto.Enabled = habilita;

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            btnLocalizar.Enabled = false;

            switch (operacao)
            {
                case Utils.Operacao.Inserir:
                    {
                        btnSalvar.Enabled = true;
                        btnCancelar.Enabled = true;
                        cmbStatus2.SelectedIndex = (int)MLOrdemServico.StatusOS.ABERTO;
                        btnSalvar.Text = "Salvar";
                        this.btnSalvar.Image = global::GUI.Properties.Resources.confirm;
                    }
                    break;
                case Utils.Operacao.Alterar:
                    {
                        dtpDataExecucao2.Value = DateTime.Now;
                        dtpDataExecucao2.Enabled = true;
                        btnSalvar.Text = "Salvar";
                        btnSalvar.Enabled = true;
                        btnCancelar.Enabled = true;
                        this.btnSalvar.Image = global::GUI.Properties.Resources.confirm;
                    }
                    break;
                case Utils.Operacao.Excluir:
                    {
                        btnCancelar.Enabled = true;
                        btnLocalizar.Enabled = true;
                        LimparCampos();
                    }
                    break;
                case Utils.Operacao.Salvar:
                    {
                        btnSalvar.Text = "Novo";
                        this.btnSalvar.Image = global::GUI.Properties.Resources.icon_plus;
                        LimparCampos();
                    }
                    break;
                case Utils.Operacao.Cancelar:
                    {
                        btnSalvar.Text = "Novo";
                        btnSalvar.Enabled = true;
                        btnLocalizar.Enabled = true;
                        this.btnSalvar.Image = global::GUI.Properties.Resources.icon_plus;
                        LimparCampos();
                    }
                    break;
                case Utils.Operacao.Localizar:
                    {

                        cmbCliente.Enabled = true;
                        txtCodigo2.Enabled = true;
                        dtpDataAbertura2.Enabled = true;
                        cmbStatus2.Enabled = true;

                        btnSalvar.Enabled = true;
                        btnCancelar.Enabled = true;
                        MessageBoxEx.Show("Utilize os campos ativos para realizar a busca!", "Pesquisa", MessageIcon.Information, MessageButton.OK);

                    }
                    break;
                case Utils.Operacao.Carregar:
                    {
                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                    break;
            }
        }

        private void LimparCampos()
        {
            cmbCliente.SelectedIndex = 0;
            txtDescricao.Clear();
            txtCodigo2.Clear();
            dtpDataAbertura2.Value = DateTime.Now;
            dtpDataExecucao2.Value = DateTime.Now;
            cmbStatus2.SelectedIndex = 0;
            cmbFormaPgto2.SelectedIndex = 0;
            txtNrParcelas2.Value = 0;
            txtObservacao2.Clear();
            txtTotal2.Text = 0.ToString("F");

            dgvServicos.DataSource = null;
            dgvServicos.Refresh();

            dgvProdutos.DataSource = null;
            dgvProdutos.Refresh();

            LimparCamposItensOS();
        }

        private void LimparCamposItensOS()
        {
            txtQtdeProduto.Value = 0;
            cmbServico2.SelectedIndex = 0;
            cmbProduto2.SelectedIndex = 0;
        }

        private void CarregarCombos()
        {
            try
            {
                CarregarComboCliente();
                CarregarComboStatus();
                CarregarComboFormaPagto();
                CarregarComboServico();
                CarregarComboProduto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarComboFormaPagto()
        {
            cmbFormaPgto2.DisplayMember = "Descricao";
            cmbFormaPgto2.ValueMember = "FormaPgtoId";

            listaMLFormaPgto = new DLFormaPgto().Listar(new MLFormaPgto());
            listaMLFormaPgto.Insert(0, new MLFormaPgto() { Descricao = "SELECIONE" });

            cmbFormaPgto2.DataSource = listaMLFormaPgto;
        }

        private void CarregarComboCliente()
        {
            try
            {
                cmbCliente.DisplayMember = "NomeRazaoSocial";
                cmbCliente.ValueMember = "ClienteId";

                listaCliente = new DLCliente().Listar(new MLCliente() { Ativo = true });
                listaCliente.Insert(0, new MLCliente() { NomeRazaoSocial = "SELECIONE" });

                cmbCliente.DataSource = listaCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarComboStatus()
        {
            try
            {
                var listaStatusOS = Enum.GetNames(typeof(MLOrdemServico.StatusOS)).ToList();
                listaStatusOS.Insert(0, "SELECIONE");
                cmbStatus2.DataSource = listaStatusOS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarComboServico()
        {
            try
            {
                cmbServico2.DisplayMember = "Descricao";
                cmbServico2.ValueMember = "ServicoId";

                listaServico = new DLServico().Listar(new MLServico() { Ativo = true });
                listaServico.Insert(0, new MLServico() { Descricao = "SELECIONE" });

                cmbServico2.DataSource = listaServico;
                listaServico = new List<MLServico>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarComboProduto()
        {
            try
            {
                cmbProduto2.DisplayMember = "Descricao";
                cmbProduto2.ValueMember = "ProdutoId";

                listaProduto = new DLProduto().Listar(new MLProduto());
                listaProduto.Insert(0, new MLProduto() { Descricao = "SELECIONE" });

                cmbProduto2.DataSource = listaProduto;
                listaProduto = new List<MLProduto>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Salvar();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void Salvar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo2.Text) && string.IsNullOrEmpty(txtDescricao.Text) && !txtDescricao.Enabled)//
                {
                    HabilitarCampos(true, Utils.Operacao.Inserir);
                }
                else
                {
                    //if (ValidarCampos())
                    //{
                    //    LerCampos();
                    //    if (OrdemServico.OrdemServicoId > 0)
                    //    {
                    //        new DLOrdemServico().Atualizar(OrdemServico);
                    //        MessageBoxEx.Show("Ordem de Serviço tualizada com sucesso!", "Atenção", MessageIcon.Information, MessageButton.OK);
                    //    }
                    //    else
                    //    {
                    //        new DLOrdemServico().Adicionar(OrdemServico);
                    //        MessageBoxEx.Show("Ordem de Serviço salva com sucesso!", "Atenção", MessageIcon.Information, MessageButton.OK);
                    //    }
                    DialogResult result = MessageBoxEx.Show("Deseja imprimir a Ordem de Serviço?", "Pergunta", MessageIcon.Question, MessageButton.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        //FrmImpressaoOrdemServico frmImpressaoOrdemServico = new FrmImpressaoOrdemServico(1);
                        //frmImpressaoOrdemServico.ShowDialog();
                        FrmImpressaoOS frmImpressaoOS = new FrmImpressaoOS();
                        frmImpressaoOS.ShowDialog();
                    }
                    //}
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LerCampos()
        {
            try
            {
                OrdemServico = new MLOrdemServico();
                OrdemServico.ClienteId = cmbCliente.SelectedIndex;
                OrdemServico.Descricao = txtDescricao.Text;
                OrdemServico.DataAbertura = dtpDataAbertura2.Value;
                OrdemServico.StatusId = Convert.ToInt32(cmbStatus2.SelectedValue);
                OrdemServico.FormaPgto = new MLFormaPgto();
                OrdemServico.FormaPgto.FormaPgtoId = Convert.ToInt32(cmbFormaPgto2.SelectedValue);
                OrdemServico.NrParcelas = Convert.ToInt32(txtNrParcelas2.Value);

                OrdemServico.ListaProdutos = new List<MLOrdemServico_Produto>();
                for (int i = 0; i < dgvProdutos.RowCount; i++)
                {
                    MLOrdemServico_Produto mLProduto = new MLOrdemServico_Produto();
                    mLProduto.ProdutoId = Convert.ToInt32(dgvProdutos.Rows[i].Cells[0].Value);
                    mLProduto.Quantidade = Convert.ToDecimal(dgvProdutos.Rows[i].Cells[2].Value);
                    mLProduto.SubTotal = Convert.ToDecimal(dgvProdutos.Rows[i].Cells[3].Value);
                    OrdemServico.ListaProdutos.Add(mLProduto);
                }

                OrdemServico.ListaServicos = new List<MLOrdemServico_Servico>();
                for (int i = 0; i < dgvServicos.RowCount; i++)
                {
                    MLOrdemServico_Servico mLServico = new MLOrdemServico_Servico();
                    mLServico.ServicoId = Convert.ToInt32(dgvServicos.Rows[i].Cells[0].Value);
                    OrdemServico.ListaServicos.Add(mLServico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (cmbCliente.SelectedIndex < 1)
                {
                    MessageBoxEx.Show("Informe o Cliente!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    cmbCliente.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtDescricao.Text))
                {
                    MessageBoxEx.Show("Informe a Descrição da Ordem de Serviço!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    txtDescricao.Focus();
                    return false;
                }

                if (cmbFormaPgto2.SelectedIndex < 1)
                {
                    MessageBoxEx.Show("Informe a Forma de Pagamento!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    cmbFormaPgto2.Focus();
                    return false;
                }

                if (txtNrParcelas2.Value < 1)
                {
                    MessageBoxEx.Show("Informe o número de parcelas!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    txtNrParcelas2.Focus();
                    return false;
                }

                if (dgvServicos.RowCount < 1)
                {
                    MessageBoxEx.Show("Informe no mínimo um Serviço!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    cmbServico2.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancelar();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void Cancelar()
        {
            HabilitarCampos(false, Utils.Operacao.Cancelar);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Alterar();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void Alterar()
        {
            HabilitarCampos(false, Utils.Operacao.Alterar);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Opereção Inválida!");
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Localizar();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void Localizar()
        {
            try
            {
                FrmConsultaOrdemServico frmConsultaOrdemServico = new FrmConsultaOrdemServico(this);
                frmConsultaOrdemServico.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAddStatus_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAddFormaPgto_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAdicionarServico_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServico2.SelectedIndex > 0)
                {
                    AdicionarServico();
                }
                else
                {
                    MessageBoxEx.Show("Nenhum serviço selecionado!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    cmbServico2.Focus();
                }
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void AdicionarServico()
        {
            try
            {
                var servicoid = Convert.ToInt32(cmbServico2.SelectedValue);
                var servico = new DLServico().Consultar(new MLServico() { ServicoId = servicoid });
                dgvServicos.DataSource = null;
                listaServico.Add(servico);
                dgvServicos.DataSource = listaServico;
                dgvServicos.Refresh();
                txtTotalServicos.Text = listaServico.Sum(c => c.Valor).ToString("F");
                Calcular();

                MontarGridServico();
                tbcGrids.SelectedTab = tbpgServicos;

                LimparCamposItensOS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Calcular()
        {
            try
            {
                var totalServicos = Convert.ToDouble(txtTotalServicos.Text);
                var totalProdutos = Convert.ToDouble(txtTotalProdutos.Text);
                txtTotal2.Text = (totalProdutos + totalServicos).ToString("F");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MontarGridServico()
        {
            dgvServicos.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);

            var objBlControleGrid = new ControleGrid(dgvServicos);
            //Define quais colunas serão visíveis
            objBlControleGrid.DefinirVisibilidade(new List<string>() { "ServicoId", "Descricao", "Valor" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBlControleGrid.DefinirCabecalhos(new List<string>() { "Código", "Descrição", "Valor R$" });

            //Define quais as larguras respectivas das colunas 
            objBlControleGrid.DefinirLarguras(new List<int>() { 20, 60, 25 }, dgvServicos.Width - 3); //5 + 15 + 25 + 10 + 15 + 15 + 15 = 100

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda" });

            //Define a altura das linhas respectivas da Grid 
            objBlControleGrid.DefinirAlturaLinha(30);
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduto2.SelectedIndex > 0)
                {
                    if (txtQtdeProduto.Value > 0)
                        AdicionarProduto();
                    else
                        MessageBoxEx.Show("Informe a quantidade do produto selecionado!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                }
                else
                {
                    MessageBoxEx.Show("Nenhum produto selecionado!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                    cmbProduto2.Focus();
                }
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void AdicionarProduto()
        {
            try
            {
                var produtoid = Convert.ToInt32(cmbProduto2.SelectedValue);
                var produto = new DLProduto().Consultar(new MLProduto() { ProdutoId = produtoid });
                listaProduto.Add(produto);
                dgvProdutos.DataSource = null;

                var newList = listaProduto.Select(prod => new //CRIA UMA NOVA LISTA PERSONALIZADA USANDO OS DADOS DA LISTA DO BANCO
                {
                    ProdutoId = prod.ProdutoId,
                    Descricao = prod.Descricao,
                    Quantidade = txtQtdeProduto.Value.ToString(),
                    SubTotal = prod.ValorVenda
                }).ToList();
                dgvProdutos.DataSource = newList;
                dgvProdutos.Refresh();
                decimal qtde = Convert.ToDecimal(txtQtdeProduto.Value);
                txtTotalProdutos.Text = ((Double)listaProduto.Sum(p => p.ValorVenda * qtde)).ToString("F");

                Calcular();

                MontarGridProduto();
                tbcGrids.SelectedTab = tbpgProdutos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void MontarGridProduto()
        {
            dgvProdutos.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);

            var objBlControleGrid = new ControleGrid(dgvProdutos);
            //Define quais colunas serão visíveis
            objBlControleGrid.DefinirVisibilidade(new List<string>() { "ProdutoId", "Descricao", "Quantidade", "SubTotal" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBlControleGrid.DefinirCabecalhos(new List<string>() { "Código", "Descrição", "Quantidade", "SubTotal R$" });

            //Define quais as larguras respectivas das colunas 
            objBlControleGrid.DefinirLarguras(new List<int>() { 15, 50, 20, 15 }, dgvProdutos.Width - 2); //5 + 15 + 25 + 10 + 15 + 15 + 15 = 100

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda", "esquerda" });

            //Define a altura das linhas respectivas da Grid 
            objBlControleGrid.DefinirAlturaLinha(30);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Text.ToUpper().Equals("SALVAR"))
            {
                if (MessageBoxEx.Show("Deseja realmente sair?\n\nAo sair todos os daods não salvos serão perdidos!", "Informação", MessageIcon.Question, MessageButton.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }

        public void CarregarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
