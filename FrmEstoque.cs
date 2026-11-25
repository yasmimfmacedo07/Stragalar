using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stragalar.Dados;
using Stragalar.Modelos;

namespace Stragalar.Telas
{
    public partial class FrmEstoque : Form
    {
        private static CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");
        private int idUsuarioLogado;
        private string funcaoUsuario;
        private List<Produto> listaProdutos = new List<Produto>();
        private Produto produtoSelecionado;
        private bool carregando;

        public event EventHandler ProdutosAlterados;

        public FrmEstoque()
        {
            InitializeComponent();
            AjustarAreaEstoque();
        }

        public FrmEstoque(int idUsuarioLogado, string funcaoUsuario) : this()
        {
            this.idUsuarioLogado = idUsuarioLogado;
            this.funcaoUsuario = funcaoUsuario;
        }

        private bool PodeAlterarEstoque()
        {
            return idUsuarioLogado > 0 && (funcaoUsuario == "Admin" || funcaoUsuario == "Estoquista");
        }

        private void FrmEstoque_Load(object sender, EventArgs e)
        {
            panel1.Enabled = PodeAlterarEstoque();
            dgvEstoque.DefaultCellStyle.FormatProvider = Cultura;
            LimparCampos();
            CarregarProdutos();
        }

        private void FrmEstoque_ClientSizeChanged(object sender, EventArgs e)
        {
            AjustarAreaEstoque();
        }

        private void AjustarAreaEstoque()
        {
            pnlAreaEstoque.Size = new Size(
                Math.Max(ClientSize.Width, pnlAreaEstoque.MinimumSize.Width),
                Math.Max(ClientSize.Height, pnlAreaEstoque.MinimumSize.Height));
        }

        private void CarregarProdutos()
        {
            try
            {
                listaProdutos = new ProdutoDAO().Listar(true);
                carregando = true;
                string categoria = cmbCategorias.Text;
                cmbCategorias.Items.Clear();
                cmbCategorias.Items.Add("Todas as categorias");
                foreach (string nome in listaProdutos.Select(produto => produto.Categoria).Distinct().OrderBy(nome => nome))
                {
                    cmbCategorias.Items.Add(nome);
                    if (!cmbSelecionarCategorias.Items.Contains(nome))
                    {
                        cmbSelecionarCategorias.Items.Add(nome);
                    }
                }
                cmbCategorias.SelectedIndex = cmbCategorias.Items.IndexOf(categoria);
                if (cmbCategorias.SelectedIndex < 0)
                {
                    cmbCategorias.SelectedIndex = 0;
                }
                carregando = false;
                LimparCampos();
                AtualizarTabela();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Erro ao carregar produtos.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao carregar produtos.\nErro: {ex.Message}",
                    "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                carregando = false;
            }
        }

