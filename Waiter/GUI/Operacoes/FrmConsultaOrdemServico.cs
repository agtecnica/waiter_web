using Dados;
using GUI.Base;
using GUI.Ferramentas;
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
    public partial class FrmConsultaOrdemServico : Form
    {
        List<MLCliente> listaCliente;
        List<MLOrdemServico> listaOrdemServico;
        private FrmOrdemServico frmOrdemServico;

        public FrmConsultaOrdemServico()
        {
            InitializeComponent();
        }
        public FrmConsultaOrdemServico(FrmOrdemServico frmOrdemServico)
        {
            InitializeComponent();
            this.frmOrdemServico = frmOrdemServico;
        }

        private void FrmOrdemServico_Load(object sender, EventArgs e)
        {
            try
            {
                listaOrdemServico = new DLOrdemServico().Listar(new MLOrdemServico());

                dtplDataInicio.Value = DateTime.Now.AddMonths(-1);
                listaOrdemServico = new List<MLOrdemServico>();
                CarregarCombos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void LimparCampos()
        {
            cmbCliente.SelectedIndex = 0;
            txtDescricao.Clear();
            txtCodigo.Clear();
            dtplDataInicio.Value = DateTime.Now;
            dtpDataFim.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;

            dgvPrincipal.DataSource = null;
            dgvPrincipal.Refresh();
        }

        private void CarregarCombos()
        {
            try
            {
                CarregarComboCliente();
                CarregarComboStatus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                cmbStatus.DataSource = listaStatusOS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }


        public void AplicarFiltro()
        {
            try
            {
                if (dtplDataInicio.Value == DateTime.MinValue || dtplDataInicio.Value == DateTime.MaxValue)
                {
                    MessageBox.Show("Data Inicial inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtplDataInicio.Focus();
                    return;
                }

                if (dtpDataFim.Value == DateTime.MinValue || dtpDataFim.Value == DateTime.MaxValue)
                {
                    MessageBox.Show("Data Inicial inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDataFim.Focus();
                    return;
                }

                LocalizarOS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LocalizarOS()
        {
            try
            {
                var listafiltrada = listaOrdemServico;

                int.TryParse(txtCodigo.Text, out int ordemServicoId);
                if (ordemServicoId > 0)
                    listafiltrada.Where(c => c.OrdemServicoId != ordemServicoId).ToList();

                listafiltrada.Where(c => c.DataAbertura >= dtplDataInicio.Value && c.DataAbertura <= dtplDataInicio.Value.AddHours(23).AddMinutes(59).AddSeconds(59)).ToList();

                if (cmbCliente.SelectedIndex > 0)
                    listafiltrada = listafiltrada.Where(c => c.ClienteId != Convert.ToInt32(cmbCliente.SelectedIndex)).ToList();

                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    listafiltrada = listafiltrada.Where(c => c.Descricao.Contains(txtDescricao.Text)).ToList();

                if (cmbStatus.SelectedIndex > 0)
                    listafiltrada = listafiltrada.Where(c => c.StatusId == Convert.ToInt32(cmbCliente.SelectedIndex)).ToList();

                CarregarGrid(listafiltrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarGrid(List<MLOrdemServico> listafiltrada = null)
        {
            try
            {

                if (listafiltrada == null)
                    listafiltrada = listaOrdemServico;


                var newList = listafiltrada.Select(os => new //CRIA UMA NOVA LISTA PERSONALIZADA USANDO OS DADOS DA LISTA DO BANCO
                {
                    Codigo = os.OrdemServicoId,
                    Cliente = os.Cliente.NomeFantasia,
                    Descricao = os.Descricao,
                    DataAbertura = os.Descricao,
                    Status = BuscarNomeStatus(os.StatusId)

                }).ToList();

                dgvPrincipal.DataSource = newList;

                MontarGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscarNomeStatus(int statusid)
        {
            string status = "";

            switch (statusid)
            {
                case (int)MLOrdemServico.StatusOS.ABERTO: status = "ABERTO"; break;
                case (int)MLOrdemServico.StatusOS.CANCELADA: status = "CANCELADA"; break;
                case (int)MLOrdemServico.StatusOS.EXECUTANDO: status = "EXECUTANDO"; break;
                case (int)MLOrdemServico.StatusOS.FINALIZADA: status = "FINALIZADA"; break;
                case (int)MLOrdemServico.StatusOS.PAUSADA: status = "PAUSADA"; break;
            }
            return status;
        }

        private void MontarGrid()
        {
            dgvPrincipal.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);

            var objBlControleGrid = new ControleGrid(dgvPrincipal);
            //Define quais colunas serão visíveis
            objBlControleGrid.DefinirVisibilidade(new List<string>() { "Codigo", "Cliente", "Descricao", "DataAbertura", "Status" });

            //Define quais os cabeçalhos respectivos das colunas 
            objBlControleGrid.DefinirCabecalhos(new List<string>() { "Código", "Cliente", "Descrição", "Data de Abertura", "Status" });

            //Define quais as larguras respectivas das colunas 
            objBlControleGrid.DefinirLarguras(new List<int>() { 5, 30, 40, 10, 15 }, dgvPrincipal.Width - 3); //5 + 15 + 25 + 10 + 15 + 15 + 15 = 100

            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda", "esquerda", "esquerda" });

            //Define a altura das linhas respectivas da Grid 
            objBlControleGrid.DefinirAlturaLinha(30);
        }
    }
}
