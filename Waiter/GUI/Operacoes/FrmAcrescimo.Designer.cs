namespace GUI.Operacoes
{
    partial class FrmAcrescimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcrescimo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAcrescimo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.lblNomeTela = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtAcrescimo);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 86);
            this.panel1.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor: R$";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Honeydew;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.Color.DarkCyan;
            this.button1.Location = new System.Drawing.Point(16, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 28);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "OK (Enter)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAcrescimo.Location = new System.Drawing.Point(98, 11);
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.Size = new System.Drawing.Size(168, 26);
            this.txtAcrescimo.TabIndex = 0;
            this.txtAcrescimo.TextChanged += new System.EventHandler(this.txtAcrescimo_TextChanged);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Honeydew;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button2.ForeColor = System.Drawing.Color.DarkCyan;
            this.button2.Location = new System.Drawing.Point(144, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 28);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Text = "Cancelar (ESC)";
            this.button2.UseVisualStyleBackColor = false;
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
            this.pnlTopo.TabIndex = 95;
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
            this.lblNomeTela.Size = new System.Drawing.Size(77, 16);
            this.lblNomeTela.TabIndex = 1;
            this.lblNomeTela.Text = "Acréscimo";
            // 
            // FrmAcrescimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(81)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(291, 119);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmAcrescimo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acrescimo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAcrescimo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlTopo;
        public System.Windows.Forms.Button btnAjuda;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label lblNomeTela;
    }
}