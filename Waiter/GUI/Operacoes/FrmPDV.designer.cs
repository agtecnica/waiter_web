namespace GUI.Operacoes
{
    partial class FrmPDV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnOrcamento = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnNovaVenda = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelValores = new System.Windows.Forms.Panel();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecoTotal = new System.Windows.Forms.Label();
            this.txtPrecoUnit = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblLancarValor = new System.Windows.Forms.Label();
            this.pbLogotipo = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGeral = new System.Windows.Forms.DataGridView();
            this.numeroItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutosId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusCaixa = new System.Windows.Forms.Label();
            this.panelDescricaoProduto = new System.Windows.Forms.Panel();
            this.lblProduto = new System.Windows.Forms.Label();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.lblOperador = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogotipo)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.panelDescricaoProduto.SuspendLayout();
            this.panelTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelRodape.Controls.Add(this.btnFinalizarVenda);
            this.panelRodape.Controls.Add(this.btnClientes);
            this.panelRodape.Controls.Add(this.btnProdutos);
            this.panelRodape.Controls.Add(this.btnOrcamento);
            this.panelRodape.Controls.Add(this.btnCancelarVenda);
            this.panelRodape.Controls.Add(this.btnExcluirItem);
            this.panelRodape.Controls.Add(this.btnNovaVenda);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 721);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(1173, 65);
            this.panelRodape.TabIndex = 40;
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.BackColor = System.Drawing.Color.White;
            this.btnFinalizarVenda.Location = new System.Drawing.Point(837, 3);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(167, 59);
            this.btnFinalizarVenda.TabIndex = 47;
            this.btnFinalizarVenda.TabStop = false;
            this.btnFinalizarVenda.Text = "F7 - Finalizar Venda";
            this.btnFinalizarVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinalizarVenda.UseVisualStyleBackColor = false;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(670, 3);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(167, 59);
            this.btnClientes.TabIndex = 45;
            this.btnClientes.TabStop = false;
            this.btnClientes.Text = "F5 - Clientes";
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.Color.White;
            this.btnProdutos.Location = new System.Drawing.Point(503, 3);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(167, 59);
            this.btnProdutos.TabIndex = 44;
            this.btnProdutos.TabStop = false;
            this.btnProdutos.Text = "F4 - Produtos";
            this.btnProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnOrcamento
            // 
            this.btnOrcamento.BackColor = System.Drawing.Color.White;
            this.btnOrcamento.Location = new System.Drawing.Point(1004, 3);
            this.btnOrcamento.Name = "btnOrcamento";
            this.btnOrcamento.Size = new System.Drawing.Size(167, 59);
            this.btnOrcamento.TabIndex = 43;
            this.btnOrcamento.TabStop = false;
            this.btnOrcamento.Text = "F4 - Orçamento";
            this.btnOrcamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrcamento.UseVisualStyleBackColor = false;
            this.btnOrcamento.Visible = false;
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.White;
            this.btnCancelarVenda.Location = new System.Drawing.Point(169, 3);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(167, 59);
            this.btnCancelarVenda.TabIndex = 42;
            this.btnCancelarVenda.TabStop = false;
            this.btnCancelarVenda.Text = "F2 - Cancelar Venda";
            this.btnCancelarVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.BackColor = System.Drawing.Color.White;
            this.btnExcluirItem.Location = new System.Drawing.Point(336, 3);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(167, 59);
            this.btnExcluirItem.TabIndex = 41;
            this.btnExcluirItem.TabStop = false;
            this.btnExcluirItem.Text = "F3 - Excluir Item";
            this.btnExcluirItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluirItem.UseVisualStyleBackColor = false;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            // 
            // btnNovaVenda
            // 
            this.btnNovaVenda.BackColor = System.Drawing.Color.White;
            this.btnNovaVenda.Location = new System.Drawing.Point(2, 3);
            this.btnNovaVenda.Name = "btnNovaVenda";
            this.btnNovaVenda.Size = new System.Drawing.Size(167, 59);
            this.btnNovaVenda.TabIndex = 40;
            this.btnNovaVenda.TabStop = false;
            this.btnNovaVenda.Text = "F1 - Nova venda";
            this.btnNovaVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovaVenda.UseVisualStyleBackColor = false;
            this.btnNovaVenda.Click += new System.EventHandler(this.btnNovaVenda_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelValores);
            this.panelPrincipal.Controls.Add(this.panelGrid);
            this.panelPrincipal.Controls.Add(this.pnlStatus);
            this.panelPrincipal.Controls.Add(this.panelDescricaoProduto);
            this.panelPrincipal.Controls.Add(this.panelTopo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1173, 721);
            this.panelPrincipal.TabIndex = 41;
            // 
            // panelValores
            // 
            this.panelValores.Controls.Add(this.lblValorTotal);
            this.panelValores.Controls.Add(this.label12);
            this.panelValores.Controls.Add(this.label10);
            this.panelValores.Controls.Add(this.label3);
            this.panelValores.Controls.Add(this.txtPrecoTotal);
            this.panelValores.Controls.Add(this.txtPrecoUnit);
            this.panelValores.Controls.Add(this.txtQtde);
            this.panelValores.Controls.Add(this.label5);
            this.panelValores.Controls.Add(this.txtCodigo);
            this.panelValores.Controls.Add(this.lblLancarValor);
            this.panelValores.Controls.Add(this.pbLogotipo);
            this.panelValores.Controls.Add(this.label15);
            this.panelValores.Controls.Add(this.label6);
            this.panelValores.Controls.Add(this.label4);
            this.panelValores.Controls.Add(this.label1);
            this.panelValores.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelValores.Location = new System.Drawing.Point(660, 116);
            this.panelValores.Name = "panelValores";
            this.panelValores.Size = new System.Drawing.Size(513, 535);
            this.panelValores.TabIndex = 3;
            this.panelValores.Paint += new System.Windows.Forms.PaintEventHandler(this.panelValores_Paint);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotal.Font = new System.Drawing.Font("Tahoma", 32F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.Firebrick;
            this.lblValorTotal.Location = new System.Drawing.Point(3, 402);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(422, 52);
            this.lblValorTotal.TabIndex = 200;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(331, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 53);
            this.label12.TabIndex = 47;
            this.label12.Text = "0,00";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(249, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 53);
            this.label10.TabIndex = 45;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total Geral";
            // 
            // txtPrecoTotal
            // 
            this.txtPrecoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoTotal.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.txtPrecoTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPrecoTotal.Location = new System.Drawing.Point(3, 304);
            this.txtPrecoTotal.Name = "txtPrecoTotal";
            this.txtPrecoTotal.Size = new System.Drawing.Size(229, 53);
            this.txtPrecoTotal.TabIndex = 44;
            this.txtPrecoTotal.Text = "0,00";
            this.txtPrecoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrecoUnit
            // 
            this.txtPrecoUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoUnit.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.txtPrecoUnit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPrecoUnit.Location = new System.Drawing.Point(3, 209);
            this.txtPrecoUnit.Name = "txtPrecoUnit";
            this.txtPrecoUnit.Size = new System.Drawing.Size(229, 53);
            this.txtPrecoUnit.TabIndex = 43;
            this.txtPrecoUnit.Text = "0,00";
            this.txtPrecoUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.White;
            this.txtQtde.Font = new System.Drawing.Font("Verdana", 28F);
            this.txtQtde.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtQtde.Location = new System.Drawing.Point(3, 112);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(229, 53);
            this.txtQtde.TabIndex = 42;
            this.txtQtde.TabStop = false;
            this.txtQtde.Text = "1,000";
            this.txtQtde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtde_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(245, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Estoque";
            this.label5.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(3, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(229, 46);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // lblLancarValor
            // 
            this.lblLancarValor.AutoSize = true;
            this.lblLancarValor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLancarValor.Location = new System.Drawing.Point(327, 297);
            this.lblLancarValor.Name = "lblLancarValor";
            this.lblLancarValor.Size = new System.Drawing.Size(111, 19);
            this.lblLancarValor.TabIndex = 12;
            this.lblLancarValor.Text = "Lançar Valor";
            this.lblLancarValor.Visible = false;
            // 
            // pbLogotipo
            // 
            this.pbLogotipo.BackColor = System.Drawing.Color.White;
            this.pbLogotipo.BackgroundImage = global::GUI.Properties.Resources.nutrir;
            this.pbLogotipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogotipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogotipo.Location = new System.Drawing.Point(249, 9);
            this.pbLogotipo.Name = "pbLogotipo";
            this.pbLogotipo.Size = new System.Drawing.Size(256, 262);
            this.pbLogotipo.TabIndex = 11;
            this.pbLogotipo.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(-1, 282);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 19);
            this.label15.TabIndex = 6;
            this.label15.Text = "Subtotal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-1, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor Unitário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantidade / F8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código / Código de Barras";
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.Controls.Add(this.label2);
            this.panelGrid.Controls.Add(this.dgvGeral);
            this.panelGrid.Location = new System.Drawing.Point(0, 116);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(654, 535);
            this.panelGrid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Firebrick;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 44);
            this.label2.TabIndex = 15;
            this.label2.Text = "LISTA DE PRODUTOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvGeral
            // 
            this.dgvGeral.AllowUserToAddRows = false;
            this.dgvGeral.AllowUserToDeleteRows = false;
            this.dgvGeral.AllowUserToResizeColumns = false;
            this.dgvGeral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGeral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGeral.BackgroundColor = System.Drawing.Color.White;
            this.dgvGeral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGeral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGeral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroItem,
            this.ProdutosId_,
            this.Descricao,
            this.Quantidade,
            this.ValorUnitario,
            this.ValorTotal});
            this.dgvGeral.GridColor = System.Drawing.Color.White;
            this.dgvGeral.Location = new System.Drawing.Point(8, 52);
            this.dgvGeral.MultiSelect = false;
            this.dgvGeral.Name = "dgvGeral";
            this.dgvGeral.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvGeral.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGeral.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGeral.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGeral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeral.Size = new System.Drawing.Size(638, 474);
            this.dgvGeral.TabIndex = 199;
            this.dgvGeral.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // numeroItem
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numeroItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.numeroItem.HeaderText = "N°Item";
            this.numeroItem.Name = "numeroItem";
            this.numeroItem.ReadOnly = true;
            this.numeroItem.Width = 60;
            // 
            // ProdutosId_
            // 
            this.ProdutosId_.HeaderText = "Código";
            this.ProdutosId_.Name = "ProdutosId_";
            this.ProdutosId_.ReadOnly = true;
            this.ProdutosId_.Width = 90;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Quantidade
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle4;
            this.Quantidade.HeaderText = "Qtd.";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 60;
            // 
            // ValorUnitario
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorUnitario.DefaultCellStyle = dataGridViewCellStyle5;
            this.ValorUnitario.HeaderText = "Unitário";
            this.ValorUnitario.Name = "ValorUnitario";
            this.ValorUnitario.ReadOnly = true;
            this.ValorUnitario.Width = 80;
            // 
            // ValorTotal
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValorTotal.HeaderText = "Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Width = 80;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblStatusCaixa);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 651);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1173, 70);
            this.pnlStatus.TabIndex = 4;
            // 
            // lblStatusCaixa
            // 
            this.lblStatusCaixa.BackColor = System.Drawing.Color.Firebrick;
            this.lblStatusCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusCaixa.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCaixa.ForeColor = System.Drawing.Color.White;
            this.lblStatusCaixa.Location = new System.Drawing.Point(0, 0);
            this.lblStatusCaixa.Name = "lblStatusCaixa";
            this.lblStatusCaixa.Size = new System.Drawing.Size(1173, 70);
            this.lblStatusCaixa.TabIndex = 10;
            this.lblStatusCaixa.Text = "Venda em andamento...";
            this.lblStatusCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDescricaoProduto
            // 
            this.panelDescricaoProduto.BackColor = System.Drawing.Color.Transparent;
            this.panelDescricaoProduto.Controls.Add(this.lblProduto);
            this.panelDescricaoProduto.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDescricaoProduto.Location = new System.Drawing.Point(0, 36);
            this.panelDescricaoProduto.Name = "panelDescricaoProduto";
            this.panelDescricaoProduto.Size = new System.Drawing.Size(1173, 80);
            this.panelDescricaoProduto.TabIndex = 1;
            // 
            // lblProduto
            // 
            this.lblProduto.BackColor = System.Drawing.Color.Firebrick;
            this.lblProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProduto.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.ForeColor = System.Drawing.Color.White;
            this.lblProduto.Location = new System.Drawing.Point(0, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(1173, 80);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTopo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTopo.Controls.Add(this.lblCliente);
            this.panelTopo.Controls.Add(this.lblTerminal);
            this.panelTopo.Controls.Add(this.lblOperador);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(1173, 36);
            this.panelTopo.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(545, 7);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(66, 18);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminal.ForeColor = System.Drawing.Color.White;
            this.lblTerminal.Location = new System.Drawing.Point(302, 6);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(79, 18);
            this.lblTerminal.TabIndex = 1;
            this.lblTerminal.Text = "Terminal:";
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperador.ForeColor = System.Drawing.Color.White;
            this.lblOperador.Location = new System.Drawing.Point(12, 6);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(84, 18);
            this.lblOperador.TabIndex = 0;
            this.lblOperador.Text = "Operador:";
            // 
            // FrmPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1173, 786);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelRodape);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPDV_KeyDown);
            this.panelRodape.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelValores.ResumeLayout(false);
            this.panelValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogotipo)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.panelDescricaoProduto.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Panel panelDescricaoProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel panelValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblStatusCaixa;
        private System.Windows.Forms.PictureBox pbLogotipo;
        private System.Windows.Forms.Label lblLancarValor;
        //private Componentes.DecimalTextbox2Novo txtTotalGeral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNovaVenda;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnOrcamento;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutosId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        public System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.DataGridView dgvGeral;
        public System.Windows.Forms.Label lblValorTotal;
        public System.Windows.Forms.Label txtPrecoTotal;
        public System.Windows.Forms.Label txtPrecoUnit;
        private System.Windows.Forms.Label lblCliente;
    }
}