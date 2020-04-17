namespace GUI.Operacoes
{
    partial class FrmDetalheMovimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalheMovimento));
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.lblTrocoInicial = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTopo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTopo.Controls.Add(this.btnSair);
            this.pnlTopo.Controls.Add(this.lblNomeTela);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(548, 28);
            this.pnlTopo.TabIndex = 93;
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
            this.btnSair.Location = new System.Drawing.Point(483, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(58, 22);
            this.btnSair.TabIndex = 8;
            this.btnSair.TabStop = false;
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
            this.lblNomeTela.Size = new System.Drawing.Size(133, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Detalhe Movimento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgvPrincipal);
            this.panel1.Location = new System.Drawing.Point(4, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 395);
            this.panel1.TabIndex = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTrocoInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTipo);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 41);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(240, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Troco Inicial:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.lblTipo.Location = new System.Drawing.Point(6, 11);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(51, 23);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "TIPO:";
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Location = new System.Drawing.Point(6, 47);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(528, 302);
            this.dgvPrincipal.TabIndex = 0;
            // 
            // lblTrocoInicial
            // 
            this.lblTrocoInicial.AutoSize = true;
            this.lblTrocoInicial.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.lblTrocoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTrocoInicial.Location = new System.Drawing.Point(350, 11);
            this.lblTrocoInicial.Name = "lblTrocoInicial";
            this.lblTrocoInicial.Size = new System.Drawing.Size(42, 23);
            this.lblTrocoInicial.TabIndex = 3;
            this.lblTrocoInicial.Text = "0,00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 41);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotal.Location = new System.Drawing.Point(61, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 23);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 14F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total:";
            // 
            // FrmDetalheMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(548, 433);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetalheMovimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhe Movimento";
            this.Load += new System.EventHandler(this.FrmDetalheMovimento_Load);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrocoInicial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
    }
}