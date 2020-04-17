namespace GUI.Operacoes
{
    partial class FrmAberturaCaixa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAberturaCaixa));
            this.lblOperadorMatricula = new System.Windows.Forms.Label();
            this.lblOperadorNome = new System.Windows.Forms.Label();
            this.txtOperadorMatricula = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.lblTroco = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblCaixa = new System.Windows.Forms.Label();
            this.cmbCaixa = new System.Windows.Forms.ComboBox();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ssStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.pnlTopo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOperadorMatricula
            // 
            this.lblOperadorMatricula.AutoSize = true;
            this.lblOperadorMatricula.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblOperadorMatricula.Location = new System.Drawing.Point(14, 12);
            this.lblOperadorMatricula.Name = "lblOperadorMatricula";
            this.lblOperadorMatricula.Size = new System.Drawing.Size(72, 18);
            this.lblOperadorMatricula.TabIndex = 0;
            this.lblOperadorMatricula.Text = "Matrícula:";
            // 
            // lblOperadorNome
            // 
            this.lblOperadorNome.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOperadorNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOperadorNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblOperadorNome.Location = new System.Drawing.Point(219, 9);
            this.lblOperadorNome.Name = "lblOperadorNome";
            this.lblOperadorNome.Size = new System.Drawing.Size(367, 24);
            this.lblOperadorNome.TabIndex = 1;
            this.lblOperadorNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOperadorMatricula
            // 
            this.txtOperadorMatricula.HideSelection = false;
            this.txtOperadorMatricula.Location = new System.Drawing.Point(89, 9);
            this.txtOperadorMatricula.Name = "txtOperadorMatricula";
            this.txtOperadorMatricula.Size = new System.Drawing.Size(124, 24);
            this.txtOperadorMatricula.TabIndex = 1;
            this.txtOperadorMatricula.TextChanged += new System.EventHandler(this.txtOperadorMatricula_TextChanged);
            this.txtOperadorMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOperadorMatricula_KeyDown);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(89, 41);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(124, 24);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            this.txtSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyUp);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblSenha.Location = new System.Drawing.Point(32, 44);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(54, 18);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha:";
            // 
            // txtTroco
            // 
            this.txtTroco.Location = new System.Drawing.Point(89, 73);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Size = new System.Drawing.Size(124, 24);
            this.txtTroco.TabIndex = 4;
            this.txtTroco.Text = "0,00";
            this.txtTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTroco.TextChanged += new System.EventHandler(this.txtTroco_TextChanged);
            this.txtTroco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTroco_KeyDown);
            this.txtTroco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTroco_KeyUp);
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTroco.Location = new System.Drawing.Point(34, 75);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(52, 18);
            this.lblTroco.TabIndex = 5;
            this.lblTroco.Text = "Troco:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Location = new System.Drawing.Point(481, 99);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(105, 44);
            this.btnAbrir.TabIndex = 5;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            this.btnAbrir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAbrir_KeyDown);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(481, 149);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(105, 44);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(481, 199);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(105, 44);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblCaixa
            // 
            this.lblCaixa.AutoSize = true;
            this.lblCaixa.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCaixa.Location = new System.Drawing.Point(337, 47);
            this.lblCaixa.Name = "lblCaixa";
            this.lblCaixa.Size = new System.Drawing.Size(59, 18);
            this.lblCaixa.TabIndex = 10;
            this.lblCaixa.Text = "Guichê:";
            // 
            // cmbCaixa
            // 
            this.cmbCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCaixa.FormattingEnabled = true;
            this.cmbCaixa.Location = new System.Drawing.Point(399, 43);
            this.cmbCaixa.Name = "cmbCaixa";
            this.cmbCaixa.Size = new System.Drawing.Size(186, 26);
            this.cmbCaixa.TabIndex = 3;
            this.cmbCaixa.SelectedIndexChanged += new System.EventHandler(this.cmbCaixa_SelectedIndexChanged);
            this.cmbCaixa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCaixa_KeyDown);
            this.cmbCaixa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbCaixa_KeyUp);
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.AllowUserToAddRows = false;
            this.dgvPrincipal.AllowUserToDeleteRows = false;
            this.dgvPrincipal.AllowUserToResizeColumns = false;
            this.dgvPrincipal.AllowUserToResizeRows = false;
            this.dgvPrincipal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPrincipal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPrincipal.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrincipal.ColumnHeadersHeight = 28;
            this.dgvPrincipal.Location = new System.Drawing.Point(29, 108);
            this.dgvPrincipal.MultiSelect = false;
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.ReadOnly = true;
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.RowHeadersWidth = 5;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(415, 140);
            this.dgvPrincipal.TabIndex = 86;
            this.dgvPrincipal.TabStop = false;
            this.dgvPrincipal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrincipal_CellContentClick);
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTopo.Controls.Add(this.btnAjuda);
            this.pnlTopo.Controls.Add(this.btn);
            this.pnlTopo.Controls.Add(this.lblNomeTela);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(605, 28);
            this.pnlTopo.TabIndex = 91;
            // 
            // btnAjuda
            // 
            this.btnAjuda.BackColor = System.Drawing.Color.Transparent;
            this.btnAjuda.FlatAppearance.BorderSize = 0;
            this.btnAjuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjuda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAjuda.ForeColor = System.Drawing.Color.White;
            this.btnAjuda.Location = new System.Drawing.Point(467, 2);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(59, 22);
            this.btnAjuda.TabIndex = 4;
            this.btnAjuda.TabStop = false;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = false;
            this.btnAjuda.Visible = false;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Transparent;
            this.btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn.FlatAppearance.BorderSize = 0;
            this.btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn.Location = new System.Drawing.Point(530, 2);
            this.btn.Name = "btn";
            this.btn.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btn.Size = new System.Drawing.Size(58, 22);
            this.btn.TabIndex = 8;
            this.btn.TabStop = false;
            this.btn.Text = "Sair";
            this.btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn.UseCompatibleTextRendering = true;
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblNomeTela
            // 
            this.lblNomeTela.AutoSize = true;
            this.lblNomeTela.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeTela.ForeColor = System.Drawing.Color.White;
            this.lblNomeTela.Location = new System.Drawing.Point(13, 5);
            this.lblNomeTela.Name = "lblNomeTela";
            this.lblNomeTela.Size = new System.Drawing.Size(161, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Abertura | Fechamento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnAbrir);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.lblCaixa);
            this.panel1.Controls.Add(this.txtTroco);
            this.panel1.Controls.Add(this.cmbCaixa);
            this.panel1.Controls.Add(this.lblTroco);
            this.panel1.Controls.Add(this.lblOperadorNome);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.lblOperadorMatricula);
            this.panel1.Controls.Add(this.lblSenha);
            this.panel1.Controls.Add(this.txtOperadorMatricula);
            this.panel1.Controls.Add(this.dgvPrincipal);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 270);
            this.panel1.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ssStatus);
            this.panel2.Location = new System.Drawing.Point(2, 303);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 27);
            this.panel2.TabIndex = 93;
            // 
            // ssStatus
            // 
            this.ssStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ssStatus.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.ssStatus.ForeColor = System.Drawing.Color.IndianRed;
            this.ssStatus.Location = new System.Drawing.Point(0, 0);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Padding = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.ssStatus.Size = new System.Drawing.Size(600, 27);
            this.ssStatus.TabIndex = 0;
            this.ssStatus.Text = "label1";
            // 
            // FrmAberturaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(605, 333);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAberturaCaixa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura e Fechamento de Caixa";
            this.Load += new System.EventHandler(this.FrmAberturaCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOperadorMatricula;
        private System.Windows.Forms.Label lblOperadorNome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblCaixa;
        private System.Windows.Forms.ComboBox cmbCaixa;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        internal System.Windows.Forms.TextBox txtOperadorMatricula;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnAjuda;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ssStatus;
    }
}