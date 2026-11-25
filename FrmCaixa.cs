using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stragalar.Modelos;
using Stragalar.Dados;

namespace Stragalar.Telas
{
    public partial class FrmCaixa : Form
    {
        private static CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");
        private int idUsuarioLogado;
        private string funcaoUsuario;
        private Caixa caixaAtual;
        private Caixa ultimoFechamento;
        private decimal saldoUltimoFechamento;
        private bool sessaoCarregada;
        private const decimal LimiteValor = 99999999.99m;
        private BindingList<ItemVenda> carrinho = new BindingList<ItemVenda>();
        private List<Produto> produtos = new List<Produto>();
        private Produto produtoSelecionado;
        private bool vinculandoProdutos;
        private bool produtosCarregados;
        private ItemVenda itemEmEdicao;
        private HashSet<MaskedTextBox> pagamentosInvalidos = new HashSet<MaskedTextBox>();

        public bool TemVendaEmAndamento => carrinho.Count > 0;

        public FrmCaixa()
        {
            InitializeComponent();
            AjustarAreaCaixa();
        }

        private void FrmCaixa_ClientSizeChanged(object sender, EventArgs e)
        {
            AjustarAreaCaixa();
        }

        private void AjustarAreaCaixa()
        {
            pnlAreaCaixa.Size = new Size(
                Math.Max(ClientSize.Width, pnlAreaCaixa.MinimumSize.Width),
                Math.Max(ClientSize.Height, pnlAreaCaixa.MinimumSize.Height));
        }

        public FrmCaixa(int idUsuarioLogado, string funcaoUsuario) : this()
        {
            this.idUsuarioLogado = idUsuarioLogado;
            this.funcaoUsuario = funcaoUsuario;
        }

        private bool OperarCaixa()
        {
            return idUsuarioLogado > 0 &&
                (funcaoUsuario == "Admin" || funcaoUsuario == "Operador de Caixa");
        }

