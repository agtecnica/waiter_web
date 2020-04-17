namespace GUI.Operacoes
{
    partial class FrmVendaBalcao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVendaBalcao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumeroCaixa = new System.Windows.Forms.Label();
            this.lblClienteId = new System.Windows.Forms.Label();
            this.lblOperadorNome = new System.Windows.Forms.Label();
            this.lblNomeOperador = new System.Windows.Forms.Label();
            this.lblOperador = new System.Windows.Forms.Label();
            this.lblTopVendasBalcao = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.lblPrecoUnit = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPrecoUnit = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnRecuperarPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAlterarQtde = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovoPedido = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIncluirCliente = new System.Windows.Forms.Button();
            this.btnSair = new RoundLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labCNPJempresa = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labIEempresa = new System.Windows.Forms.Label();
            this.labIMempresa = new System.Windows.Forms.Label();
            this.labEnderecoEmpresa = new System.Windows.Forms.Label();
            this.labNomeEmpresa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvGeral = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecoTotal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblProduto = new RoundLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblNumeroCaixa);
            this.panel1.Controls.Add(this.lblClienteId);
            this.panel1.Controls.Add(this.lblOperadorNome);
            this.panel1.Controls.Add(this.lblNomeOperador);
            this.panel1.Controls.Add(this.lblOperador);
            this.panel1.Controls.Add(this.lblTopVendasBalcao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 42);
            this.panel1.TabIndex = 21;
            // 
            // lblNumeroCaixa
            // 
            this.lblNumeroCaixa.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNumeroCaixa.BackColor = System.Drawing.Color.Gray;
            this.lblNumeroCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumeroCaixa.ForeColor = System.Drawing.Color.White;
            this.lblNumeroCaixa.Location = new System.Drawing.Point(678, 11);
            this.lblNumeroCaixa.Name = "lblNumeroCaixa";
            this.lblNumeroCaixa.Size = new System.Drawing.Size(120, 21);
            this.lblNumeroCaixa.TabIndex = 28;
            this.lblNumeroCaixa.Text = "Caixa 1";
            this.lblNumeroCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClienteId
            // 
            this.lblClienteId.AutoSize = true;
            this.lblClienteId.BackColor = System.Drawing.Color.Gray;
            this.lblClienteId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteId.ForeColor = System.Drawing.Color.White;
            this.lblClienteId.Location = new System.Drawing.Point(511, 16);
            this.lblClienteId.Name = "lblClienteId";
            this.lblClienteId.Size = new System.Drawing.Size(62, 14);
            this.lblClienteId.TabIndex = 28;
            this.lblClienteId.Text = "lblUsuarioId";
            this.lblClienteId.Visible = false;
            // 
            // lblOperadorNome
            // 
            this.lblOperadorNome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOperadorNome.BackColor = System.Drawing.Color.Gray;
            this.lblOperadorNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperadorNome.ForeColor = System.Drawing.Color.White;
            this.lblOperadorNome.Location = new System.Drawing.Point(867, 11);
            this.lblOperadorNome.Name = "lblOperadorNome";
            this.lblOperadorNome.Size = new System.Drawing.Size(196, 20);
            this.lblOperadorNome.TabIndex = 27;
            // 
            // lblNomeOperador
            // 
            this.lblNomeOperador.AutoSize = true;
            this.lblNomeOperador.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeOperador.Location = new System.Drawing.Point(929, 14);
            this.lblNomeOperador.Name = "lblNomeOperador";
            this.lblNomeOperador.Size = new System.Drawing.Size(0, 20);
            this.lblNomeOperador.TabIndex = 26;
            // 
            // lblOperador
            // 
            this.lblOperador.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOperador.BackColor = System.Drawing.Color.Gray;
            this.lblOperador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperador.ForeColor = System.Drawing.Color.White;
            this.lblOperador.Location = new System.Drawing.Point(770, 11);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(91, 20);
            this.lblOperador.TabIndex = 25;
            this.lblOperador.Text = "- Operador:";
            this.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTopVendasBalcao
            // 
            this.lblTopVendasBalcao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopVendasBalcao.BackColor = System.Drawing.Color.Gray;
            this.lblTopVendasBalcao.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopVendasBalcao.ForeColor = System.Drawing.Color.White;
            this.lblTopVendasBalcao.Location = new System.Drawing.Point(3, 6);
            this.lblTopVendasBalcao.Name = "lblTopVendasBalcao";
            this.lblTopVendasBalcao.Size = new System.Drawing.Size(1070, 33);
            this.lblTopVendasBalcao.TabIndex = 0;
            this.lblTopVendasBalcao.Text = "SUPPSYS SYSTEM";
            this.lblTopVendasBalcao.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblQtde
            // 
            this.lblQtde.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblQtde.AutoSize = true;
            this.lblQtde.BackColor = System.Drawing.Color.Transparent;
            this.lblQtde.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.ForeColor = System.Drawing.Color.Black;
            this.lblQtde.Location = new System.Drawing.Point(30, 201);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(97, 16);
            this.lblQtde.TabIndex = 19;
            this.lblQtde.Text = "Quantidade:";
            // 
            // lblPrecoUnit
            // 
            this.lblPrecoUnit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblPrecoUnit.AutoSize = true;
            this.lblPrecoUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecoUnit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoUnit.ForeColor = System.Drawing.Color.Black;
            this.lblPrecoUnit.Location = new System.Drawing.Point(30, 282);
            this.lblPrecoUnit.Name = "lblPrecoUnit";
            this.lblPrecoUnit.Size = new System.Drawing.Size(110, 16);
            this.lblPrecoUnit.TabIndex = 18;
            this.lblPrecoUnit.Text = "Preço Unitário";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubTotal.Location = new System.Drawing.Point(30, 584);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(80, 16);
            this.lblSubTotal.TabIndex = 17;
            this.lblSubTotal.Text = "Sub Total:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Verdana", 28F);
            this.txtCodigo.ForeColor = System.Drawing.Color.Black;
            this.txtCodigo.Location = new System.Drawing.Point(30, 141);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(379, 53);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // txtPrecoUnit
            // 
            this.txtPrecoUnit.BackColor = System.Drawing.Color.White;
            this.txtPrecoUnit.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoUnit.ForeColor = System.Drawing.Color.Sienna;
            this.txtPrecoUnit.Location = new System.Drawing.Point(30, 302);
            this.txtPrecoUnit.Multiline = true;
            this.txtPrecoUnit.Name = "txtPrecoUnit";
            this.txtPrecoUnit.Size = new System.Drawing.Size(258, 45);
            this.txtPrecoUnit.TabIndex = 7;
            this.txtPrecoUnit.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 42);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1085, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(305, 580);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(134, 24);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total Geral:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Código Item:";
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.White;
            this.txtQtde.Font = new System.Drawing.Font("Verdana", 28F);
            this.txtQtde.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtQtde.Location = new System.Drawing.Point(30, 221);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(258, 53);
            this.txtQtde.TabIndex = 40;
            this.txtQtde.TabStop = false;
            this.txtQtde.Text = "1,000";
            this.txtQtde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtde_KeyDown);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFinalizarVenda.BackColor = System.Drawing.Color.Transparent;
            this.btnFinalizarVenda.FlatAppearance.BorderSize = 0;
            this.btnFinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenda.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenda.Location = new System.Drawing.Point(187, 5);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(166, 30);
            this.btnFinalizarVenda.TabIndex = 49;
            this.btnFinalizarVenda.TabStop = false;
            this.btnFinalizarVenda.Text = "FINALIZAR VENDA - F5";
            this.btnFinalizarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizarVenda.UseVisualStyleBackColor = false;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExcluirItem.BackColor = System.Drawing.Color.Transparent;
            this.btnExcluirItem.FlatAppearance.BorderSize = 0;
            this.btnExcluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirItem.ForeColor = System.Drawing.Color.White;
            this.btnExcluirItem.Location = new System.Drawing.Point(187, 29);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(166, 30);
            this.btnExcluirItem.TabIndex = 42;
            this.btnExcluirItem.TabStop = false;
            this.btnExcluirItem.Text = "EXCLUIR ITEM - F4";
            this.btnExcluirItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirItem.UseVisualStyleBackColor = false;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            // 
            // btnRecuperarPedido
            // 
            this.btnRecuperarPedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRecuperarPedido.BackColor = System.Drawing.Color.Transparent;
            this.btnRecuperarPedido.FlatAppearance.BorderSize = 0;
            this.btnRecuperarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperarPedido.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperarPedido.ForeColor = System.Drawing.Color.White;
            this.btnRecuperarPedido.Location = new System.Drawing.Point(362, 29);
            this.btnRecuperarPedido.Name = "btnRecuperarPedido";
            this.btnRecuperarPedido.Size = new System.Drawing.Size(182, 30);
            this.btnRecuperarPedido.TabIndex = 46;
            this.btnRecuperarPedido.TabStop = false;
            this.btnRecuperarPedido.Text = "RECUPERAR PEDIDO - F7";
            this.btnRecuperarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecuperarPedido.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(547, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(166, 30);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "CANCELAR VENDA - F8";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAlterarQtde
            // 
            this.btnAlterarQtde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAlterarQtde.BackColor = System.Drawing.Color.Transparent;
            this.btnAlterarQtde.FlatAppearance.BorderSize = 0;
            this.btnAlterarQtde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterarQtde.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarQtde.ForeColor = System.Drawing.Color.White;
            this.btnAlterarQtde.Location = new System.Drawing.Point(18, 29);
            this.btnAlterarQtde.Name = "btnAlterarQtde";
            this.btnAlterarQtde.Size = new System.Drawing.Size(166, 30);
            this.btnAlterarQtde.TabIndex = 45;
            this.btnAlterarQtde.TabStop = false;
            this.btnAlterarQtde.Text = "ALTERAR QTDE - F2";
            this.btnAlterarQtde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterarQtde.UseVisualStyleBackColor = false;
            this.btnAlterarQtde.Click += new System.EventHandler(this.btnAlterarQtde_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(18, 5);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(166, 30);
            this.btnPesquisar.TabIndex = 44;
            this.btnPesquisar.TabStop = false;
            this.btnPesquisar.Text = "PESQUISAR - F3";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnNovoPedido
            // 
            this.btnNovoPedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNovoPedido.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoPedido.FlatAppearance.BorderSize = 0;
            this.btnNovoPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoPedido.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoPedido.ForeColor = System.Drawing.Color.White;
            this.btnNovoPedido.Location = new System.Drawing.Point(362, 5);
            this.btnNovoPedido.Name = "btnNovoPedido";
            this.btnNovoPedido.Size = new System.Drawing.Size(166, 30);
            this.btnNovoPedido.TabIndex = 47;
            this.btnNovoPedido.TabStop = false;
            this.btnNovoPedido.Text = "NOVO PEDIDO - F6";
            this.btnNovoPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoPedido.UseVisualStyleBackColor = false;
            this.btnNovoPedido.Click += new System.EventHandler(this.btnNovoPedido_Click);
            this.btnNovoPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNovoPedido_KeyDown);
            this.btnNovoPedido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmVendaBalcao_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnIncluirCliente);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Controls.Add(this.btnExcluirItem);
            this.panel2.Controls.Add(this.btnNovoPedido);
            this.panel2.Controls.Add(this.btnFinalizarVenda);
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Controls.Add(this.btnAlterarQtde);
            this.panel2.Controls.Add(this.btnRecuperarPedido);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(0, 734);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 67);
            this.panel2.TabIndex = 51;
            // 
            // btnIncluirCliente
            // 
            this.btnIncluirCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnIncluirCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnIncluirCliente.FlatAppearance.BorderSize = 0;
            this.btnIncluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncluirCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluirCliente.ForeColor = System.Drawing.Color.White;
            this.btnIncluirCliente.Location = new System.Drawing.Point(547, 29);
            this.btnIncluirCliente.Name = "btnIncluirCliente";
            this.btnIncluirCliente.Size = new System.Drawing.Size(166, 30);
            this.btnIncluirCliente.TabIndex = 61;
            this.btnIncluirCliente.TabStop = false;
            this.btnIncluirCliente.Text = "INCLUIR CLIENTE - F9";
            this.btnIncluirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluirCliente.UseVisualStyleBackColor = false;
            this.btnIncluirCliente.Click += new System.EventHandler(this.btnIncluirCliente_Click);
            // 
            // btnSair
            // 
            this.btnSair._BackColor = System.Drawing.Color.Green;
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(924, 14);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(140, 41);
            this.btnSair.TabIndex = 60;
            this.btnSair.Text = "SAIR- ESC";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.Click += new System.EventHandler(this.roundLabel1_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.labIEempresa);
            this.panel3.Controls.Add(this.labIMempresa);
            this.panel3.Controls.Add(this.labEnderecoEmpresa);
            this.panel3.Controls.Add(this.labNomeEmpresa);
            this.panel3.Location = new System.Drawing.Point(582, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 104);
            this.panel3.TabIndex = 53;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.labCNPJempresa);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(147, 52);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 16);
            this.panel4.TabIndex = 26;
            // 
            // labCNPJempresa
            // 
            this.labCNPJempresa.BackColor = System.Drawing.SystemColors.GrayText;
            this.labCNPJempresa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labCNPJempresa.Dock = System.Windows.Forms.DockStyle.Right;
            this.labCNPJempresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.labCNPJempresa.ForeColor = System.Drawing.Color.White;
            this.labCNPJempresa.Location = new System.Drawing.Point(50, 0);
            this.labCNPJempresa.Mask = "00,000,000/0000-00";
            this.labCNPJempresa.Name = "labCNPJempresa";
            this.labCNPJempresa.Size = new System.Drawing.Size(150, 14);
            this.labCNPJempresa.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "CNPJ: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(169, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "CUPOM DE VENDA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labIEempresa
            // 
            this.labIEempresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labIEempresa.BackColor = System.Drawing.Color.Transparent;
            this.labIEempresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIEempresa.ForeColor = System.Drawing.Color.White;
            this.labIEempresa.Location = new System.Drawing.Point(129, 36);
            this.labIEempresa.Name = "labIEempresa";
            this.labIEempresa.Size = new System.Drawing.Size(230, 16);
            this.labIEempresa.TabIndex = 22;
            this.labIEempresa.Text = "1111111111111111111111";
            this.labIEempresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labIMempresa
            // 
            this.labIMempresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labIMempresa.BackColor = System.Drawing.Color.Transparent;
            this.labIMempresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIMempresa.ForeColor = System.Drawing.Color.White;
            this.labIMempresa.Location = new System.Drawing.Point(129, 65);
            this.labIMempresa.Name = "labIMempresa";
            this.labIMempresa.Size = new System.Drawing.Size(230, 18);
            this.labIMempresa.TabIndex = 21;
            this.labIMempresa.Text = " 1111111111111111111111";
            this.labIMempresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labEnderecoEmpresa
            // 
            this.labEnderecoEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labEnderecoEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.labEnderecoEmpresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEnderecoEmpresa.ForeColor = System.Drawing.Color.White;
            this.labEnderecoEmpresa.Location = new System.Drawing.Point(18, 20);
            this.labEnderecoEmpresa.Name = "labEnderecoEmpresa";
            this.labEnderecoEmpresa.Size = new System.Drawing.Size(453, 15);
            this.labEnderecoEmpresa.TabIndex = 19;
            this.labEnderecoEmpresa.Text = "Av.cosme ferreira S/N 9 9281-9474";
            this.labEnderecoEmpresa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labNomeEmpresa
            // 
            this.labNomeEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labNomeEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.labNomeEmpresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNomeEmpresa.ForeColor = System.Drawing.Color.White;
            this.labNomeEmpresa.Location = new System.Drawing.Point(127, 2);
            this.labNomeEmpresa.Name = "labNomeEmpresa";
            this.labNomeEmpresa.Size = new System.Drawing.Size(235, 22);
            this.labNomeEmpresa.TabIndex = 18;
            this.labNomeEmpresa.Text = "Jv informatica";
            this.labNomeEmpresa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(158, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 38);
            this.label3.TabIndex = 54;
            this.label3.Text = "SUPPSYS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvGeral
            // 
            this.dgvGeral.AllowUserToAddRows = false;
            this.dgvGeral.AllowUserToDeleteRows = false;
            this.dgvGeral.AllowUserToOrderColumns = true;
            this.dgvGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGeral.BackgroundColor = System.Drawing.Color.White;
            this.dgvGeral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGeral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGeral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.ProdutoId,
            this.Descricao,
            this.Quantidade,
            this.UnidMedida,
            this.ValorUnit,
            this.ValorTotal});
            this.dgvGeral.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGeral.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGeral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGeral.EnableHeadersVisualStyles = false;
            this.dgvGeral.GridColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvGeral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvGeral.Location = new System.Drawing.Point(582, 232);
            this.dgvGeral.MaximumSize = new System.Drawing.Size(1350, 600);
            this.dgvGeral.Name = "dgvGeral";
            this.dgvGeral.ReadOnly = true;
            this.dgvGeral.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeral.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvGeral.RowHeadersVisible = false;
            this.dgvGeral.RowHeadersWidth = 25;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvGeral.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvGeral.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvGeral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeral.Size = new System.Drawing.Size(481, 432);
            this.dgvGeral.TabIndex = 60;
            this.dgvGeral.TabStop = false;
            this.dgvGeral.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGeral_CellContentClick);
            // 
            // item
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.item.DefaultCellStyle = dataGridViewCellStyle2;
            this.item.HeaderText = "Item Nº";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // ProdutoId
            // 
            this.ProdutoId.HeaderText = "Código";
            this.ProdutoId.Name = "ProdutoId";
            this.ProdutoId.ReadOnly = true;
            this.ProdutoId.Visible = false;
            // 
            // Descricao
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Quantidade
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle4;
            this.Quantidade.HeaderText = "Qtde";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // UnidMedida
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.UnidMedida.DefaultCellStyle = dataGridViewCellStyle5;
            this.UnidMedida.HeaderText = "Unid";
            this.UnidMedida.Name = "UnidMedida";
            this.UnidMedida.ReadOnly = true;
            // 
            // ValorUnit
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorUnit.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValorUnit.HeaderText = "Valor Unit.";
            this.ValorUnit.Name = "ValorUnit";
            this.ValorUnit.ReadOnly = true;
            // 
            // ValorTotal
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SeaGreen;
            this.label4.Location = new System.Drawing.Point(67, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(432, 58);
            this.label4.TabIndex = 64;
            this.label4.Text = "SISTEMAS PARA AUTOMAÇÃO COMERCIAL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrecoTotal
            // 
            this.txtPrecoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPrecoTotal.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecoTotal.ForeColor = System.Drawing.Color.White;
            this.txtPrecoTotal.Image = ((System.Drawing.Image)(resources.GetObject("txtPrecoTotal.Image")));
            this.txtPrecoTotal.Location = new System.Drawing.Point(33, 604);
            this.txtPrecoTotal.Name = "txtPrecoTotal";
            this.txtPrecoTotal.Size = new System.Drawing.Size(255, 60);
            this.txtPrecoTotal.TabIndex = 62;
            this.txtPrecoTotal.Text = "0,00";
            this.txtPrecoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblValorTotal.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.White;
            this.lblValorTotal.Image = ((System.Drawing.Image)(resources.GetObject("lblValorTotal.Image")));
            this.lblValorTotal.Location = new System.Drawing.Point(302, 604);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(255, 60);
            this.lblValorTotal.TabIndex = 61;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProduto
            // 
            this.lblProduto._BackColor = System.Drawing.Color.Green;
            this.lblProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProduto.BackColor = System.Drawing.Color.Transparent;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblProduto.ForeColor = System.Drawing.Color.White;
            this.lblProduto.Location = new System.Drawing.Point(30, 47);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(1033, 60);
            this.lblProduto.TabIndex = 56;
            // 
            // FrmVendaBalcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 801);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecoTotal);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.dgvGeral);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txtPrecoUnit);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblPrecoUnit);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVendaBalcao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "      ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVendaBalcao_FormClosed);
            this.Load += new System.EventHandler(this.FrmVendaBalcao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendaBalcao_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApresentaProd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label lblPrecoUnit;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtPrecoUnit;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNomeOperador;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label lblNumeroCaixa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _item;
        public System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblOperadorNome;
        public System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnRecuperarPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAlterarQtde;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovoPedido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labIEempresa;
        private System.Windows.Forms.Label labIMempresa;
        private System.Windows.Forms.Label labEnderecoEmpresa;
        private System.Windows.Forms.Label labNomeEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox labCNPJempresa;
        private System.Windows.Forms.Label label3;
        private RoundLabel lblProduto;
        private RoundLabel btnSair;
        public System.Windows.Forms.DataGridView dgvGeral;
        public System.Windows.Forms.Label lblValorTotal;
        public System.Windows.Forms.Label txtPrecoTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnIncluirCliente;
        private System.Windows.Forms.Label lblTopVendasBalcao;
        public System.Windows.Forms.Label lblClienteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
    }
}