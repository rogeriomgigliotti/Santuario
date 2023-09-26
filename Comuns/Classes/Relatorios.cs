using Microsoft.Office.Interop.Excel;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Comuns.Classes
{
    public static class Relatorios
    {
        public static void Vendas(decimal codigoEvento, string evento)
        {
            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conexao.Open();

                    using (var da = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine($" SELECT '{evento}' AS \"Evento\", ");
                            sql.AppendLine("        P.NM_PRODUTO AS \"Nome Produto\", ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO AS \"Tipo Produto\", ");
                            sql.AppendLine("        SUM(V.QT_VENDA) AS \"Quantidade Venda\", ");
                            sql.AppendLine("        SUM(V.VL_VENDA) AS \"Valor Venda\", ");
                            sql.AppendLine("        COALESCE(E.QT_MOVIMENTO, 0) \"Quantidade Estorno\", ");
                            sql.AppendLine("        COALESCE(E.QT_MOVIMENTO * EP.VL_PRODUTO, 0) \"Valor Estorno\", ");
                            sql.AppendLine("        SUM(V.QT_VENDA) - COALESCE(E.QT_MOVIMENTO, 0) AS \"Quantidade Final\", ");
                            sql.AppendLine("        SUM(V.VL_VENDA) - COALESCE(E.QT_MOVIMENTO * EP.VL_PRODUTO, 0) AS \"Valor Final\" ");
                            sql.AppendLine("   FROM VENDA V ");
                            sql.AppendLine("  INNER JOIN EVENTOPRODUTO EP ON (EP.CD_EVENTOPRODUTO = V.CD_EVENTOPRODUTO) ");
                            sql.AppendLine("  INNER JOIN PRODUTO P ON (P.CD_PRODUTO = EP.CD_PRODUTO) ");
                            sql.AppendLine("  INNER JOIN TIPOPRODUTO TP ON (TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) ");
                            sql.AppendLine("   LEFT JOIN (SELECT CD_EVENTOPRODUTO, ");
                            sql.AppendLine("                     SUM(QT_MOVIMENTO) AS QT_MOVIMENTO ");
                            sql.AppendLine("                FROM ESTOQUE ");
                            sql.AppendLine("               WHERE CD_TIPOMOVIMENTOESTOQUE = 2 ");
                            sql.AppendLine("               GROUP BY CD_EVENTOPRODUTO) E ON (E.CD_EVENTOPRODUTO = V.CD_EVENTOPRODUTO) ");
                            sql.AppendLine($"  WHERE EP.CD_EVENTO = {codigoEvento} ");
                            sql.AppendLine("  GROUP BY P.NM_PRODUTO, TP.DS_TIPOPRODUTO, E.QT_MOVIMENTO, EP.VL_PRODUTO ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO, TP.DS_TIPOPRODUTO, E.QT_MOVIMENTO, EP.VL_PRODUTO ");

                            comando.CommandText = sql.ToString();
                            da.SelectCommand = comando;

                            var ds = new DataSet();
                            da.Fill(ds);

                            var dt = ds.Tables[0];

                            var app = new Application();
                            app.Visible = false;

                            var wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                            var ws = (Worksheet)wb.ActiveSheet;

                            for (int i = 0; i < dt.Columns.Count; i++)
                                ws.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                    ws.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                            }

                            wb.SaveAs($"{evento} - Vendas");
                            //wb.Close();

                            app.Visible = true;
                        }
                    }

                    conexao.Close();
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        public static void Estoque(decimal codigoEvento, string evento)
        {
            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conexao.Open();

                    using (var da = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine($" SELECT '{evento}' AS Evento, ");
                            sql.AppendLine("        P.NM_PRODUTO AS \"Nome Produto\", ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO AS \"Tipo Produto\", ");
                            sql.AppendLine("        TME.DS_TIPOMOVIMENTOESTOQUE AS \"Tipo Movimento\", ");
                            sql.AppendLine("        SUM(E.QT_MOVIMENTO) AS \"Quantidade Movimento\", ");
                            sql.AppendLine("        SUM(E.QT_MOVIMENTO * EP.VL_PRODUTO) AS \"Valor Movimento\" ");
                            sql.AppendLine("   FROM ESTOQUE E ");
                            sql.AppendLine("  INNER JOIN EVENTOPRODUTO EP ON (EP.CD_EVENTOPRODUTO = E.CD_EVENTOPRODUTO) ");
                            sql.AppendLine("  INNER JOIN PRODUTO P ON (P.CD_PRODUTO = EP.CD_PRODUTO) ");
                            sql.AppendLine("  INNER JOIN TIPOPRODUTO TP ON (TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) ");
                            sql.AppendLine("  INNER JOIN TIPOMOVIMENTOESTOQUE TME ON (TME.CD_TIPOMOVIMENTOESTOQUE = E.CD_TIPOMOVIMENTOESTOQUE) ");
                            sql.AppendLine($"  WHERE EP.CD_EVENTO = {codigoEvento} ");
                            sql.AppendLine("  GROUP BY P.NM_PRODUTO, TP.DS_TIPOPRODUTO, TME.DS_TIPOMOVIMENTOESTOQUE ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO, TP.DS_TIPOPRODUTO, TME.DS_TIPOMOVIMENTOESTOQUE ");

                            comando.CommandText = sql.ToString();
                            da.SelectCommand = comando;

                            var ds = new DataSet();
                            da.Fill(ds);

                            var dt = ds.Tables[0];

                            var app = new Application();
                            app.Visible = false;

                            var wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                            var ws = (Worksheet)wb.ActiveSheet;

                            for (int i = 0; i < dt.Columns.Count; i++)
                                ws.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                    ws.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                            }

                            wb.SaveAs($"{evento} - Estoque");
                            //wb.Close();

                            app.Visible = true;
                        }
                    }

                    conexao.Close();
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }
    }
}
