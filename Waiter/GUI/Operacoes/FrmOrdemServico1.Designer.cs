namespace GUI.Operacoes
{
    partial class FrmOrdemServico1
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
            this.pnlDadosOS = new System.Windows.Forms.Panel();
            this.cbExecutado = new System.Windows.Forms.CheckBox();
            this.btnAddStatus = new System.Windows.Forms.Button();
            this.btnAddFormaPgto = new System.Windows.Forms.Button();
            this.cmbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAbertura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatusManutencao = new System.Windows.Forms.ComboBox();
            this.lblStatusManutencao = new System.Windows.Forms.Label();
            this.txtNrParcelas = new System.Windows.Forms.NumericUpDown();
            this.lblNrParcelas = new System.Windows.Forms.Label();
            this.dtpDataExecucao = new System.Windows.Forms.DateTimePicker();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblDataExecucao = new System.Windows.Forms.Label();
            this.btnAddCliente = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnAdicionarServico = new System.Windows.Forms.Button();
            this.cmbServico = new System.Windows.Forms.ComboBox();
            this.lblServiço = new System.Windows.Forms.Label();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtQtdeProduto = new System.Windows.Forms.TextBox();
            this.lblQtdeProduto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.pnlDadosOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrParcelas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCadastro
            // 
            this.lblCadastro.Text = "Ordem de Serviço";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlDadosOS);
            this.panel1.Location = new System.Drawing.Point(12, 103);
            this.panel1.Controls.SetChildIndex(this.pnlDadosOS, 0);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            // 
            // btnAjuda
            // 
            this.btnAjuda.FlatAppearance.BorderSize = 0;
            this.btnAjuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAjuda.Location = new System.Drawing.Point(925, 2);
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSair.Location = new System.Drawing.Point(982, 2);
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblNomeTela
            // 
            this.lblNomeTela.Size = new System.Drawing.Size(125, 16);
            this.lblNomeTela.Text = "Ordem de Serviço";
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnLocalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // pnlDadosOS
            // 
            this.pnlDadosOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDadosOS.BackColor = System.Drawing.Color.White;
            this.pnlDadosOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosOS.Controls.Add(this.cbExecutado);
            this.pnlDadosOS.Controls.Add(this.btnAddStatus);
            this.pnlDadosOS.Controls.Add(this.btnAddFormaPgto);
            this.pnlDadosOS.Controls.Add(this.cmbTipoPagamento);
            this.pnlDadosOS.Controls.Add(this.label2);
            this.pnlDadosOS.Controls.Add(this.dtpAbertura);
            this.pnlDadosOS.Controls.Add(this.label1);
            this.pnlDadosOS.Controls.Add(this.cmbStatusManutencao);
            this.pnlDadosOS.Controls.Add(this.lblStatusManutencao);
            this.pnlDadosOS.Controls.Add(this.txtNrParcelas);
            this.pnlDadosOS.Controls.Add(this.lblNrParcelas);
            this.pnlDadosOS.Controls.Add(this.dtpDataExecucao);
            this.pnlDadosOS.Controls.Add(this.txtObservacao);
            this.pnlDadosOS.Controls.Add(this.lblObservacao);
            this.pnlDadosOS.Controls.Add(this.lblDataExecucao);
            this.pnlDadosOS.Controls.Add(this.btnAddCliente);
            this.pnlDadosOS.Controls.Add(this.cmbCliente);
            this.pnlDadosOS.Controls.Add(this.lblCliente);
            this.pnlDadosOS.Controls.Add(this.txtDescricao);
            this.pnlDadosOS.Controls.Add(this.txtCodigo);
            this.pnlDadosOS.Controls.Add(this.lblCodigo);
            this.pnlDadosOS.Controls.Add(this.lblDescricao);
            this.pnlDadosOS.Location = new System.Drawing.Point(5, 3);
            this.pnlDadosOS.Name = "pnlDadosOS";
            this.pnlDadosOS.Size = new System.Drawing.Size(1018, 264);
            this.pnlDadosOS.TabIndex = 90;
            // 
            // cbExecutado
            // 
            this.cbExecutado.AutoSize = true;
            this.cbExecutado.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbExecutado.Location = new System.Drawing.Point(264, 70);
            this.cbExecutado.Name = "cbExecutado";
            this.cbExecutado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbExecutado.Size = new System.Drawing.Size(96, 21);
            this.cbExecutado.TabIndex = 74;
            this.cbExecutado.Text = "Executado";
            this.cbExecutado.UseVisualStyleBackColor = true;
            // 
            // btnAddStatus
            // 
            this.btnAddStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAddStatus.Location = new System.Drawing.Point(391, 98);
            this.btnAddStatus.Name = "btnAddStatus";
            this.btnAddStatus.Size = new System.Drawing.Size(24, 25);
            this.btnAddStatus.TabIndex = 72;
            this.btnAddStatus.Text = "+";
            this.btnAddStatus.UseVisualStyleBackColor = true;
            this.btnAddStatus.Click += new System.EventHandler(this.btnAddStatus_Click);
            // 
            // btnAddFormaPgto
            // 
            this.btnAddFormaPgto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFormaPgto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAddFormaPgto.Location = new System.Drawing.Point(392, 130);
            this.btnAddFormaPgto.Name = "btnAddFormaPgto";
            this.btnAddFormaPgto.Size = new System.Drawing.Size(24, 25);
            this.btnAddFormaPgto.TabIndex = 71;
            this.btnAddFormaPgto.Text = "+";
            this.btnAddFormaPgto.UseVisualStyleBackColor = true;
            this.btnAddFormaPgto.Click += new System.EventHandler(this.btnAddFormaPgto_Click);
            // 
            // cmbTipoPagamento
            // 
            this.cmbTipoPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoPagamento.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbTipoPagamento.FormattingEnabled = true;
            this.cmbTipoPagamento.IntegralHeight = false;
            this.cmbTipoPagamento.Location = new System.Drawing.Point(121, 130);
            this.cmbTipoPagamento.MaxDropDownItems = 10;
            this.cmbTipoPagamento.Name = "cmbTipoPagamento";
            this.cmbTipoPagamento.Size = new System.Drawing.Size(268, 25);
            this.cmbTipoPagamento.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.Location = new System.Drawing.Point(2, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "FORMA PGTO";
            // 
            // dtpAbertura
            // 
            this.dtpAbertura.Enabled = false;
            this.dtpAbertura.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtpAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAbertura.Location = new System.Drawing.Point(120, 69);
            this.dtpAbertura.Name = "dtpAbertura";
            this.dtpAbertura.Size = new System.Drawing.Size(135, 23);
            this.dtpAbertura.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(2, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "DATA ABERTURA";
            // 
            // cmbStatusManutencao
            // 
            this.cmbStatusManutencao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatusManutencao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatusManutencao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbStatusManutencao.FormattingEnabled = true;
            this.cmbStatusManutencao.IntegralHeight = false;
            this.cmbStatusManutencao.Location = new System.Drawing.Point(120, 98);
            this.cmbStatusManutencao.MaxDropDownItems = 10;
            this.cmbStatusManutencao.Name = "cmbStatusManutencao";
            this.cmbStatusManutencao.Size = new System.Drawing.Size(268, 25);
            this.cmbStatusManutencao.TabIndex = 65;
            // 
            // lblStatusManutencao
            // 
            this.lblStatusManutencao.AutoSize = true;
            this.lblStatusManutencao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblStatusManutencao.Location = new System.Drawing.Point(2, 102);
            this.lblStatusManutencao.Name = "lblStatusManutencao";
            this.lblStatusManutencao.Size = new System.Drawing.Size(47, 17);
            this.lblStatusManutencao.TabIndex = 66;
            this.lblStatusManutencao.Text = "STATUS";
            // 
            // txtNrParcelas
            // 
            this.txtNrParcelas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNrParcelas.Location = new System.Drawing.Point(519, 131);
            this.txtNrParcelas.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtNrParcelas.Name = "txtNrParcelas";
            this.txtNrParcelas.Size = new System.Drawing.Size(49, 23);
            this.txtNrParcelas.TabIndex = 64;
            this.txtNrParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNrParcelas
            // 
            this.lblNrParcelas.AutoSize = true;
            this.lblNrParcelas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblNrParcelas.Location = new System.Drawing.Point(425, 134);
            this.lblNrParcelas.Name = "lblNrParcelas";
            this.lblNrParcelas.Size = new System.Drawing.Size(91, 17);
            this.lblNrParcelas.TabIndex = 63;
            this.lblNrParcelas.Text = "Nº PARCELAS";
            // 
            // dtpDataExecucao
            // 
            this.dtpDataExecucao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtpDataExecucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataExecucao.Location = new System.Drawing.Point(484, 69);
            this.dtpDataExecucao.Name = "dtpDataExecucao";
            this.dtpDataExecucao.Size = new System.Drawing.Size(135, 23);
            this.dtpDataExecucao.TabIndex = 58;
            this.dtpDataExecucao.Visible = false;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtObservacao.Location = new System.Drawing.Point(120, 162);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacao.Size = new System.Drawing.Size(587, 89);
            this.txtObservacao.TabIndex = 56;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblObservacao.Location = new System.Drawing.Point(2, 195);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(96, 17);
            this.lblObservacao.TabIndex = 57;
            this.lblObservacao.Text = "OBSERVAÇÃO";
            // 
            // lblDataExecucao
            // 
            this.lblDataExecucao.AutoSize = true;
            this.lblDataExecucao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDataExecucao.Location = new System.Drawing.Point(366, 72);
            this.lblDataExecucao.Name = "lblDataExecucao";
            this.lblDataExecucao.Size = new System.Drawing.Size(117, 17);
            this.lblDataExecucao.TabIndex = 55;
            this.lblDataExecucao.Text = "DATA EXECUÇÃO";
            this.lblDataExecucao.Visible = false;
            // 
            // btnAddCliente
            // 
            this.btnAddCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAddCliente.Location = new System.Drawing.Point(534, 8);
            this.btnAddCliente.Name = "btnAddCliente";
            this.btnAddCliente.Size = new System.Drawing.Size(24, 25);
            this.btnAddCliente.TabIndex = 51;
            this.btnAddCliente.Text = "+";
            this.btnAddCliente.UseVisualStyleBackColor = true;
            this.btnAddCliente.Click += new System.EventHandler(this.btnAddCliente_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(120, 8);
            this.cmbCliente.MaxDropDownItems = 10;
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(411, 25);
            this.cmbCliente.TabIndex = 32;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCliente.Location = new System.Drawing.Point(2, 12);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(57, 17);
            this.lblCliente.TabIndex = 36;
            this.lblCliente.Text = "CLIENTE";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtDescricao.Location = new System.Drawing.Point(120, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(739, 23);
            this.txtDescricao.TabIndex = 30;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCodigo.Location = new System.Drawing.Point(638, 9);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(78, 23);
            this.txtCodigo.TabIndex = 35;
            this.txtCodigo.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCodigo.Location = new System.Drawing.Point(567, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(65, 17);
            this.lblCodigo.TabIndex = 33;
            this.lblCodigo.Text = "CÓDIGO";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDescricao.Location = new System.Drawing.Point(2, 42);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(84, 17);
            this.lblDescricao.TabIndex = 31;
            this.lblDescricao.Text = "DESCRIÇÃO";
            // 
            // btnAdicionarServico
            // 
            this.btnAdicionarServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarServico.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAdicionarServico.Location = new System.Drawing.Point(535, 11);
            this.btnAdicionarServico.Name = "btnAdicionarServico";
            this.btnAdicionarServico.Size = new System.Drawing.Size(24, 25);
            this.btnAdicionarServico.TabIndex = 77;
            this.btnAdicionarServico.Text = "+";
            this.btnAdicionarServico.UseVisualStyleBackColor = true;
            this.btnAdicionarServico.Click += new System.EventHandler(this.btnAdicionarServico_Click);
            // 
            // cmbServico
            // 
            this.cmbServico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbServico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbServico.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbServico.FormattingEnabled = true;
            this.cmbServico.IntegralHeight = false;
            this.cmbServico.Location = new System.Drawing.Point(121, 11);
            this.cmbServico.MaxDropDownItems = 10;
            this.cmbServico.Name = "cmbServico";
            this.cmbServico.Size = new System.Drawing.Size(411, 25);
            this.cmbServico.TabIndex = 75;
            // 
            // lblServiço
            // 
            this.lblServiço.AutoSize = true;
            this.lblServiço.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblServiço.Location = new System.Drawing.Point(4, 15);
            this.lblServiço.Name = "lblServiço";
            this.lblServiço.Size = new System.Drawing.Size(63, 17);
            this.lblServiço.TabIndex = 76;
            this.lblServiço.Text = "SERVIÇO";
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAdicionarProduto.Location = new System.Drawing.Point(656, 44);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(24, 25);
            this.btnAdicionarProduto.TabIndex = 93;
            this.btnAdicionarProduto.Text = "+";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // cmbProduto
            // 
            this.cmbProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.IntegralHeight = false;
            this.cmbProduto.Location = new System.Drawing.Point(121, 44);
            this.cmbProduto.MaxDropDownItems = 10;
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(411, 25);
            this.cmbProduto.TabIndex = 91;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblProduto.Location = new System.Drawing.Point(4, 48);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(69, 17);
            this.lblProduto.TabIndex = 92;
            this.lblProduto.Text = "PRODUTO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtQtdeProduto);
            this.panel2.Controls.Add(this.lblQtdeProduto);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.cmbServico);
            this.panel2.Controls.Add(this.btnAdicionarProduto);
            this.panel2.Controls.Add(this.lblServiço);
            this.panel2.Controls.Add(this.cmbProduto);
            this.panel2.Controls.Add(this.btnAdicionarServico);
            this.panel2.Controls.Add(this.lblProduto);
            this.panel2.Location = new System.Drawing.Point(5, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 79);
            this.panel2.TabIndex = 94;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(862, 40);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(147, 31);
            this.txtTotal.TabIndex = 76;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(770, 44);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(91, 23);
            this.lblTotal.TabIndex = 75;
            this.lblTotal.Text = "TOTAL R$";
            // 
            // txtQtdeProduto
            // 
            this.txtQtdeProduto.Enabled = false;
            this.txtQtdeProduto.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtQtdeProduto.Location = new System.Drawing.Point(575, 44);
            this.txtQtdeProduto.Name = "txtQtdeProduto";
            this.txtQtdeProduto.Size = new System.Drawing.Size(78, 25);
            this.txtQtdeProduto.TabIndex = 76;
            this.txtQtdeProduto.TabStop = false;
            this.txtQtdeProduto.Text = "0";
            this.txtQtdeProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQtdeProduto
            // 
            this.lblQtdeProduto.AutoSize = true;
            this.lblQtdeProduto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblQtdeProduto.Location = new System.Drawing.Point(535, 48);
            this.lblQtdeProduto.Name = "lblQtdeProduto";
            this.lblQtdeProduto.Size = new System.Drawing.Size(41, 17);
            this.lblQtdeProduto.TabIndex = 75;
            this.lblQtdeProduto.Text = "QTDE";
            // 
            // FrmOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 656);
            this.Name = "FrmOrdemServico";
            this.Text = "FrmOrdemServico";
            this.Load += new System.EventHandler(this.FrmOrdemServico_Load);
            this.panel1.ResumeLayout(false);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlDadosOS.ResumeLayout(false);
            this.pnlDadosOS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNrParcelas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbServico;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Label lblServiço;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Button btnAdicionarServico;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Panel pnlDadosOS;
        private System.Windows.Forms.CheckBox cbExecutado;
        private System.Windows.Forms.Button btnAddStatus;
        private System.Windows.Forms.Button btnAddFormaPgto;
        private System.Windows.Forms.ComboBox cmbTipoPagamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAbertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatusManutencao;
        private System.Windows.Forms.Label lblStatusManutencao;
        private System.Windows.Forms.NumericUpDown txtNrParcelas;
        private System.Windows.Forms.Label lblNrParcelas;
        private System.Windows.Forms.DateTimePicker dtpDataExecucao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblDataExecucao;
        private System.Windows.Forms.Button btnAddCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtQtdeProduto;
        private System.Windows.Forms.Label lblQtdeProduto;
    }
}