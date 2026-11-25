namespace Stragalar.Telas
{
    partial class FrmEstoque
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlAreaEstoque = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.Label();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.txtNomeProduto = new System.Windows.Forms.Label();
            this.txbNomeProduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSelecionarCategorias = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDimensao = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpValidade = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEntrada = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPrecoUnitario = new System.Windows.Forms.NumericUpDown();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txbMotivo = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPesquisarProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.chkValidadeProxima = new System.Windows.Forms.CheckBox();
            this.chkBaixoEstoque = new System.Windows.Forms.CheckBox();
            this.chkExibirInativos = new System.Windows.Forms.CheckBox();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.lblResumo = new System.Windows.Forms.Label();
            this.pnlAreaEstoque.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecoUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAreaEstoque
            // 
            this.pnlAreaEstoque.Controls.Add(this.label3);
            this.pnlAreaEstoque.Controls.Add(this.panel1);
            this.pnlAreaEstoque.Controls.Add(this.label2);
            this.pnlAreaEstoque.Controls.Add(this.txtPesquisarProduto);
            this.pnlAreaEstoque.Controls.Add(this.label1);
            this.pnlAreaEstoque.Controls.Add(this.cmbCategorias);
            this.pnlAreaEstoque.Controls.Add(this.chkValidadeProxima);
            this.pnlAreaEstoque.Controls.Add(this.chkBaixoEstoque);
            this.pnlAreaEstoque.Controls.Add(this.chkExibirInativos);
            this.pnlAreaEstoque.Controls.Add(this.btnRecarregar);
            this.pnlAreaEstoque.Controls.Add(this.dgvEstoque);
            this.pnlAreaEstoque.Controls.Add(this.lblResumo);
            this.pnlAreaEstoque.Location = new System.Drawing.Point(0, 0);
            this.pnlAreaEstoque.MinimumSize = new System.Drawing.Size(840, 570);
            this.pnlAreaEstoque.Name = "pnlAreaEstoque";
            this.pnlAreaEstoque.Size = new System.Drawing.Size(840, 570);
            this.pnlAreaEstoque.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(700, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "CONTROLE DE ESTOQUE";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txbCodigo);
            this.panel1.Controls.Add(this.txtNomeProduto);
            this.panel1.Controls.Add(this.txbNomeProduto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbSelecionarCategorias);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbDimensao);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtpValidade);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtpEntrada);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nudQuantidade);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.nudPrecoUnitario);
            this.panel1.Controls.Add(this.lblMotivo);
            this.panel1.Controls.Add(this.txbMotivo);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Location = new System.Drawing.Point(16, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 238);
            this.panel1.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(14, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(70, 20);
            this.txtCodigo.TabIndex = 4;
            this.txtCodigo.Text = "Código";
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(14, 32);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.ReadOnly = true;
            this.txbCodigo.Size = new System.Drawing.Size(70, 25);
            this.txbCodigo.TabIndex = 5;
            this.txbCodigo.TabStop = false;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(102, 10);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(318, 20);
            this.txtNomeProduto.TabIndex = 6;
            this.txtNomeProduto.Text = "Nome do produto";
            // 
            // txbNomeProduto
            // 
            this.txbNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNomeProduto.Location = new System.Drawing.Point(102, 32);
            this.txbNomeProduto.MaxLength = 100;
            this.txbNomeProduto.Name = "txbNomeProduto";
            this.txbNomeProduto.Size = new System.Drawing.Size(318, 25);
            this.txbNomeProduto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(438, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Categoria";
            // 
            // cmbSelecionarCategorias
            // 
            this.cmbSelecionarCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelecionarCategorias.Items.AddRange(new object[] {
            "Bebidas",
            "Laticínios",
            "Carnes",
            "Verduras",
            "Legumes",
            "Frutas",
            "Porções",
            "Lanches",
            "Pratos",
            "Sobremesas",
            "Outros"});
            this.cmbSelecionarCategorias.Location = new System.Drawing.Point(438, 32);
            this.cmbSelecionarCategorias.MaxLength = 45;
            this.cmbSelecionarCategorias.Name = "cmbSelecionarCategorias";
            this.cmbSelecionarCategorias.Size = new System.Drawing.Size(170, 25);
            this.cmbSelecionarCategorias.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(626, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Unidade";
            // 
            // cmbDimensao
            // 
            this.cmbDimensao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimensao.Items.AddRange(new object[] {
            "un",
            "kg",
            "L",
            "Caixa",
            "Pacote",
            "Metro"});
            this.cmbDimensao.Location = new System.Drawing.Point(626, 32);
            this.cmbDimensao.MaxLength = 45;
            this.cmbDimensao.Name = "cmbDimensao";
            this.cmbDimensao.Size = new System.Drawing.Size(164, 25);
            this.cmbDimensao.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(14, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Validade (opcional)";
            // 
            // dtpValidade
            // 
            this.dtpValidade.Location = new System.Drawing.Point(14, 88);
            this.dtpValidade.Mask = "00/00/0000";
            this.dtpValidade.Name = "dtpValidade";
            this.dtpValidade.Size = new System.Drawing.Size(130, 25);
            this.dtpValidade.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(166, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Entrada (opcional)";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Location = new System.Drawing.Point(166, 88);
            this.dtpEntrada.Mask = "00/00/0000";
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(130, 25);
            this.dtpEntrada.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(318, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Quantidade em estoque";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 3;
            this.nudQuantidade.Location = new System.Drawing.Point(318, 88);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            196608});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(200, 25);
            this.nudQuantidade.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(540, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Preço unitário (R$)";
            // 
            // nudPrecoUnitario
            // 
            this.nudPrecoUnitario.DecimalPlaces = 2;
            this.nudPrecoUnitario.Location = new System.Drawing.Point(540, 88);
            this.nudPrecoUnitario.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            131072});
            this.nudPrecoUnitario.Name = "nudPrecoUnitario";
            this.nudPrecoUnitario.Size = new System.Drawing.Size(250, 25);
            this.nudPrecoUnitario.TabIndex = 19;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Location = new System.Drawing.Point(14, 122);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(600, 20);
            this.lblMotivo.TabIndex = 20;
            this.lblMotivo.Text = "Motivo (obrigatório ao alterar a quantidade)";
            // 
            // txbMotivo
            // 
            this.txbMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMotivo.Location = new System.Drawing.Point(14, 144);
            this.txbMotivo.MaxLength = 200;
            this.txbMotivo.Name = "txbMotivo";
            this.txbMotivo.Size = new System.Drawing.Size(776, 25);
            this.txbMotivo.TabIndex = 21;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(14, 188);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(124, 34);
            this.btnAdicionar.TabIndex = 22;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Location = new System.Drawing.Point(152, 188);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(124, 34);
            this.btnAtualizar.TabIndex = 23;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExcluir.Location = new System.Drawing.Point(290, 188);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(124, 34);
            this.btnExcluir.TabIndex = 24;
            this.btnExcluir.Text = "Desativar";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLimpar.Location = new System.Drawing.Point(428, 188);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(124, 34);
            this.btnLimpar.TabIndex = 25;
            this.btnLimpar.Text = "Limpar / Novo";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Pesquisar ID ou nome";
            // 
            // txtPesquisarProduto
            // 
            this.txtPesquisarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisarProduto.Location = new System.Drawing.Point(159, 304);
            this.txtPesquisarProduto.Name = "txtPesquisarProduto";
            this.txtPesquisarProduto.Size = new System.Drawing.Size(246, 25);
            this.txtPesquisarProduto.TabIndex = 27;
            this.txtPesquisarProduto.TextChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(429, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Categoria";
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorias.Location = new System.Drawing.Point(527, 304);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(297, 25);
            this.cmbCategorias.TabIndex = 29;
            this.cmbCategorias.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // chkValidadeProxima
            // 
            this.chkValidadeProxima.Location = new System.Drawing.Point(16, 340);
            this.chkValidadeProxima.Name = "chkValidadeProxima";
            this.chkValidadeProxima.Size = new System.Drawing.Size(242, 22);
            this.chkValidadeProxima.TabIndex = 30;
            this.chkValidadeProxima.Text = "Validade nos próximos 30 dias";
            this.chkValidadeProxima.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // chkBaixoEstoque
            // 
            this.chkBaixoEstoque.Location = new System.Drawing.Point(268, 340);
            this.chkBaixoEstoque.Name = "chkBaixoEstoque";
            this.chkBaixoEstoque.Size = new System.Drawing.Size(154, 22);
            this.chkBaixoEstoque.TabIndex = 31;
            this.chkBaixoEstoque.Text = "Estoque baixo";
            this.chkBaixoEstoque.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // chkExibirInativos
            // 
            this.chkExibirInativos.Location = new System.Drawing.Point(430, 340);
            this.chkExibirInativos.Name = "chkExibirInativos";
            this.chkExibirInativos.Size = new System.Drawing.Size(158, 22);
            this.chkExibirInativos.TabIndex = 32;
            this.chkExibirInativos.Text = "Exibir inativos";
            this.chkExibirInativos.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecarregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRecarregar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRecarregar.Location = new System.Drawing.Point(700, 337);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(124, 28);
            this.btnRecarregar.TabIndex = 33;
            this.btnRecarregar.Text = "Recarregar";
            this.btnRecarregar.UseVisualStyleBackColor = false;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstoque.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstoque.ColumnHeadersHeight = 42;
            this.dgvEstoque.Location = new System.Drawing.Point(16, 374);
            this.dgvEstoque.MultiSelect = false;
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.RowHeadersVisible = false;
            this.dgvEstoque.RowTemplate.Height = 28;
            this.dgvEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstoque.Size = new System.Drawing.Size(808, 160);
            this.dgvEstoque.TabIndex = 34;
            this.dgvEstoque.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstoque_CellClick);
            // 
            // lblResumo
            // 
            this.lblResumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResumo.Location = new System.Drawing.Point(16, 543);
            this.lblResumo.Name = "lblResumo";
            this.lblResumo.Size = new System.Drawing.Size(808, 22);
            this.lblResumo.TabIndex = 35;
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.pnlAreaEstoque);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEstoque";
            this.Text = "Controle de Estoque";
            this.Load += new System.EventHandler(this.FrmEstoque_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FrmEstoque_ClientSizeChanged);
            this.pnlAreaEstoque.ResumeLayout(false);
            this.pnlAreaEstoque.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecoUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlAreaEstoque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtCodigo;
        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.Label txtNomeProduto;
        private System.Windows.Forms.TextBox txbNomeProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSelecionarCategorias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDimensao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox dtpValidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox dtpEntrada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPrecoUnitario;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txbMotivo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPesquisarProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.CheckBox chkValidadeProxima;
        private System.Windows.Forms.CheckBox chkBaixoEstoque;
        private System.Windows.Forms.CheckBox chkExibirInativos;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomedoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatadeValidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecounitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAtivo;
    }
}
