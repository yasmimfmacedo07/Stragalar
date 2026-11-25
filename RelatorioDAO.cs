using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Stragalar.Dados
{
    internal class RelatorioDAO
    {
        public DataSet Consultar(DateTime inicio, DateTime fim, bool agruparPorMes)
        {
            const string sqlFaturamento =
                "SELECT CASE WHEN @agruparPorMes THEN " +
                "DATE_SUB(DATE(dataMovimentacao), INTERVAL DAYOFMONTH(dataMovimentacao) - 1 DAY) " +
                "ELSE DATE(dataMovimentacao) END AS periodo, " +
                "COUNT(DISTINCT CASE WHEN origem = 'Venda' AND tipo = 'Entrada' THEN idVenda END) AS quantidadeVendas, " +
                "SUM(CASE WHEN origem = 'Venda' AND tipo = 'Entrada' THEN valor ELSE 0 END) AS valorVendas, " +
                "SUM(CASE WHEN origem = 'Estorno' AND tipo = 'Saída' THEN valor ELSE 0 END) AS valorEstornos " +
                "FROM movimentacaoCaixa WHERE dataMovimentacao >= @inicio AND dataMovimentacao < @fim " +
                "AND ((origem = 'Venda' AND tipo = 'Entrada') OR (origem = 'Estorno' AND tipo = 'Saída')) " +
                "GROUP BY periodo ORDER BY periodo";

            const string sqlCaixas =
                "SELECT caixa.idCaixa, usuario.nomeUsuario AS usuarioAbertura, caixa.dataAbertura, " +
                "caixa.dataFechamento, CASE WHEN caixa.dataFechamento IS NULL THEN 'Aberto' ELSE 'Fechado' END AS situacao, " +
                "caixa.valorAbertura, caixa.valorContadoFechamento, " +
                "(SELECT usuario.nomeUsuario FROM usuario WHERE usuario.idUsuario = caixa.idUsuarioFechamento) AS usuarioFechamento, " +
                "COALESCE((SELECT SUM(venda.valorTotal) FROM venda WHERE venda.idCaixa = caixa.idCaixa " +
                "AND venda.status = TRUE), 0) AS vendasValidas, " +
                "caixa.valorAbertura + COALESCE((SELECT SUM(CASE movimentacaoCaixa.tipo " +
                "WHEN 'Entrada' THEN movimentacaoCaixa.valor WHEN 'Saída' THEN -movimentacaoCaixa.valor ELSE 0 END) " +
                "FROM movimentacaoCaixa WHERE movimentacaoCaixa.idCaixa = caixa.idCaixa " +
                "AND movimentacaoCaixa.formaPagamento = 'Dinheiro'), 0) AS saldoDinheiro " +
                "FROM caixa INNER JOIN usuario ON usuario.idUsuario = caixa.idUsuarioAbertura " +
                "WHERE caixa.dataAbertura < @fim AND (caixa.dataFechamento IS NULL OR caixa.dataFechamento >= @inicio) " +
                "ORDER BY caixa.dataAbertura DESC, caixa.idCaixa DESC";

            const string sqlMovimentacoesCaixa =
                "SELECT movimentacaoCaixa.idMovimentacaoCaixa, movimentacaoCaixa.dataMovimentacao, " +
                "movimentacaoCaixa.idCaixa, movimentacaoCaixa.idVenda, usuario.nomeUsuario, " +
                "movimentacaoCaixa.tipo, movimentacaoCaixa.origem, movimentacaoCaixa.formaPagamento, " +
                "movimentacaoCaixa.descricao, movimentacaoCaixa.valor FROM movimentacaoCaixa " +
                "INNER JOIN usuario ON usuario.idUsuario = movimentacaoCaixa.idUsuario " +
                "WHERE movimentacaoCaixa.dataMovimentacao >= @inicio AND movimentacaoCaixa.dataMovimentacao < @fim " +
                "ORDER BY movimentacaoCaixa.dataMovimentacao DESC, movimentacaoCaixa.idMovimentacaoCaixa DESC";

            const string sqlMovimentacoesEstoque =
                "SELECT movimentacaoEstoque.idMovimentacaoEstoque, movimentacaoEstoque.dataMovimentacao, " +
                "produto.idProduto, produto.nomeProduto, produto.unidadeMedida, usuario.nomeUsuario, " +
                "movimentacaoEstoque.tipo, movimentacaoEstoque.quantidade, movimentacaoEstoque.motivo " +
                "FROM movimentacaoEstoque INNER JOIN produto ON produto.idProduto = movimentacaoEstoque.idProduto " +
                "INNER JOIN usuario ON usuario.idUsuario = movimentacaoEstoque.idUsuario " +
                "WHERE movimentacaoEstoque.dataMovimentacao >= @inicio AND movimentacaoEstoque.dataMovimentacao < @fim " +
                "ORDER BY movimentacaoEstoque.dataMovimentacao DESC, movimentacaoEstoque.idMovimentacaoEstoque DESC";

            using (var conexao = Conexao.ObterConexao())
            using (var transacao = conexao.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                var dados = new DataSet();
                dados.Tables.Add(LerTabela(sqlFaturamento, "Faturamento", inicio, fim, agruparPorMes, conexao, transacao));
                dados.Tables.Add(LerTabela(sqlCaixas, "Caixas", inicio, fim, agruparPorMes, conexao, transacao));
                dados.Tables.Add(LerTabela(sqlMovimentacoesCaixa, "MovimentacoesCaixa", inicio, fim, agruparPorMes, conexao, transacao));
                dados.Tables.Add(LerTabela(sqlMovimentacoesEstoque, "MovimentacoesEstoque", inicio, fim, agruparPorMes, conexao, transacao));
                transacao.Commit();
                return dados;
            }
        }

        private DataTable LerTabela(string sql, string nome, DateTime inicio, DateTime fim,
            bool agruparPorMes, MySqlConnection conexao, MySqlTransaction transacao)
        {
            using (var comando = new MySqlCommand(sql, conexao, transacao))
            {
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                comando.Parameters.AddWithValue("@agruparPorMes", agruparPorMes);
                using (var adaptador = new MySqlDataAdapter(comando))
                {
                    var tabela = new DataTable(nome);
                    adaptador.Fill(tabela);
                    return tabela;
                }
            }
        }
    }
}
