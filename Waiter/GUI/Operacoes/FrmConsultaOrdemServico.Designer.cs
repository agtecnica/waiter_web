namespace GUI.Operacoes
{
    partial class FrmConsultaOrdemServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaOrdemServico));
            this.pnlGeral2 = new System.Windows.Forms.Panel();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.pnlDados2 = new System.Windows.Forms.Panel();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.dtplDataInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.lblCliente2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.lblDescricao2 = new System.Windows.Forms.Label();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.pnlGeral2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.pnlDados2.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGeral2
            // 
            this.pnlGeral2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlGeral2.BackColor = System.Drawing.Color.White;
            this.pnlGeral2.Controls.Add(this.dgvPrincipal);
            this.pnlGeral2.Controls.Add(this.pnlDados2);
            this.pnlGeral2.Location = new System.Drawing.Point(11, 105);
            this.pnlGeral2.Name = "pnlGeral2";
            this.pnlGeral2.Size = new System.Drawing.Size(1028, 543);
            this.pnlGeral2.TabIndex = 88;
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Location = new System.Drawing.Point(5, 122);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.Size = new System.Drawing.Size(1018, 414);
            this.dgvPrincipal.TabIndex = 96;
            this.dgvPrincipal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrincipal_CellDoubleClick);
            // 
            // pnlDados2
            // 
            this.pnlDados2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDados2.BackColor = System.Drawing.Color.White;
            this.pnlDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDados2.Controls.Add(this.btnAplicarFiltro);
            this.pnlDados2.Controls.Add(this.cmbStatus);
            this.pnlDados2.Controls.Add(this.cmbCliente);
            this.pnlDados2.Controls.Add(this.dtplDataInicio);
            this.pnlDados2.Controls.Add(this.lblDataInicio);
            this.pnlDados2.Controls.Add(this.lblStatus2);
            this.pnlDados2.Controls.Add(this.dtpDataFim);
            this.pnlDados2.Controls.Add(this.lblDataFim);
            this.pnlDados2.Controls.Add(this.lblCliente2);
            this.pnlDados2.Controls.Add(this.txtDescricao);
            this.pnlDados2.Controls.Add(this.txtCodigo);
            this.pnlDados2.Controls.Add(this.lblCodigo2);
            this.pnlDados2.Controls.Add(this.lblDescricao2);
            this.pnlDados2.Location = new System.Drawing.Point(5, 5);
            this.pnlDados2.Name = "pnlDados2";
            this.pnlDados2.Size = new System.Drawing.Size(1018, 113);
            this.pnlDados2.TabIndex = 95;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnAplicarFiltro.Location = new System.Drawing.Point(899, 24);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(80, 52);
            this.btnAplicarFiltro.TabIndex = 73;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.IntegralHeight = false;
            this.cmbStatus.Location = new System.Drawing.Point(525, 68);
            this.cmbStatus.MaxDropDownItems = 10;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(278, 25);
            this.cmbStatus.TabIndex = 72;
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
            this.cmbCliente.Size = new System.Drawing.Size(483, 25);
            this.cmbCliente.TabIndex = 71;
            // 
            // dtplDataInicio
            // 
            this.dtplDataInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtplDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtplDataInicio.Location = new System.Drawing.Point(120, 69);
            this.dtplDataInicio.Name = "dtplDataInicio";
            this.dtplDataInicio.Size = new System.Drawing.Size(135, 23);
            this.dtplDataInicio.TabIndex = 68;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDataInicio.Location = new System.Drawing.Point(2, 72);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(86, 17);
            this.lblDataInicio.TabIndex = 67;
            this.lblDataInicio.Text = "DATA INÍCIO";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblStatus2.Location = new System.Drawing.Point(472, 72);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(47, 17);
            this.lblStatus2.TabIndex = 66;
            this.lblStatus2.Text = "STATUS";
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(331, 69);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(135, 23);
            this.dtpDataFim.TabIndex = 58;
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDataFim.Location = new System.Drawing.Point(260, 72);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(65, 17);
            this.lblDataFim.TabIndex = 55;
            this.lblDataFim.Text = "DATA FIM";
            // 
            // lblCliente2
            // 
            this.lblCliente2.AutoSize = true;
            this.lblCliente2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCliente2.Location = new System.Drawing.Point(2, 13);
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
            this.txtDescricao.Size = new System.Drawing.Size(683, 23);
            this.txtDescricao.TabIndex = 30;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCodigo.Location = new System.Drawing.Point(680, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(122, 23);
            this.txtCodigo.TabIndex = 35;
            this.txtCodigo.TabStop = false;
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCodigo2.Location = new System.Drawing.Point(609, 13);
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
            this.lblCadastro.Location = new System.Drawing.Point(3, 4);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(1017, 51);
            this.lblCadastro.TabIndex = 0;
            this.lblCadastro.Text = "Consulta Ordem de Serviço";
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
            // FrmConsultaOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 656);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlGeral2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaOrdemServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrdemServico";
            this.Load += new System.EventHandler(this.FrmOrdemServico_Load);
            this.pnlGeral2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.pnlDados2.ResumeLayout(false);
            this.pnlDados2.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlGeral2;
        public System.Windows.Forms.Panel pnlBotoes;
        protected System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnAjuda;
        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel pnlDados2;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblCliente2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo2;
        private System.Windows.Forms.Label lblDescricao2;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.DateTimePicker dtplDataInicio;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.Button btnAplicarFiltro;
    }
}