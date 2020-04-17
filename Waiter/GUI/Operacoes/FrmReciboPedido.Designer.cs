namespace Apresentacao
{
    partial class FrmReciboPedido
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.VendaBalcaoPorClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VendaBalcaoPorClienteItensBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VendaBalcaoPorClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VendaBalcaoPorClienteItensBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsPedido";
            reportDataSource1.Value = this.VendaBalcaoPorClienteBindingSource;
            reportDataSource2.Name = "dsPedidoItens";
            reportDataSource2.Value = this.VendaBalcaoPorClienteItensBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AMSSoft.Apresentacao.Relatorios.rltReciboPedido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 44);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(902, 571);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnImprimir.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(591, 9);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 26);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir -  F3";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnImprimir_KeyUp);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnFechar.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(745, 9);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(138, 26);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar -  F4";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnFechar_KeyUp);
            // 
            // FrmReciboPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 615);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReciboPedido";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo do Pedido";
            this.Load += new System.EventHandler(this.FrmReciboPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendaBalcaoPorClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VendaBalcaoPorClienteItensBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VendaBalcaoPorClienteBindingSource;
        //private DataSources.AMSDataSet AMSDataSet;
        private System.Windows.Forms.BindingSource VendaBalcaoPorClienteItensBindingSource;
        //private Apresentacao.DataSources.AMSDataSetTableAdapters.VendaBalcaoPorClienteTableAdapter VendaBalcaoPorClienteTableAdapter;
        //private Apresentacao.DataSources.AMSDataSetTableAdapters.VendaBalcaoPorClienteItensTableAdapter VendaBalcaoPorClienteItensTableAdapter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
    }
}