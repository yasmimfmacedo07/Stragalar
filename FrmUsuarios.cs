using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stragalar.Dados;
using Stragalar.Modelos;

namespace Stragalar.Telas
{
    public partial class FrmUsuarios : Form
    {
        private int idUsuarioLogado;
        private string funcaoUsuario;
        private int idSelecionado;

        public FrmUsuarios()
        {
            InitializeComponent();
            AjustarAreaUsuarios();
        }

        public FrmUsuarios(int idUsuarioLogado, string funcaoUsuario) : this()
        {
            this.idUsuarioLogado = idUsuarioLogado;
            this.funcaoUsuario = funcaoUsuario;
        }

        private bool PodeGerenciar()
        {
            return idUsuarioLogado > 0 && funcaoUsuario == "Admin";
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            if (!PodeGerenciar())
            {
                pnlAreaUsuarios.Enabled = false;
                lblTitulo.Text = "Gerenciamento disponível para Admin.";
                return;
            }
            LimparCampos();
            CarregarUsuarios();
        }

        private void FrmUsuarios_ClientSizeChanged(object sender, EventArgs e)
        {
            AjustarAreaUsuarios();
        }

        private void AjustarAreaUsuarios()
        {
            pnlAreaUsuarios.Size = new Size(
                Math.Max(ClientSize.Width, pnlAreaUsuarios.MinimumSize.Width),
                Math.Max(ClientSize.Height, pnlAreaUsuarios.MinimumSize.Height));
        }

        private void CarregarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = new UsuarioDAO().Listar(txbFiltro.Text.Trim());
                dgvUsuarios.Columns["Cadastro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvUsuarios.Columns["Nome"].FillWeight = 170;
                dgvUsuarios.Columns["Código"].FillWeight = 55;
                dgvUsuarios.Columns["Código"].MinimumWidth = 55;
                dgvUsuarios.Columns["Nome"].MinimumWidth = 155;
                dgvUsuarios.Columns["Login"].MinimumWidth = 90;
                dgvUsuarios.Columns["Função"].MinimumWidth = 140;
                dgvUsuarios.Columns["Status"].MinimumWidth = 65;
                dgvUsuarios.Columns["Cadastro"].MinimumWidth = 130;
                dgvUsuarios.ClearSelection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Erro ao carregar usuários.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao carregar usuários.\nErro: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txbNome.Text))
            {
                MessageBox.Show(this, "Informe o nome do usuário.", "Atenção");
                txbNome.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbLogin.Text))
            {
                MessageBox.Show(this, "Informe o login.", "Atenção");
                txbLogin.Focus();
                return false;
            }
            if (idSelecionado == 0 && string.IsNullOrWhiteSpace(txbSenha.Text))
            {
                MessageBox.Show(this, "Informe a senha do novo usuário.", "Atenção");
                txbSenha.Focus();
                return false;
            }
            if (txbSenha.Text.Length > 0 && string.IsNullOrWhiteSpace(txbSenha.Text))
            {
                MessageBox.Show(this, "A senha não pode conter apenas espaços.", "Atenção");
                txbSenha.Focus();
                return false;
            }
            if (cbxFuncao.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Selecione uma função.", "Atenção");
                cbxFuncao.Focus();
                return false;
            }
            if (idSelecionado == idUsuarioLogado && (!chkAtivo.Checked || cbxFuncao.Text != "Admin"))
            {
                MessageBox.Show(this, "Mantenha sua conta ativa como Admin enquanto estiver utilizando esta sessão.", "Atenção");
                return false;
            }
            return true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeGerenciar())
            {
                return;
            }
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }
                if (new UsuarioDAO().LoginExiste(txbLogin.Text.Trim(), idSelecionado))
                {
                    MessageBox.Show(this, "Este login já está em uso.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbLogin.Focus();
                    return;
                }
                var usuario = new Usuario
                {
                    IdUsuario = idSelecionado,
                    NomeUsuario = txbNome.Text.Trim(),
                    Login = txbLogin.Text.Trim(),
                    Senha = txbSenha.Text,
                    Funcao = cbxFuncao.Text,
                    Ativo = chkAtivo.Checked
                };
                if (idSelecionado == 0)
                {
                    new UsuarioDAO().Inserir(usuario);
                    MessageBox.Show(this, $"Usuário cadastrado.\nCódigo: {usuario.IdUsuario}", "Usuários",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!new UsuarioDAO().Atualizar(usuario))
                    {
                        throw new InvalidOperationException("Usuário não encontrado. Recarregue a lista.");
                    }
                    MessageBox.Show(this, "Usuário atualizado.", "Usuários",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimparCampos();
                CarregarUsuarios();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Não foi possível salvar o usuário.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(this, $"Erro de formato: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao salvar usuário.\nErro: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregarUsuarios();
        }

        private void BtnLimparFiltro_Click(object sender, EventArgs e)
        {
            txbFiltro.Clear();
            LimparCampos();
            CarregarUsuarios();
        }

        private void TxbFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnFiltrar_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private bool ValidarSelecao()
        {
            if (!PodeGerenciar())
            {
                return false;
            }
            if (idSelecionado == 0)
            {
                MessageBox.Show(this, "Selecione um usuário na lista.", "Atenção");
                return false;
            }
            if (idSelecionado == idUsuarioLogado)
            {
                MessageBox.Show(this, "Não é possível remover ou desativar sua conta durante esta sessão.", "Atenção");
                return false;
            }
            return true;
        }

        private void BtnDesativar_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecao() || MessageBox.Show(this, "Deseja desativar este usuário?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                if (!new UsuarioDAO().Desativar(idSelecionado))
                {
                    throw new InvalidOperationException("Usuário não encontrado.");
                }
                LimparCampos();
                CarregarUsuarios();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Não foi possível desativar.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao desativar usuário.\nErro: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecao() || MessageBox.Show(this,
                "Deseja excluir este usuário? Usuários com histórico devem ser desativados.", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                if (!new UsuarioDAO().Excluir(idSelecionado))
                {
                    throw new InvalidOperationException("Usuário não encontrado.");
                }
                LimparCampos();
                CarregarUsuarios();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this,
                    $"Não foi possível excluir. Se houver histórico, utilize Desativar.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao excluir usuário.\nErro: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !PodeGerenciar())
            {
                return;
            }
            try
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["Código"].Value);
                Usuario usuario = new UsuarioDAO().BuscarPorId(idUsuario);
                if (usuario == null)
                {
                    LimparCampos();
                    CarregarUsuarios();
                    return;
                }
                idSelecionado = usuario.IdUsuario;
                txbNome.Text = usuario.NomeUsuario;
                txbLogin.Text = usuario.Login;
                txbSenha.Clear();
                cbxFuncao.Text = usuario.Funcao;
                chkAtivo.Checked = usuario.Ativo;
                btnDesativar.Enabled = usuario.Ativo && idSelecionado != idUsuarioLogado;
                btnExcluir.Enabled = idSelecionado != idUsuarioLogado;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Erro ao consultar usuário.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao selecionar usuário.\nErro: {ex.Message}", "Usuários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            idSelecionado = 0;
            txbNome.Clear();
            txbLogin.Clear();
            txbSenha.Clear();
            cbxFuncao.SelectedIndex = 1;
            chkAtivo.Checked = true;
            btnDesativar.Enabled = false;
            btnExcluir.Enabled = false;
            dgvUsuarios.ClearSelection();
            txbNome.Focus();
        }
    }
}
