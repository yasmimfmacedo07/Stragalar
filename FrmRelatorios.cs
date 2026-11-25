using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stragalar.Dados;

namespace Stragalar.Telas
{
    public partial class FrmRelatorios : Form
    {
        private static CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");
        private bool carregando = true;

        public FrmRelatorios()
        {
            InitializeComponent();
            AjustarAreaRelatorios();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            cmbPeriodo.SelectedIndex = 0;
            dtpReferencia.Value = DateTime.Today;
            dgvFaturamento.DefaultCellStyle.FormatProvider = Cultura;
            dgvCaixas.DefaultCellStyle.FormatProvider = Cultura;
            dgvMovimentacoesCaixa.DefaultCellStyle.FormatProvider = Cultura;
            dgvMovimentacoesEstoque.DefaultCellStyle.FormatProvider = Cultura;
            carregando = false;
            CarregarRelatorios();
        }

        private void FrmRelatorios_ClientSizeChanged(object sender, EventArgs e)
        {
            AjustarAreaRelatorios();
        }

        private void AjustarAreaRelatorios()
        {
            pnlAreaRelatorios.Size = new Size(
                Math.Max(ClientSize.Width, pnlAreaRelatorios.MinimumSize.Width),
                Math.Max(ClientSize.Height, pnlAreaRelatorios.MinimumSize.Height));
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (!carregando && !Disposing && !IsDisposed)
            {
                CarregarRelatorios();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarRelatorios();
        }

        private void CalcularPeriodo(out DateTime inicio, out DateTime fim)
        {
            DateTime referencia = dtpReferencia.Value.Date;
            switch (cmbPeriodo.SelectedIndex)
            {
                case 0:
                    inicio = referencia;
                    fim = inicio.AddDays(1);
                    break;
                case 1:
                    int diasDesdeSegunda = ((int)referencia.DayOfWeek + 6) % 7;
                    inicio = referencia.AddDays(-diasDesdeSegunda);
                    fim = inicio.AddDays(7);
                    break;
                case 2:
                    inicio = new DateTime(referencia.Year, referencia.Month, 1);
                    fim = inicio.AddMonths(1);
                    break;
                case 3:
                    inicio = new DateTime(referencia.Year, 1, 1);
                    fim = inicio.AddYears(1);
                    break;
                default:
                    throw new FormatException("Selecione Diário, Semanal, Mensal ou Anual.");
            }
        }

        private DataTable PrepararFaturamento(DataTable consulta, DateTime inicio, DateTime fim, bool agruparPorMes)
        {
            var tabela = new DataTable();
            tabela.Columns.Add("periodo", typeof(DateTime));
            tabela.Columns.Add("quantidadeVendas", typeof(long));
            tabela.Columns.Add("valorVendas", typeof(decimal));
            tabela.Columns.Add("valorEstornos", typeof(decimal));
            tabela.Columns.Add("valorLiquido", typeof(decimal));
            for (DateTime data = inicio; data < fim; data = agruparPorMes ? data.AddMonths(1) : data.AddDays(1))
            {
                DataRow registro = consulta.AsEnumerable().FirstOrDefault(linha => Convert.ToDateTime(linha["periodo"]).Date == data);
                long quantidade = registro == null ? 0 : Convert.ToInt64(registro["quantidadeVendas"]);
                decimal vendas = registro == null ? 0m : Convert.ToDecimal(registro["valorVendas"]);
                decimal estornos = registro == null ? 0m : Convert.ToDecimal(registro["valorEstornos"]);
                tabela.Rows.Add(data, quantidade, vendas, estornos, vendas - estornos);
            }
            return tabela;
        }

        private void PrepararCaixas(DataTable tabela)
        {
            tabela.Columns.Add("sobra", typeof(decimal));
            tabela.Columns.Add("falta", typeof(decimal));
            foreach (DataRow linha in tabela.Rows)
            {
                if (linha["valorContadoFechamento"] != DBNull.Value)
                {
                    decimal diferenca = Convert.ToDecimal(linha["valorContadoFechamento"]) - Convert.ToDecimal(linha["saldoDinheiro"]);
                    linha["sobra"] = Math.Max(0m, diferenca);
                    linha["falta"] = Math.Max(0m, -diferenca);
                }
            }
        }

        private void CarregarRelatorios()
        {
            if (carregando || Disposing || IsDisposed)
            {
                return;
            }
            btnAtualizar.Enabled = false;
            UseWaitCursor = true;
            try
            {
                DateTime inicio, fim;
                CalcularPeriodo(out inicio, out fim);
                bool agruparPorMes = cmbPeriodo.SelectedIndex == 3;
                DataSet dados = new RelatorioDAO().Consultar(inicio, fim, agruparPorMes);
                DataTable faturamento = PrepararFaturamento(dados.Tables["Faturamento"], inicio, fim, agruparPorMes);
                DataTable caixas = dados.Tables["Caixas"];
                DataTable movimentacoesCaixa = dados.Tables["MovimentacoesCaixa"];
                DataTable movimentacoesEstoque = dados.Tables["MovimentacoesEstoque"];
                PrepararCaixas(caixas);
                decimal vendas = faturamento.AsEnumerable().Sum(linha => linha.Field<decimal>("valorVendas"));
                decimal estornos = faturamento.AsEnumerable().Sum(linha => linha.Field<decimal>("valorEstornos"));
                decimal entradas = movimentacoesCaixa.AsEnumerable().Where(linha => linha.Field<string>("tipo") == "Entrada")
                    .Sum(linha => Convert.ToDecimal(linha["valor"]));
                decimal saidas = movimentacoesCaixa.AsEnumerable().Where(linha => linha.Field<string>("tipo") == "Saída")
                    .Sum(linha => Convert.ToDecimal(linha["valor"]));
                dgvFaturamento.DataSource = faturamento;
                DataGridViewColumn colunaPeriodo = dgvFaturamento.Columns["colPeriodo"];
                if (colunaPeriodo != null)
                {
                    colunaPeriodo.DefaultCellStyle.Format = agruparPorMes ? "MM/yyyy" : "dd/MM/yyyy";
                }
                dgvCaixas.DataSource = caixas;
                dgvMovimentacoesCaixa.DataSource = movimentacoesCaixa;
                dgvMovimentacoesEstoque.DataSource = movimentacoesEstoque;
                dgvFaturamento.ClearSelection();
                dgvCaixas.ClearSelection();
                dgvMovimentacoesCaixa.ClearSelection();
                dgvMovimentacoesEstoque.ClearSelection();
                lblTotalVendas.Text = vendas.ToString("C2", Cultura);
                lblTotalEstornos.Text = estornos.ToString("C2", Cultura);
                lblFaturamentoLiquido.Text = (vendas - estornos).ToString("C2", Cultura);
                lblFaturamentoLiquido.ForeColor = vendas < estornos ? Color.Firebrick : Color.DarkGreen;
                lblPeriodo.Text = "Período consultado\n" + inicio.ToString("dd/MM/yyyy") + " a " + fim.AddDays(-1).ToString("dd/MM/yyyy");
                lblResumoFaturamento.Text = dados.Tables["Faturamento"].Rows.Count == 0
                    ? "Nenhuma venda ou estorno no período." : (agruparPorMes ? "Valores agrupados por mês." : "Valores agrupados por dia.");
                lblResumoCaixas.Text = $"{caixas.Rows.Count} caixa(s). Os valores de cada caixa abrangem a sessão inteira.";
                lblResumoMovimentacoesCaixa.Text = $"{movimentacoesCaixa.Rows.Count} movimento(s) | Entradas: {entradas.ToString("C2", Cultura)} | " +
                    $"Saídas: {saidas.ToString("C2", Cultura)} | Diferença: {(entradas - saidas).ToString("C2", Cultura)}";
                lblResumoMovimentacoesEstoque.Text = $"{movimentacoesEstoque.Rows.Count} movimento(s). Quantidades na unidade de cada produto.";
                lblRetorno.Text = $"Consulta atualizada às {DateTime.Now:HH:mm:ss}. Abrange todos os usuários e caixas.";
            }
            catch (MySqlException ex)
            {
                LimparRelatorios();
                MessageBox.Show(this, $"Não foi possível consultar os relatórios.\nCódigo: {ex.Number}\nErro no banco: {ex.Message}",
                    "Erro - Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                LimparRelatorios();
                MessageBox.Show(this, $"Erro de formato: {ex.Message}", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LimparRelatorios();
                MessageBox.Show(this, $"Falha ao carregar os relatórios.\nErro: {ex.Message}", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                btnAtualizar.Enabled = true;
            }
        }

        private void LimparRelatorios()
        {
            dgvFaturamento.DataSource = null;
            dgvCaixas.DataSource = null;
            dgvMovimentacoesCaixa.DataSource = null;
            dgvMovimentacoesEstoque.DataSource = null;
            lblTotalVendas.Text = "—";
            lblTotalEstornos.Text = "—";
            lblFaturamentoLiquido.Text = "—";
            lblPeriodo.Text = "Consulta não carregada";
            lblResumoFaturamento.Text = string.Empty;
            lblResumoCaixas.Text = string.Empty;
            lblResumoMovimentacoesCaixa.Text = string.Empty;
            lblResumoMovimentacoesEstoque.Text = string.Empty;
            lblRetorno.Text = "Confira a conexão e clique em Atualizar para tentar novamente.";
        }
    }
}
