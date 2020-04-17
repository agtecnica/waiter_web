namespace Apresentacao
{
    partial class FrmPedidoVendaCadastrar
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
            this.lblEmitente = new System.Windows.Forms.Label();
            this.txtEmitente = new System.Windows.Forms.TextBox();
            this.btnPesquisarEmitente = new System.Windows.Forms.Button();
            this.btnPesquisarDestinatario = new System.Windows.Forms.Button();
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtOperacao = new System.Windows.Forms.TextBox();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.gbxItens = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblItens = new System.Windows.Forms.Label();
            this.txtItens = new System.Windows.Forms.TextBox();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.txtPercentualDesconto = new System.Windows.Forms.TextBox();
            this.txtValorUntitario = new System.Windows.Forms.TextBox();
            this.btnInserirProduto = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtProdutoCodigo = new System.Windows.Forms.TextBox();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.txtProdutoDescricao = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gbxItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmitente
            // 
            this.lblEmitente.AutoSize = true;
            this.lblEmitente.Location = new System.Drawing.Point(19, 17);
            this.lblEmitente.Name = "lblEmitente";
            this.lblEmitente.Size = new System.Drawing.Size(48, 13);
            this.lblEmitente.TabIndex = 0;
            this.lblEmitente.Text = "Emitente";
            // 
            // txtEmitente
            // 
            this.txtEmitente.Location = new System.Drawing.Point(19, 37);
            this.txtEmitente.Name = "txtEmitente";
            this.txtEmitente.Size = new System.Drawing.Size(442, 20);
            this.txtEmitente.TabIndex = 1;
            // 
            // btnPesquisarEmitente
            // 
            this.btnPesquisarEmitente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarEmitente.Location = new System.Drawing.Point(467, 35);
            this.btnPesquisarEmitente.Name = "btnPesquisarEmitente";
            this.btnPesquisarEmitente.Size = new System.Drawing.Size(43, 23);
            this.btnPesquisarEmitente.TabIndex = 2;
            this.btnPesquisarEmitente.Text = ". . .";
            this.btnPesquisarEmitente.UseVisualStyleBackColor = true;
            this.btnPesquisarEmitente.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPesquisarDestinatario
            // 
            this.btnPesquisarDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarDestinatario.Location = new System.Drawing.Point(467, 84);
            this.btnPesquisarDestinatario.Name = "btnPesquisarDestinatario";
            this.btnPesquisarDestinatario.Size = new System.Drawing.Size(43, 23);
            this.btnPesquisarDestinatario.TabIndex = 4;
            this.btnPesquisarDestinatario.Text = ". . .";
            this.btnPesquisarDestinatario.UseVisualStyleBackColor = true;
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Location = new System.Drawing.Point(19, 86);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Size = new System.Drawing.Size(442, 20);
            this.txtDestinatario.TabIndex = 3;
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Location = new System.Drawing.Point(19, 66);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(63, 13);
            this.lblDestinatario.TabIndex = 3;
            this.lblDestinatario.Text = "Destinatário";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(525, 17);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 6;
            this.lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(525, 38);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(120, 20);
            this.txtNumero.TabIndex = 8;
            this.txtNumero.TabStop = false;
            // 
            // txtOperacao
            // 
            this.txtOperacao.Location = new System.Drawing.Point(525, 86);
            this.txtOperacao.Name = "txtOperacao";
            this.txtOperacao.ReadOnly = true;
            this.txtOperacao.Size = new System.Drawing.Size(120, 20);
            this.txtOperacao.TabIndex = 6;
            this.txtOperacao.TabStop = false;
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Location = new System.Drawing.Point(525, 65);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(54, 13);
            this.lblOperacao.TabIndex = 9;
            this.lblOperacao.Text = "Operação";
            // 
            // txtSituacao
            // 
            this.txtSituacao.Location = new System.Drawing.Point(651, 86);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(120, 20);
            this.txtSituacao.TabIndex = 7;
            this.txtSituacao.TabStop = false;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(651, 65);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(49, 13);
            this.lblSituacao.TabIndex = 13;
            this.lblSituacao.Text = "Situação";
            // 
            // txtDataHora
            // 
            this.txtDataHora.Location = new System.Drawing.Point(651, 38);
            this.txtDataHora.Name = "txtDataHora";
            this.txtDataHora.ReadOnly = true;
            this.txtDataHora.Size = new System.Drawing.Size(120, 20);
            this.txtDataHora.TabIndex = 5;
            this.txtDataHora.TabStop = false;
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Location = new System.Drawing.Point(651, 17);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(58, 13);
            this.lblDataHora.TabIndex = 11;
            this.lblDataHora.Text = "Data/Hora";
            // 
            // gbxItens
            // 
            this.gbxItens.Controls.Add(this.btnExcluir);
            this.gbxItens.Controls.Add(this.btnAlterar);
            this.gbxItens.Controls.Add(this.lblValor);
            this.gbxItens.Controls.Add(this.txtValor);
            this.gbxItens.Controls.Add(this.lblItens);
            this.gbxItens.Controls.Add(this.txtItens);
            this.gbxItens.Controls.Add(this.lblEstoque);
            this.gbxItens.Controls.Add(this.lblDesconto);
            this.gbxItens.Controls.Add(this.lblValorUnitario);
            this.gbxItens.Controls.Add(this.lblQuantidade);
            this.gbxItens.Controls.Add(this.dgvPrincipal);
            this.gbxItens.Controls.Add(this.lblProduto);
            this.gbxItens.Controls.Add(this.txtEstoque);
            this.gbxItens.Controls.Add(this.txtPercentualDesconto);
            this.gbxItens.Controls.Add(this.txtValorUntitario);
            this.gbxItens.Controls.Add(this.btnInserirProduto);
            this.gbxItens.Controls.Add(this.txtQuantidade);
            this.gbxItens.Controls.Add(this.txtProdutoCodigo);
            this.gbxItens.Controls.Add(this.btnPesquisarProduto);
            this.gbxItens.Controls.Add(this.txtProdutoDescricao);
            this.gbxItens.Location = new System.Drawing.Point(13, 116);
            this.gbxItens.Name = "gbxItens";
            this.gbxItens.Size = new System.Drawing.Size(759, 285);
            this.gbxItens.TabIndex = 14;
            this.gbxItens.TabStop = false;
            this.gbxItens.Text = "Itens";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(661, 251);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(578, 251);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 25;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(126, 256);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 24;
            this.lblValor.Text = "Valor:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(165, 252);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(70, 20);
            this.txtValor.TabIndex = 23;
            this.txtValor.TabStop = false;
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.Location = new System.Drawing.Point(10, 256);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(36, 13);
            this.lblItens.TabIndex = 22;
            this.lblItens.Text = "Itens: ";
            // 
            // txtItens
            // 
            this.txtItens.Location = new System.Drawing.Point(48, 252);
            this.txtItens.Name = "txtItens";
            this.txtItens.ReadOnly = true;
            this.txtItens.Size = new System.Drawing.Size(70, 20);
            this.txtItens.TabIndex = 21;
            this.txtItens.TabStop = false;
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(679, 20);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(46, 13);
            this.lblEstoque.TabIndex = 20;
            this.lblEstoque.Text = "Estoque";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(598, 20);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(64, 13);
            this.lblDesconto.TabIndex = 16;
            this.lblDesconto.Text = "% Desconto";
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(524, 20);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(70, 13);
            this.lblValorUnitario.TabIndex = 18;
            this.lblValorUnitario.Text = "Valor Unitário";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(376, 20);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 15;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Location = new System.Drawing.Point(6, 66);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.Size = new System.Drawing.Size(748, 179);
            this.dgvPrincipal.TabIndex = 0;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(3, 20);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 15;
            this.lblProduto.Text = "Produto";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(673, 40);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.ReadOnly = true;
            this.txtEstoque.Size = new System.Drawing.Size(65, 20);
            this.txtEstoque.TabIndex = 19;
            this.txtEstoque.TabStop = false;
            // 
            // txtPercentualDesconto
            // 
            this.txtPercentualDesconto.Location = new System.Drawing.Point(600, 40);
            this.txtPercentualDesconto.Name = "txtPercentualDesconto";
            this.txtPercentualDesconto.ReadOnly = true;
            this.txtPercentualDesconto.Size = new System.Drawing.Size(65, 20);
            this.txtPercentualDesconto.TabIndex = 15;
            this.txtPercentualDesconto.TabStop = false;
            // 
            // txtValorUntitario
            // 
            this.txtValorUntitario.Location = new System.Drawing.Point(527, 40);
            this.txtValorUntitario.Name = "txtValorUntitario";
            this.txtValorUntitario.ReadOnly = true;
            this.txtValorUntitario.Size = new System.Drawing.Size(65, 20);
            this.txtValorUntitario.TabIndex = 17;
            this.txtValorUntitario.TabStop = false;
            // 
            // btnInserirProduto
            // 
            this.btnInserirProduto.Location = new System.Drawing.Point(444, 39);
            this.btnInserirProduto.Name = "btnInserirProduto";
            this.btnInserirProduto.Size = new System.Drawing.Size(75, 23);
            this.btnInserirProduto.TabIndex = 17;
            this.btnInserirProduto.Text = "Inserir";
            this.btnInserirProduto.UseVisualStyleBackColor = true;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(376, 40);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(60, 20);
            this.txtQuantidade.TabIndex = 16;
            // 
            // txtProdutoCodigo
            // 
            this.txtProdutoCodigo.Location = new System.Drawing.Point(6, 40);
            this.txtProdutoCodigo.Name = "txtProdutoCodigo";
            this.txtProdutoCodigo.ReadOnly = true;
            this.txtProdutoCodigo.Size = new System.Drawing.Size(51, 20);
            this.txtProdutoCodigo.TabIndex = 15;
            this.txtProdutoCodigo.TabStop = false;
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarProduto.Location = new System.Drawing.Point(325, 39);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(43, 23);
            this.btnPesquisarProduto.TabIndex = 9;
            this.btnPesquisarProduto.Text = ". . .";
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            // 
            // txtProdutoDescricao
            // 
            this.txtProdutoDescricao.Location = new System.Drawing.Point(65, 40);
            this.txtProdutoDescricao.Name = "txtProdutoDescricao";
            this.txtProdutoDescricao.Size = new System.Drawing.Size(252, 20);
            this.txtProdutoDescricao.TabIndex = 8;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(530, 412);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 27;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(613, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(696, 412);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 29;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // FrmPedidoVendaCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gbxItens);
            this.Controls.Add(this.txtSituacao);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.txtDataHora);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.txtOperacao);
            this.Controls.Add(this.lblOperacao);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.btnPesquisarDestinatario);
            this.Controls.Add(this.txtDestinatario);
            this.Controls.Add(this.lblDestinatario);
            this.Controls.Add(this.btnPesquisarEmitente);
            this.Controls.Add(this.txtEmitente);
            this.Controls.Add(this.lblEmitente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPedidoVendaCadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto de Venda";
            this.gbxItens.ResumeLayout(false);
            this.gbxItens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmitente;
        private System.Windows.Forms.TextBox txtEmitente;
        private System.Windows.Forms.Button btnPesquisarEmitente;
        private System.Windows.Forms.Button btnPesquisarDestinatario;
        private System.Windows.Forms.TextBox txtDestinatario;
        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtOperacao;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.TextBox txtDataHora;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.GroupBox gbxItens;
        private System.Windows.Forms.TextBox txtProdutoCodigo;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.TextBox txtProdutoDescricao;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.TextBox txtItens;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.TextBox txtPercentualDesconto;
        private System.Windows.Forms.TextBox txtValorUntitario;
        private System.Windows.Forms.Button btnInserirProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFechar;
    }
}