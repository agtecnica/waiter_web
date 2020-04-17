namespace GUI.Operacoes
{
    partial class FrmOrdemServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrdemServico));
            this.pnlGeral2 = new System.Windows.Forms.Panel();
            this.tbcGrids = new System.Windows.Forms.TabControl();
            this.tbpgServicos = new System.Windows.Forms.TabPage();
            this.dgvServicos = new System.Windows.Forms.DataGridView();
            this.tbpgProdutos = new System.Windows.Forms.TabPage();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.pnlItens2 = new System.Windows.Forms.Panel();
            this.txtQtdeProduto = new System.Windows.Forms.NumericUpDown();
            this.lblQtde2 = new System.Windows.Forms.Label();
            this.txtTotal2 = new System.Windows.Forms.TextBox();
            this.lblTotal2 = new System.Windows.Forms.Label();
            this.cmbServico2 = new System.Windows.Forms.ComboBox();
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.lblServico2 = new System.Windows.Forms.Label();
            this.cmbProduto2 = new System.Windows.Forms.ComboBox();
            this.btnAddServico = new System.Windows.Forms.Button();
            this.lblProduto2 = new System.Windows.Forms.Label();
            this.pnlDados2 = new System.Windows.Forms.Panel();
            this.cmbFormaPgto2 = new System.Windows.Forms.ComboBox();
            this.cmbStatus2 = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblFormaPgto2 = new System.Windows.Forms.Label();
            this.dtpDataAbertura2 = new System.Windows.Forms.DateTimePicker();
            this.lblDataAbertura2 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.txtNrParcelas2 = new System.Windows.Forms.NumericUpDown();
            this.lblNrParcelas2 = new System.Windows.Forms.Label();
            this.dtpDataExecucao2 = new System.Windows.Forms.DateTimePicker();
            this.txtObservacao2 = new System.Windows.Forms.TextBox();
            this.lblObservacao2 = new System.Windows.Forms.Label();
            this.lblDataExecucao2 = new System.Windows.Forms.Label();
            this.lblCliente2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo2 = new System.Windows.Forms.TextBox();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.lblDescricao2 = new System.Windows.Forms.Label();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.txtTotalServicos = new System.Windows.Forms.TextBox();
            this.lblTotalServicos = new System.Windows.Forms.Label();
            this.txtTotalProdutos = new System.Windows.Forms.TextBox();
            this.lblTotalProdutos = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pnlGeral2.SuspendLayout();
            this.tbcGrids.SuspendLayout();
            this.tbpgServicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicos)).BeginInit();
            this.tbpgProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.pnlItens2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdeProduto)).BeginInit();
            this.pnlDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrParcelas2)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGeral2
            // 
            this.pnlGeral2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlGeral2.BackColor = System.Drawing.Color.White;
            this.pnlGeral2.Controls.Add(this.txtTotal2);
            this.pnlGeral2.Controls.Add(this.lblTotal2);
            this.pnlGeral2.Controls.Add(this.tbcGrids);
            this.pnlGeral2.Controls.Add(this.pnlItens2);
            this.pnlGeral2.Controls.Add(this.pnlDados2);
            this.pnlGeral2.Location = new System.Drawing.Point(11, 105);
            this.pnlGeral2.Name = "pnlGeral2";
            this.pnlGeral2.Size = new System.Drawing.Size(1028, 543);
            this.pnlGeral2.TabIndex = 88;
            // 
            // tbcGrids
            // 
            this.tbcGrids.Controls.Add(this.tbpgServicos);
            this.tbcGrids.Controls.Add(this.tbpgProdutos);
            this.tbcGrids.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbcGrids.Location = new System.Drawing.Point(5, 338);
            this.tbcGrids.Name = "tbcGrids";
            this.tbcGrids.SelectedIndex = 0;
            this.tbcGrids.Size = new System.Drawing.Size(1020, 201);
            this.tbcGrids.TabIndex = 97;
            // 
            // tbpgServicos
            // 
            this.tbpgServicos.Controls.Add(this.dgvServicos);
            this.tbpgServicos.Location = new System.Drawing.Point(4, 25);
            this.tbpgServicos.Name = "tbpgServicos";
            this.tbpgServicos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgServicos.Size = new System.Drawing.Size(1012, 172);
            this.tbpgServicos.TabIndex = 0;
            this.tbpgServicos.Text = "SERVIÇOS";
            this.tbpgServicos.UseVisualStyleBackColor = true;
            // 
            // dgvServicos
            // 
            this.dgvServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicos.Location = new System.Drawing.Point(0, -2);
            this.dgvServicos.Name = "dgvServicos";
            this.dgvServicos.RowHeadersVisible = false;
            this.dgvServicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicos.Size = new System.Drawing.Size(1012, 176);
            this.dgvServicos.TabIndex = 92;
            // 
            // tbpgProdutos
            // 
            this.tbpgProdutos.Controls.Add(this.dgvProdutos);
            this.tbpgProdutos.Location = new System.Drawing.Point(4, 25);
            this.tbpgProdutos.Name = "tbpgProdutos";
            this.tbpgProdutos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgProdutos.Size = new System.Drawing.Size(1012, 172);
            this.tbpgProdutos.TabIndex = 1;
            this.tbpgProdutos.Text = "PRODUTOS";
            this.tbpgProdutos.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(-3, -3);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(1012, 176);
            this.dgvProdutos.TabIndex = 91;
            // 
            // pnlItens2
            // 
            this.pnlItens2.Controls.Add(this.txtTotalProdutos);
            this.pnlItens2.Controls.Add(this.lblTotalProdutos);
            this.pnlItens2.Controls.Add(this.txtTotalServicos);
            this.pnlItens2.Controls.Add(this.lblTotalServicos);
            this.pnlItens2.Controls.Add(this.txtQtdeProduto);
            this.pnlItens2.Controls.Add(this.lblQtde2);
            this.pnlItens2.Controls.Add(this.cmbServico2);
            this.pnlItens2.Controls.Add(this.btnAddProduto);
            this.pnlItens2.Controls.Add(this.lblServico2);
            this.pnlItens2.Controls.Add(this.cmbProduto2);
            this.pnlItens2.Controls.Add(this.btnAddServico);
            this.pnlItens2.Controls.Add(this.lblProduto2);
            this.pnlItens2.Location = new System.Drawing.Point(5, 252);
            this.pnlItens2.Name = "pnlItens2";
            this.pnlItens2.Size = new System.Drawing.Size(1017, 79);
            this.pnlItens2.TabIndex = 96;
            // 
            // txtQtdeProduto
            // 
            this.txtQtdeProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtQtdeProduto.Location = new System.Drawing.Point(513, 45);
            this.txtQtdeProduto.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtQtdeProduto.Name = "txtQtdeProduto";
            this.txtQtdeProduto.Size = new System.Drawing.Size(68, 23);
            this.txtQtdeProduto.TabIndex = 74;
            this.txtQtdeProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeProduto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQtde2
            // 
            this.lblQtde2.AutoSize = true;
            this.lblQtde2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblQtde2.Location = new System.Drawing.Point(470, 48);
            this.lblQtde2.Name = "lblQtde2";
            this.lblQtde2.Size = new System.Drawing.Size(41, 17);
            this.lblQtde2.TabIndex = 75;
            this.lblQtde2.Text = "QTDE";
            // 
            // txtTotal2
            // 
            this.txtTotal2.Enabled = false;
            this.txtTotal2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal2.ForeColor = System.Drawing.Color.Maroon;
            this.txtTotal2.Location = new System.Drawing.Point(776, 330);
            this.txtTotal2.Name = "txtTotal2";
            this.txtTotal2.Size = new System.Drawing.Size(147, 31);
            this.txtTotal2.TabIndex = 76;
            this.txtTotal2.TabStop = false;
            this.txtTotal2.Text = "0,00";
            this.txtTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal2
            // 
            this.lblTotal2.AutoSize = true;
            this.lblTotal2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal2.Location = new System.Drawing.Point(672, 333);
            this.lblTotal2.Name = "lblTotal2";
            this.lblTotal2.Size = new System.Drawing.Size(91, 23);
            this.lblTotal2.TabIndex = 75;
            this.lblTotal2.Text = "TOTAL R$";
            // 
            // cmbServico2
            // 
            this.cmbServico2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbServico2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbServico2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbServico2.FormattingEnabled = true;
            this.cmbServico2.IntegralHeight = false;
            this.cmbServico2.Location = new System.Drawing.Point(121, 11);
            this.cmbServico2.MaxDropDownItems = 10;
            this.cmbServico2.Name = "cmbServico2";
            this.cmbServico2.Size = new System.Drawing.Size(347, 25);
            this.cmbServico2.TabIndex = 75;
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAddProduto.Location = new System.Drawing.Point(584, 44);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Size = new System.Drawing.Size(24, 25);
            this.btnAddProduto.TabIndex = 93;
            this.btnAddProduto.Text = "+";
            this.btnAddProduto.UseVisualStyleBackColor = true;
            this.btnAddProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // lblServico2
            // 
            this.lblServico2.AutoSize = true;
            this.lblServico2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblServico2.Location = new System.Drawing.Point(4, 15);
            this.lblServico2.Name = "lblServico2";
            this.lblServico2.Size = new System.Drawing.Size(63, 17);
            this.lblServico2.TabIndex = 76;
            this.lblServico2.Text = "SERVIÇO";
            // 
            // cmbProduto2
            // 
            this.cmbProduto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduto2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbProduto2.FormattingEnabled = true;
            this.cmbProduto2.IntegralHeight = false;
            this.cmbProduto2.Location = new System.Drawing.Point(121, 44);
            this.cmbProduto2.MaxDropDownItems = 10;
            this.cmbProduto2.Name = "cmbProduto2";
            this.cmbProduto2.Size = new System.Drawing.Size(347, 25);
            this.cmbProduto2.TabIndex = 91;
            // 
            // btnAddServico
            // 
            this.btnAddServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServico.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAddServico.Location = new System.Drawing.Point(471, 11);
            this.btnAddServico.Name = "btnAddServico";
            this.btnAddServico.Size = new System.Drawing.Size(24, 25);
            this.btnAddServico.TabIndex = 77;
            this.btnAddServico.Text = "+";
            this.btnAddServico.UseVisualStyleBackColor = true;
            this.btnAddServico.Click += new System.EventHandler(this.btnAdicionarServico_Click);
            // 
            // lblProduto2
            // 
            this.lblProduto2.AutoSize = true;
            this.lblProduto2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblProduto2.Location = new System.Drawing.Point(4, 48);
            this.lblProduto2.Name = "lblProduto2";
            this.lblProduto2.Size = new System.Drawing.Size(69, 17);
            this.lblProduto2.TabIndex = 92;
            this.lblProduto2.Text = "PRODUTO";
            // 
            // pnlDados2
            // 
            this.pnlDados2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDados2.BackColor = System.Drawing.Color.White;
            this.pnlDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDados2.Controls.Add(this.cmbFormaPgto2);
            this.pnlDados2.Controls.Add(this.cmbStatus2);
            this.pnlDados2.Controls.Add(this.cmbCliente);
            this.pnlDados2.Controls.Add(this.lblFormaPgto2);
            this.pnlDados2.Controls.Add(this.dtpDataAbertura2);
            this.pnlDados2.Controls.Add(this.lblDataAbertura2);
            this.pnlDados2.Controls.Add(this.lblStatus2);
            this.pnlDados2.Controls.Add(this.txtNrParcelas2);
            this.pnlDados2.Controls.Add(this.lblNrParcelas2);
            this.pnlDados2.Controls.Add(this.dtpDataExecucao2);
            this.pnlDados2.Controls.Add(this.txtObservacao2);
            this.pnlDados2.Controls.Add(this.lblObservacao2);
            this.pnlDados2.Controls.Add(this.lblDataExecucao2);
            this.pnlDados2.Controls.Add(this.lblCliente2);
            this.pnlDados2.Controls.Add(this.txtDescricao);
            this.pnlDados2.Controls.Add(this.txtCodigo2);
            this.pnlDados2.Controls.Add(this.lblCodigo2);
            this.pnlDados2.Controls.Add(this.lblDescricao2);
            this.pnlDados2.Location = new System.Drawing.Point(5, 5);
            this.pnlDados2.Name = "pnlDados2";
            this.pnlDados2.Size = new System.Drawing.Size(1018, 242);
            this.pnlDados2.TabIndex = 95;
            // 
            // cmbFormaPgto2
            // 
            this.cmbFormaPgto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormaPgto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormaPgto2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbFormaPgto2.FormattingEnabled = true;
            this.cmbFormaPgto2.IntegralHeight = false;
            this.cmbFormaPgto2.Location = new System.Drawing.Point(120, 131);
            this.cmbFormaPgto2.MaxDropDownItems = 10;
            this.cmbFormaPgto2.Name = "cmbFormaPgto2";
            this.cmbFormaPgto2.Size = new System.Drawing.Size(268, 25);
            this.cmbFormaPgto2.TabIndex = 73;
            // 
            // cmbStatus2
            // 
            this.cmbStatus2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbStatus2.FormattingEnabled = true;
            this.cmbStatus2.IntegralHeight = false;
            this.cmbStatus2.Location = new System.Drawing.Point(120, 99);
            this.cmbStatus2.MaxDropDownItems = 10;
            this.cmbStatus2.Name = "cmbStatus2";
            this.cmbStatus2.Size = new System.Drawing.Size(268, 25);
            this.cmbStatus2.TabIndex = 72;
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(120, 9);
            this.cmbCliente.MaxDropDownItems = 10;
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(584, 25);
            this.cmbCliente.TabIndex = 71;
            // 
            // lblFormaPgto2
            // 
            this.lblFormaPgto2.AutoSize = true;
            this.lblFormaPgto2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblFormaPgto2.Location = new System.Drawing.Point(2, 134);
            this.lblFormaPgto2.Name = "lblFormaPgto2";
            this.lblFormaPgto2.Size = new System.Drawing.Size(92, 17);
            this.lblFormaPgto2.TabIndex = 70;
            this.lblFormaPgto2.Text = "FORMA PGTO";
            // 
            // dtpDataAbertura2
            // 
            this.dtpDataAbertura2.Enabled = false;
            this.dtpDataAbertura2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtpDataAbertura2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAbertura2.Location = new System.Drawing.Point(120, 69);
            this.dtpDataAbertura2.Name = "dtpDataAbertura2";
            this.dtpDataAbertura2.Size = new System.Drawing.Size(135, 23);
            this.dtpDataAbertura2.TabIndex = 68;
            // 
            // lblDataAbertura2
            // 
            this.lblDataAbertura2.AutoSize = true;
            this.lblDataAbertura2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDataAbertura2.Location = new System.Drawing.Point(2, 72);
            this.lblDataAbertura2.Name = "lblDataAbertura2";
            this.lblDataAbertura2.Size = new System.Drawing.Size(106, 17);
            this.lblDataAbertura2.TabIndex = 67;
            this.lblDataAbertura2.Text = "DATA ABERTURA";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblStatus2.Location = new System.Drawing.Point(2, 102);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(47, 17);
            this.lblStatus2.TabIndex = 66;
            this.lblStatus2.Text = "STATUS";
            // 
            // txtNrParcelas2
            // 
            this.txtNrParcelas2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNrParcelas2.Location = new System.Drawing.Point(489, 131);
            this.txtNrParcelas2.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtNrParcelas2.Name = "txtNrParcelas2";
            this.txtNrParcelas2.Size = new System.Drawing.Size(49, 23);
            this.txtNrParcelas2.TabIndex = 64;
            this.txtNrParcelas2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNrParcelas2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNrParcelas2
            // 
            this.lblNrParcelas2.AutoSize = true;
            this.lblNrParcelas2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblNrParcelas2.Location = new System.Drawing.Point(395, 134);
            this.lblNrParcelas2.Name = "lblNrParcelas2";
            this.lblNrParcelas2.Size = new System.Drawing.Size(91, 17);
            this.lblNrParcelas2.TabIndex = 63;
            this.lblNrParcelas2.Text = "Nº PARCELAS";
            // 
            // dtpDataExecucao2
            // 
            this.dtpDataExecucao2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtpDataExecucao2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataExecucao2.Location = new System.Drawing.Point(378, 69);
            this.dtpDataExecucao2.Name = "dtpDataExecucao2";
            this.dtpDataExecucao2.Size = new System.Drawing.Size(135, 23);
            this.dtpDataExecucao2.TabIndex = 58;
            this.dtpDataExecucao2.Visible = false;
            // 
            // txtObservacao2
            // 
            this.txtObservacao2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtObservacao2.Location = new System.Drawing.Point(120, 162);
            this.txtObservacao2.Multiline = true;
            this.txtObservacao2.Name = "txtObservacao2";
            this.txtObservacao2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacao2.Size = new System.Drawing.Size(587, 69);
            this.txtObservacao2.TabIndex = 56;
            // 
            // lblObservacao2
            // 
            this.lblObservacao2.AutoSize = true;
            this.lblObservacao2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblObservacao2.Location = new System.Drawing.Point(2, 183);
            this.lblObservacao2.Name = "lblObservacao2";
            this.lblObservacao2.Size = new System.Drawing.Size(96, 17);
            this.lblObservacao2.TabIndex = 57;
            this.lblObservacao2.Text = "OBSERVAÇÃO";
            // 
            // lblDataExecucao2
            // 
            this.lblDataExecucao2.AutoSize = true;
            this.lblDataExecucao2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDataExecucao2.Location = new System.Drawing.Point(260, 72);
            this.lblDataExecucao2.Name = "lblDataExecucao2";
            this.lblDataExecucao2.Size = new System.Drawing.Size(117, 17);
            this.lblDataExecucao2.TabIndex = 55;
            this.lblDataExecucao2.Text = "DATA EXECUÇÃO";
            this.lblDataExecucao2.Visible = false;
            // 
            // lblCliente2
            // 
            this.lblCliente2.AutoSize = true;
            this.lblCliente2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCliente2.Location = new System.Drawing.Point(2, 12);
            this.lblCliente2.Name = "lblCliente2";
            this.lblCliente2.Size = new System.Drawing.Size(57, 17);
            this.lblCliente2.TabIndex = 36;
            this.lblCliente2.Text = "CLIENTE";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtDescricao.Location = new System.Drawing.Point(120, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(739, 23);
            this.txtDescricao.TabIndex = 30;
            // 
            // txtCodigo2
            // 
            this.txtCodigo2.Enabled = false;
            this.txtCodigo2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCodigo2.Location = new System.Drawing.Point(781, 9);
            this.txtCodigo2.Name = "txtCodigo2";
            this.txtCodigo2.Size = new System.Drawing.Size(78, 23);
            this.txtCodigo2.TabIndex = 35;
            this.txtCodigo2.TabStop = false;
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCodigo2.Location = new System.Drawing.Point(710, 12);
            this.lblCodigo2.Name = "lblCodigo2";
            this.lblCodigo2.Size = new System.Drawing.Size(65, 17);
            this.lblCodigo2.TabIndex = 33;
            this.lblCodigo2.Text = "CÓDIGO";
            // 
            // lblDescricao2
            // 
            this.lblDescricao2.AutoSize = true;
            this.lblDescricao2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDescricao2.Location = new System.Drawing.Point(2, 42);
            this.lblDescricao2.Name = "lblDescricao2";
            this.lblDescricao2.Size = new System.Drawing.Size(84, 17);
            this.lblDescricao2.TabIndex = 31;
            this.lblDescricao2.Text = "DESCRIÇÃO";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnLocalizar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.lblCadastro);
            this.pnlBotoes.Location = new System.Drawing.Point(10, 36);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1028, 63);
            this.pnlBotoes.TabIndex = 89;
            // 
            // lblCadastro
            // 
            this.lblCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCadastro.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lblCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCadastro.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCadastro.Location = new System.Drawing.Point(495, 4);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(525, 51);
            this.lblCadastro.TabIndex = 0;
            this.lblCadastro.Text = "Ordem de Serviço";
            this.lblCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTopo.Controls.Add(this.btnAjuda);
            this.pnlTopo.Controls.Add(this.btnSair);
            this.pnlTopo.Controls.Add(this.lblNomeTela);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1050, 28);
            this.pnlTopo.TabIndex = 90;
            // 
            // btnAjuda
            // 
            this.btnAjuda.BackColor = System.Drawing.Color.Transparent;
            this.btnAjuda.FlatAppearance.BorderSize = 0;
            this.btnAjuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjuda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAjuda.ForeColor = System.Drawing.Color.White;
            this.btnAjuda.Location = new System.Drawing.Point(934, 2);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(59, 22);
            this.btnAjuda.TabIndex = 4;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = false;
            // 
            // lblNomeTela
            // 
            this.lblNomeTela.AutoSize = true;
            this.lblNomeTela.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeTela.ForeColor = System.Drawing.Color.White;
            this.lblNomeTela.Location = new System.Drawing.Point(13, 5);
            this.lblNomeTela.Name = "lblNomeTela";
            this.lblNomeTela.Size = new System.Drawing.Size(125, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Ordem de Serviço";
            // 
            // txtTotalServicos
            // 
            this.txtTotalServicos.Enabled = false;
            this.txtTotalServicos.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTotalServicos.Location = new System.Drawing.Point(771, 12);
            this.txtTotalServicos.Name = "txtTotalServicos";
            this.txtTotalServicos.Size = new System.Drawing.Size(105, 23);
            this.txtTotalServicos.TabIndex = 95;
            this.txtTotalServicos.TabStop = false;
            this.txtTotalServicos.Text = "0,00";
            this.txtTotalServicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalServicos
            // 
            this.lblTotalServicos.AutoSize = true;
            this.lblTotalServicos.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblTotalServicos.Location = new System.Drawing.Point(631, 15);
            this.lblTotalServicos.Name = "lblTotalServicos";
            this.lblTotalServicos.Size = new System.Drawing.Size(128, 17);
            this.lblTotalServicos.TabIndex = 94;
            this.lblTotalServicos.Text = "TOTAL SERVIÇOS R$";
            this.lblTotalServicos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalProdutos
            // 
            this.txtTotalProdutos.Enabled = false;
            this.txtTotalProdutos.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTotalProdutos.Location = new System.Drawing.Point(771, 45);
            this.txtTotalProdutos.Name = "txtTotalProdutos";
            this.txtTotalProdutos.Size = new System.Drawing.Size(105, 23);
            this.txtTotalProdutos.TabIndex = 97;
            this.txtTotalProdutos.TabStop = false;
            this.txtTotalProdutos.Text = "0,00";
            this.txtTotalProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalProdutos
            // 
            this.lblTotalProdutos.AutoSize = true;
            this.lblTotalProdutos.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblTotalProdutos.Location = new System.Drawing.Point(624, 48);
            this.lblTotalProdutos.Name = "lblTotalProdutos";
            this.lblTotalProdutos.Size = new System.Drawing.Size(134, 17);
            this.lblTotalProdutos.TabIndex = 96;
            this.lblTotalProdutos.Text = "TOTAL PRODUTOS R$";
            this.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(991, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(58, 22);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseCompatibleTextRendering = true;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.BackColor = System.Drawing.Color.White;
            this.btnLocalizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLocalizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnLocalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLocalizar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnLocalizar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLocalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizar.Image")));
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.Location = new System.Drawing.Point(360, 0);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(90, 59);
            this.btnLocalizar.TabIndex = 22;
            this.btnLocalizar.Text = "Localizar";
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLocalizar.UseVisualStyleBackColor = false;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoEllipsis = true;
            this.btnExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExcluir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExcluir.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnExcluir.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.Location = new System.Drawing.Point(270, 0);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 59);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoEllipsis = true;
            this.btnAlterar.BackColor = System.Drawing.Color.White;
            this.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAlterar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAlterar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnAlterar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlterar.Location = new System.Drawing.Point(180, 0);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(90, 59);
            this.btnAlterar.TabIndex = 19;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.Location = new System.Drawing.Point(90, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 59);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnSalvar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.Location = new System.Drawing.Point(0, 0);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 59);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "Novo";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FrmOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 656);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlGeral2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdemServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrdemServico";
            this.Load += new System.EventHandler(this.FrmOrdemServico_Load);
            this.pnlGeral2.ResumeLayout(false);
            this.pnlGeral2.PerformLayout();
            this.tbcGrids.ResumeLayout(false);
            this.tbpgServicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicos)).EndInit();
            this.tbpgProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.pnlItens2.ResumeLayout(false);
            this.pnlItens2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdeProduto)).EndInit();
            this.pnlDados2.ResumeLayout(false);
            this.pnlDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrParcelas2)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlGeral2;
        public System.Windows.Forms.Panel pnlBotoes;
        public System.Windows.Forms.Button btnLocalizar;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.Button btnAlterar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnSalvar;
        protected System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnAjuda;
        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel pnlItens2;
        private System.Windows.Forms.Label lblQtde2;
        private System.Windows.Forms.TextBox txtTotal2;
        private System.Windows.Forms.Label lblTotal2;
        private System.Windows.Forms.ComboBox cmbServico2;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.Label lblServico2;
        private System.Windows.Forms.ComboBox cmbProduto2;
        private System.Windows.Forms.Button btnAddServico;
        private System.Windows.Forms.Label lblProduto2;
        private System.Windows.Forms.Panel pnlDados2;
        private System.Windows.Forms.Label lblFormaPgto2;
        private System.Windows.Forms.DateTimePicker dtpDataAbertura2;
        private System.Windows.Forms.Label lblDataAbertura2;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.NumericUpDown txtNrParcelas2;
        private System.Windows.Forms.Label lblNrParcelas2;
        private System.Windows.Forms.DateTimePicker dtpDataExecucao2;
        private System.Windows.Forms.TextBox txtObservacao2;
        private System.Windows.Forms.Label lblObservacao2;
        private System.Windows.Forms.Label lblDataExecucao2;
        private System.Windows.Forms.Label lblCliente2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo2;
        private System.Windows.Forms.Label lblCodigo2;
        private System.Windows.Forms.Label lblDescricao2;
        private System.Windows.Forms.TabControl tbcGrids;
        private System.Windows.Forms.TabPage tbpgServicos;
        private System.Windows.Forms.TabPage tbpgProdutos;
        public System.Windows.Forms.DataGridView dgvServicos;
        public System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbStatus2;
        private System.Windows.Forms.ComboBox cmbFormaPgto2;
        private System.Windows.Forms.NumericUpDown txtQtdeProduto;
        private System.Windows.Forms.TextBox txtTotalProdutos;
        private System.Windows.Forms.Label lblTotalProdutos;
        private System.Windows.Forms.TextBox txtTotalServicos;
        private System.Windows.Forms.Label lblTotalServicos;
    }
}