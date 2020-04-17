using Dados;
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
    public partial class FrmEncerramentoCaixa : Form
    {
        public MLCaixa objMlCaixa { get; set; }
        public bool isAbrirCaixa { get; set; }
        int ControleMovimentoCaixaId { get; set; }
        FrmAberturaCaixa frmAberturaCaixa { get; set; }
        private FrmPrincipalNovo frmPrincipal { get; set; }

        #region *** Impressão ***

        int largura;
        int altura;

        Font fonte;
        SolidBrush cor;
        int y = 50;
        int x = 0;
        int num_frase = 1;
        int pagina = 0;
        int paginas_criadas = 0;

        #endregion

        public enum Detalhe
        {
            DINHEIRO = 1,
            DEBITO = 2,
            CREDITO = 3,
            BOLETO = 4,
            CHEQUE = 5,
            SUPRIMENTO = 6,
            SANGRIA = 7,
            FATURAMENTO = 8,
            FATURAMENTOREAL = 9
        }

        public FrmEncerramentoCaixa(FrmAberturaCaixa frmAberturaCaixa, MLCaixa objMlCaixa, bool isAbrirCaixa, FrmPrincipalNovo frmPrincipal)
        {
            InitializeComponent();
            this.objMlCaixa = objMlCaixa;
            this.isAbrirCaixa = isAbrirCaixa;
            this.frmAberturaCaixa = frmAberturaCaixa;
            this.frmPrincipal = frmPrincipal;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEncerramentoCaixa_Load(object sender, EventArgs e)
        {
            ControleMovimentoCaixaId = Sessao.Instance.Caixa.ControleMovimentoCaixaId;
            if (Sessao.Instance.Caixa.ControleMovimentoCaixaId == 0)
                Sessao.Instance.Caixa.ControleMovimentoCaixaId = objMlCaixa.ControleMovimentoCaixaId;
            try
            {
                var rm = new DLResumoMovimento().Consultar(objMlCaixa.ControleMovimentoCaixaId);
                CarregarResumoMovimento(rm);
                ValidarCamposFechamento();
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void CarregarResumoMovimento(MLResumoMovimento rm)
        {
            try
            {
                if ((decimal)objMlCaixa.SaldoFinal != (rm.Faturamento + rm.TrocoInicial))
                {
                    MessageBoxEx.Show("O valor informado no fechamento do caixa não confere!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                }

                txtFaturamentoReal.Text = rm.TotalPedidos.ToString();
                txtCaixa.Text = rm.Guiche;
                txtCodigoMovimento.Text = rm.ControleMovimentoCaixaId.ToString();
                txtFaturamento.Text = rm.Faturamento.ToString();
                txtTrocoInicial.Text = rm.TrocoInicial.ToString();
                txtSuprimento.Text = rm.Suprimento.ToString();
                txtSangria.Text = rm.Sangria.ToString();
                txtTotal.Text = (rm.Faturamento + rm.TrocoInicial).ToString();
                txtBoleto.Text = rm.Boleto.ToString();
                txtCheque.Text = rm.Cheque.ToString();
                txtCredito.Text = rm.Credito.ToString();
                txtDebito.Text = rm.Debito.ToString();
                txtDinheiro.Text = (rm.Dinheiro + Convert.ToDecimal(txtTrocoInicial.Text)).ToString();
                objMlCaixa.SaldoFinal = (double)rm.Total;
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sessao.Instance.Caixa.ControleMovimentoCaixaId > 0)
                    objMlCaixa.ControleMovimentoCaixaId = Sessao.Instance.Caixa.ControleMovimentoCaixaId;
                if (ValidarFechamento())//Verifica se botoes referentes a valores estão com status ok
                {
                    if (objMlCaixa.DataHoraFechamento == null)
                        objMlCaixa.DataHoraFechamento = DateTime.Now;
                    new DLCaixa().AbrirFecharCaixa(objMlCaixa, isAbrirCaixa);
                    frmAberturaCaixa.CarregarGrid();
                    GerarRecibo();
                    Close();
                    Dispose();
                }
                else
                {
                    if (txtOcorrencia.Text.Length > 10 && ValidarUsuarioResponsavel())
                    {
                        //verificar valor divergencia
                        decimal boleto = 0, cheque = 0, credito = 0, debito = 0, dinheiro = 0, total = 0;

                        decimal.TryParse(txtConfirmaBoleto.Text, out boleto);
                        decimal.TryParse(txtConfirmaCheque.Text, out cheque);
                        decimal.TryParse(txtConfirmaCredito.Text, out credito);
                        decimal.TryParse(txtConfirmaDebito.Text, out debito);
                        decimal.TryParse(txtConfirmaDinheiro.Text, out dinheiro);
                        decimal.TryParse(txtTotal.Text, out total);

                        decimal valorDivergencia = total - (boleto + cheque + credito + debito + dinheiro);
                        var ControleMovimento = new MLControleMovimento()
                        {
                            CaixaId = objMlCaixa.CaixaId,
                            COntroleMovimentoId = objMlCaixa.ControleMovimentoCaixaId,
                            MotivoDivergencia = txtOcorrencia.Text,
                            ValorDivergencia = valorDivergencia,
                        };
                        if (Sessao.Instance.Caixa.Usuario.UsuarioId > 0)
                            objMlCaixa.Usuario.UsuarioId = Sessao.Instance.Caixa.Usuario.UsuarioId;
                        new DLCaixa().AbrirFecharCaixa(objMlCaixa, isAbrirCaixa, ControleMovimento);
                        frmAberturaCaixa.CarregarGrid();
                        GerarRecibo();
                        Close();
                        Dispose();
                    }
                    else
                    {
                        txtOcorrencia.Focus();
                        if (txtOcorrencia.Text.Length > 10)
                        {
                            if (!ValidarUsuarioResponsavel())
                            {
                                MessageBoxEx.Show("Usuário responsável ou ocorrência da divergência inválidos!", "Atenção", MessageIcon.Warning, MessageButton.OK);
                                txtLoginResponsavel.Focus();
                            }
                        }
                        txtLoginResponsavel.Clear();
                        txtSenhaResponsavel.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void GerarRecibo()
        {
            DialogResult dr = MessageBoxEx.Show("Deseja Imprimir Recibo?", "Impressão", MessageIcon.Question, MessageButton.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                //define as dimensões da página
                largura = documento.DefaultPageSettings.Bounds.Width;
                altura = documento.DefaultPageSettings.Bounds.Height;

                fonte = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                cor = new SolidBrush(Color.Black);
                y = 50;
                num_frase = 1;
                pagina = 0;

                #region *** Impressão com caixa selecionadora de impressora ***
                documento.PrinterSettings.Copies = 2;
                documento.Print(); //--LINHA PARA IMPRIMIR

                #endregion
            }
        }

        private void documento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //DEFINE O ESTILO DA LINHA TRACEJADA
                float[] dashValues = { 2, 2 };
                Pen blackPen = new Pen(Color.Black, 1);
                blackPen.DashPattern = dashValues;

                #region CUPOM ANDRE

                #region DEFINIÇÃO DE FONTES
                var fonteLucidaSans10Regular = new Font("Lucida Sans Unicode", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial10Regular = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial12Regular = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
                var fonteArial10Negrito = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);
                #endregion

                var corPreta = new SolidBrush(Color.Black);
                var posicao = new Rectangle(0, 50, largura, 30);

                var ponto = " . ";
                //Busca as dimensões da string '.' para calculo da largura de uma linha pontilhada
                SizeF dimensaoPonto = e.Graphics.MeasureString(ponto, fonteLucidaSans10Regular);

                var traco = "-";
                SizeF dimensaoTraco = e.Graphics.MeasureString(traco, fonteArial12Regular);

                #region  DEFINE ESTILO DE ALINHAMENTO

                var alinhamnetoCentro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var alinhamnetoEsquerda = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                };

                var alinhamnetoDireita = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Far
                };

                #endregion

                //REDEFINE TAMANHO DA PAGINA
                posicao.Width = 527;

                //VARIVEL PROVISÓRIA, FUTURAMENTE SERÁ UTILIZADA VARIAVAL CALCULADA DE ACORDO COM O TAMANHO DEFINIDO PARA A PÁGINA
                string linhaTracejada = "----------------------------------------------------------------------------";
                //string linhaTracejada = "";
                //for (decimal i = 0; i < posicao.Width; i = i + Convert.ToDecimal(dimensaoTraco.Width))
                //    linhaTracejada += traco;


                //RESUMO DO MOVIMENTO
                var resumoMovimento = new DLResumoMovimento().Consultar(objMlCaixa.ControleMovimentoCaixaId);
                var controleMovimento = new DLControleMovimento().Consultar(objMlCaixa.ControleMovimentoCaixaId);

                //CARREGA OBJETO ESTABELECIMENTO

                if (resumoMovimento == null) throw new Exception("Erro ao consultar dados do movimento!\n\n Consulte o Administrador do sistema.");


                #region *** MontaCabecalhoCupom ***

                #region Carrega variáveis
                var codigoMovimento = resumoMovimento.ControleMovimentoCaixaId;
                var Caixa = resumoMovimento.Guiche;
                var horaAbertura = controleMovimento.HoraAbertura;
                var horaFechamento = DateTime.Now;
                if (controleMovimento.HoraFechamento != null)
                    horaFechamento = (DateTime)controleMovimento.HoraFechamento;

                var funcionarioFechamentoId = controleMovimento.UsuarioFechamentoId;
                var funcionarioAberturaId = controleMovimento.UsuarioAberturaId;
                var funcionarioAbertura = new DLUsuario().Listar(new MLUsuario() { UsuarioId = funcionarioAberturaId }).FirstOrDefault();
                var funcionarioFechamento = new DLUsuario().Listar(new MLUsuario() { UsuarioId = funcionarioFechamentoId }).FirstOrDefault();

                var dinheiro = resumoMovimento.Dinheiro;
                var debito = resumoMovimento.Debito;
                var credito = resumoMovimento.Credito;
                var cheque = resumoMovimento.Cheque;
                var boleto = resumoMovimento.Boleto;

                var qtdePedidos = resumoMovimento.QtdePedidos;
                var trocoInicial = resumoMovimento.TrocoInicial;
                var faturamento = resumoMovimento.Faturamento;
                var suprimento = resumoMovimento.Suprimento;
                var sangria = resumoMovimento.Sangria;

                var total = resumoMovimento.Total;

                var motivoDivergencia = controleMovimento.MotivoDivergencia;
                var valorDivergencia = controleMovimento.ValorDivergencia;


                #endregion
                //DEFINE A DISTANCIA EM RELAÇÂO A COORDENADA X (HORIZONTAL) E EM RELAÇÂO AO ALINHAMENTO DETERMINADO
                posicao.X = 5;
                //DEFINE LARGURA DA PÁGINA
                posicao.Width = 527;
                e.Graphics.DrawString("RESUMO DO MOVIMENTO DO CAIXA", fonteArial10Negrito, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 20;//soma mais 20 Pixels para baixo (VERTICAL)
                e.Graphics.DrawString("Caixa: " + Caixa, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;//soma mais 20 Pixels para baixo (VERTICAL)
                e.Graphics.DrawString("Cod. Movimento: " + codigoMovimento.ToString(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;//soma mais 13 Pixels para baixo (VERTICAL)
                e.Graphics.DrawString("Data Abertura:  " + horaAbertura.ToShortDateString() + " - " + horaAbertura.ToLongTimeString(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;
                e.Graphics.DrawString("Data Fechamento:  " + horaFechamento.ToShortDateString() + " - " + horaFechamento.ToLongTimeString(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;
                e.Graphics.DrawString("Usuário Abertura:  " + funcionarioAbertura.Nome, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;
                e.Graphics.DrawString("Usuário Fechamento:  " + funcionarioFechamento.Nome, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString("Valor Abertura: R$ " + trocoInicial.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME CNPJ COM MASCARA FORMATADA

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 20;
                e.Graphics.DrawString("RECEBIMENTOS EM: ", fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA


                posicao.Y += 20;
                e.Graphics.DrawString("DINHEIRO: R$ " + dinheiro.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 13;
                e.Graphics.DrawString("DÉBITO: R$ " + debito.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 13;
                e.Graphics.DrawString("CRÉDITO: R$ " + credito.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 13;
                e.Graphics.DrawString("CHEQUE: R$ " + cheque.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 13;
                e.Graphics.DrawString("BOLETO: R$ " + boleto.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 15;
                posicao.X = 5;


                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 10;
                e.Graphics.DrawString("SUPRIMENTO: R$ " + suprimento.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 13;
                e.Graphics.DrawString("SANGRIA: R$ " + sangria.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 13;
                e.Graphics.DrawString("QTDE PEDIDOS: R$ " + qtdePedidos.ToString(), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 13;
                e.Graphics.DrawString("FATURAMENTO: R$ " + faturamento.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 13;
                e.Graphics.DrawString("TOTAL EM CAIXA: R$ " + total.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                posicao.Y += 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                posicao.Y += 20;
                e.Graphics.DrawString("MOTIVO DIVERGÊNCIA:", fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                if (controleMovimento.MotivoDivergencia != null)
                {
                    posicao.Y += 13;
                    e.Graphics.DrawString(controleMovimento.MotivoDivergencia, fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA
                }

                posicao.Y += 20;
                e.Graphics.DrawString("VALOR DIVERGÊNCIA: R$ " + controleMovimento.ValorDivergencia.ToString("F"), fonteLucidaSans10Regular, corPreta, posicao, alinhamnetoEsquerda);//IMPRIME IE COM MASCARA FORMATADA

                posicao.Y += 15;
                posicao.X = 5;
                e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);
                #endregion

                #region ESTRUTURA SUPERIOR CUPOM 


                //var tamLinha = e.Graphics.MeasureString(linhaTracejada, fonteArial10Regular);
                //e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //posicao.Y += 10; //desce 17 pixels
                //posicao.X = 5; // margim de 0 pixels
                //e.Graphics.DrawString(DateTime.Now.ToString(CultureInfo.CurrentCulture), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //posicao.Y -= 10;
                //posicao.X = -110;
                //e.Graphics.DrawString("CCF: 123456", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);//VALOR DO CCF FICTÍCIO

                //posicao.Y -= 9;
                //posicao.X -= 130;
                //e.Graphics.DrawString("Pedido Nº: " + this.frmVendaBalcao._objMLPedido.PedidoId.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoDireita);

                ////--------------------------------------------------------------------------------- LInha Tracejada
                //posicao.Y += 25;
                //posicao.X = 5;
                //e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //posicao.Y += 5;
                //posicao.X = -110;

                //e.Graphics.DrawString("CUPOM NÃO FISCAL", fonteArial10Negrito, corPreta, posicao, alinhamnetoCentro);

                //posicao.Y += 23;
                //posicao.X = 5;
                //fonteLucidaSans10Regular = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                //string cabecalhoCupom = "ITEM          CÓDIGO          DESCRIÇÃO ";
                //var tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                //e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //posicao.X = 5;
                //posicao.Y += 10;
                //tamCabecalhoCupom = e.Graphics.MeasureString(cabecalhoCupom, fonteArial10Regular);
                //cabecalhoCupom = "QTD             UN          VL. UNITÁRIO (R$)         VL. ITEM (R$)";
                //e.Graphics.DrawString(cabecalhoCupom, fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                ////--------------------------------------------------------------------------------- LInha Tracejada
                //posicao.Y += 7;
                //posicao.X = 5;
                //e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //#endregion

                ////Monta pedido

                //#region *** MontaItensCupom ***
                //posicao.Y += 15;
                //for (int i = 0; i < lstItem.Count; i++)
                //{
                //    posicao.X = 5;//MARGEM ESQUERDA DE 5 
                //                  //Carrega o produto dentro da lista de itens do pedido
                //    lstItem[i].Produto = new DLProduto().Listar(lstItem[i].Produto)
                //        .Find(p => p.ProdutoId == lstItem[i].Produto.ProdutoId);

                //    var tamI = i.ToString().Length;
                //    string itemNr = "";

                //    //Formata código com 4 digitos
                //    itemNr = Formatacao.ZerosEsquerda((i + 1).ToString(), 4);

                //    string item = lstItem[i].Produto.Descricao.ToString();
                //    string codigo = lstItem[i].Produto.CodigoBarras.ToString();
                //    string valorUnit = lstItem[i].Produto.ValorVenda.ToString();
                //    string Qtde = lstItem[i].Quantidade.ToString();
                //    string UnMedida = lstItem[i].Produto.UnidadeMedida.Descricao;
                //    string valorTotal = (lstItem[i].Quantidade * lstItem[i].Produto.ValorVenda).ToString();
                //    string strMultiplicador = "X ";

                //    //Busca as dimensões das strings 
                //    dimensaoItenNr = e.Graphics.MeasureString(itemNr, fonteArial10Regular);
                //    dimensaoItem = e.Graphics.MeasureString(item, fonteArial10Regular);
                //    dimensaoCodigo = e.Graphics.MeasureString(codigo, fonteArial10Regular);
                //    dimensaoValorUnit = e.Graphics.MeasureString(valorUnit, fonteArial10Regular);
                //    dimensaoQtde = e.Graphics.MeasureString(Qtde, fonteArial10Regular);
                //    dimensaoUnMedida = e.Graphics.MeasureString(UnMedida, fonteArial10Regular);
                //    dimensaoX = e.Graphics.MeasureString(strMultiplicador, fonteArial10Regular);
                //    dimensaoValorTotal = e.Graphics.MeasureString(valorTotal.ToString(CultureInfo.CurrentCulture), fonteArial10Negrito);

                //    //IMPRIME AS VARIAVEIS
                //    e.Graphics.DrawString(itemNr, fonteArial10Regular, corPreta, posicao);
                //    posicao.X = 30;

                //    e.Graphics.DrawString(codigo, fonteArial10Regular, corPreta, posicao);
                //    posicao.X += Convert.ToInt32(dimensaoCodigo.Width) + 5;

                //    if (Qtde == "0,0000")
                //        e.Graphics.DrawString(" ***ITEM CANCELADO*** ".ToUpper(), fonteArial10Regular, corPreta, posicao);
                //    else
                //        e.Graphics.DrawString(item.ToUpper(), fonteArial10Regular, corPreta, posicao);
                //    posicao.X += Convert.ToInt32(dimensaoItem.Width);

                //    posicao.Y += 10;
                //    posicao.X = 30;

                //    e.Graphics.DrawString(Qtde, fonteArial10Regular, corPreta, posicao);
                //    posicao.X += Convert.ToInt32(dimensaoQtde.Width) + 5;

                //    e.Graphics.DrawString(UnMedida, fonteArial10Regular, corPreta, posicao);
                //    posicao.X += Convert.ToInt32(dimensaoUnMedida.Width) + 5;

                //    e.Graphics.DrawString(strMultiplicador, fonteArial10Regular, corPreta, posicao);
                //    posicao.X += Convert.ToInt32(dimensaoX.Width) + 5;

                //    if (Qtde == "0,0000")
                //        e.Graphics.DrawString("0", fonteArial10Regular, corPreta, posicao);
                //    else
                //        e.Graphics.DrawString(valorUnit, fonteArial10Regular, corPreta, posicao);
                //    SizeF tamValorSubTotal = e.Graphics.MeasureString(Convert.ToDouble(valorTotal).ToString("F"), fonteArial10Regular);
                //    posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorSubTotal.Width + 15;
                //    e.Graphics.DrawString(Convert.ToDouble(valorTotal).ToString("F"), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                //    _objMLPedido.ValorTotal += Convert.ToDecimal(valorTotal);

                //    posicao.Y += 15;
                //    posicao.X = 145;
                //}
                //#endregion


                //#region *** MontaRodapeCupom ***
                ////var formapgto = 
                ////var lstFormaPgto = new DLFormaPgto().Listar();

                //string operador = _objMLPedido.Usuario.Nome;
                //dimensaoOperador = e.Graphics.MeasureString(operador, fonteArial10Regular);

                /////////////////////////////valor total///////////////////////////
                //posicao.Y += 5;
                //posicao.X = 5; //Margem de0 pixels
                //e.Graphics.DrawString("TOTAL R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //var tamValorTotal = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F"), fonteArial10Regular);
                //posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorTotal.Width + 15;
                //var valorPedido = Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F");
                //e.Graphics.DrawString(valorPedido.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                ///////////////////////////valor pago//////////////////////////////
                //posicao.Y += 15;
                //posicao.X = 5; //Margem de0 pixels
                //e.Graphics.DrawString("PAGO R$", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //var tamValorPago = e.Graphics.MeasureString(Convert.ToDouble(_objMLPedido.ValorTotal).ToString("F"), fonteArial10Regular);
                //posicao.X = Convert.ToInt32(tamLinha.Width) - (int)tamValorPago.Width + 15;
                //var pago = lblValorRecebidoValor.Text.Replace("R$", "").Replace("R$ ", "");
                //var valorpago = Convert.ToDouble(pago).ToString("F");
                //e.Graphics.DrawString(valorpago.ToString(), fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                ///////////////////////////////TROCO//////////////////////////////////
                //posicao.Y += 20;
                //posicao.X = 5; //Margem de0 pixels
                //e.Graphics.DrawString("TROCO R$", fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);

                ////var tamanhoTroco = e.Graphics.MeasureString((_objMLPedido.ValorTotal - _objMLPedido.ValorTotal);
                //posicao.X = Convert.ToInt32(tamLinha.Width) - 10;
                //var troco = lblTrocoValor.Text.Replace("R$", "").Replace("R$ ", "");
                //var valortroco = Convert.ToDouble(troco).ToString("F");
                //e.Graphics.DrawString(valortroco.ToString(), fonteArial10Negrito, corPreta, posicao, alinhamnetoEsquerda);

                //#region Forma de Pagamento nao imprementado
                ////FORMAS DE PAGAMENTO
                //var lstFormaPgto = new DLPedido().ListarFormaPgtoPedido(pedido.PedidoId);

                //for (int i = 0; i < lstFormaPgto.Count; i++)
                //{
                //    if (lstFormaPgto[i].FormaPgtoId == 1 && lstFormaPgto[i].Valor > 0)
                //    {
                //        posicao.Y += 20;//20Pixels para baixo
                //        posicao.X = 5; //Margem de 5 pixels
                //        e.Graphics.DrawString("DINHEIRO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                //        continue;
                //    }
                //    if (lstFormaPgto[i].FormaPgtoId == 2 && lstFormaPgto[i].Valor > 0)
                //    {
                //        posicao.Y += 15;//15Pixels para baixo
                //        posicao.X = 5; //Margem de0 pixels
                //        e.Graphics.DrawString("DÉBITO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                //        continue;
                //    }
                //    if (lstFormaPgto[i].FormaPgtoId == 3 && lstFormaPgto[i].Valor > 0)
                //    {
                //        posicao.Y += 15;//15Pixels para baixo
                //        posicao.X = 5; //Margem de 5 pixels
                //        e.Graphics.DrawString("CRÉDITO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                //        continue;
                //    }
                //    if (lstFormaPgto[i].FormaPgtoId == 4 && lstFormaPgto[i].Valor > 0)
                //    {
                //        posicao.Y += 15;//15Pixels para baixo
                //        posicao.X = 5; //Margem de 5 pixels
                //        e.Graphics.DrawString("BOLETO: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                //        continue;
                //    }
                //    if (lstFormaPgto[i].FormaPgtoId == 5 && lstFormaPgto[i].Valor > 0)
                //    {
                //        posicao.Y += 15;//15Pixels para baixo
                //        posicao.X = 5; //Margem de0 pixels
                //        e.Graphics.DrawString("CHEQUE: R$" + lstFormaPgto[i].Valor.ToString(), fonteArial10Regular, corPreta, posicao, alinhamnetoEsquerda);
                //        continue;
                //    }
                //}




                //////REDEFINE LARGURA DA PÁGINA
                ////posicao.Width = 527;
                ////posicao.X = -115;
                ////posicao.Y += 5;
                //////posicao.X = 5; //Margem de0 pixels
                ////e.Graphics.DrawString("Obrigado pela preferência!", fonteArial10Regular, corPreta, posicao, alinhamnetoCentro);

                //////--------------------------------------------------------------------------------- LInha Tracejada
                //#endregion

                //posicao.Y += 20;
                //posicao.X = 5;
                //e.Graphics.DrawString(linhaTracejada, fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                //posicao.Y += 15;
                //posicao.X = -115;
                //e.Graphics.DrawString("<< DOCUMENTO NAO FISCAL >>", fonteArial12Regular, corPreta, posicao, alinhamnetoCentro);

                //posicao.Y += 20;
                ////posicao.X = 5; //Margem de0 pixels
                //e.Graphics.DrawString("<< NAO SERVE COMO GARANTIA >>", fonteArial12Regular, corPreta, posicao, alinhamnetoCentro);
                //posicao.Y += 5;
                //e.Graphics.DrawString("", fonteArial12Regular, corPreta, posicao, alinhamnetoEsquerda);

                ////qrcod com chave de acesso
                //BarcodeWriter br = new BarcodeWriter();
                //br.Format = BarcodeFormat.QR_CODE;
                //Bitmap bm = new Bitmap(br.Write(frmVendaBalcao._objMLPedido.PedidoId.ToString()), 150, 150);
                //posicao.Y += 25;

                //posicao.X = Convert.ToInt32(263 - bm.Width - 40);
                //posicao.Width = 150;//largura do qrcode
                //posicao.Height = 150;//altura do qrcode
                //e.Graphics.DrawImage(bm, posicao);



                #endregion

                //y = new ImprimeCupomNaoFiscal(frmVendaBalcao, e, y).MontaCupom();



                ///----------------------------------------------------------------------------------
                ///
                //DEFINE O ESTILO DA LINHA TRACEJADA

                y += 30;
                num_frase++;

                if (y < altura - 50)
                    return;
                y = 50;// Seta no inicio da página com uma margim superior de 50 pixels
                e.HasMorePages = true; //informa que o documento necessita ser impresso em outra página e irá iniciar novamente esse evento
                paginas_criadas++;
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //IMPRESSAO FORMATO 2
            //new ImprimeVenda(this.frmVendaBalcao._objMLPedido, this.frmVendaBalcao._lstMlPedidoItem).Print();

        }


        private bool ValidarUsuarioResponsavel()
        {
            var dlUsuario = new DLUsuario();
            var valido = false;
            var loginResponsavel = txtLoginResponsavel.Text.Trim();
            var senhaResponsavel = txtSenhaResponsavel.Text.Trim();
            var usuario = new MLUsuario()
            {
                Login = loginResponsavel,
                Senha = senhaResponsavel
            };

            try
            {
                usuario = dlUsuario.Consultar(usuario);
                if (usuario.isGerente != null)
                {
                    if ((bool)usuario.isGerente)
                        valido = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                usuario = null;
                dlUsuario = null;
            }
            return valido;
        }

        private bool ValidarFechamento()
        {
            if (btnConfirmaBoleto.Tag.ToString() == "close")
            {
                if (txtOcorrencia.Text.Length <= 10)
                    MessageBoxEx.Show("O valor informado do BOLETO no fechamento do caixa não confere!\n\nInforme a ocorrência da divergência ou corrija o valor do boleto.", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return false;
            }
            if (btnConfirmaCheque.Tag.ToString() == "close")
            {
                if (txtOcorrencia.Text.Length <= 10)
                    MessageBoxEx.Show("O valor informado do CHEQUE no fechamento do caixa não confere!\n\nInforme a ocorrência da divergência ou corrija o valor do cheque.", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return false;
            }
            if (btnConfirmaCredito.Tag.ToString() == "close")
            {
                if (txtOcorrencia.Text.Length <= 10)
                    MessageBoxEx.Show("O valor informado do CRÉDITO no fechamento do caixa não confere!\n\nInforme a ocorrência da divergência ou corrija o valor do crédito.", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return false;
            }
            if (btnConfirmaDebito.Tag.ToString() == "close")
            {
                if (txtOcorrencia.Text.Length <= 10)
                    MessageBoxEx.Show("O valor informado do DÉBITO no fechamento do caixa não confere!\n\nInforme a ocorrência da divergência ou corrija o valor do débito.", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return false;
            }
            if (btnConfirmaDinheiro.Tag.ToString() == "close")
            {
                if (txtOcorrencia.Text.Length <= 10)
                    MessageBoxEx.Show("O valor informado do DINHEIRO no fechamento do caixa não confere!\n\nInforme a ocorrência da divergência ou corrija o valor do dinheiro.", "Atenção", MessageIcon.Warning, MessageButton.OK);
                return false;
            }

            return true;
        }

        #region DETALHES 

        private void btnDetalheBoleto_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.BOLETO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheCheque_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.CHEQUE);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheCredito_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.CREDITO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheDebito_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.DEBITO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheDinheiro_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.DINHEIRO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheSuprimento_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.SUPRIMENTO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheSangria_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.SANGRIA);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }

        private void btnDetalheFaturamento_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.FATURAMENTO);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }
        #endregion

        private void CarregarDetalheFormaPagto(Detalhe tipo)
        {
            FrmDetalheMovimento frmDetalheMovimento = new FrmDetalheMovimento(tipo, Sessao.Instance.Caixa.ControleMovimentoCaixaId);
            frmDetalheMovimento.ShowDialog();
        }

        #region CONFIRMAÇÂO 
        private void txtConfirmaBoleto_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtConfirmaBoleto);
            ValidarCamposFechamento();
        }

        private void ValidarCamposFechamento()
        {
            #region campo boleto
            decimal.TryParse(txtBoleto.Text, out decimal boleto);
            if (decimal.TryParse(txtConfirmaBoleto.Text, out decimal confirmaBoleto))
            {
                if (boleto == confirmaBoleto)
                {
                    btnConfirmaBoleto.Tag = "ok";
                    btnConfirmaBoleto.BackgroundImage = Properties.Resources.icon_ok;
                }
                else
                {
                    btnConfirmaBoleto.Tag = "close";
                    btnConfirmaBoleto.BackgroundImage = Properties.Resources.icon_close;

                }

                lblMenssagem.Text = "";
            }
            else
            {
                lblMenssagem.Text = "Informe somente números!";
            }
            #endregion

            #region campo cheque
            decimal.TryParse(txtCheque.Text, out decimal cheque);
            if (decimal.TryParse(txtConfirmaCheque.Text, out decimal confirmaCheque))
            {
                if (cheque == confirmaCheque)
                {

                    btnConfirmaCheque.Tag = "ok";
                    btnConfirmaCheque.BackgroundImage = Properties.Resources.icon_ok;
                }
                else
                {

                    btnConfirmaCheque.Tag = "close";
                    btnConfirmaCheque.BackgroundImage = Properties.Resources.icon_close;
                }

                lblMenssagem.Text = "";
            }
            else
            {
                lblMenssagem.Text = "Informe somente números!";
            }
            #endregion

            #region campo crédito
            decimal.TryParse(txtCredito.Text, out decimal credito);
            if (decimal.TryParse(txtConfirmaCredito.Text, out decimal confirmaCredito))
            {
                if (credito == confirmaCredito)
                {

                    btnConfirmaCredito.Tag = "ok";
                    btnConfirmaCredito.BackgroundImage = Properties.Resources.icon_ok;
                }
                else
                {
                    btnConfirmaCredito.Tag = "close";
                    btnConfirmaCredito.BackgroundImage = Properties.Resources.icon_close;
                }

                lblMenssagem.Text = "";
            }
            else
            {
                lblMenssagem.Text = "Informe somente números!";
            }
            #endregion

            #region campo débito

            decimal.TryParse(txtDebito.Text, out decimal debito);
            if (decimal.TryParse(txtConfirmaDebito.Text, out decimal confirmaDebito))
            {
                if (debito == confirmaDebito)
                {
                    btnConfirmaDebito.Tag = "ok";
                    btnConfirmaDebito.BackgroundImage = Properties.Resources.icon_ok;
                }
                else
                {
                    btnConfirmaDebito.Tag = "close";
                    btnConfirmaDebito.BackgroundImage = Properties.Resources.icon_close;
                }

                lblMenssagem.Text = "";
            }
            else
            {
                lblMenssagem.Text = "Informe somente números!";
            }
            #endregion

            #region campo dinheiro

            decimal.TryParse(txtDinheiro.Text, out decimal dinheiro);
            if (decimal.TryParse(txtConfirmaDinheiro.Text, out decimal confirmaDinheiro))
            {
                if (dinheiro == confirmaDinheiro)
                {
                    btnConfirmaDinheiro.Tag = "ok";
                    btnConfirmaDinheiro.BackgroundImage = Properties.Resources.icon_ok;
                }
                else
                {
                    btnConfirmaDinheiro.Tag = "close";
                    btnConfirmaDinheiro.BackgroundImage = Properties.Resources.icon_close;
                }

                lblMenssagem.Text = "";
            }
            else
            {
                lblMenssagem.Text = "Informe somente números!";
            }
            #endregion
        }

        private void txtConfirmaCheque_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtConfirmaCheque);
            ValidarCamposFechamento();
        }

        private void txtConfirmaCredito_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtConfirmaCredito);
            ValidarCamposFechamento();
        }

        private void txtConfirmaDebito_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtConfirmaDebito);
            ValidarCamposFechamento();
        }

        private void txtConfirmaDinheiro_TextChanged(object sender, EventArgs e)
        {
            Formatacao.Moeda(ref txtConfirmaDinheiro);
            ValidarCamposFechamento();
        }

        #endregion

        private void txtsFechamento_MouseLeave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length == 0)
                textBox.Text = "0,00";
        }

        private void txtsFechamento_MouseHover(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void txtsConfirmaFechamento(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void txtCodigoMovimento_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtCaixa_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        private void txtFaturamentoReal_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaDebito_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaDinheiro_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaCredito_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaCheque_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaBoleto_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtSenhaResponsavel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginResponsavel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtOcorrencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void txtDinheiro_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtDebito_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtCredito_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtCheque_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtBoleto_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtSangria_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtSuprimento_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTrocoInicial_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtFaturamento_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalheFaturamentoReal_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDetalheFormaPagto(Detalhe.FATURAMENTOREAL);
            }
            catch (Exception ex)
            {
                Erro.ExibirMenssagemException(ex);
            }
        }
    }
}
