using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using Stragalar.Dados;

namespace Stragalar.Telas
{
    public partial class FrmPrincipal : Form
    {
        private int idUsuarioLogado;
        private string funcaoUsuario;
        private Form telaAtual;
        private FrmCaixa telaCaixa;

        public bool Deslogou { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public FrmPrincipal(int idUsuarioLogado, string funcaoUsuario, string nomeUsuario) : this()
        {
            this.idUsuarioLogado = idUsuarioLogado;
            this.funcaoUsuario = funcaoUsuario;
            lblUsuario.Text = $"Usuário: {nomeUsuario}";
            lblCargo.Text = $"Cargo: {funcaoUsuario}";
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            btnUsuarios.Enabled = funcaoUsuario == "Admin";
            AbrirForm(new FrmInicio());
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Deslogou)
            {
                DialogResult resposta = MessageBox.Show(this,
                    "Deseja realmente sair do sistema?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                e.Cancel = resposta != DialogResult.Yes;
            }
        }

        private void AbrirForm(Form tela)
        {
            if (telaAtual != null && telaAtual != tela)
            {
                if (telaAtual == telaCaixa)
                {
                    telaAtual.Hide();
                }
                else
                {
                    telaAtual.Dispose();
                }
            }

            if (tela.Parent == null)
            {
                tela.TopLevel = false;
                tela.FormBorderStyle = FormBorderStyle.None;
                tela.Dock = DockStyle.Fill;
                pnlConteudo.Controls.Add(tela);
            }

            telaAtual = tela;
            tela.Show();
            tela.BringToFront();
            AtualizarRodape();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirForm(new FrmInicio());
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            if (telaCaixa == null || telaCaixa.IsDisposed)
            {
                telaCaixa = new FrmCaixa(idUsuarioLogado, funcaoUsuario);
            }

            AbrirForm(telaCaixa);
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            var estoque = new FrmEstoque(idUsuarioLogado, funcaoUsuario);
            estoque.ProdutosAlterados += Estoque_ProdutosAlterados;
            AbrirForm(estoque);
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            AbrirForm(new FrmRelatorios());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (funcaoUsuario == "Admin")
            {
                AbrirForm(new FrmUsuarios(idUsuarioLogado, funcaoUsuario));
            }
        }

        private void AtualizarRodape()
        {
            try
            {
                int total = new ProdutoDAO().ContarProdutos();
                lblTotalProdutos.Text = $"Total de produtos cadastrados: {total}";
                lblConexao.Text = "Conexão: conectado";
                lblConexao.ForeColor = Color.DarkGreen;
                lblConexao.ToolTipText = $"Verificado às {DateTime.Now:HH:mm:ss}. Clique para atualizar.";
            }
            catch (MySqlException ex)
            {
                lblTotalProdutos.Text = "Total de produtos cadastrados: —";
                lblConexao.Text = "Conexão: indisponível";
                lblConexao.ForeColor = Color.Firebrick;
                lblConexao.ToolTipText = $"Código: {ex.Number}\nErro no banco: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblTotalProdutos.Text = "Total de produtos cadastrados: —";
                lblConexao.Text = "Conexão: falha na consulta";
                lblConexao.ForeColor = Color.Firebrick;
                lblConexao.ToolTipText = ex.Message;
            }
        }

        private void Estoque_ProdutosAlterados(object sender, EventArgs e)
        {
            AtualizarRodape();
        }

        private void lblConexao_Click(object sender, EventArgs e)
        {
            AtualizarRodape();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (telaCaixa != null && !telaCaixa.IsDisposed && telaCaixa.TemVendaEmAndamento)
            {
                DialogResult resposta = MessageBox.Show(this,
                    "Ao sair do usuário, os itens da venda ainda não finalizada serão descartados. Deseja continuar?",
                    "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta != DialogResult.Yes)
                {
                    return;
                }
            }

            Deslogou = true;
            Close();
        }

    }
}
