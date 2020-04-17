using Apresentacao.Operacoes;
using GUI.Ferramentas;
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
    public partial class FrmDesconto : Form
    {
        public FrmFinalizaVenda _frmFinalizaVenda;
        public FrmDesconto(FrmFinalizaVenda frmFinalizaVenda)
        {
            InitializeComponent();
            this._frmFinalizaVenda = frmFinalizaVenda;
        }

        private void FrmDesconto_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// </summary>
        /// <param name="texto de numeros"></param>
       
        private void btnDesconto_Click(object sender, EventArgs e)
        {
            Decimal desconto = 0, totalReceber = 0;

            if(Decimal.TryParse(txtDesconto.Text, out desconto))
            {
                _frmFinalizaVenda.lblDescontoValor.Text = desconto.ToString("F");
                _frmFinalizaVenda.CalcularValoresVenda();
                Close();
                Dispose();
            }
            //if (Decimal.TryParse(txtDesconto.Text, out desconto))
            //{
            //    if (this._frmFinalizaVenda.lblTotalReceberValor.Text.Contains("R$"))
            //    {
            //        Decimal.TryParse(this._frmFinalizaVenda.lblTotalReceberValor.Text.Replace("R$", "").Trim(), out totalReceber);
            //    }
            //    else
            //    {
            //        Decimal.TryParse(this._frmFinalizaVenda.lblTotalReceberValor.Text.Trim(), out totalReceber);
            //    }

            //    this._frmFinalizaVenda.lblDescontoValor.Text = desconto.ToString("c");
            //    this._frmFinalizaVenda.lblTotalReceberValor.Text = (totalReceber - desconto).ToString("c");
            //    this._frmFinalizaVenda.lblSaldoRestanteValor.Text = (totalReceber - desconto).ToString("c");
            //    this.Close();
            //    this.Dispose();
            //}
            else
            {
                MessageBox.Show("Informe um valor válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //codigo para permiti apenas numeros no texbox
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtDesconto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        btnDesconto_Click(sender, e);
                        e = null;
                        sender = null;
                    }
                    break;
                case Keys.Escape:
                    {
                        btnCancelar_Click(sender, e);
                        e = null;
                        sender = null;
                    }
                    break;

            }
        }
    }
}
