namespace GUI.Operacoes
{
    partial class FrmDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesconto));
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ordemServicoNewDataSet1 = new GUI.OrdemServicoNewDataSet();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ordemServicoNewDataSet1)).BeginInit();
            this.pnlTopo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Honeydew;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOK.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnOK.Location = new System.Drawing.Point(16, 45);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(122, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK (Enter)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnDesconto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor: R$";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDesconto.Location = new System.Drawing.Point(98, 11);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(168, 26);
            this.txtDesconto.TabIndex = 0;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesconto_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Honeydew;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnCancelar.Location = new System.Drawing.Point(144, 45);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar (ESC)";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ordemServicoNewDataSet1
            // 
            this.ordemServicoNewDataSet1.DataSetName = "OrdemServicoNewDataSet";
            this.ordemServicoNewDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.pnlTopo.Size = new System.Drawing.Size(291, 28);
            this.pnlTopo.TabIndex = 92;
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
            // 
            // lblNomeTela
            // 
            this.lblNomeTela.AutoSize = true;
            this.lblNomeTela.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeTela.ForeColor = System.Drawing.Color.White;
            this.lblNomeTela.Location = new System.Drawing.Point(13, 5);
            this.lblNomeTela.Name = "lblNomeTela";
            this.lblNomeTela.Size = new System.Drawing.Size(67, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Desconto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtDesconto);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 86);
            this.panel1.TabIndex = 93;
            // 
            // FrmDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(291, 119);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDesconto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desconto";
            this.Load += new System.EventHandler(this.FrmDesconto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDesconto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ordemServicoNewDataSet1)).EndInit();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Button btnCancelar;
        private OrdemServicoNewDataSet ordemServicoNewDataSet1;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnAjuda;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label lblNomeTela;
        private System.Windows.Forms.Panel panel1;
    }
}