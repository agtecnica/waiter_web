using Apresentacao.Operacoes;
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
    public partial class FrmAcrescimo : Form
    {
        public FrmFinalizaVenda _frmFinalizaVenda;
        public FrmAcrescimo(FrmFinalizaVenda frmFinalizaVenda)
        {
            InitializeComponent();
            this._frmFinalizaVenda = frmFinalizaVenda;
        }

        private void FrmAcrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnAcrecimo_Click(sender, e);
                    break;
             
            }
        }
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
        private void btnAcrecimo_Click(object sender, EventArgs e)
        {
            Decimal acrescimo = 0, totalReceber = 0;

            if (Decimal.TryParse(txtAcrescimo.Text, out acrescimo))
            {
                _frmFinalizaVenda.lblAcrescimoValor.Text = acrescimo.ToString("F");
                _frmFinalizaVenda.CalcularValoresVenda();
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Informe um valor válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //codigo para permiti apenas numeros no texbox
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtAcrescimo_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtAcrescimo);
        }
    }
}
