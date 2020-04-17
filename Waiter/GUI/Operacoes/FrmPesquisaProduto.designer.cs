namespace GUI.Operacoes
{
    partial class FrmPesquisaProduto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaProduto));
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCarregar = new System.Windows.Forms.Button();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtPesquisarProduto = new System.Windows.Forms.TextBox();
            this.pnlTopo = new System.Windows.Forms.Panel();
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
            // lblPesquisar
            // 
            resources.ApplyResources(this.lblPesquisar, "lblPesquisar");
            this.lblPesquisar.Name = "lblPesquisar";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCarregar
            // 
            resources.ApplyResources(this.btnCarregar, "btnCarregar");
            this.btnCarregar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCarregar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.UseVisualStyleBackColor = false;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // dgvPrincipal
            // 
            resources.ApplyResources(this.dgvPrincipal, "dgvPrincipal");
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPrincipal_KeyUp);
            // 
            // btnSair
            // 
            resources.ApplyResources(this.btnSair, "btnSair");
            this.btnSair.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSair.Name = "btnSair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtPesquisarProduto
            // 
            resources.ApplyResources(this.txtPesquisarProduto, "txtPesquisarProduto");
            this.txtPesquisarProduto.Name = "txtPesquisarProduto";
            this.txtPesquisarProduto.TextChanged += new System.EventHandler(this.txtProduto_TextChanged);
            this.txtPesquisarProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisarProduto_KeyDown);
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTopo.Controls.Add(this.btn);
            this.pnlTopo.Controls.Add(this.lblNomeTela);
            resources.ApplyResources(this.pnlTopo, "pnlTopo");
            this.pnlTopo.Name = "pnlTopo";
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn, "btn");
            this.btn.FlatAppearance.BorderSize = 0;
            this.btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Name = "btn";
            this.btn.TabStop = false;
            this.btn.UseCompatibleTextRendering = true;
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblNomeTela
            // 
            resources.ApplyResources(this.lblNomeTela, "lblNomeTela");
            this.lblNomeTela.ForeColor = System.Drawing.Color.White;
            this.lblNomeTela.Name = "lblNomeTela";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtPesquisarProduto);
            this.panel1.Controls.Add(this.lblPesquisar);
            this.panel1.Controls.Add(this.dgvPrincipal);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnCarregar);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ssStatus);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ssStatus
            // 
            resources.ApplyResources(this.ssStatus, "ssStatus");
            this.ssStatus.ForeColor = System.Drawing.Color.IndianRed;
            this.ssStatus.Name = "ssStatus";
            // 
            // FrmPesquisaProduto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaProduto";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmPesquisarProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisaProduto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtPesquisarProduto;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ssStatus;
    }
}