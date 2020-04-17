using GUI.Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.Operacoes
{
    public partial class FrmFinalizaVendaBalcao : Form
    {
        private FrmVendaPadrao frmVendaPadrao;

        public FrmFinalizaVendaBalcao(FrmVendaPadrao frmVendaPadrao)
        {
            InitializeComponent();
            this.frmVendaPadrao = frmVendaPadrao;
        }

        private void FrmFinalizaVendaBalcao_Load(object sender, EventArgs e)
        {
            txtTotalVenda.Text = frmVendaPadrao.txtValorTotal.Text;
            txtTotalReceber.Text = frmVendaPadrao.txtValorTotal.Text;
            txtSaldoRestante.Text = frmVendaPadrao.txtValorTotal.Text;

            txtValorDinheiro.Text = "0";
            txtValorDebito.Text = "0";
            txtValorCredito.Text = "0";
            txtValorCheque.Text = "0";
            txtValorBoleto.Text = "0";
        }

        private void txtValorDinheiro_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero(txtValorDinheiro.Text);
            Utils.Moeda(ref txtValorDinheiro);
            CalcularValoresVenda();
        }

        private void txtValorDebito_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero(txtValorDebito.Text);
            Utils.Moeda(ref txtValorDebito);
            CalcularValoresVenda();
        }

        private void txtValorCredito_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero(txtValorCredito.Text);
            Utils.Moeda(ref txtValorCredito);
            CalcularValoresVenda();
        }

        private void txtValorCheque_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero(txtValorCheque.Text);
            Utils.Moeda(ref txtValorCheque);
            CalcularValoresVenda();
        }

        private void txtValorBoleto_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero(txtValorBoleto.Text);
            Utils.Moeda(ref txtValorBoleto);
            CalcularValoresVenda();
        }
        private string ValidarNumero(string texto)
        {
            if (!int.TryParse(texto, out int numero))
            {
                texto = texto.Remove(texto.Length - 1);
            }
            return texto;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValorDinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtValorDebito_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtValorCredito_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtValorCheque_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }

        private void txtValorBoleto_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTecla(sender, e);
        }
        private void VerificarTecla(object sender, KeyEventArgs e)
        {
            if (e != null)
            {
                switch (e.KeyCode)
                {
                    case (Keys.Enter):
                        {
                            if (sender is TextBox)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        }
                        break;
                }
            }
            e = null;
            sender = null;
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            decimal valorTotalPago = 0;
            frmVendaPadrao._objMLPedido.lstMLPgtoEntrada = new List<MLPgtoEntrada>();

            MLPgtoEntrada pgtoEntrada;
            if (!string.IsNullOrEmpty(txtValorDinheiro.Text) && Convert.ToDecimal(txtValorDinheiro.Text) > 0)
            {
                pgtoEntrada = new MLPgtoEntrada();
                pgtoEntrada.PedidoId = this.frmVendaPadrao._objMLPedido.PedidoId;
                pgtoEntrada.FormaPgtoId = (int)MLPgtoEntrada.FormaPagto.DINHEIRO;//Dinheiro
                pgtoEntrada.Valor = Convert.ToDecimal(txtValorDinheiro.Text) - Convert.ToDecimal(txtTroco.Text.Replace("R$",""));
                frmVendaPadrao._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);

                valorTotalPago += pgtoEntrada.Valor;
            }
            if (!string.IsNullOrEmpty(txtValorDebito.Text) && Convert.ToDecimal(txtValorDebito.Text) > 0)
            {
                pgtoEntrada = new MLPgtoEntrada();
                pgtoEntrada.PedidoId = this.frmVendaPadrao._objMLPedido.PedidoId;
                pgtoEntrada.FormaPgtoId = (int)MLPgtoEntrada.FormaPagto.DEBITO;//Dinheiro
                pgtoEntrada.Valor = Convert.ToDecimal(txtValorDebito.Text);
                frmVendaPadrao._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);

                valorTotalPago += pgtoEntrada.Valor;
            }
            if (!string.IsNullOrEmpty(txtValorCredito.Text) && Convert.ToDecimal(txtValorCredito.Text) > 0)
            {
                pgtoEntrada = new MLPgtoEntrada();
                pgtoEntrada.PedidoId = this.frmVendaPadrao._objMLPedido.PedidoId;
                pgtoEntrada.FormaPgtoId = (int)MLPgtoEntrada.FormaPagto.CREDITO;//Dinheiro
                pgtoEntrada.Valor = Convert.ToDecimal(txtValorCredito.Text);
                frmVendaPadrao._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);

                valorTotalPago += pgtoEntrada.Valor;
            }
            if (!string.IsNullOrEmpty(txtValorBoleto.Text) && Convert.ToDecimal(txtValorBoleto.Text) > 0)
            {
                pgtoEntrada = new MLPgtoEntrada();
                pgtoEntrada.PedidoId = this.frmVendaPadrao._objMLPedido.PedidoId;
                pgtoEntrada.FormaPgtoId = (int)MLPgtoEntrada.FormaPagto.BOLETO;//Dinheiro
                pgtoEntrada.Valor = Convert.ToDecimal(txtValorBoleto.Text);
                frmVendaPadrao._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);

                valorTotalPago += pgtoEntrada.Valor;
            }
            if (!string.IsNullOrEmpty(txtValorCheque.Text) && Convert.ToDecimal(txtValorCheque.Text) > 0)
            {
                pgtoEntrada = new MLPgtoEntrada();
                pgtoEntrada.PedidoId = this.frmVendaPadrao._objMLPedido.PedidoId;
                pgtoEntrada.FormaPgtoId = (int)MLPgtoEntrada.FormaPagto.CHEQUE;//Dinheiro
                pgtoEntrada.Valor = Convert.ToDecimal(txtValorCheque.Text);
                frmVendaPadrao._objMLPedido.lstMLPgtoEntrada.Add(pgtoEntrada);

                valorTotalPago += pgtoEntrada.Valor;
            }
            if (valorTotalPago < Convert.ToDecimal(txtTotalVenda.Text))
            {
                MessageBoxEx.Show("O valor total informado não confere com o valor da venda", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return;
            }
            //frmVendaPadrao.txtValorPago.Text = valorTotalPago.ToString();
            //frmVendaPadrao.txtTroco.Text= txtTroco.Text.Replace("R$","");
            Close();
            Dispose();
        }

        public void CalcularValoresVenda()
        {
            decimal valorPago = 0;
            decimal valorTotal = 0;
            decimal valorTotalReceber = 0;
            decimal valorTotalPago = 0;
            decimal valorUnit = 0;
            decimal valorRecebido = 0;
            decimal saldoRestante = 0;
            decimal desconto = 0;
            decimal acrescimo = 0;

            #region *** CARREGA O DESCONTO DA VENDA EM UMA VARIAVEL ***
            if (txtDesconto.Text.Contains("R$"))
                desconto = Convert.ToDecimal(Utils.RemoveCifrao(txtDesconto.Text).Trim());
            else
                desconto = Convert.ToDecimal(txtDesconto.Text.Trim());
            #endregion

            #region *** CARREGA O ACRESCIMO DA VENDA EM UMA VARIAVEL ***
            if (txtAcrescimo.Text.Contains("R$"))
                acrescimo = Convert.ToDecimal(Utils.RemoveCifrao(txtAcrescimo.Text).Trim());
            else
                acrescimo = Convert.ToDecimal(txtAcrescimo.Text.Trim());
            #endregion

            #region *** CARREGA O VALOR TOTAL DA VENDA EM UMA VARIAVEL ***
            if (txtTotalVenda.Text.Contains("R$"))
                valorTotal = Convert.ToDecimal(Utils.RemoveCifrao(txtTotalVenda.Text).Trim());
            else
                valorTotal = Convert.ToDecimal(txtTotalVenda.Text.Trim());
            #endregion

            #region *** CARREGA O VALOR TOTAL A RECEBER DA VENDA EM UMA VARIAVEL ***
            if (txtTotalReceber.Text.Contains("R$"))
                valorTotalReceber = Convert.ToDecimal(Utils.RemoveCifrao(txtTotalReceber.Text).Trim());
            else
                valorTotalReceber = Convert.ToDecimal(txtTotalReceber.Text.Trim());
            #endregion

            #region *** LOOP - Carrega o total pago ***
            valorTotalPago = 0;
            valorTotalPago += Convert.ToDecimal((txtValorDinheiro.Text.Equals("")) ? "0" : txtValorDinheiro.Text);
            valorTotalPago += Convert.ToDecimal((txtValorDebito.Text.Equals("")) ? "0" : txtValorDebito.Text);
            valorTotalPago += Convert.ToDecimal((txtValorCredito.Text.Equals("")) ? "0" : txtValorCredito.Text);
            valorTotalPago += Convert.ToDecimal((txtValorCheque.Text.Equals("")) ? "0" : txtValorCheque.Text);
            valorTotalPago += Convert.ToDecimal((txtValorBoleto.Text.Equals("")) ? "0" : txtValorBoleto.Text);

            #endregion

            txtValorRecebido.Text = valorTotalPago.ToString("c");

            bool haveSaldoRestante = Decimal.TryParse(txtSaldoRestante.Text.ToString().Replace("R$ ", "").Trim(), out saldoRestante);
            bool haveValorRecebido = Decimal.TryParse(txtValorRecebido.Text.ToString().Replace("R$ ", "").Trim(), out valorRecebido);

            saldoRestante = valorTotal - desconto + acrescimo - valorTotalPago;

            if (saldoRestante >= 0)
            {
                #region *** VERIFICA SE VALOR PAGO É MENOR QUE TOTAL, SE MENOR TEXTBOX TROCO == 0, SENÃO SALDO TEXTBOX SALDO RESTANTE == 0 **
                if ((valorTotalPago - valorTotal) < 0)
                {
                    txtTroco.Text = 0.ToString("c");
                }
                else
                {
                    txtTroco.Text = (valorTotalPago - valorTotal).ToString("c");
                    txtSaldoRestante.Text = "R$ 0,00";
                }
                #endregion

                txtSaldoRestante.Text = (saldoRestante).ToString("c");
            }
            else
            {
                txtSaldoRestante.Text = (0).ToString("c");
                txtTroco.Text = Math.Abs(saldoRestante).ToString("C");
            }

            #region *** CARREGA O VALOR DO CAMPO VALOR PAGO EM UMA VARIAVEL***
            //if (txtValorPago.Text.Contains("R$") || txtValorPago.Text.Contains("R"))
            //{
            //    if (txtValorPago.Text.Contains("R$"))
            //    {
            //        if (!String.IsNullOrEmpty(RemoveCifrao(txtValorPago.Text).Trim()))
            //            valorPago = Convert.ToDecimal(Utils.RemoveCifrao(txtValorPago.Text).Trim());
            //    }
            //    else if (txtValorPago.Text.Contains("R"))
            //    {
            //        if (!String.IsNullOrEmpty(txtValorPago.Text.Replace("R", "").Trim()))
            //            valorPago = Convert.ToDecimal(Utils.RemoveCifrao(txtValorPago.Text).Trim());
            //    }

            //}
            //else
            //{

            //    if (!String.IsNullOrEmpty(txtValorPago.Text.Trim()))
            //        valorPago = Convert.ToDecimal(txtValorPago.Text.Trim());
            //}
            #endregion

            #region *** RECARREGA NO FORMATO DE MOEDA O VALOR TOTAL A RECEBER NO LABEL ***
            if (txtTotalReceber.Text.Contains("R$"))
                txtTotalReceber.Text = Convert.ToDecimal(Utils.RemoveCifrao(txtTotalReceber.Text).Trim()).ToString("c");
            else
                txtTotalReceber.Text = Convert.ToDecimal(txtTotalReceber.Text.Trim()).ToString("c");
            #endregion


        }

    }
}