        private void AtualizarSessao()
        {
            bool aberto, habilitado;

            aberto = caixaAtual != null;
            habilitado = sessaoCarregada && OperarCaixa();

            lblSessao.Text = aberto ? $"Caixa #{caixaAtual.IdCaixa} aberto"
                : "Caixa fechado";
            lblValorCaixa.Text = aberto ? "Valor contado (R$)" : "Valor de abertura (R$)";
            nudValorCaixa.Enabled = habilitado;
            btnAbrirCaixa.Enabled = habilitado && !aberto;
            btnFecharCaixa.Enabled = habilitado && aberto;
        }
        private void AtualizarResumo(decimal? totalVendasAtual, decimal? saldoAtual = null)
        {
            decimal saldo, vendas;

            Caixa resumo = caixaAtual ?? ultimoFechamento;
            grpResumoCaixa.Text = resumo == null ? "Resumo do caixa" :
                (caixaAtual != null ? $"Resumo do caixa #{resumo.IdCaixa}" : $"Fechamento do caixa #{resumo.IdCaixa}");
            lblResumoAbertura.Text = "—";
            lblResumoVendas.Text = "—";
            lblResumoSaldo.Text = "—";
            lblResumoContado.Text = "—";
            lblResumoSobra.Text = "—";
            lblResumoFalta.Text = "—";

            if (resumo == null)
            {
                return;
            }

            saldo = saldoAtual ?? (caixaAtual != null
                ? new CaixaDAO().ConsultarSaldo(resumo.IdCaixa)
                : saldoUltimoFechamento);
            vendas = totalVendasAtual ?? new CaixaDAO().ConsultarVendas(resumo.IdCaixa);

            lblResumoAbertura.Text = ConverterReal(resumo.ValorAbertura);
            lblResumoVendas.Text = ConverterReal(vendas);
            lblResumoSaldo.Text = ConverterReal(saldo);
            if (caixaAtual != null)
            {
                lblSaldoSangria.Text = $"Disponível em dinheiro   {ConverterReal(saldo)}";
            }

            if (resumo.ValorContadoFechamento.HasValue)
            {
                decimal contado, diferenca;

                contado = resumo.ValorContadoFechamento.Value;
                diferenca = contado - saldo;

                lblResumoContado.Text = ConverterReal(contado);
                lblResumoSobra.Text = ConverterReal(Math.Max(0, diferenca));
                lblResumoFalta.Text = ConverterReal(Math.Max(0, -diferenca));
            }
        }
        private void AtualizarTela()
        {
            AtualizarSessao();
            AtualizarVenda();
            AtualizarSangria();
            decimal? totalVendasAtual = AtualizarHistorico();
            AtualizarResumo(totalVendasAtual);
        }
        private void AtualizarTratamento(string confirmacao = "")
        {
            string mensagem = "Falha ao atualizar a tela do caixa.";
            if (confirmacao.Length > 0)
            {
                mensagem = confirmacao + "\n" + mensagem;
            }

            try
            {
                AtualizarTela();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"{mensagem}\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{mensagem}\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ConverterReal(decimal valor)
        {
            return valor.ToString("C2", Cultura);
        }

        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            ConfigurarVenda();
            ConfigurarHistorico();
            AtualizarSessao();

            if (!OperarCaixa())
            {
                lblRetorno.Text = "Você não possui permissão para acessar essa função. Entre como Admin ou Operador de Caixa.";
                AtualizarTratamento();
                return;
            }

            try
            {
                caixaAtual = new CaixaDAO().BuscarCaixaAberto(idUsuarioLogado);
                sessaoCarregada = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco ao consultar sessão do caixa\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao consultar a sessão do caixa.\nErro: {ex.Message}", "Caixa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AtualizarTratamento();
        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            if (!sessaoCarregada || !OperarCaixa() || caixaAtual != null)
            {
                return;
            }

            var caixa = new Caixa
            {
                IdUsuarioAbertura = idUsuarioLogado,
                ValorAbertura = nudValorCaixa.Value
            };
            List<Produto> produtosAbertura;
            List<Venda> vendas;
            DataTable movimentacoes;
            decimal saldo;

            try
            {
                new CaixaDAO().AbrirCaixaComDados(caixa, out produtosAbertura,
                    out vendas, out movimentacoes, out saldo);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Erro no banco ao tentar abrir o caixa.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Falha ao tentar abrir o caixa.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            caixaAtual = caixa;
            lblRetorno.Text = $"Caixa #{caixa.IdCaixa} aberto.";

            try
            {
                nudValorCaixa.Value = 0;
                AtualizarSessao();
                ExibirProdutos(produtosAbertura);
                AtualizarVenda();
                AtualizarSangria();
                ExibirHistorico(vendas, movimentacoes);
                AtualizarResumo(vendas.Where(venda => venda.Status).Sum(venda => venda.ValorTotal), saldo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{lblRetorno.Text}\nFalha ao atualizar a tela.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (caixaAtual == null || !OperarCaixa())
                {
                    return;
                }

                if (carrinho.Count > 0)
                {
                    MessageBox.Show("Finalize a venda ou retire os itens do carrinho.", "Caixa",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal contado = nudValorCaixa.Value;
                DialogResult confirmar = MessageBox.Show($"Fechar caixa com {ConverterReal(contado)} contados?",
                    "Caixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes)
                {
                    return;
                }

                saldoUltimoFechamento = new CaixaDAO().FecharCaixa(caixaAtual, idUsuarioLogado, contado);

                ultimoFechamento = caixaAtual;
                caixaAtual = null;
                nudValorCaixa.Value = 0;
                lblRetorno.Text = $"Caixa #{ultimoFechamento.IdCaixa} fechado.";
                AtualizarTratamento(lblRetorno.Text);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco ao tentar fechar o caixa\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao tentar fechar o caixa.\nErro: {ex.Message}", "Caixa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ConfigurarVenda()
        {
            dvgCarrinhoCompra.AutoGenerateColumns = false;
            dvgCarrinhoCompra.DefaultCellStyle.FormatProvider = Cultura;
            dvgCarrinhoCompra.DataSource = carrinho;
            dvgCarrinhoCompra.ClearSelection();
            dvgCarrinhoCompra.CurrentCell = null;
            cmbProdutoPesquisa.DisplayMember = "Nome";
            cmbProdutoPesquisa.FormattingEnabled = true;
        }

        private void AtualizarVenda()
        {
            bool aberto = caixaAtual != null && OperarCaixa();
            grpCarrinho.Enabled = aberto;
            grpPagamento.Enabled = aberto;

            if (!aberto)
            {
                carrinho.Clear();
                itemEmEdicao = null;
                produtos.Clear();
                produtoSelecionado = null;
                produtosCarregados = false;
                VincularProdutos(produtos, string.Empty);
                LimparPagamentos();
            }
            else if (!produtosCarregados)
            {
                CarregarProdutos();
            }

            AtualizarEstoqueDoProduto();
            AtualizarPagamento();
        }

        private void CarregarProdutos()
        {
            ExibirProdutos(new ProdutoDAO().Listar());
        }

        private void ExibirProdutos(List<Produto> lista)
        {
            produtos = lista;
            produtoSelecionado = null;
            VincularProdutos(produtos, string.Empty);
            produtosCarregados = true;
            if (itemEmEdicao != null && carrinho.Contains(itemEmEdicao))
            {
                ExibirItemCarrinho(itemEmEdicao);
            }
            AtualizarEstoqueDoProduto();
        }

        private void FrmCaixa_VisibleChanged(object sender, EventArgs e)
        {
            if (IsDisposed || Disposing)
            {
                return;
            }
            if (!Visible)
            {
                tmrPesquisaProduto.Stop();
                return;
            }
            if (Visible && sessaoCarregada)
            {
                AtualizarListaProdutos();
                if (abas.SelectedTab == tabHistorico)
                {
                    AtualizarTratamento();
                }
            }
        }

        private void btnAtualizarItem_Click(object sender, EventArgs e)
        {
            AlterarCarrinho(true);
        }

        private void AtualizarListaProdutos()
        {
            if (caixaAtual == null || !OperarCaixa())
            {
                return;
            }

            try
            {
                CarregarProdutos();
                lblRetorno.Text = "Lista de produtos atualizada.";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco ao carregar os produtos.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao carregar os produtos.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VincularProdutos(List<Produto> lista, string texto)
        {
            tmrPesquisaProduto.Stop();
            vinculandoProdutos = true;
            cmbProdutoPesquisa.BeginUpdate();
            try
            {
                cmbProdutoPesquisa.DroppedDown = false;
                cmbProdutoPesquisa.SelectedIndex = -1;
                cmbProdutoPesquisa.Items.Clear();
                cmbProdutoPesquisa.Items.AddRange(lista.ToArray());
                cmbProdutoPesquisa.SelectedIndex = -1;
                cmbProdutoPesquisa.Text = texto;
                cmbProdutoPesquisa.SelectionStart = texto.Length;
                cmbProdutoPesquisa.SelectionLength = 0;
            }
            finally
            {
                cmbProdutoPesquisa.EndUpdate();
                vinculandoProdutos = false;
            }
        }

        private void cmbProdutoPesquisa_Format(object sender, ListControlConvertEventArgs e)
        {
            var produto = e.ListItem as Produto;
            if (produto != null)
            {
                e.Value = $"{produto.Id} - {produto.Nome}";
            }
        }

        private void cmbProdutoPesquisa_TextUpdate(object sender, EventArgs e)
        {
            if (vinculandoProdutos || caixaAtual == null || IsDisposed || Disposing)
            {
                return;
            }

            itemEmEdicao = null;
            produtoSelecionado = null;
            dvgCarrinhoCompra.ClearSelection();
            dvgCarrinhoCompra.CurrentCell = null;
            AtualizarEstoqueDoProduto();
            tmrPesquisaProduto.Stop();
            tmrPesquisaProduto.Start();
        }

        private void tmrPesquisaProduto_Tick(object sender, EventArgs e)
        {
            tmrPesquisaProduto.Stop();
            if (IsDisposed || Disposing || !Visible || !cmbProdutoPesquisa.Focused ||
                vinculandoProdutos || caixaAtual == null)
            {
                return;
            }

            string texto = cmbProdutoPesquisa.Text;
            int cursor = cmbProdutoPesquisa.SelectionStart;
            string termo = texto.Trim();
            int codigo;
            bool temId = int.TryParse(termo, out codigo);
            produtoSelecionado = null;

            List<Produto> lista = produtos.Where(produto =>
                (temId && produto.Id == codigo) ||
                Cultura.CompareInfo.IndexOf(produto.Nome, termo,
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0)
                .OrderByDescending(produto => temId && produto.Id == codigo)
                .ToList();

            VincularProdutos(lista, texto);
            cmbProdutoPesquisa.DroppedDown = lista.Count > 0;
            cmbProdutoPesquisa.SelectionStart = Math.Min(cursor, texto.Length);
            cmbProdutoPesquisa.SelectionLength = 0;
            if (lista.Count == 0)
            {
                lblRetorno.Text = "Nenhum produto encontrado para essa pesquisa.";
            }
            AtualizarEstoqueDoProduto();
        }

        private void cmbProdutoPesquisa_Leave(object sender, EventArgs e)
        {
            tmrPesquisaProduto.Stop();
        }

        private void cmbProdutoPesquisa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (vinculandoProdutos || IsDisposed || Disposing)
            {
                return;
            }
            tmrPesquisaProduto.Stop();
            itemEmEdicao = null;
            int indice = cmbProdutoPesquisa.SelectedIndex;
            produtoSelecionado = indice >= 0 && indice < cmbProdutoPesquisa.Items.Count
                ? cmbProdutoPesquisa.Items[indice] as Produto : null;
            nudQuantidadeCarrinho.Value = 1m;
            dvgCarrinhoCompra.ClearSelection();
            dvgCarrinhoCompra.CurrentCell = null;
            AtualizarEstoqueDoProduto();
        }

        private decimal EstoqueDisponivel(Produto produto)
        {
            decimal noCarrinho = carrinho.Where(item => item.IdProduto == produto.Id && item != itemEmEdicao)
                .Sum(item => item.Quantidade);
            return Math.Max(0m, produto.QuantidadeEstoque - noCarrinho);
        }

        private void AtualizarEstoqueDoProduto()
        {
            bool selecionado = caixaAtual != null && produtoSelecionado != null && OperarCaixa();
            lblEstoque.Text = selecionado
                ? EstoqueDisponivel(produtoSelecionado).ToString("N3", Cultura) : "—";
            lblPrecoProduto.Text = selecionado
                ? "Unitário: " + ConverterReal(produtoSelecionado.Preco) : "Unitário: —";
            btnAdicionarItem.Enabled = selecionado && itemEmEdicao == null;
            btnAtualizarItem.Enabled = selecionado && itemEmEdicao != null && carrinho.Contains(itemEmEdicao);
        }

        private void dvgCarrinhoCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dvgCarrinhoCompra.Rows.Count ||
                caixaAtual == null || !OperarCaixa())
            {
                return;
            }
            var item = dvgCarrinhoCompra.Rows[e.RowIndex].DataBoundItem as ItemVenda;
            if (item == null)
            {
                return;
            }
            try
            {
                produtos = new ProdutoDAO().Listar();
                VincularProdutos(produtos, string.Empty);
                ExibirItemCarrinho(item);
            }
            catch (MySqlException ex)
            {
                LimparItemCarrinho();
                MessageBox.Show(this, $"Erro ao consultar o produto.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LimparItemCarrinho();
                MessageBox.Show(this, $"Falha ao selecionar o item.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExibirItemCarrinho(ItemVenda item)
        {
            itemEmEdicao = item;
            produtoSelecionado = produtos.FirstOrDefault(produto => produto.Id == item.IdProduto);
            if (produtoSelecionado == null)
            {
                cmbProdutoPesquisa.SelectedIndex = -1;
                cmbProdutoPesquisa.Text = item.NomeProduto;
                lblRetorno.Text = "Produto indisponível. Remova o item do carrinho ou reative o produto no estoque.";
            }
            else
            {
                cmbProdutoPesquisa.SelectedItem = produtoSelecionado;
                lblRetorno.Text = "Altere a quantidade e clique em Atualizar item.";
            }
            nudQuantidadeCarrinho.Value = item.Quantidade;
            AtualizarEstoqueDoProduto();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            AlterarCarrinho(false);
        }

        private void AlterarCarrinho(bool atualizar)
        {
            if (caixaAtual == null || produtoSelecionado == null || !OperarCaixa() ||
                (atualizar && (itemEmEdicao == null || !carrinho.Contains(itemEmEdicao))))
            {
                return;
            }
            try
            {
                int idProduto = produtoSelecionado.Id;
                decimal quantidade = nudQuantidadeCarrinho.Value;
                produtos = new ProdutoDAO().Listar();
                Produto produto = produtos.FirstOrDefault(produtoAtual => produtoAtual.Id == idProduto);
                if (produto == null)
                {
                    throw new InvalidOperationException("Produto indisponível. Confira seu cadastro no estoque.");
                }
                produtoSelecionado = produto;
                AtualizarEstoqueDoProduto();
                ItemVenda existente = atualizar ? itemEmEdicao : carrinho.FirstOrDefault(item => item.IdProduto == idProduto);
                decimal novaQuantidade = atualizar || existente == null ? quantidade : existente.Quantidade + quantidade;
                decimal outrasQuantidades = carrinho.Where(item => item.IdProduto == idProduto && item != existente)
                    .Sum(item => item.Quantidade);
                if (quantidade <= 0m || novaQuantidade > produto.QuantidadeEstoque - outrasQuantidades)
                {
                    MessageBox.Show(this, "Informe uma quantidade maior que zero e dentro do estoque disponível.", "Caixa",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQuantidadeCarrinho.Focus();
                    return;
                }
                var novoItem = new ItemVenda
                {
                    IdProduto = produto.Id,
                    NomeProduto = produto.Nome,
                    Quantidade = novaQuantidade,
                    PrecoUnitario = produto.Preco
                };
                decimal total = carrinho.Sum(item => item.Subtotal)
                    - (existente == null ? 0m : existente.Subtotal) + novoItem.Subtotal;
                if (novoItem.PrecoUnitario < 0m || total > LimiteValor)
                {
                    throw new InvalidOperationException("Confira o preço e o limite da venda.");
                }
                if (existente == null)
                {
                    carrinho.Add(novoItem);
                }
                else
                {
                    carrinho[carrinho.IndexOf(existente)] = novoItem;
                }
                VincularProdutos(produtos, string.Empty);
                cmbProdutoPesquisa.SelectedItem = produto;
                itemEmEdicao = atualizar ? novoItem : null;
                nudQuantidadeCarrinho.Value = atualizar ? novaQuantidade : 1m;
                dvgCarrinhoCompra.ClearSelection();
                int indice = carrinho.IndexOf(novoItem);
                if (atualizar && indice >= 0 && indice < dvgCarrinhoCompra.Rows.Count)
                {
                    dvgCarrinhoCompra.CurrentCell = dvgCarrinhoCompra.Rows[indice].Cells[0];
                    dvgCarrinhoCompra.Rows[indice].Selected = true;
                }
                else
                {
                    dvgCarrinhoCompra.CurrentCell = null;
                }
                lblRetorno.Text = atualizar ? "Item atualizado no carrinho." : "Item adicionado ao carrinho.";
                AtualizarEstoqueDoProduto();
                AtualizarPagamento();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, $"Erro ao consultar o estoque.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Não foi possível alterar o carrinho.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparItemCarrinho()
        {
            itemEmEdicao = null;
            produtoSelecionado = null;
            VincularProdutos(produtos, string.Empty);
            nudQuantidadeCarrinho.Value = 1m;
            dvgCarrinhoCompra.ClearSelection();
            dvgCarrinhoCompra.CurrentCell = null;
            AtualizarEstoqueDoProduto();
        }

        private void btnNovoItem_Click(object sender, EventArgs e)
        {
            LimparItemCarrinho();
            cmbProdutoPesquisa.Focus();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            var item = dvgCarrinhoCompra.CurrentRow?.DataBoundItem as ItemVenda;
            if (item == null || caixaAtual == null || !OperarCaixa())
            {
                return;
            }
            carrinho.Remove(item);
            LimparItemCarrinho();
            if (carrinho.Count == 0)
            {
                LimparPagamentos();
            }
            AtualizarPagamento();
        }

        private bool LerPagamentos(out Dictionary<string, decimal> pagamentos,
            out string erro)
        {
            pagamentos = new Dictionary<string, decimal>();
            return LerParcela(mtbDinheiro, "Dinheiro", pagamentos, out erro)
                && LerParcela(mtbPix, "Pix", pagamentos, out erro)
                && LerParcela(mtbDebito, "Débito", pagamentos, out erro)
                && LerParcela(mtbCredito, "Crédito", pagamentos, out erro);
        }

        private static bool LerValorPagamento(string texto, out decimal valor)
        {
            valor = 0m;
            if (texto.Length == 0)
            {
                return true;
            }
            string[] partes = texto.Split(',');
            if (partes.Length > 2 || partes[0].Length > 8 ||
                (partes.Length == 2 && partes[1].Length > 2) ||
                texto.Any(caractere => (caractere < '0' || caractere > '9') && caractere != ','))
            {
                return false;
            }
            if (texto == ",")
            {
                return true;
            }
            return decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, Cultura, out valor) &&
                valor >= 0m && valor <= LimiteValor && Math.Round(valor, 2) == valor;
        }

        private bool LerParcela(MaskedTextBox campo, string forma,
            Dictionary<string, decimal> pagamentos, out string erro)
        {
            erro = string.Empty;
            decimal valor;
            if (pagamentosInvalidos.Contains(campo) ||
                !LerValorPagamento(campo.Text, out valor))
            {
                erro = "Valor inválido em " + forma + ". Use vírgula e até duas casas decimais.";
                return false;
            }
            if (valor > 0m)
            {
                pagamentos.Add(forma, valor);
            }
            return true;
        }

        private void DefinirPagamento(MaskedTextBox campo, decimal valor)
        {
            pagamentosInvalidos.Remove(campo);
            campo.BackColor = SystemColors.Window;
            campo.Text = valor.ToString("0.00", Cultura);
        }

        private void LimparPagamentos()
        {
            DefinirPagamento(mtbDinheiro, 0m);
            DefinirPagamento(mtbPix, 0m);
            DefinirPagamento(mtbDebito, 0m);
            DefinirPagamento(mtbCredito, 0m);
        }

        private void mtbPagamento_TextChanged(object sender, EventArgs e)
        {
            var campo = (MaskedTextBox)sender;
            pagamentosInvalidos.Remove(campo);
            campo.BackColor = SystemColors.Window;
            if (sessaoCarregada)
            {
                AtualizarPagamento();
            }
        }

        private void mtbPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            var campo = (MaskedTextBox)sender;
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            string texto = campo.Text.Remove(campo.SelectionStart, campo.SelectionLength)
                .Insert(campo.SelectionStart, e.KeyChar.ToString());
            decimal valor;
            if (!LerValorPagamento(texto, out valor))
            {
                e.Handled = true;
                pagamentosInvalidos.Add(campo);
                campo.BackColor = Color.MistyRose;
                AtualizarPagamento();
            }
        }

        private void mtbPagamento_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).SelectAll();
        }

        private void mtbPagamento_Leave(object sender, EventArgs e)
        {
            var campo = (MaskedTextBox)sender;
            decimal valor;
            if (!pagamentosInvalidos.Contains(campo) &&
                LerValorPagamento(campo.Text, out valor))
            {
                DefinirPagamento(campo, valor);
            }
        }

        private void ColarPagamento(MaskedTextBox campo)
        {
            try
            {
                if (campo == null || !Clipboard.ContainsText())
                {
                    return;
                }
                decimal valor;
                if (!LerValorPagamento(Clipboard.GetText().Trim().Replace('.', ','), out valor))
                {
                    pagamentosInvalidos.Add(campo);
                    campo.BackColor = Color.MistyRose;
                    AtualizarPagamento();
                    return;
                }
                DefinirPagamento(campo, valor);
                campo.SelectionStart = campo.Text.Length;
                AtualizarPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Não foi possível colar o valor.\nErro: {ex.Message}", "Caixa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtbPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                e.SuppressKeyPress = true;
                ColarPagamento((MaskedTextBox)sender);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                ((MaskedTextBox)sender).SelectAll();
            }
        }

        private void mnuColarPagamento_Click(object sender, EventArgs e)
        {
            ColarPagamento(menuPagamento.SourceControl as MaskedTextBox);
        }

        private void mnuLimparPagamento_Click(object sender, EventArgs e)
        {
            var campo = menuPagamento.SourceControl as MaskedTextBox;
            if (campo != null)
            {
                DefinirPagamento(campo, 0m);
                AtualizarPagamento();
            }
        }

        private void AtualizarPagamento()
        {
            decimal total = carrinho.Sum(item => item.Subtotal);
            Dictionary<string, decimal> pagamentos;
            string erro;
            bool valido = LerPagamentos(out pagamentos, out erro);
            decimal informado = pagamentos.Values.Sum();
            decimal diferenca = total - informado;

            lblTotalVendas.Text = "Total da venda   " + ConverterReal(total);
            lblPago.Text = valido ? "Total informado   " + ConverterReal(informado)
                : "Total informado   —";
            lblFalta.Text = valido
                ? (diferenca >= 0m ? "Falta receber   " : "Valor a ajustar   ")
                    + ConverterReal(Math.Abs(diferenca))
                : erro;
            btnRemoverItem.Enabled = caixaAtual != null && carrinho.Count > 0;
            btnFinalizar.Enabled = caixaAtual != null && valido && total > 0m
                && informado == total && OperarCaixa();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (caixaAtual == null || !OperarCaixa())
            {
                return;
            }

            List<ItemVenda> itens = carrinho.ToList();
            decimal total = itens.Sum(item => item.Subtotal);
            if (total <= 0m)
            {
                MessageBox.Show(this, "Adicione itens com valor maior que zero.", "Caixa");
                return;
            }

            Dictionary<string, decimal> pagamentos;
            string erro;
            if (!LerPagamentos(out pagamentos, out erro))
            {
                MessageBox.Show(this, erro, "Caixa");
                return;
            }

            if (pagamentos.Values.Sum() != total)
            {
                MessageBox.Show(this,
                    "A soma dos pagamentos deve ser " + ConverterReal(total) + ".", "Caixa");
                return;
            }

            int idVenda;
            btnFinalizar.Enabled = false;
            try
            {
                idVenda = new VendaDAO().FinalizarVenda(caixaAtual.IdCaixa,
                    idUsuarioLogado, itens, pagamentos);
            }
            catch (MySqlException ex)
            {
                AtualizarPagamento();
                MessageBox.Show($"Erro no banco ao confirmar a venda.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                AtualizarPagamento();
                MessageBox.Show($"Falha ao confirmar a venda.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            carrinho.Clear();
            itemEmEdicao = null;
            LimparPagamentos();
            produtosCarregados = false;
            produtoSelecionado = null;
            lblRetorno.Text = $"Venda #{idVenda} finalizada.";
            AtualizarTratamento(lblRetorno.Text);
        }

        private void AtualizarSangria()
        {
            grpSangria.Enabled = caixaAtual != null && OperarCaixa();
            lblSaldoSangria.Text = "Disponível em dinheiro   —";

            if (!grpSangria.Enabled)
            {
                nudSangria.Value = 0;
                txbMotivoSangria.Clear();
            }
        }

        private void btnRegistrarSangria_Click(object sender, EventArgs e)
        {
            if (caixaAtual == null || !OperarCaixa())
            {
                MessageBox.Show(this, "Abra o caixa com um usuário autorizado.", "Caixa");
                return;
            }

            decimal valor = nudSangria.Value;
            string motivo = txbMotivoSangria.Text.Trim();
            if (valor <= 0m)
            {
                MessageBox.Show(this, "Informe um valor maior que zero.", "Caixa");
                return;
            }

            if (motivo.Length == 0 || motivo.Length > 200)
            {
                MessageBox.Show(this, "Informe um motivo de até 200 caracteres.", "Caixa");
                return;
            }

            int id;
            try
            {
                id = new CaixaDAO().RegistrarSangria(caixaAtual.IdCaixa, idUsuarioLogado,
                    valor, motivo);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco ao registrar a sangria.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao registrar a sangria.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nudSangria.Value = 0m;
            txbMotivoSangria.Clear();
            lblRetorno.Text = $"Sangria #{id} registrada.";
            AtualizarTratamento(lblRetorno.Text);
        }

        private void ConfigurarHistorico()
        {
            dvgVendas.AutoGenerateColumns = false;
            dvgMovimentacoes.AutoGenerateColumns = false;
            dvgVendas.DefaultCellStyle.FormatProvider = Cultura;
            dvgMovimentacoes.DefaultCellStyle.FormatProvider = Cultura;
        }

        private void abas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sessaoCarregada && abas.SelectedTab == tabHistorico)
            {
                AtualizarTratamento();
            }
        }

        private decimal? AtualizarHistorico()
        {
            if (caixaAtual == null)
            {
                ExibirHistorico(null, null);
                return null;
            }

            ExibirHistorico(null, null);
            txbMotivoEstorno.Enabled = false;
            lblVendas.Text = "Histórico não carregado. Selecione a aba novamente para tentar.";
            lblMovimentos.Text = "Movimentações não carregadas.";
            List<Venda> vendas = new VendaDAO().ListarPorCaixa(caixaAtual.IdCaixa);
            DataTable movimentacoes = new CaixaDAO().ListarMovimentacoes(caixaAtual.IdCaixa);
            ExibirHistorico(vendas, movimentacoes);
            return vendas.Where(venda => venda.Status).Sum(venda => venda.ValorTotal);
        }

        private void ExibirHistorico(List<Venda> vendas, DataTable movimentacoes)
        {
            txbMotivoEstorno.Clear();
            txbMotivoEstorno.Enabled = caixaAtual != null && funcaoUsuario == "Admin";
            dvgVendas.DataSource = vendas;
            dvgVendas.ClearSelection();
            dvgVendas.CurrentCell = null;
            dvgMovimentacoes.DataSource = movimentacoes;
            dvgMovimentacoes.ClearSelection();
            dvgMovimentacoes.CurrentCell = null;
            lblVendas.Text = caixaAtual == null
                ? "Sem caixa aberto. Consulte os caixas anteriores em Relatórios."
                : $"Vendas do caixa #{caixaAtual.IdCaixa}: {vendas?.Count ?? 0}";
            lblMovimentos.Text = caixaAtual == null ? "Movimentações do caixa atual"
                : $"Movimentações do caixa #{caixaAtual.IdCaixa}: {movimentacoes?.Rows.Count ?? 0}";
            btnEstornar.Enabled = false;
        }

        private void SelecaoOuMotivoEstornoMudou(object sender, EventArgs e)
        {
            if (!sessaoCarregada)
            {
                return;
            }

            var venda = dvgVendas.CurrentRow?.DataBoundItem as Venda;
            btnEstornar.Enabled = caixaAtual != null && funcaoUsuario == "Admin" &&
                venda != null && venda.Status && txbMotivoEstorno.Text.Trim().Length > 0;
        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            if (caixaAtual == null || funcaoUsuario != "Admin")
            {
                MessageBox.Show(this, "O estorno exige um caixa aberto e um Admin.", "Caixa");
                return;
            }

            var venda = dvgVendas.CurrentRow?.DataBoundItem as Venda;
            if (venda == null || !venda.Status)
            {
                MessageBox.Show(this, "Selecione uma venda finalizada.", "Caixa");
                return;
            }

            string motivo = txbMotivoEstorno.Text.Trim();
            if (motivo.Length == 0 || motivo.Length > 200)
            {
                MessageBox.Show(this, "Informe o motivo do estorno em até 200 caracteres.",
                    "Caixa");
                return;
            }

            try
            {
                new VendaDAO().EstornarVenda(caixaAtual.IdCaixa, idUsuarioLogado,
                    venda.IdVenda, motivo);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco ao estornar a venda.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao estornar a venda.\nErro: {ex.Message}",
                    "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            produtosCarregados = false;
            produtoSelecionado = null;
            lblRetorno.Text = $"Venda #{venda.IdVenda} estornada.";
            AtualizarTratamento(lblRetorno.Text);
        }
    }
}