        private void AtualizarTabela()
        {
            if (carregando)
            {
                return;
            }

            string pesquisa = txtPesquisarProduto.Text.Trim();
            string categoria = cmbCategorias.Text;
            dgvEstoque.DataSource = listaProdutos.Where(produto =>
                (produto.Id.ToString() == pesquisa ||
                 Cultura.CompareInfo.IndexOf(produto.Nome, pesquisa,
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0) &&
                (cmbCategorias.SelectedIndex <= 0 || produto.Categoria == categoria) &&
                (!chkValidadeProxima.Checked || (produto.DataValidade.HasValue &&
                    produto.DataValidade.Value.Date >= DateTime.Today &&
                    produto.DataValidade.Value.Date <= DateTime.Today.AddDays(30))) &&
                (!chkBaixoEstoque.Checked || produto.QuantidadeEstoque <= 5m) &&
                (chkExibirInativos.Checked || produto.Ativo)).ToList();
            dgvEstoque.ClearSelection();
            lblResumo.Text = $"{dgvEstoque.Rows.Count} produto(s) na lista. Estoque baixo: até 5 na unidade cadastrada.";
        }

        private bool ValidarCampos(out DateTime? entrada, out DateTime? validade)
        {
            entrada = null;
            validade = null;

            if (string.IsNullOrWhiteSpace(txbNomeProduto.Text))
            {
                MessageBox.Show(this, "Informe o nome do produto.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNomeProduto.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbSelecionarCategorias.Text) ||
                string.IsNullOrWhiteSpace(cmbDimensao.Text))
            {
                MessageBox.Show(this, "Informe a categoria e a unidade de medida.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSelecionarCategorias.Focus();
                return false;
            }

            DateTime data;
            if (dtpEntrada.Text.Any(char.IsDigit))
            {
                if (!DateTime.TryParseExact(dtpEntrada.Text, "dd/MM/yyyy", Cultura, DateTimeStyles.None, out data) ||
                    data.Year < 1000 || data.Date > DateTime.Today)
                {
                    MessageBox.Show(this, "Informe uma data de entrada válida, até hoje.", "Atenção");
                    dtpEntrada.Focus();
                    return false;
                }
                entrada = data.Date;
            }
            if (dtpValidade.Text.Any(char.IsDigit))
            {
                if (!DateTime.TryParseExact(dtpValidade.Text, "dd/MM/yyyy", Cultura, DateTimeStyles.None, out data) ||
                    data.Year < 1000 || (entrada.HasValue && data.Date < entrada.Value))
                {
                    MessageBox.Show(this, "Informe uma validade válida, igual ou posterior à entrada.", "Atenção");
                    dtpValidade.Focus();
                    return false;
                }
                validade = data.Date;
            }
            if (produtoSelecionado != null && nudQuantidade.Value != produtoSelecionado.QuantidadeEstoque &&
                string.IsNullOrWhiteSpace(txbMotivo.Text))
            {
                MessageBox.Show(this, "Informe o motivo da alteração de quantidade.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMotivo.Focus();
                return false;
            }

            return true;
        }

        private Produto LerProduto(DateTime? entrada, DateTime? validade)
        {
            return new Produto
            {
                Id = produtoSelecionado == null ? 0 : produtoSelecionado.Id,
                Nome = txbNomeProduto.Text.Trim(),
                Categoria = cmbSelecionarCategorias.Text.Trim(),
                UnidadeMedida = cmbDimensao.Text.Trim(),
                Preco = nudPrecoUnitario.Value,
                QuantidadeEstoque = nudQuantidade.Value,
                DataEntrada = entrada,
                DataValidade = validade,
                Ativo = produtoSelecionado == null || produtoSelecionado.Ativo
            };
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!PodeAlterarEstoque() || produtoSelecionado != null)
            {
                return;
            }
            try
            {
                DateTime? entrada, validade;
                if (!ValidarCampos(out entrada, out validade))
                {
                    return;
                }
                Produto produto = LerProduto(entrada, validade);
                new ProdutoDAO().Inserir(produto, idUsuarioLogado);
                ProdutosAlterados?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(this, $"Produto cadastrado.\nCódigo: {produto.Id}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarProdutos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Não foi possível cadastrar.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(this, $"Erro de formato: {ex.Message}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao cadastrar produto.\nErro: {ex.Message}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!PodeAlterarEstoque() || produtoSelecionado == null)
            {
                return;
            }
            try
            {
                DateTime? entrada, validade;
                if (!ValidarCampos(out entrada, out validade))
                {
                    return;
                }
                Produto produto = LerProduto(entrada, validade);
                new ProdutoDAO().Atualizar(produto, idUsuarioLogado,
                    produtoSelecionado.QuantidadeEstoque, txbMotivo.Text.Trim());
                ProdutosAlterados?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(this, "Produto atualizado.", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarProdutos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Não foi possível atualizar.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(this, $"Erro de formato: {ex.Message}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao atualizar produto.\nErro: {ex.Message}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!PodeAlterarEstoque() || produtoSelecionado == null)
            {
                return;
            }
            string acao = produtoSelecionado.Ativo ? "desativar" : "reativar";
            if (MessageBox.Show(this, $"Deseja {acao} o produto {produtoSelecionado.Nome}?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                if (!new ProdutoDAO().AlterarSituacao(produtoSelecionado.Id, !produtoSelecionado.Ativo))
                {
                    throw new InvalidOperationException("Produto não encontrado.");
                }
                ProdutosAlterados?.Invoke(this, EventArgs.Empty);
                CarregarProdutos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Não foi possível {acao}.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao {acao} produto.\nErro: {ex.Message}", "Estoque",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            produtoSelecionado = dgvEstoque.Rows[e.RowIndex].DataBoundItem as Produto;
            if (produtoSelecionado == null)
            {
                return;
            }
            txbCodigo.Text = produtoSelecionado.Id.ToString();
            txbNomeProduto.Text = produtoSelecionado.Nome;
            cmbSelecionarCategorias.Text = produtoSelecionado.Categoria;
            cmbDimensao.Text = produtoSelecionado.UnidadeMedida;
            dtpEntrada.Text = produtoSelecionado.DataEntrada.HasValue
                ? produtoSelecionado.DataEntrada.Value.ToString("dd/MM/yyyy", Cultura) : string.Empty;
            dtpValidade.Text = produtoSelecionado.DataValidade.HasValue
                ? produtoSelecionado.DataValidade.Value.ToString("dd/MM/yyyy", Cultura) : string.Empty;
            nudQuantidade.Value = produtoSelecionado.QuantidadeEstoque;
            nudPrecoUnitario.Value = produtoSelecionado.Preco;
            txbMotivo.Clear();
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = PodeAlterarEstoque();
            btnExcluir.Enabled = PodeAlterarEstoque();
            btnExcluir.Text = produtoSelecionado.Ativo ? "Desativar" : "Reativar";
        }

        private void LimparCampos(bool focarNome = true)
        {
            produtoSelecionado = null;
            txbCodigo.Clear();
            txbNomeProduto.Clear();
            dtpEntrada.Text = DateTime.Today.ToString("dd/MM/yyyy", Cultura);
            dtpValidade.Clear();
            cmbSelecionarCategorias.SelectedIndex = -1;
            cmbSelecionarCategorias.Text = string.Empty;
            cmbDimensao.Text = "un";
            nudQuantidade.Value = 0m;
            nudPrecoUnitario.Value = 0m;
            txbMotivo.Clear();
            btnAdicionar.Enabled = PodeAlterarEstoque();
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnExcluir.Text = "Desativar";
            dgvEstoque.ClearSelection();
            if (focarNome)
            {
                txbNomeProduto.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (carregando)
            {
                return;
            }
            LimparCampos(false);
            AtualizarTabela();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
