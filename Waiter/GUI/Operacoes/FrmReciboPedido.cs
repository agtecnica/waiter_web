using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmReciboPedido : Form
    {
        private Int32 pedidoId;

        public FrmReciboPedido(Int32 pedidoId)
        {
            InitializeComponent();
            this.pedidoId = pedidoId;
        }

        private void FrmReciboPedido_Load(object sender, EventArgs e)
        {
            //this.VendaBalcaoPorClienteTableAdapter.Fill(this.AMSDataSet.VendaBalcaoPorCliente, pedidoId);
            //this.VendaBalcaoPorClienteItensTableAdapter.Fill(this.AMSDataSet.VendaBalcaoPorClienteItens, pedidoId);

            this.reportViewer1.RefreshReport();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.PrintDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnImprimir_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                this.reportViewer1.PrintDialog();
            }

            if (e.KeyCode == Keys.F4)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnFechar_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.F3)
            {
                this.reportViewer1.PrintDialog();
            }

            if (e.KeyCode == Keys.F4)
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}
