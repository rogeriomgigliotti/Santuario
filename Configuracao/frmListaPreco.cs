using Comuns.Classes;
using Comuns.Janelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configuracao
{
    public partial class frmListaPreco : Form
    {
        private decimal _CodigoEvento;
        private string _Evento;

        public frmListaPreco()
        {
            InitializeComponent();

            this.SelecionarEvento();
        }

        private void SelecionarEvento()
        {
            _CodigoEvento = Variaveis.CodigoEvento;
            _Evento = Variaveis.Evento;

            this.lblEvento.Text = "Lista de Preços - " + _Evento;

            this.CarregarListaPreco();
        }

        private void CarregarListaPreco()
        {
            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT P.CD_PRODUTO, ");
                            sql.AppendLine("        P.NM_PRODUTO, ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO, ");
                            sql.AppendLine("        EP.VL_PRODUTO ");
                            sql.AppendLine("   FROM PRODUTO P ");
                            sql.AppendLine("  INNER JOIN TIPOPRODUTO TP ON (TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) ");
                            sql.AppendLine($"   LEFT JOIN EVENTOPRODUTO EP ON (EP.CD_EVENTO = {_CodigoEvento} AND ");
                            sql.AppendLine("                                  EP.CD_PRODUTO = P.CD_PRODUTO) ");
                            sql.AppendLine("  ORDER BY CASE WHEN EP.CD_EVENTOPRODUTO IS NULL THEN 1 ");
                            sql.AppendLine("                ELSE 0 ");
                            sql.AppendLine("           END, ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO, ");
                            sql.AppendLine("        P.NM_PRODUTO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            var lstListaPreco = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new ListaPreco
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_PRODUTO"].ToString()),
                                    strNome = row["NM_PRODUTO"].ToString(),
                                    strTipo = row["DS_TIPOPRODUTO"].ToString(),
                                    decPreco = (row["VL_PRODUTO"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["VL_PRODUTO"].ToString()))
                                };
                            });

                            this.dgvListaPreco.DataSource = lstListaPreco.ToList();
                            this.dgvListaPreco.Columns["decCodigo"].Visible = false;
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

        private void btnEvento_Click(object sender, EventArgs e)
        {
            var fEventoSelecao = new frmEventoSelecao();
            if (fEventoSelecao.ShowDialog() == DialogResult.OK)
                SelecionarEvento();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conexao.Open();

                    using (var comando = conexao.CreateCommand())
                    {
                        var sql = new StringBuilder();
                        sql.AppendLine(" IF (@VL_PRODUTO IS NULL) ");
                        sql.AppendLine("  BEGIN ");
                        sql.AppendLine("    DELETE FROM EVENTOPRODUTO ");
                        sql.AppendLine("     WHERE CD_EVENTO = @CD_EVENTO ");
                        sql.AppendLine("       AND CD_PRODUTO = @CD_PRODUTO ");
                        sql.AppendLine("  END ");
                        sql.AppendLine(" ELSE ");
                        sql.AppendLine("  BEGIN ");
                        sql.AppendLine("    UPDATE EVENTOPRODUTO SET ");
                        sql.AppendLine("           VL_PRODUTO = @VL_PRODUTO ");
                        sql.AppendLine("     WHERE CD_EVENTO = @CD_EVENTO ");
                        sql.AppendLine("       AND CD_PRODUTO = @CD_PRODUTO ");
                        sql.AppendLine("     ");
                        sql.AppendLine("    IF (@@ROWCOUNT = 0) ");
                        sql.AppendLine("     BEGIN ");
                        sql.AppendLine("       INSERT INTO EVENTOPRODUTO ( ");
                        sql.AppendLine("              CD_EVENTO, ");
                        sql.AppendLine("              CD_PRODUTO, ");
                        sql.AppendLine("              VL_PRODUTO ");
                        sql.AppendLine("       ) VALUES ( ");
                        sql.AppendLine("              @CD_EVENTO, ");
                        sql.AppendLine("              @CD_PRODUTO, ");
                        sql.AppendLine("              @VL_PRODUTO ");
                        sql.AppendLine("       ) ");
                        sql.AppendLine("     END ");
                        sql.AppendLine("  END ");

                        comando.Parameters.AddWithValue("@CD_EVENTO", _CodigoEvento);
                        comando.Parameters.AddWithValue("@CD_PRODUTO", DBNull.Value);
                        comando.Parameters.AddWithValue("@VL_PRODUTO", DBNull.Value);

                        comando.CommandText = sql.ToString();

                        var lstListaPreco = (this.dgvListaPreco.DataSource as IEnumerable<ListaPreco>);

                        foreach (var preco in lstListaPreco)
                        {
                            comando.Parameters["@CD_PRODUTO"].Value = preco.decCodigo;
                            comando.Parameters["@VL_PRODUTO"].Value = (object)preco.decPreco ?? DBNull.Value;

                            comando.ExecuteNonQuery();
                        }
                    }

                    conexao.Close();
                }

                MessageBox.Show("Registro Salvo com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.CarregarListaPreco();
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }
    }

    public class ListaPreco
    {
        [DisplayName("Código")]
        public decimal decCodigo { get; set; }

        [DisplayName("Nome")]
        public string strNome { get; set; }

        [DisplayName("Tipo")]
        public string strTipo { get; set; }

        [DisplayName("Preço (R$)")]
        public decimal? decPreco { get; set; }
    }
}
