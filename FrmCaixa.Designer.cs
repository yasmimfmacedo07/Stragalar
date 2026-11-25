namespace Stragalar.Telas
{
    partial class FrmCaixa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tmrPesquisaProduto = new System.Windows.Forms.Timer(this.components);
            this.menuPagamento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuColarPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLimparPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.btnNovoItem = new System.Windows.Forms.Button();
            this.pnlAreaCaixa = new System.Windows.Forms.Panel();
            this.lblRetorno = new System.Windows.Forms.Label();
            this.lblSessao = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.abas = new System.Windows.Forms.TabControl();
            this.tabSessao = new System.Windows.Forms.TabPage();
            this.grpResumoCaixa = new System.Windows.Forms.GroupBox();
            this.tlpResumoCaixa = new System.Windows.Forms.TableLayoutPanel();
            this.pnlResumoVendas = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblResumoAbertura = new System.Windows.Forms.Label();
            this.lblResumoVendas = new System.Windows.Forms.Label();
            this.lblResumoSaldo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlResumoContagem = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblResumoContado = new System.Windows.Forms.Label();
            this.lblResumoSobra = new System.Windows.Forms.Label();
            this.lblResumoFalta = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpOperacaoCaixa = new System.Windows.Forms.GroupBox();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.btnAbrirCaixa = new System.Windows.Forms.Button();
            this.nudValorCaixa = new System.Windows.Forms.NumericUpDown();
            this.lblValorCaixa = new System.Windows.Forms.Label();
            this.tabVenda = new System.Windows.Forms.TabPage();
            this.grpPagamento = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblFalta = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.mtbCredito = new System.Windows.Forms.MaskedTextBox();
            this.mtbDebito = new System.Windows.Forms.MaskedTextBox();
            this.mtbPix = new System.Windows.Forms.MaskedTextBox();
            this.mtbDinheiro = new System.Windows.Forms.MaskedTextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.lblDebito = new System.Windows.Forms.Label();
            this.lblPix = new System.Windows.Forms.Label();
            this.lblDinheiro = new System.Windows.Forms.Label();
            this.grpCarrinho = new System.Windows.Forms.GroupBox();
            this.lblTotalVendas = new System.Windows.Forms.Label();
            this.dvgCarrinhoCompra = new System.Windows.Forms.DataGridView();
            this.colProdutoCarrinho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidadeCarrinho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitarioCarrinho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotalCarrinho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnAtualizarItem = new System.Windows.Forms.Button();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.nudQuantidadeCarrinho = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidade2 = new System.Windows.Forms.Label();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.lblRotuloEstoque2 = new System.Windows.Forms.Label();
            this.cmbProdutoPesquisa = new System.Windows.Forms.ComboBox();
            this.lblProdutoCarrinho = new System.Windows.Forms.Label();
            this.tabHistorico = new System.Windows.Forms.TabPage();
            this.tlpHistorico = new System.Windows.Forms.TableLayoutPanel();
            this.lblVendas = new System.Windows.Forms.Label();
            this.dvgVendas = new System.Windows.Forms.DataGridView();
            this.pnlEstorno = new System.Windows.Forms.TableLayoutPanel();
            this.lblMotivoEstorno = new System.Windows.Forms.Label();
            this.txbMotivoEstorno = new System.Windows.Forms.TextBox();
            this.btnEstornar = new System.Windows.Forms.Button();
            this.lblMovimentos = new System.Windows.Forms.Label();
            this.dvgMovimentacoes = new System.Windows.Forms.DataGridView();
            this.tabSangria = new System.Windows.Forms.TabPage();
            this.grpSangria = new System.Windows.Forms.GroupBox();
            this.lblSaldoSangria = new System.Windows.Forms.Label();
            this.lblLinhaSangria = new System.Windows.Forms.Label();
            this.lblValorSangria = new System.Windows.Forms.Label();
            this.nudSangria = new System.Windows.Forms.NumericUpDown();
            this.lblMotivoSangria = new System.Windows.Forms.Label();
            this.txbMotivoSangria = new System.Windows.Forms.TextBox();
            this.btnRegistrarSangria = new System.Windows.Forms.Button();
            this.menuPagamento.SuspendLayout();
            this.pnlAreaCaixa.SuspendLayout();
            this.abas.SuspendLayout();
            this.tabSessao.SuspendLayout();
            this.grpResumoCaixa.SuspendLayout();
            this.tlpResumoCaixa.SuspendLayout();
            this.pnlResumoVendas.SuspendLayout();
            this.pnlResumoContagem.SuspendLayout();
            this.grpOperacaoCaixa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorCaixa)).BeginInit();
            this.tabVenda.SuspendLayout();
            this.grpPagamento.SuspendLayout();
            this.grpCarrinho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCarrinhoCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeCarrinho)).BeginInit();
            this.tabHistorico.SuspendLayout();
            this.tlpHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVendas)).BeginInit();
            this.pnlEstorno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgMovimentacoes)).BeginInit();
            this.tabSangria.SuspendLayout();
            this.grpSangria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSangria)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrPesquisaProduto
            // 
            this.tmrPesquisaProduto.Interval = 150;
            this.tmrPesquisaProduto.Tick += new System.EventHandler(this.tmrPesquisaProduto_Tick);
            // 
            // menuPagamento
            // 
            this.menuPagamento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColarPagamento,
            this.mnuLimparPagamento});
            this.menuPagamento.Name = "menuPagamento";
            this.menuPagamento.Size = new System.Drawing.Size(112, 48);
            // 
            // mnuColarPagamento
            // 
            this.mnuColarPagamento.Name = "mnuColarPagamento";
            this.mnuColarPagamento.Size = new System.Drawing.Size(111, 22);
            this.mnuColarPagamento.Text = "Colar";
            this.mnuColarPagamento.Click += new System.EventHandler(this.mnuColarPagamento_Click);
            // 
            // mnuLimparPagamento
            // 
            this.mnuLimparPagamento.Name = "mnuLimparPagamento";
            this.mnuLimparPagamento.Size = new System.Drawing.Size(111, 22);
            this.mnuLimparPagamento.Text = "Limpar";
            this.mnuLimparPagamento.Click += new System.EventHandler(this.mnuLimparPagamento_Click);
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrecoProduto.AutoEllipsis = true;
            this.lblPrecoProduto.Location = new System.Drawing.Point(158, 87);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(192, 32);
            this.lblPrecoProduto.TabIndex = 0;
            this.lblPrecoProduto.Text = "Unitário: —";
            this.lblPrecoProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNovoItem
            // 
            this.btnNovoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovoItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNovoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoItem.Location = new System.Drawing.Point(164, 311);
            this.btnNovoItem.Name = "btnNovoItem";
            this.btnNovoItem.Size = new System.Drawing.Size(140, 32);
            this.btnNovoItem.TabIndex = 6;
            this.btnNovoItem.Text = "Novo item";
            this.btnNovoItem.UseVisualStyleBackColor = false;
            this.btnNovoItem.Click += new System.EventHandler(this.btnNovoItem_Click);
            // 
            // pnlAreaCaixa
            // 
            this.pnlAreaCaixa.Controls.Add(this.lblRetorno);
            this.pnlAreaCaixa.Controls.Add(this.lblSessao);
            this.pnlAreaCaixa.Controls.Add(this.lblTitulo);
            this.pnlAreaCaixa.Controls.Add(this.abas);
            this.pnlAreaCaixa.Location = new System.Drawing.Point(0, 0);
            this.pnlAreaCaixa.MinimumSize = new System.Drawing.Size(864, 575);
            this.pnlAreaCaixa.Name = "pnlAreaCaixa";
            this.pnlAreaCaixa.Size = new System.Drawing.Size(864, 575);
            this.pnlAreaCaixa.TabIndex = 0;
            // 
            // lblRetorno
            // 
            this.lblRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRetorno.Location = new System.Drawing.Point(20, 543);
            this.lblRetorno.Name = "lblRetorno";
            this.lblRetorno.Size = new System.Drawing.Size(824, 22);
            this.lblRetorno.TabIndex = 6;
            // 
            // lblSessao
            // 
            this.lblSessao.AutoSize = true;
            this.lblSessao.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSessao.Location = new System.Drawing.Point(20, 52);
            this.lblSessao.Name = "lblSessao";
            this.lblSessao.Size = new System.Drawing.Size(106, 21);
            this.lblSessao.TabIndex = 5;
            this.lblSessao.Text = "Caixa fechado";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(95, 41);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Caixa";
            // 
            // abas
            // 
            this.abas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.abas.Controls.Add(this.tabSessao);
            this.abas.Controls.Add(this.tabVenda);
            this.abas.Controls.Add(this.tabHistorico);
            this.abas.Controls.Add(this.tabSangria);
            this.abas.Location = new System.Drawing.Point(20, 79);
            this.abas.Name = "abas";
            this.abas.SelectedIndex = 0;
            this.abas.Size = new System.Drawing.Size(824, 453);
            this.abas.TabIndex = 0;
            this.abas.SelectedIndexChanged += new System.EventHandler(this.abas_SelectedIndexChanged);
            // 
            // tabSessao
            // 
            this.tabSessao.Controls.Add(this.grpResumoCaixa);
            this.tabSessao.Controls.Add(this.grpOperacaoCaixa);
            this.tabSessao.Location = new System.Drawing.Point(4, 26);
            this.tabSessao.Name = "tabSessao";
            this.tabSessao.Padding = new System.Windows.Forms.Padding(3);
            this.tabSessao.Size = new System.Drawing.Size(816, 423);
            this.tabSessao.TabIndex = 3;
            this.tabSessao.Text = "Abertura e Fechamento";
            this.tabSessao.UseVisualStyleBackColor = true;
            // 
            // grpResumoCaixa
            // 
            this.grpResumoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResumoCaixa.Controls.Add(this.tlpResumoCaixa);
            this.grpResumoCaixa.Location = new System.Drawing.Point(12, 121);
            this.grpResumoCaixa.Name = "grpResumoCaixa";
            this.grpResumoCaixa.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.grpResumoCaixa.Size = new System.Drawing.Size(792, 172);
            this.grpResumoCaixa.TabIndex = 1;
            this.grpResumoCaixa.TabStop = false;
            this.grpResumoCaixa.Text = "Resumo do caixa";
            // 
            // tlpResumoCaixa
            // 
            this.tlpResumoCaixa.ColumnCount = 2;
            this.tlpResumoCaixa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumoCaixa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumoCaixa.Controls.Add(this.pnlResumoVendas, 0, 0);
            this.tlpResumoCaixa.Controls.Add(this.pnlResumoContagem, 1, 0);
            this.tlpResumoCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumoCaixa.Location = new System.Drawing.Point(16, 28);
            this.tlpResumoCaixa.Name = "tlpResumoCaixa";
            this.tlpResumoCaixa.RowCount = 1;
            this.tlpResumoCaixa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumoCaixa.Size = new System.Drawing.Size(760, 134);
            this.tlpResumoCaixa.TabIndex = 0;
            // 
            // pnlResumoVendas
            // 
            this.pnlResumoVendas.Controls.Add(this.label2);
            this.pnlResumoVendas.Controls.Add(this.label10);
            this.pnlResumoVendas.Controls.Add(this.label12);
            this.pnlResumoVendas.Controls.Add(this.lblResumoAbertura);
            this.pnlResumoVendas.Controls.Add(this.lblResumoVendas);
            this.pnlResumoVendas.Controls.Add(this.lblResumoSaldo);
            this.pnlResumoVendas.Controls.Add(this.label3);
            this.pnlResumoVendas.Controls.Add(this.label4);
            this.pnlResumoVendas.Controls.Add(this.label5);
            this.pnlResumoVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumoVendas.Location = new System.Drawing.Point(0, 0);
            this.pnlResumoVendas.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlResumoVendas.Name = "pnlResumoVendas";
            this.pnlResumoVendas.Size = new System.Drawing.Size(368, 134);
            this.pnlResumoVendas.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label2.Enabled = false;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(0, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 1);
            this.label2.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label10.Enabled = false;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(0, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 1);
            this.label10.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label12.Enabled = false;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(0, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(368, 1);
            this.label12.TabIndex = 16;
            // 
            // lblResumoAbertura
            // 
            this.lblResumoAbertura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoAbertura.Location = new System.Drawing.Point(212, 7);
            this.lblResumoAbertura.Name = "lblResumoAbertura";
            this.lblResumoAbertura.Size = new System.Drawing.Size(130, 24);
            this.lblResumoAbertura.TabIndex = 6;
            this.lblResumoAbertura.Text = "—";
            this.lblResumoAbertura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResumoVendas
            // 
            this.lblResumoVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoVendas.Location = new System.Drawing.Point(212, 50);
            this.lblResumoVendas.Name = "lblResumoVendas";
            this.lblResumoVendas.Size = new System.Drawing.Size(130, 24);
            this.lblResumoVendas.TabIndex = 7;
            this.lblResumoVendas.Text = "—";
            this.lblResumoVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResumoSaldo
            // 
            this.lblResumoSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoSaldo.Location = new System.Drawing.Point(212, 93);
            this.lblResumoSaldo.Name = "lblResumoSaldo";
            this.lblResumoSaldo.Size = new System.Drawing.Size(130, 24);
            this.lblResumoSaldo.TabIndex = 8;
            this.lblResumoSaldo.Text = "—";
            this.lblResumoSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valor de abertura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total de vendas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Saldo esperado em dinheiro";
            // 
            // pnlResumoContagem
            // 
            this.pnlResumoContagem.Controls.Add(this.label9);
            this.pnlResumoContagem.Controls.Add(this.label11);
            this.pnlResumoContagem.Controls.Add(this.label13);
            this.pnlResumoContagem.Controls.Add(this.lblResumoContado);
            this.pnlResumoContagem.Controls.Add(this.lblResumoSobra);
            this.pnlResumoContagem.Controls.Add(this.lblResumoFalta);
            this.pnlResumoContagem.Controls.Add(this.label6);
            this.pnlResumoContagem.Controls.Add(this.label7);
            this.pnlResumoContagem.Controls.Add(this.label8);
            this.pnlResumoContagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumoContagem.Location = new System.Drawing.Point(392, 0);
            this.pnlResumoContagem.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlResumoContagem.Name = "pnlResumoContagem";
            this.pnlResumoContagem.Size = new System.Drawing.Size(368, 134);
            this.pnlResumoContagem.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label9.Enabled = false;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(0, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(368, 1);
            this.label9.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label11.Enabled = false;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(0, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(368, 1);
            this.label11.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.label13.Enabled = false;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(0, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(368, 1);
            this.label13.TabIndex = 17;
            // 
            // lblResumoContado
            // 
            this.lblResumoContado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoContado.Location = new System.Drawing.Point(233, 7);
            this.lblResumoContado.Name = "lblResumoContado";
            this.lblResumoContado.Size = new System.Drawing.Size(130, 24);
            this.lblResumoContado.TabIndex = 9;
            this.lblResumoContado.Text = "—";
            this.lblResumoContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResumoSobra
            // 
            this.lblResumoSobra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoSobra.Location = new System.Drawing.Point(233, 50);
            this.lblResumoSobra.Name = "lblResumoSobra";
            this.lblResumoSobra.Size = new System.Drawing.Size(130, 24);
            this.lblResumoSobra.TabIndex = 10;
            this.lblResumoSobra.Text = "—";
            this.lblResumoSobra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResumoFalta
            // 
            this.lblResumoFalta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoFalta.Location = new System.Drawing.Point(233, 93);
            this.lblResumoFalta.Name = "lblResumoFalta";
            this.lblResumoFalta.Size = new System.Drawing.Size(130, 24);
            this.lblResumoFalta.TabIndex = 11;
            this.lblResumoFalta.Text = "—";
            this.lblResumoFalta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Valor contado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sobra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Falta";
            // 
            // grpOperacaoCaixa
            // 
            this.grpOperacaoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOperacaoCaixa.Controls.Add(this.btnFecharCaixa);
            this.grpOperacaoCaixa.Controls.Add(this.btnAbrirCaixa);
            this.grpOperacaoCaixa.Controls.Add(this.nudValorCaixa);
            this.grpOperacaoCaixa.Controls.Add(this.lblValorCaixa);
            this.grpOperacaoCaixa.Location = new System.Drawing.Point(12, 13);
            this.grpOperacaoCaixa.Name = "grpOperacaoCaixa";
            this.grpOperacaoCaixa.Size = new System.Drawing.Size(792, 95);
            this.grpOperacaoCaixa.TabIndex = 0;
            this.grpOperacaoCaixa.TabStop = false;
            this.grpOperacaoCaixa.Text = "Operação do caixa";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFecharCaixa.Enabled = false;
            this.btnFecharCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCaixa.Location = new System.Drawing.Point(298, 44);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(128, 32);
            this.btnFecharCaixa.TabIndex = 3;
            this.btnFecharCaixa.Text = "Fechar caixa";
            this.btnFecharCaixa.UseVisualStyleBackColor = false;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // btnAbrirCaixa
            // 
            this.btnAbrirCaixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAbrirCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCaixa.Location = new System.Drawing.Point(162, 44);
            this.btnAbrirCaixa.Name = "btnAbrirCaixa";
            this.btnAbrirCaixa.Size = new System.Drawing.Size(124, 32);
            this.btnAbrirCaixa.TabIndex = 2;
            this.btnAbrirCaixa.Text = "Abrir caixa";
            this.btnAbrirCaixa.UseVisualStyleBackColor = false;
            this.btnAbrirCaixa.Click += new System.EventHandler(this.btnAbrirCaixa_Click);
            // 
            // nudValorCaixa
            // 
            this.nudValorCaixa.DecimalPlaces = 2;
            this.nudValorCaixa.Location = new System.Drawing.Point(16, 47);
            this.nudValorCaixa.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            131072});
            this.nudValorCaixa.Name = "nudValorCaixa";
            this.nudValorCaixa.Size = new System.Drawing.Size(132, 25);
            this.nudValorCaixa.TabIndex = 1;
            this.nudValorCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorCaixa
            // 
            this.lblValorCaixa.AutoSize = true;
            this.lblValorCaixa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValorCaixa.Location = new System.Drawing.Point(16, 23);
            this.lblValorCaixa.Name = "lblValorCaixa";
            this.lblValorCaixa.Size = new System.Drawing.Size(143, 19);
            this.lblValorCaixa.TabIndex = 0;
            this.lblValorCaixa.Text = "Valor de abertura (R$)";
            // 
            // tabVenda
            // 
            this.tabVenda.Controls.Add(this.grpPagamento);
            this.tabVenda.Controls.Add(this.grpCarrinho);
            this.tabVenda.Location = new System.Drawing.Point(4, 26);
            this.tabVenda.Name = "tabVenda";
            this.tabVenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabVenda.Size = new System.Drawing.Size(816, 423);
            this.tabVenda.TabIndex = 4;
            this.tabVenda.Text = "Nova venda";
            this.tabVenda.UseVisualStyleBackColor = true;
            // 
            // grpPagamento
            // 
            this.grpPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPagamento.Controls.Add(this.btnFinalizar);
            this.grpPagamento.Controls.Add(this.lblFalta);
            this.grpPagamento.Controls.Add(this.lblPago);
            this.grpPagamento.Controls.Add(this.mtbCredito);
            this.grpPagamento.Controls.Add(this.mtbDebito);
            this.grpPagamento.Controls.Add(this.mtbPix);
            this.grpPagamento.Controls.Add(this.mtbDinheiro);
            this.grpPagamento.Controls.Add(this.lblCredito);
            this.grpPagamento.Controls.Add(this.lblDebito);
            this.grpPagamento.Controls.Add(this.lblPix);
            this.grpPagamento.Controls.Add(this.lblDinheiro);
            this.grpPagamento.Location = new System.Drawing.Point(524, 13);
            this.grpPagamento.Name = "grpPagamento";
            this.grpPagamento.Size = new System.Drawing.Size(280, 393);
            this.grpPagamento.TabIndex = 1;
            this.grpPagamento.TabStop = false;
            this.grpPagamento.Text = "Pagamento";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Location = new System.Drawing.Point(16, 343);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(246, 32);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Finalizar venda";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblFalta
            // 
            this.lblFalta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFalta.Location = new System.Drawing.Point(16, 258);
            this.lblFalta.Name = "lblFalta";
            this.lblFalta.Size = new System.Drawing.Size(246, 44);
            this.lblFalta.TabIndex = 9;
            this.lblFalta.Text = "Falta receber  R$ 0,00";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPago.Location = new System.Drawing.Point(16, 229);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(180, 21);
            this.lblPago.TabIndex = 8;
            this.lblPago.Text = "Total informado  R$ 0,00";
            // 
            // mtbCredito
            // 
            this.mtbCredito.ContextMenuStrip = this.menuPagamento;
            this.mtbCredito.Location = new System.Drawing.Point(101, 176);
            this.mtbCredito.Name = "mtbCredito";
            this.mtbCredito.Size = new System.Drawing.Size(161, 25);
            this.mtbCredito.TabIndex = 3;
            this.mtbCredito.Text = "0,00";
            this.mtbCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbCredito.TextChanged += new System.EventHandler(this.mtbPagamento_TextChanged);
            this.mtbCredito.Enter += new System.EventHandler(this.mtbPagamento_Enter);
            this.mtbCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbPagamento_KeyDown);
            this.mtbCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPagamento_KeyPress);
            this.mtbCredito.Leave += new System.EventHandler(this.mtbPagamento_Leave);
            // 
            // mtbDebito
            // 
            this.mtbDebito.ContextMenuStrip = this.menuPagamento;
            this.mtbDebito.Location = new System.Drawing.Point(101, 128);
            this.mtbDebito.Name = "mtbDebito";
            this.mtbDebito.Size = new System.Drawing.Size(161, 25);
            this.mtbDebito.TabIndex = 2;
            this.mtbDebito.Text = "0,00";
            this.mtbDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbDebito.TextChanged += new System.EventHandler(this.mtbPagamento_TextChanged);
            this.mtbDebito.Enter += new System.EventHandler(this.mtbPagamento_Enter);
            this.mtbDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbPagamento_KeyDown);
            this.mtbDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPagamento_KeyPress);
            this.mtbDebito.Leave += new System.EventHandler(this.mtbPagamento_Leave);
            // 
            // mtbPix
            // 
            this.mtbPix.ContextMenuStrip = this.menuPagamento;
            this.mtbPix.Location = new System.Drawing.Point(101, 80);
            this.mtbPix.Name = "mtbPix";
            this.mtbPix.Size = new System.Drawing.Size(161, 25);
            this.mtbPix.TabIndex = 1;
            this.mtbPix.Text = "0,00";
            this.mtbPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbPix.TextChanged += new System.EventHandler(this.mtbPagamento_TextChanged);
            this.mtbPix.Enter += new System.EventHandler(this.mtbPagamento_Enter);
            this.mtbPix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbPagamento_KeyDown);
            this.mtbPix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPagamento_KeyPress);
            this.mtbPix.Leave += new System.EventHandler(this.mtbPagamento_Leave);
            // 
            // mtbDinheiro
            // 
            this.mtbDinheiro.ContextMenuStrip = this.menuPagamento;
            this.mtbDinheiro.Location = new System.Drawing.Point(101, 32);
            this.mtbDinheiro.Name = "mtbDinheiro";
            this.mtbDinheiro.Size = new System.Drawing.Size(161, 25);
            this.mtbDinheiro.TabIndex = 0;
            this.mtbDinheiro.Text = "0,00";
            this.mtbDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbDinheiro.TextChanged += new System.EventHandler(this.mtbPagamento_TextChanged);
            this.mtbDinheiro.Enter += new System.EventHandler(this.mtbPagamento_Enter);
            this.mtbDinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbPagamento_KeyDown);
            this.mtbDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPagamento_KeyPress);
            this.mtbDinheiro.Leave += new System.EventHandler(this.mtbPagamento_Leave);
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCredito.Location = new System.Drawing.Point(16, 180);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(61, 21);
            this.lblCredito.TabIndex = 3;
            this.lblCredito.Text = "Crédito";
            // 
            // lblDebito
            // 
            this.lblDebito.AutoSize = true;
            this.lblDebito.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDebito.Location = new System.Drawing.Point(16, 132);
            this.lblDebito.Name = "lblDebito";
            this.lblDebito.Size = new System.Drawing.Size(56, 21);
            this.lblDebito.TabIndex = 2;
            this.lblDebito.Text = "Débito";
            // 
            // lblPix
            // 
            this.lblPix.AutoSize = true;
            this.lblPix.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPix.Location = new System.Drawing.Point(16, 84);
            this.lblPix.Name = "lblPix";
            this.lblPix.Size = new System.Drawing.Size(30, 21);
            this.lblPix.TabIndex = 1;
            this.lblPix.Text = "Pix";
            // 
            // lblDinheiro
            // 
            this.lblDinheiro.AutoSize = true;
            this.lblDinheiro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDinheiro.Location = new System.Drawing.Point(16, 36);
            this.lblDinheiro.Name = "lblDinheiro";
            this.lblDinheiro.Size = new System.Drawing.Size(70, 21);
            this.lblDinheiro.TabIndex = 0;
            this.lblDinheiro.Text = "Dinheiro";
            // 
            // grpCarrinho
            // 
            this.grpCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCarrinho.Controls.Add(this.lblPrecoProduto);
            this.grpCarrinho.Controls.Add(this.btnNovoItem);
            this.grpCarrinho.Controls.Add(this.lblTotalVendas);
            this.grpCarrinho.Controls.Add(this.dvgCarrinhoCompra);
            this.grpCarrinho.Controls.Add(this.btnRemoverItem);
            this.grpCarrinho.Controls.Add(this.btnAtualizarItem);
            this.grpCarrinho.Controls.Add(this.btnAdicionarItem);
            this.grpCarrinho.Controls.Add(this.nudQuantidadeCarrinho);
            this.grpCarrinho.Controls.Add(this.lblQuantidade2);
            this.grpCarrinho.Controls.Add(this.lblEstoque);
            this.grpCarrinho.Controls.Add(this.lblRotuloEstoque2);
            this.grpCarrinho.Controls.Add(this.cmbProdutoPesquisa);
            this.grpCarrinho.Controls.Add(this.lblProdutoCarrinho);
            this.grpCarrinho.Location = new System.Drawing.Point(12, 13);
            this.grpCarrinho.Name = "grpCarrinho";
            this.grpCarrinho.Size = new System.Drawing.Size(500, 393);
            this.grpCarrinho.TabIndex = 0;
            this.grpCarrinho.TabStop = false;
            this.grpCarrinho.Text = "Carrinho";
            // 
            // lblTotalVendas
            // 
            this.lblTotalVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVendas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendas.Location = new System.Drawing.Point(16, 349);
            this.lblTotalVendas.Name = "lblTotalVendas";
            this.lblTotalVendas.Size = new System.Drawing.Size(468, 31);
            this.lblTotalVendas.TabIndex = 10;
            this.lblTotalVendas.Text = "Total de venda  R$ 0,00";
            this.lblTotalVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dvgCarrinhoCompra
            // 
            this.dvgCarrinhoCompra.AllowUserToAddRows = false;
            this.dvgCarrinhoCompra.AllowUserToDeleteRows = false;
            this.dvgCarrinhoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgCarrinhoCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCarrinhoCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCarrinhoCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProdutoCarrinho,
            this.colQuantidadeCarrinho,
            this.colUnitarioCarrinho,
            this.colSubtotalCarrinho});
            this.dvgCarrinhoCompra.GridColor = System.Drawing.Color.White;
            this.dvgCarrinhoCompra.Location = new System.Drawing.Point(16, 129);
            this.dvgCarrinhoCompra.MultiSelect = false;
            this.dvgCarrinhoCompra.Name = "dvgCarrinhoCompra";
            this.dvgCarrinhoCompra.ReadOnly = true;
            this.dvgCarrinhoCompra.RowHeadersVisible = false;
            this.dvgCarrinhoCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCarrinhoCompra.Size = new System.Drawing.Size(468, 171);
            this.dvgCarrinhoCompra.TabIndex = 4;
            this.dvgCarrinhoCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCarrinhoCompra_CellClick);
            // 
            // colProdutoCarrinho
            // 
            this.colProdutoCarrinho.DataPropertyName = "NomeProduto";
            this.colProdutoCarrinho.HeaderText = "Produto";
            this.colProdutoCarrinho.Name = "colProdutoCarrinho";
            this.colProdutoCarrinho.ReadOnly = true;
            // 
            // colQuantidadeCarrinho
            // 
            this.colQuantidadeCarrinho.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colQuantidadeCarrinho.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQuantidadeCarrinho.HeaderText = "Qtd.";
            this.colQuantidadeCarrinho.Name = "colQuantidadeCarrinho";
            this.colQuantidadeCarrinho.ReadOnly = true;
            // 
            // colUnitarioCarrinho
            // 
            this.colUnitarioCarrinho.DataPropertyName = "PrecoUnitario";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colUnitarioCarrinho.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUnitarioCarrinho.HeaderText = "Unitário";
            this.colUnitarioCarrinho.Name = "colUnitarioCarrinho";
            this.colUnitarioCarrinho.ReadOnly = true;
            // 
            // colSubtotalCarrinho
            // 
            this.colSubtotalCarrinho.DataPropertyName = "Subtotal";
            dataGridViewCellStyle3.Format = "C2";
            this.colSubtotalCarrinho.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSubtotalCarrinho.HeaderText = "Subtotal";
            this.colSubtotalCarrinho.Name = "colSubtotalCarrinho";
            this.colSubtotalCarrinho.ReadOnly = true;
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverItem.Location = new System.Drawing.Point(16, 311);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(134, 32);
            this.btnRemoverItem.TabIndex = 5;
            this.btnRemoverItem.Text = "Remover item";
            this.btnRemoverItem.UseVisualStyleBackColor = false;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
            // 
            // btnAtualizarItem
            // 
            this.btnAtualizarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarItem.Location = new System.Drawing.Point(360, 87);
            this.btnAtualizarItem.Name = "btnAtualizarItem";
            this.btnAtualizarItem.Size = new System.Drawing.Size(124, 32);
            this.btnAtualizarItem.TabIndex = 3;
            this.btnAtualizarItem.Text = "Atualizar item";
            this.btnAtualizarItem.UseVisualStyleBackColor = false;
            this.btnAtualizarItem.Click += new System.EventHandler(this.btnAtualizarItem_Click);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdicionarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarItem.Location = new System.Drawing.Point(16, 87);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(133, 32);
            this.btnAdicionarItem.TabIndex = 2;
            this.btnAdicionarItem.Text = "Adicionar item";
            this.btnAdicionarItem.UseVisualStyleBackColor = false;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // nudQuantidadeCarrinho
            // 
            this.nudQuantidadeCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantidadeCarrinho.DecimalPlaces = 3;
            this.nudQuantidadeCarrinho.Location = new System.Drawing.Point(372, 49);
            this.nudQuantidadeCarrinho.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            196608});
            this.nudQuantidadeCarrinho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudQuantidadeCarrinho.Name = "nudQuantidadeCarrinho";
            this.nudQuantidadeCarrinho.Size = new System.Drawing.Size(112, 25);
            this.nudQuantidadeCarrinho.TabIndex = 1;
            this.nudQuantidadeCarrinho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQuantidadeCarrinho.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantidade2
            // 
            this.lblQuantidade2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantidade2.AutoSize = true;
            this.lblQuantidade2.Location = new System.Drawing.Point(369, 27);
            this.lblQuantidade2.Name = "lblQuantidade2";
            this.lblQuantidade2.Size = new System.Drawing.Size(76, 17);
            this.lblQuantidade2.TabIndex = 4;
            this.lblQuantidade2.Text = "Quantidade";
            // 
            // lblEstoque
            // 
            this.lblEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstoque.Location = new System.Drawing.Point(258, 49);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(102, 25);
            this.lblEstoque.TabIndex = 3;
            this.lblEstoque.Text = "—";
            this.lblEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRotuloEstoque2
            // 
            this.lblRotuloEstoque2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotuloEstoque2.AutoSize = true;
            this.lblRotuloEstoque2.Location = new System.Drawing.Point(255, 27);
            this.lblRotuloEstoque2.Name = "lblRotuloEstoque2";
            this.lblRotuloEstoque2.Size = new System.Drawing.Size(87, 17);
            this.lblRotuloEstoque2.TabIndex = 2;
            this.lblRotuloEstoque2.Text = "Estoque disp.";
            // 
            // cmbProdutoPesquisa
            // 
            this.cmbProdutoPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProdutoPesquisa.FormattingEnabled = true;
            this.cmbProdutoPesquisa.Location = new System.Drawing.Point(16, 49);
            this.cmbProdutoPesquisa.Name = "cmbProdutoPesquisa";
            this.cmbProdutoPesquisa.Size = new System.Drawing.Size(230, 25);
            this.cmbProdutoPesquisa.TabIndex = 0;
            this.cmbProdutoPesquisa.SelectionChangeCommitted += new System.EventHandler(this.cmbProdutoPesquisa_SelectionChangeCommitted);
            this.cmbProdutoPesquisa.TextUpdate += new System.EventHandler(this.cmbProdutoPesquisa_TextUpdate);
            this.cmbProdutoPesquisa.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProdutoPesquisa_Format);
            this.cmbProdutoPesquisa.Leave += new System.EventHandler(this.cmbProdutoPesquisa_Leave);
            // 
            // lblProdutoCarrinho
            // 
            this.lblProdutoCarrinho.AutoSize = true;
            this.lblProdutoCarrinho.Location = new System.Drawing.Point(13, 27);
            this.lblProdutoCarrinho.Name = "lblProdutoCarrinho";
            this.lblProdutoCarrinho.Size = new System.Drawing.Size(135, 17);
            this.lblProdutoCarrinho.TabIndex = 0;
            this.lblProdutoCarrinho.Text = "Produto (ID ou nome)";
            // 
            // tabHistorico
            // 
            this.tabHistorico.Controls.Add(this.tlpHistorico);
            this.tabHistorico.Location = new System.Drawing.Point(4, 26);
            this.tabHistorico.Name = "tabHistorico";
            this.tabHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorico.Size = new System.Drawing.Size(816, 423);
            this.tabHistorico.TabIndex = 5;
            this.tabHistorico.Text = "Histórico";
            this.tabHistorico.UseVisualStyleBackColor = true;
            // 
            // tlpHistorico
            // 
            this.tlpHistorico.ColumnCount = 1;
            this.tlpHistorico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistorico.Controls.Add(this.lblVendas, 0, 0);
            this.tlpHistorico.Controls.Add(this.dvgVendas, 0, 1);
            this.tlpHistorico.Controls.Add(this.pnlEstorno, 0, 2);
            this.tlpHistorico.Controls.Add(this.lblMovimentos, 0, 3);
            this.tlpHistorico.Controls.Add(this.dvgMovimentacoes, 0, 4);
            this.tlpHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHistorico.Location = new System.Drawing.Point(3, 3);
            this.tlpHistorico.Name = "tlpHistorico";
            this.tlpHistorico.Padding = new System.Windows.Forms.Padding(9);
            this.tlpHistorico.RowCount = 5;
            this.tlpHistorico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpHistorico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHistorico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpHistorico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpHistorico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHistorico.Size = new System.Drawing.Size(810, 417);
            this.tlpHistorico.TabIndex = 0;
            // 
            // lblVendas
            // 
            this.lblVendas.AutoSize = true;
            this.lblVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVendas.Location = new System.Drawing.Point(9, 9);
            this.lblVendas.Margin = new System.Windows.Forms.Padding(0);
            this.lblVendas.Name = "lblVendas";
            this.lblVendas.Size = new System.Drawing.Size(792, 28);
            this.lblVendas.TabIndex = 0;
            this.lblVendas.Text = "Vendas do caixa atual";
            this.lblVendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dvgVendas
            // 
            this.dvgVendas.AllowUserToAddRows = false;
            this.dvgVendas.AllowUserToDeleteRows = false;
            this.dvgVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgVendas.GridColor = System.Drawing.Color.White;
            this.dvgVendas.Location = new System.Drawing.Point(9, 37);
            this.dvgVendas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.dvgVendas.MultiSelect = false;
            this.dvgVendas.Name = "dvgVendas";
            this.dvgVendas.ReadOnly = true;
            this.dvgVendas.RowHeadersVisible = false;
            this.dvgVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgVendas.Size = new System.Drawing.Size(792, 125);
            this.dvgVendas.TabIndex = 0;
            this.dvgVendas.CurrentCellChanged += new System.EventHandler(this.SelecaoOuMotivoEstornoMudou);
            // 
            // pnlEstorno
            // 
            this.pnlEstorno.ColumnCount = 2;
            this.pnlEstorno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlEstorno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.pnlEstorno.Controls.Add(this.lblMotivoEstorno, 0, 0);
            this.pnlEstorno.Controls.Add(this.txbMotivoEstorno, 0, 1);
            this.pnlEstorno.Controls.Add(this.btnEstornar, 1, 1);
            this.pnlEstorno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEstorno.Location = new System.Drawing.Point(9, 170);
            this.pnlEstorno.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEstorno.Name = "pnlEstorno";
            this.pnlEstorno.RowCount = 2;
            this.pnlEstorno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.pnlEstorno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.pnlEstorno.Size = new System.Drawing.Size(792, 76);
            this.pnlEstorno.TabIndex = 1;
            // 
            // lblMotivoEstorno
            // 
            this.lblMotivoEstorno.AutoSize = true;
            this.lblMotivoEstorno.Location = new System.Drawing.Point(3, 0);
            this.lblMotivoEstorno.Name = "lblMotivoEstorno";
            this.lblMotivoEstorno.Size = new System.Drawing.Size(118, 17);
            this.lblMotivoEstorno.TabIndex = 0;
            this.lblMotivoEstorno.Text = "Motivo do estorno";
            // 
            // txbMotivoEstorno
            // 
            this.txbMotivoEstorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMotivoEstorno.Enabled = false;
            this.txbMotivoEstorno.Location = new System.Drawing.Point(0, 37);
            this.txbMotivoEstorno.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.txbMotivoEstorno.MaxLength = 200;
            this.txbMotivoEstorno.Name = "txbMotivoEstorno";
            this.txbMotivoEstorno.Size = new System.Drawing.Size(550, 25);
            this.txbMotivoEstorno.TabIndex = 0;
            this.txbMotivoEstorno.TextChanged += new System.EventHandler(this.SelecaoOuMotivoEstornoMudou);
            // 
            // btnEstornar
            // 
            this.btnEstornar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEstornar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEstornar.Enabled = false;
            this.btnEstornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstornar.Location = new System.Drawing.Point(562, 26);
            this.btnEstornar.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnEstornar.Name = "btnEstornar";
            this.btnEstornar.Size = new System.Drawing.Size(230, 48);
            this.btnEstornar.TabIndex = 1;
            this.btnEstornar.Text = "Estornar venda";
            this.btnEstornar.UseVisualStyleBackColor = false;
            this.btnEstornar.Click += new System.EventHandler(this.btnEstornar_Click);
            // 
            // lblMovimentos
            // 
            this.lblMovimentos.AutoSize = true;
            this.lblMovimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMovimentos.Location = new System.Drawing.Point(9, 246);
            this.lblMovimentos.Margin = new System.Windows.Forms.Padding(0);
            this.lblMovimentos.Name = "lblMovimentos";
            this.lblMovimentos.Size = new System.Drawing.Size(792, 28);
            this.lblMovimentos.TabIndex = 2;
            this.lblMovimentos.Text = "Movimentações do caixa atual";
            this.lblMovimentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dvgMovimentacoes
            // 
            this.dvgMovimentacoes.AllowUserToAddRows = false;
            this.dvgMovimentacoes.AllowUserToDeleteRows = false;
            this.dvgMovimentacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgMovimentacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgMovimentacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgMovimentacoes.GridColor = System.Drawing.Color.White;
            this.dvgMovimentacoes.Location = new System.Drawing.Point(9, 274);
            this.dvgMovimentacoes.Margin = new System.Windows.Forms.Padding(0);
            this.dvgMovimentacoes.MultiSelect = false;
            this.dvgMovimentacoes.Name = "dvgMovimentacoes";
            this.dvgMovimentacoes.ReadOnly = true;
            this.dvgMovimentacoes.RowHeadersVisible = false;
            this.dvgMovimentacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgMovimentacoes.Size = new System.Drawing.Size(792, 134);
            this.dvgMovimentacoes.TabIndex = 2;
            // 
            // tabSangria
            // 
            this.tabSangria.Controls.Add(this.grpSangria);
            this.tabSangria.Location = new System.Drawing.Point(4, 26);
            this.tabSangria.Name = "tabSangria";
            this.tabSangria.Padding = new System.Windows.Forms.Padding(3);
            this.tabSangria.Size = new System.Drawing.Size(816, 423);
            this.tabSangria.TabIndex = 6;
            this.tabSangria.Text = "Sangria";
            this.tabSangria.UseVisualStyleBackColor = true;
            // 
            // grpSangria
            // 
            this.grpSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSangria.Controls.Add(this.lblSaldoSangria);
            this.grpSangria.Controls.Add(this.lblLinhaSangria);
            this.grpSangria.Controls.Add(this.lblValorSangria);
            this.grpSangria.Controls.Add(this.nudSangria);
            this.grpSangria.Controls.Add(this.lblMotivoSangria);
            this.grpSangria.Controls.Add(this.txbMotivoSangria);
            this.grpSangria.Controls.Add(this.btnRegistrarSangria);
            this.grpSangria.Enabled = false;
            this.grpSangria.Location = new System.Drawing.Point(12, 13);
            this.grpSangria.Name = "grpSangria";
            this.grpSangria.Size = new System.Drawing.Size(792, 245);
            this.grpSangria.TabIndex = 0;
            this.grpSangria.TabStop = false;
            this.grpSangria.Text = "Sangria";
            // 
            // lblSaldoSangria
            // 
            this.lblSaldoSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoSangria.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSaldoSangria.Location = new System.Drawing.Point(20, 27);
            this.lblSaldoSangria.Name = "lblSaldoSangria";
            this.lblSaldoSangria.Size = new System.Drawing.Size(752, 24);
            this.lblSaldoSangria.TabIndex = 0;
            this.lblSaldoSangria.Text = "Disponível em dinheiro   —";
            // 
            // lblLinhaSangria
            // 
            this.lblLinhaSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinhaSangria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.lblLinhaSangria.Location = new System.Drawing.Point(20, 56);
            this.lblLinhaSangria.Name = "lblLinhaSangria";
            this.lblLinhaSangria.Size = new System.Drawing.Size(752, 1);
            this.lblLinhaSangria.TabIndex = 1;
            // 
            // lblValorSangria
            // 
            this.lblValorSangria.AutoSize = true;
            this.lblValorSangria.Location = new System.Drawing.Point(17, 63);
            this.lblValorSangria.Name = "lblValorSangria";
            this.lblValorSangria.Size = new System.Drawing.Size(134, 17);
            this.lblValorSangria.TabIndex = 2;
            this.lblValorSangria.Text = "Valor da retirada (R$)";
            // 
            // nudSangria
            // 
            this.nudSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSangria.DecimalPlaces = 2;
            this.nudSangria.Location = new System.Drawing.Point(20, 85);
            this.nudSangria.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            131072});
            this.nudSangria.Name = "nudSangria";
            this.nudSangria.Size = new System.Drawing.Size(199, 25);
            this.nudSangria.TabIndex = 0;
            this.nudSangria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMotivoSangria
            // 
            this.lblMotivoSangria.AutoSize = true;
            this.lblMotivoSangria.Location = new System.Drawing.Point(17, 122);
            this.lblMotivoSangria.Name = "lblMotivoSangria";
            this.lblMotivoSangria.Size = new System.Drawing.Size(49, 17);
            this.lblMotivoSangria.TabIndex = 3;
            this.lblMotivoSangria.Text = "Motivo";
            // 
            // txbMotivoSangria
            // 
            this.txbMotivoSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMotivoSangria.Location = new System.Drawing.Point(20, 144);
            this.txbMotivoSangria.MaxLength = 200;
            this.txbMotivoSangria.Name = "txbMotivoSangria";
            this.txbMotivoSangria.Size = new System.Drawing.Size(199, 25);
            this.txbMotivoSangria.TabIndex = 1;
            // 
            // btnRegistrarSangria
            // 
            this.btnRegistrarSangria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarSangria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRegistrarSangria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSangria.Location = new System.Drawing.Point(20, 190);
            this.btnRegistrarSangria.Name = "btnRegistrarSangria";
            this.btnRegistrarSangria.Size = new System.Drawing.Size(199, 32);
            this.btnRegistrarSangria.TabIndex = 2;
            this.btnRegistrarSangria.Text = "Registrar sangria";
            this.btnRegistrarSangria.UseVisualStyleBackColor = false;
            this.btnRegistrarSangria.Click += new System.EventHandler(this.btnRegistrarSangria_Click);
            // 
            // FrmCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(864, 575);
            this.Controls.Add(this.pnlAreaCaixa);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCaixa";
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.FrmCaixa_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FrmCaixa_ClientSizeChanged);
            this.VisibleChanged += new System.EventHandler(this.FrmCaixa_VisibleChanged);
            this.menuPagamento.ResumeLayout(false);
            this.pnlAreaCaixa.ResumeLayout(false);
            this.pnlAreaCaixa.PerformLayout();
            this.abas.ResumeLayout(false);
            this.tabSessao.ResumeLayout(false);
            this.grpResumoCaixa.ResumeLayout(false);
            this.tlpResumoCaixa.ResumeLayout(false);
            this.pnlResumoVendas.ResumeLayout(false);
            this.pnlResumoVendas.PerformLayout();
            this.pnlResumoContagem.ResumeLayout(false);
            this.pnlResumoContagem.PerformLayout();
            this.grpOperacaoCaixa.ResumeLayout(false);
            this.grpOperacaoCaixa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorCaixa)).EndInit();
            this.tabVenda.ResumeLayout(false);
            this.grpPagamento.ResumeLayout(false);
            this.grpPagamento.PerformLayout();
            this.grpCarrinho.ResumeLayout(false);
            this.grpCarrinho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCarrinhoCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeCarrinho)).EndInit();
            this.tabHistorico.ResumeLayout(false);
            this.tlpHistorico.ResumeLayout(false);
            this.tlpHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVendas)).EndInit();
            this.pnlEstorno.ResumeLayout(false);
            this.pnlEstorno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgMovimentacoes)).EndInit();
            this.tabSangria.ResumeLayout(false);
            this.grpSangria.ResumeLayout(false);
            this.grpSangria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSangria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl abas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSessao;
        private System.Windows.Forms.TabPage tabSessao;
        private System.Windows.Forms.TabPage tabVenda;
        private System.Windows.Forms.TabPage tabHistorico;
        private System.Windows.Forms.TabPage tabSangria;
        private System.Windows.Forms.GroupBox grpResumoCaixa;
        private System.Windows.Forms.GroupBox grpOperacaoCaixa;
        private System.Windows.Forms.Button btnFecharCaixa;
        private System.Windows.Forms.Button btnAbrirCaixa;
        private System.Windows.Forms.NumericUpDown nudValorCaixa;
        private System.Windows.Forms.Label lblValorCaixa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRetorno;
        private System.Windows.Forms.Label lblResumoAbertura;
        private System.Windows.Forms.Label lblResumoVendas;
        private System.Windows.Forms.Label lblResumoSaldo;
        private System.Windows.Forms.Label lblResumoContado;
        private System.Windows.Forms.Label lblResumoSobra;
        private System.Windows.Forms.Label lblResumoFalta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpCarrinho;
        private System.Windows.Forms.GroupBox grpPagamento;
        private System.Windows.Forms.Label lblRotuloEstoque2;
        private System.Windows.Forms.ComboBox cmbProdutoPesquisa;
        private System.Windows.Forms.Label lblProdutoCarrinho;
        private System.Windows.Forms.NumericUpDown nudQuantidadeCarrinho;
        private System.Windows.Forms.Label lblQuantidade2;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnAtualizarItem;
        private System.Windows.Forms.Button btnNovoItem;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.ContextMenuStrip menuPagamento;
        private System.Windows.Forms.Timer tmrPesquisaProduto;
        private System.Windows.Forms.ToolStripMenuItem mnuColarPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnuLimparPagamento;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.DataGridView dvgCarrinhoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutoCarrinho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidadeCarrinho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitarioCarrinho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotalCarrinho;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label lblPix;
        private System.Windows.Forms.Label lblDinheiro;
        private System.Windows.Forms.Label lblFalta;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.MaskedTextBox mtbCredito;
        private System.Windows.Forms.MaskedTextBox mtbDebito;
        private System.Windows.Forms.MaskedTextBox mtbPix;
        private System.Windows.Forms.MaskedTextBox mtbDinheiro;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.GroupBox grpSangria;
        private System.Windows.Forms.Label lblSaldoSangria;
        private System.Windows.Forms.Label lblLinhaSangria;
        private System.Windows.Forms.Label lblValorSangria;
        private System.Windows.Forms.NumericUpDown nudSangria;
        private System.Windows.Forms.Label lblMotivoSangria;
        private System.Windows.Forms.TextBox txbMotivoSangria;
        private System.Windows.Forms.Button btnRegistrarSangria;
        private System.Windows.Forms.Label lblVendas;
        private System.Windows.Forms.DataGridView dvgVendas;
        private System.Windows.Forms.TableLayoutPanel pnlEstorno;
        private System.Windows.Forms.Label lblMotivoEstorno;
        private System.Windows.Forms.TextBox txbMotivoEstorno;
        private System.Windows.Forms.Button btnEstornar;
        private System.Windows.Forms.Label lblMovimentos;
        private System.Windows.Forms.DataGridView dvgMovimentacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagamentoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSituacaoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataMovimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaMovimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorMovimentacao;
        private System.Windows.Forms.Panel pnlAreaCaixa;
        private System.Windows.Forms.TableLayoutPanel tlpResumoCaixa;
        private System.Windows.Forms.Panel pnlResumoVendas;
        private System.Windows.Forms.Panel pnlResumoContagem;
        private System.Windows.Forms.TableLayoutPanel tlpHistorico;
    }
}
