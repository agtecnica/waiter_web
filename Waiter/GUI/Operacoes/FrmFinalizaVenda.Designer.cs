using System.Windows.Forms;

namespace GUI.Operacoes
{
    partial class FrmFinalizaVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbFormaPgto = new System.Windows.Forms.GroupBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.cmbFormaPgto = new System.Windows.Forms.ComboBox();
            this.pnlFinalizarCancelar = new System.Windows.Forms.Panel();
            this.btnAcrescimo = new System.Windows.Forms.Button();
            this.btnDesconto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.gbResumoVenda = new System.Windows.Forms.GroupBox();
            this.lblTrocoValor = new System.Windows.Forms.Label();
            this.lblSaldoRestanteValor = new System.Windows.Forms.Label();
            this.lblValorRecebidoValor = new System.Windows.Forms.Label();
            this.lblTotalReceberValor = new System.Windows.Forms.Label();
            this.lblAcrescimoValor = new System.Windows.Forms.Label();
            this.lblDescontoValor = new System.Windows.Forms.Label();
            this.lblTotalVendaValor = new System.Windows.Forms.Label();
            this.lblTrocoDesc = new System.Windows.Forms.Label();
            this.lblSaldoRestanteDesc = new System.Windows.Forms.Label();
            this.lblValorRecebidoDesc = new System.Windows.Forms.Label();
            this.lblTotalReceberDesc = new System.Windows.Forms.Label();
            this.lblAcrescimoDesc = new System.Windows.Forms.Label();
            this.lblDescontoDesc = new System.Windows.Forms.Label();
            this.lblTotalVendaDesc = new System.Windows.Forms.Label();
            this.lblBoxTroco = new System.Windows.Forms.Label();
            this.lblBoxSaldoRestante = new System.Windows.Forms.Label();
            this.lblBoxValorRecebido = new System.Windows.Forms.Label();
            this.lblBoxTotalReceber = new System.Windows.Forms.Label();
            this.lblBoxAcrescimo = new System.Windows.Forms.Label();
            this.lblBoxDesconto = new System.Windows.Forms.Label();
            this.lblBoxValorTotal = new System.Windows.Forms.Label();
            this.gbValoresInformados = new System.Windows.Forms.GroupBox();
            this.dgvGeral = new System.Windows.Forms.DataGridView();
            this.pnlAddFormaEValor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNao = new System.Windows.Forms.Button();
            this.btnSim = new System.Windows.Forms.Button();
            this.pnlMensagem = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.documento = new System.Drawing.Printing.PrintDocument();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFormaPgto.SuspendLayout();
            this.pnlFinalizarCancelar.SuspendLayout();
            this.gbResumoVenda.SuspendLayout();
            this.gbValoresInformados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).BeginInit();
            this.pnlAddFormaEValor.SuspendLayout();
            this.pnlMensagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormaPgto
            // 
            this.gbFormaPgto.BackColor = System.Drawing.Color.Green;
            this.gbFormaPgto.Controls.Add(this.txtValorPago);
            this.gbFormaPgto.Controls.Add(this.cmbFormaPgto);
            this.gbFormaPgto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.gbFormaPgto.ForeColor = System.Drawing.Color.Black;
            this.gbFormaPgto.Location = new System.Drawing.Point(12, 13);
            this.gbFormaPgto.Name = "gbFormaPgto";
            this.gbFormaPgto.Size = new System.Drawing.Size(718, 79);
            this.gbFormaPgto.TabIndex = 0;
            this.gbFormaPgto.TabStop = false;
            this.gbFormaPgto.Text = "Forma de Pagamento e Valor:";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(375, 36);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(335, 27);
            this.txtValorPago.TabIndex = 2;
            this.txtValorPago.Text = "0,00";
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtValorPago_TextChanged);
            this.txtValorPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorPago_KeyDown);
            this.txtValorPago.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorPago_KeyUp);
            // 
            // cmbFormaPgto
            // 
            this.cmbFormaPgto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbFormaPgto.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.cmbFormaPgto.FormattingEnabled = true;
            this.cmbFormaPgto.Location = new System.Drawing.Point(7, 36);
            this.cmbFormaPgto.Name = "cmbFormaPgto";
            this.cmbFormaPgto.Size = new System.Drawing.Size(362, 28);
            this.cmbFormaPgto.TabIndex = 1;
            this.cmbFormaPgto.TabStop = false;
            this.cmbFormaPgto.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPgto_SelectedIndexChanged);
            this.cmbFormaPgto.GotFocus += new System.EventHandler(this.cmbFormaPgto_OnGotFocus);
            this.cmbFormaPgto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFormaPgto_KeyUp);
            // 
            // pnlFinalizarCancelar
            // 
            this.pnlFinalizarCancelar.BackColor = System.Drawing.Color.Green;
            this.pnlFinalizarCancelar.Controls.Add(this.btnAcrescimo);
            this.pnlFinalizarCancelar.Controls.Add(this.btnDesconto);
            this.pnlFinalizarCancelar.Controls.Add(this.btnCancelar);
            this.pnlFinalizarCancelar.Controls.Add(this.btnFinalizar);
            this.pnlFinalizarCancelar.Location = new System.Drawing.Point(12, 5);
            this.pnlFinalizarCancelar.Name = "pnlFinalizarCancelar";
            this.pnlFinalizarCancelar.Size = new System.Drawing.Size(717, 37);
            this.pnlFinalizarCancelar.TabIndex = 6;
            // 
            // btnAcrescimo
            // 
            this.btnAcrescimo.BackColor = System.Drawing.Color.Gray;
            this.btnAcrescimo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.btnAcrescimo.ForeColor = System.Drawing.Color.White;
            this.btnAcrescimo.Location = new System.Drawing.Point(6, 3);
            this.btnAcrescimo.Name = "btnAcrescimo";
            this.btnAcrescimo.Size = new System.Drawing.Size(170, 30);
            this.btnAcrescimo.TabIndex = 2;
            this.btnAcrescimo.TabStop = false;
            this.btnAcrescimo.Text = "Desconto (F10)";
            this.btnAcrescimo.UseVisualStyleBackColor = false;
            this.btnAcrescimo.Click += new System.EventHandler(this.btnAcrescimo_Click);
            // 
            // btnDesconto
            // 
            this.btnDesconto.BackColor = System.Drawing.Color.Gray;
            this.btnDesconto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.btnDesconto.ForeColor = System.Drawing.Color.White;
            this.btnDesconto.Location = new System.Drawing.Point(184, 4);
            this.btnDesconto.Name = "btnDesconto";
            this.btnDesconto.Size = new System.Drawing.Size(170, 30);
            this.btnDesconto.TabIndex = 3;
            this.btnDesconto.TabStop = false;
            this.btnDesconto.Text = "Acréscimo (F11)";
            this.btnDesconto.UseVisualStyleBackColor = false;
            this.btnDesconto.Click += new System.EventHandler(this.btnDesconto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(540, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar (ESC)";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.Gray;
            this.btnFinalizar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(362, 4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(170, 30);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.TabStop = false;
            this.btnFinalizar.Text = "Finalizar (F12)";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // gbResumoVenda
            // 
            this.gbResumoVenda.AccessibleDescription = " ";
            this.gbResumoVenda.BackColor = System.Drawing.SystemColors.Control;
            this.gbResumoVenda.Controls.Add(this.lblTrocoValor);
            this.gbResumoVenda.Controls.Add(this.lblSaldoRestanteValor);
            this.gbResumoVenda.Controls.Add(this.lblValorRecebidoValor);
            this.gbResumoVenda.Controls.Add(this.lblTotalReceberValor);
            this.gbResumoVenda.Controls.Add(this.lblAcrescimoValor);
            this.gbResumoVenda.Controls.Add(this.lblDescontoValor);
            this.gbResumoVenda.Controls.Add(this.lblTotalVendaValor);
            this.gbResumoVenda.Controls.Add(this.lblTrocoDesc);
            this.gbResumoVenda.Controls.Add(this.lblSaldoRestanteDesc);
            this.gbResumoVenda.Controls.Add(this.lblValorRecebidoDesc);
            this.gbResumoVenda.Controls.Add(this.lblTotalReceberDesc);
            this.gbResumoVenda.Controls.Add(this.lblAcrescimoDesc);
            this.gbResumoVenda.Controls.Add(this.lblDescontoDesc);
            this.gbResumoVenda.Controls.Add(this.lblTotalVendaDesc);
            this.gbResumoVenda.Controls.Add(this.lblBoxTroco);
            this.gbResumoVenda.Controls.Add(this.lblBoxSaldoRestante);
            this.gbResumoVenda.Controls.Add(this.lblBoxValorRecebido);
            this.gbResumoVenda.Controls.Add(this.lblBoxTotalReceber);
            this.gbResumoVenda.Controls.Add(this.lblBoxAcrescimo);
            this.gbResumoVenda.Controls.Add(this.lblBoxDesconto);
            this.gbResumoVenda.Controls.Add(this.lblBoxValorTotal);
            this.gbResumoVenda.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.gbResumoVenda.Location = new System.Drawing.Point(10, 93);
            this.gbResumoVenda.Name = "gbResumoVenda";
            this.gbResumoVenda.Size = new System.Drawing.Size(380, 328);
            this.gbResumoVenda.TabIndex = 1;
            this.gbResumoVenda.TabStop = false;
            this.gbResumoVenda.Text = "Resumo da Venda:";
            // 
            // lblTrocoValor
            // 
            this.lblTrocoValor.BackColor = System.Drawing.Color.White;
            this.lblTrocoValor.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold);
            this.lblTrocoValor.ForeColor = System.Drawing.Color.Red;
            this.lblTrocoValor.Location = new System.Drawing.Point(151, 290);
            this.lblTrocoValor.Name = "lblTrocoValor";
            this.lblTrocoValor.Size = new System.Drawing.Size(209, 27);
            this.lblTrocoValor.TabIndex = 20;
            this.lblTrocoValor.Text = "0,00";
            this.lblTrocoValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldoRestanteValor
            // 
            this.lblSaldoRestanteValor.BackColor = System.Drawing.Color.White;
            this.lblSaldoRestanteValor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblSaldoRestanteValor.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoRestanteValor.Location = new System.Drawing.Point(151, 252);
            this.lblSaldoRestanteValor.Name = "lblSaldoRestanteValor";
            this.lblSaldoRestanteValor.Size = new System.Drawing.Size(209, 17);
            this.lblSaldoRestanteValor.TabIndex = 19;
            this.lblSaldoRestanteValor.Text = "0,00";
            this.lblSaldoRestanteValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValorRecebidoValor
            // 
            this.lblValorRecebidoValor.BackColor = System.Drawing.Color.White;
            this.lblValorRecebidoValor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorRecebidoValor.ForeColor = System.Drawing.Color.Green;
            this.lblValorRecebidoValor.Location = new System.Drawing.Point(151, 209);
            this.lblValorRecebidoValor.Name = "lblValorRecebidoValor";
            this.lblValorRecebidoValor.Size = new System.Drawing.Size(209, 17);
            this.lblValorRecebidoValor.TabIndex = 18;
            this.lblValorRecebidoValor.Text = "0,00";
            this.lblValorRecebidoValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalReceberValor
            // 
            this.lblTotalReceberValor.BackColor = System.Drawing.Color.White;
            this.lblTotalReceberValor.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalReceberValor.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalReceberValor.Location = new System.Drawing.Point(151, 161);
            this.lblTotalReceberValor.Name = "lblTotalReceberValor";
            this.lblTotalReceberValor.Size = new System.Drawing.Size(209, 26);
            this.lblTotalReceberValor.TabIndex = 17;
            this.lblTotalReceberValor.Text = "0,00";
            this.lblTotalReceberValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAcrescimoValor
            // 
            this.lblAcrescimoValor.BackColor = System.Drawing.Color.White;
            this.lblAcrescimoValor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblAcrescimoValor.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblAcrescimoValor.Location = new System.Drawing.Point(151, 123);
            this.lblAcrescimoValor.Name = "lblAcrescimoValor";
            this.lblAcrescimoValor.Size = new System.Drawing.Size(209, 17);
            this.lblAcrescimoValor.TabIndex = 16;
            this.lblAcrescimoValor.Text = "0,00";
            this.lblAcrescimoValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescontoValor
            // 
            this.lblDescontoValor.BackColor = System.Drawing.Color.White;
            this.lblDescontoValor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescontoValor.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDescontoValor.Location = new System.Drawing.Point(151, 80);
            this.lblDescontoValor.Name = "lblDescontoValor";
            this.lblDescontoValor.Size = new System.Drawing.Size(209, 17);
            this.lblDescontoValor.TabIndex = 15;
            this.lblDescontoValor.Text = "0,00";
            this.lblDescontoValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalVendaValor
            // 
            this.lblTotalVendaValor.BackColor = System.Drawing.Color.White;
            this.lblTotalVendaValor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendaValor.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalVendaValor.Location = new System.Drawing.Point(151, 37);
            this.lblTotalVendaValor.Name = "lblTotalVendaValor";
            this.lblTotalVendaValor.Size = new System.Drawing.Size(209, 17);
            this.lblTotalVendaValor.TabIndex = 14;
            this.lblTotalVendaValor.Text = "0,00";
            this.lblTotalVendaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrocoDesc
            // 
            this.lblTrocoDesc.AutoSize = true;
            this.lblTrocoDesc.BackColor = System.Drawing.Color.White;
            this.lblTrocoDesc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrocoDesc.ForeColor = System.Drawing.Color.Red;
            this.lblTrocoDesc.Location = new System.Drawing.Point(15, 295);
            this.lblTrocoDesc.Name = "lblTrocoDesc";
            this.lblTrocoDesc.Size = new System.Drawing.Size(65, 18);
            this.lblTrocoDesc.TabIndex = 13;
            this.lblTrocoDesc.Text = "Troco:";
            // 
            // lblSaldoRestanteDesc
            // 
            this.lblSaldoRestanteDesc.AutoSize = true;
            this.lblSaldoRestanteDesc.BackColor = System.Drawing.Color.White;
            this.lblSaldoRestanteDesc.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoRestanteDesc.Location = new System.Drawing.Point(15, 252);
            this.lblSaldoRestanteDesc.Name = "lblSaldoRestanteDesc";
            this.lblSaldoRestanteDesc.Size = new System.Drawing.Size(130, 17);
            this.lblSaldoRestanteDesc.TabIndex = 12;
            this.lblSaldoRestanteDesc.Text = "Saldo Restante:";
            // 
            // lblValorRecebidoDesc
            // 
            this.lblValorRecebidoDesc.AutoSize = true;
            this.lblValorRecebidoDesc.BackColor = System.Drawing.Color.White;
            this.lblValorRecebidoDesc.ForeColor = System.Drawing.Color.Green;
            this.lblValorRecebidoDesc.Location = new System.Drawing.Point(15, 209);
            this.lblValorRecebidoDesc.Name = "lblValorRecebidoDesc";
            this.lblValorRecebidoDesc.Size = new System.Drawing.Size(131, 17);
            this.lblValorRecebidoDesc.TabIndex = 11;
            this.lblValorRecebidoDesc.Text = "Valor Recebido:";
            // 
            // lblTotalReceberDesc
            // 
            this.lblTotalReceberDesc.AutoSize = true;
            this.lblTotalReceberDesc.BackColor = System.Drawing.Color.White;
            this.lblTotalReceberDesc.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalReceberDesc.Location = new System.Drawing.Point(15, 166);
            this.lblTotalReceberDesc.Name = "lblTotalReceberDesc";
            this.lblTotalReceberDesc.Size = new System.Drawing.Size(135, 17);
            this.lblTotalReceberDesc.TabIndex = 10;
            this.lblTotalReceberDesc.Text = "Total a Receber:";
            // 
            // lblAcrescimoDesc
            // 
            this.lblAcrescimoDesc.AutoSize = true;
            this.lblAcrescimoDesc.BackColor = System.Drawing.Color.White;
            this.lblAcrescimoDesc.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblAcrescimoDesc.Location = new System.Drawing.Point(15, 123);
            this.lblAcrescimoDesc.Name = "lblAcrescimoDesc";
            this.lblAcrescimoDesc.Size = new System.Drawing.Size(93, 17);
            this.lblAcrescimoDesc.TabIndex = 9;
            this.lblAcrescimoDesc.Text = "Acréscimo:";
            // 
            // lblDescontoDesc
            // 
            this.lblDescontoDesc.AutoSize = true;
            this.lblDescontoDesc.BackColor = System.Drawing.Color.White;
            this.lblDescontoDesc.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDescontoDesc.Location = new System.Drawing.Point(15, 80);
            this.lblDescontoDesc.Name = "lblDescontoDesc";
            this.lblDescontoDesc.Size = new System.Drawing.Size(86, 17);
            this.lblDescontoDesc.TabIndex = 8;
            this.lblDescontoDesc.Text = "Desconto:";
            // 
            // lblTotalVendaDesc
            // 
            this.lblTotalVendaDesc.AutoSize = true;
            this.lblTotalVendaDesc.BackColor = System.Drawing.Color.White;
            this.lblTotalVendaDesc.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalVendaDesc.Location = new System.Drawing.Point(15, 37);
            this.lblTotalVendaDesc.Name = "lblTotalVendaDesc";
            this.lblTotalVendaDesc.Size = new System.Drawing.Size(107, 17);
            this.lblTotalVendaDesc.TabIndex = 7;
            this.lblTotalVendaDesc.Text = "Total Venda:";
            // 
            // lblBoxTroco
            // 
            this.lblBoxTroco.BackColor = System.Drawing.Color.White;
            this.lblBoxTroco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxTroco.Location = new System.Drawing.Point(7, 286);
            this.lblBoxTroco.Name = "lblBoxTroco";
            this.lblBoxTroco.Size = new System.Drawing.Size(364, 35);
            this.lblBoxTroco.TabIndex = 6;
            this.lblBoxTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxSaldoRestante
            // 
            this.lblBoxSaldoRestante.BackColor = System.Drawing.Color.White;
            this.lblBoxSaldoRestante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxSaldoRestante.Location = new System.Drawing.Point(7, 243);
            this.lblBoxSaldoRestante.Name = "lblBoxSaldoRestante";
            this.lblBoxSaldoRestante.Size = new System.Drawing.Size(364, 35);
            this.lblBoxSaldoRestante.TabIndex = 5;
            this.lblBoxSaldoRestante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxValorRecebido
            // 
            this.lblBoxValorRecebido.BackColor = System.Drawing.Color.White;
            this.lblBoxValorRecebido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxValorRecebido.Location = new System.Drawing.Point(7, 200);
            this.lblBoxValorRecebido.Name = "lblBoxValorRecebido";
            this.lblBoxValorRecebido.Size = new System.Drawing.Size(364, 35);
            this.lblBoxValorRecebido.TabIndex = 4;
            this.lblBoxValorRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxTotalReceber
            // 
            this.lblBoxTotalReceber.BackColor = System.Drawing.Color.White;
            this.lblBoxTotalReceber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxTotalReceber.Location = new System.Drawing.Point(7, 157);
            this.lblBoxTotalReceber.Name = "lblBoxTotalReceber";
            this.lblBoxTotalReceber.Size = new System.Drawing.Size(364, 35);
            this.lblBoxTotalReceber.TabIndex = 3;
            this.lblBoxTotalReceber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxAcrescimo
            // 
            this.lblBoxAcrescimo.BackColor = System.Drawing.Color.White;
            this.lblBoxAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxAcrescimo.Location = new System.Drawing.Point(7, 114);
            this.lblBoxAcrescimo.Name = "lblBoxAcrescimo";
            this.lblBoxAcrescimo.Size = new System.Drawing.Size(364, 35);
            this.lblBoxAcrescimo.TabIndex = 2;
            this.lblBoxAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxDesconto
            // 
            this.lblBoxDesconto.BackColor = System.Drawing.Color.White;
            this.lblBoxDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxDesconto.Location = new System.Drawing.Point(7, 71);
            this.lblBoxDesconto.Name = "lblBoxDesconto";
            this.lblBoxDesconto.Size = new System.Drawing.Size(364, 35);
            this.lblBoxDesconto.TabIndex = 1;
            this.lblBoxDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBoxValorTotal
            // 
            this.lblBoxValorTotal.BackColor = System.Drawing.Color.White;
            this.lblBoxValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBoxValorTotal.Location = new System.Drawing.Point(7, 28);
            this.lblBoxValorTotal.Name = "lblBoxValorTotal";
            this.lblBoxValorTotal.Size = new System.Drawing.Size(364, 35);
            this.lblBoxValorTotal.TabIndex = 0;
            this.lblBoxValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbValoresInformados
            // 
            this.gbValoresInformados.BackColor = System.Drawing.SystemColors.Control;
            this.gbValoresInformados.Controls.Add(this.dgvGeral);
            this.gbValoresInformados.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.gbValoresInformados.Location = new System.Drawing.Point(396, 93);
            this.gbValoresInformados.Name = "gbValoresInformados";
            this.gbValoresInformados.Size = new System.Drawing.Size(334, 327);
            this.gbValoresInformados.TabIndex = 2;
            this.gbValoresInformados.TabStop = false;
            this.gbValoresInformados.Text = "Valores Informados:";
            // 
            // dgvGeral
            // 
            this.dgvGeral.AllowUserToAddRows = false;
            this.dgvGeral.AllowUserToDeleteRows = false;
            this.dgvGeral.AllowUserToOrderColumns = true;
            this.dgvGeral.AllowUserToResizeColumns = false;
            this.dgvGeral.AllowUserToResizeRows = false;
            this.dgvGeral.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvGeral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGeral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGeral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeral.ColumnHeadersHeight = 20;
            this.dgvGeral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.item,
            this.valorPago});
            this.dgvGeral.EnableHeadersVisualStyles = false;
            this.dgvGeral.Location = new System.Drawing.Point(7, 28);
            this.dgvGeral.Name = "dgvGeral";
            this.dgvGeral.ReadOnly = true;
            this.dgvGeral.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGeral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeral.Size = new System.Drawing.Size(321, 293);
            this.dgvGeral.TabIndex = 0;
            this.dgvGeral.TabStop = false;
            // 
            // pnlAddFormaEValor
            // 
            this.pnlAddFormaEValor.BackColor = System.Drawing.Color.Green;
            this.pnlAddFormaEValor.Controls.Add(this.label1);
            this.pnlAddFormaEValor.Controls.Add(this.btnNao);
            this.pnlAddFormaEValor.Controls.Add(this.btnSim);
            this.pnlAddFormaEValor.Location = new System.Drawing.Point(13, 432);
            this.pnlAddFormaEValor.Name = "pnlAddFormaEValor";
            this.pnlAddFormaEValor.Size = new System.Drawing.Size(717, 35);
            this.pnlAddFormaEValor.TabIndex = 5;
            this.pnlAddFormaEValor.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Confirma a forma de pagamento e valor?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNao
            // 
            this.btnNao.BackColor = System.Drawing.Color.Gray;
            this.btnNao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNao.ForeColor = System.Drawing.Color.White;
            this.btnNao.Location = new System.Drawing.Point(553, 3);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(158, 30);
            this.btnNao.TabIndex = 6;
            this.btnNao.TabStop = false;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = false;
            this.btnNao.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // btnSim
            // 
            this.btnSim.BackColor = System.Drawing.Color.Gray;
            this.btnSim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSim.ForeColor = System.Drawing.Color.White;
            this.btnSim.Location = new System.Drawing.Point(389, 3);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(158, 30);
            this.btnSim.TabIndex = 6;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = false;
            this.btnSim.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // pnlMensagem
            // 
            this.pnlMensagem.BackColor = System.Drawing.Color.Green;
            this.pnlMensagem.Controls.Add(this.lblMensagem);
            this.pnlMensagem.Location = new System.Drawing.Point(12, 471);
            this.pnlMensagem.Name = "pnlMensagem";
            this.pnlMensagem.Size = new System.Drawing.Size(717, 35);
            this.pnlMensagem.TabIndex = 8;
            // 
            // lblMensagem
            // 
            this.lblMensagem.BackColor = System.Drawing.Color.Green;
            this.lblMensagem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.White;
            this.lblMensagem.Location = new System.Drawing.Point(7, 6);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(704, 23);
            this.lblMensagem.TabIndex = 7;
            this.lblMensagem.Text = "AMS SOFT - Sistemas para Automação Comercial";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // documento
            // 
            this.documento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.documento_PrintPage);
            // 
            // ItemId
            // 
            this.ItemId.HeaderText = "Forma Id";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // item
            // 
            this.item.HeaderText = "Forma";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // valorPago
            // 
            this.valorPago.HeaderText = "Valor";
            this.valorPago.Name = "valorPago";
            this.valorPago.ReadOnly = true;
            // 
            // FrmFinalizaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(742, 514);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMensagem);
            this.Controls.Add(this.pnlFinalizarCancelar);
            this.Controls.Add(this.pnlAddFormaEValor);
            this.Controls.Add(this.gbValoresInformados);
            this.Controls.Add(this.gbResumoVenda);
            this.Controls.Add(this.gbFormaPgto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFinalizaVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finalizar Venda";
            this.Load += new System.EventHandler(this.FrmFinalizaVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFinalizaVenda_KeyDown);
            this.gbFormaPgto.ResumeLayout(false);
            this.gbFormaPgto.PerformLayout();
            this.pnlFinalizarCancelar.ResumeLayout(false);
            this.gbResumoVenda.ResumeLayout(false);
            this.gbResumoVenda.PerformLayout();
            this.gbValoresInformados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).EndInit();
            this.pnlAddFormaEValor.ResumeLayout(false);
            this.pnlMensagem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormaPgto;
        private System.Windows.Forms.GroupBox gbResumoVenda;
        private System.Windows.Forms.Label lblBoxTroco;
        private System.Windows.Forms.Label lblBoxSaldoRestante;
        private System.Windows.Forms.Label lblBoxValorRecebido;
        private System.Windows.Forms.Label lblBoxTotalReceber;
        private System.Windows.Forms.Label lblBoxAcrescimo;
        private System.Windows.Forms.Label lblBoxDesconto;
        private System.Windows.Forms.Label lblBoxValorTotal;
        private System.Windows.Forms.GroupBox gbValoresInformados;
        private System.Windows.Forms.Label lblTrocoDesc;
        private System.Windows.Forms.Label lblSaldoRestanteDesc;
        private System.Windows.Forms.Label lblValorRecebidoDesc;
        private System.Windows.Forms.Label lblTotalReceberDesc;
        private System.Windows.Forms.Label lblAcrescimoDesc;
        private System.Windows.Forms.Label lblDescontoDesc;
        private System.Windows.Forms.Label lblTotalVendaDesc;
        private System.Windows.Forms.ComboBox cmbFormaPgto;
        private System.Windows.Forms.Label lblTrocoValor;
        private System.Windows.Forms.Label lblValorRecebidoValor;
        private System.Windows.Forms.Label lblTotalVendaValor;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlFinalizarCancelar;
        private System.Windows.Forms.Panel pnlAddFormaEValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnSim;
        private System.Windows.Forms.Button btnAcrescimo;
        private System.Windows.Forms.Button btnDesconto;
        public System.Windows.Forms.Label lblDescontoValor;
        internal System.Windows.Forms.Label lblSaldoRestanteValor;
        internal System.Windows.Forms.Label lblTotalReceberValor;
        internal System.Windows.Forms.Label lblAcrescimoValor;
        private System.Drawing.Printing.PrintDocument documento;
        private System.Windows.Forms.Panel pnlMensagem;
        private System.Windows.Forms.Label lblMensagem;
        private TextBox txtValorPago;
        private DataGridViewTextBoxColumn ItemId;
        private DataGridViewTextBoxColumn item;
        private DataGridViewTextBoxColumn valorPago;
        internal DataGridView dgvGeral;
    }
}