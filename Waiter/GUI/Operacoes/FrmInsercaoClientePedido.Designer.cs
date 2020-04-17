namespace GUI.Operacoes
{
    partial class FrmInsercaoClientePedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsercaoClientePedido));
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.Label();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btn = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdCnpj = new System.Windows.Forms.MaskedTextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblInformacao = new System.Windows.Forms.Label();
            this.pnlTopo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCnpj.Location = new System.Drawing.Point(11, 12);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(90, 18);
            this.lblCnpj.TabIndex = 0;
            this.lblCnpj.Text = "CPF / CNPJ";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(242, 9);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(344, 24);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlTopo.Controls.Add(this.btn);
            this.pnlTopo.Controls.Add(this.lblNomeTela);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(605, 28);
            this.pnlTopo.TabIndex = 91;
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
            this.lblNomeTela.Size = new System.Drawing.Size(98, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Inserir Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtIdCnpj);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Controls.Add(this.lblCnpj);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 43);
            this.panel1.TabIndex = 92;
            // 
            // txtIdCnpj
            // 
            this.txtIdCnpj.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtIdCnpj.Location = new System.Drawing.Point(105, 9);
            this.txtIdCnpj.Name = "txtIdCnpj";
            this.txtIdCnpj.Size = new System.Drawing.Size(132, 25);
            this.txtIdCnpj.TabIndex = 87;
            this.txtIdCnpj.TextChanged += new System.EventHandler(this.txtIdCnpj_TextChanged);
            this.txtIdCnpj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCnpj_KeyDown);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblInformacao);
            this.pnlFooter.Location = new System.Drawing.Point(2, 76);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(600, 27);
            this.pnlFooter.TabIndex = 93;
            // 
            // lblInformacao
            // 
            this.lblInformacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInformacao.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.lblInformacao.ForeColor = System.Drawing.Color.IndianRed;
            this.lblInformacao.Location = new System.Drawing.Point(0, 0);
            this.lblInformacao.Name = "lblInformacao";
            this.lblInformacao.Padding = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.lblInformacao.Size = new System.Drawing.Size(600, 27);
            this.lblInformacao.TabIndex = 0;
            this.lblInformacao.Text = "Informe o ID do cliente ou o CNPJ ";
            // 
            // FrmInsercaoClientePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(605, 105);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInsercaoClientePedido";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura e Fechamento de Caixa";
            this.Load += new System.EventHandler(this.FrmInsercaoCliente_Load);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label txtCliente;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblInformacao;
        private System.Windows.Forms.MaskedTextBox txtIdCnpj;
    }
}