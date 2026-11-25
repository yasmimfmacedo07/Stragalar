using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stragalar.Dados;
using Stragalar.Modelos;

namespace Stragalar.Telas
{
    public partial class FrmLogin : Form
    {
        private FrmPrincipal telaPrincipal;
        private bool entrando;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (entrando || (telaPrincipal != null && !telaPrincipal.IsDisposed))
            {
                return;
            }

            entrando = true;
            btnEntrar.Enabled = false;
            try
            {
                string login = txbUsuario.Text.Trim();
                string senha = txbSenha.Text;

                if (login.Length == 0 || senha.Length == 0)
                {
                    MessageBox.Show(this, "Informe o usuário e a senha.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (login.Length == 0)
                    {
                        txbUsuario.Focus();
                    }
                    else
                    {
                        txbSenha.Focus();
                    }

                    return;
                }

                Usuario usuario = new UsuarioDAO().ValidarLogin(login, senha);

                if (usuario == null)
                {
                    MessageBox.Show(this, "Usuário ou senha inválidos.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbSenha.Focus();
                    txbSenha.SelectAll();
                    return;
                }

                telaPrincipal = new FrmPrincipal(usuario.IdUsuario, usuario.Funcao, usuario.NomeUsuario);
                telaPrincipal.FormClosed += TelaPrincipal_FormClosed;
                telaPrincipal.Show();
                Hide();
            }
            catch (MySqlException ex)
            {
                DescartarTelaPrincipal();
                Show();
                MessageBox.Show(this, $"Erro no banco ao entrar.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                DescartarTelaPrincipal();
                Show();
                MessageBox.Show(this, $"Falha ao entrar.\nErro: {ex.Message}",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                entrando = false;
                btnEntrar.Enabled = true;
            }
        }

        private void DescartarTelaPrincipal()
        {
            if (telaPrincipal != null)
            {
                telaPrincipal.FormClosed -= TelaPrincipal_FormClosed;
                telaPrincipal.Dispose();
                telaPrincipal = null;
            }
        }

        private void TelaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            var principal = (FrmPrincipal)sender;
            principal.FormClosed -= TelaPrincipal_FormClosed;
            telaPrincipal = null;

            if (!principal.Deslogou)
            {
                Close();
                return;
            }

            txbUsuario.Clear();
            txbSenha.Clear();
            Show();
            Activate();
            txbUsuario.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
