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
    public partial class FrmOrdemServico1 : FrmCadastroBase
    {
        public List<MLCliente> listaCliente;
        public List<MLServico> listaServico;
        public List<MLProduto> listaProduto;

        public FrmOrdemServico1()
        {
            InitializeComponent();
        }

        private void FrmOrdemServico_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombos();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void CarregarCombos()
        {
            try
            {
                CarregarComboCliente();
                CarregarComboStatus();
                CarregarComboServico();
                CarregarComboProduto();
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

                listaCliente = new DLCliente().Listar(new MLCliente());
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
                //cmbCliente.DisplayMember = "NomeRazaoSocial";
                //cmbCliente.ValueMember = "ClienteId";

                //listaCliente = new DLCliente().Listar(new MLCliente());
                //listaCliente.Insert(0, new MLCliente() { NomeRazaoSocial = "SELECIONE" });

                //cmbCliente.DataSource = listaCliente;
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
                cmbServico.DisplayMember = "Descricao";
                cmbServico.ValueMember = "ServicoId";

                listaServico = new DLServico().Listar(new MLServico());
                listaServico.Insert(0, new MLServico() { Descricao = "SELECIONE" });

                cmbServico.DataSource = listaServico;
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
                cmbProduto.DisplayMember = "Descricao";
                cmbProduto.ValueMember = "ProdutoId";

                listaProduto = new DLProduto().Listar(new MLProduto());
                listaProduto.Insert(0, new MLProduto() { Descricao = "SELECIONE" });

                cmbProduto.DataSource = listaProduto;
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

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
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

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
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

        public override void BuscarModelo()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
