using Comuns.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comuns.Janelas
{
    public partial class frmEventoSelecao : Form
    {
        public frmEventoSelecao()
        {
            InitializeComponent();
            IEnumerable<EventoSelecao> lstEvento;

            try
            {
                using (SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT CD_EVENTO, ");
                            sql.AppendLine("        DS_EVENTO, ");
                            sql.AppendLine("        CONVERT(VARCHAR, DT_EVENTO, 103) AS DT_EVENTO ");
                            sql.AppendLine("   FROM EVENTO ");
                            sql.AppendLine("  ORDER BY DT_EVENTO DESC ");

                            comando.CommandText = sql.ToString();
                            da.SelectCommand = comando;

                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            lstEvento = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new EventoSelecao
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_EVENTO"].ToString()),
                                    strNome = row["DS_EVENTO"].ToString(),
                                    datData = row["DT_EVENTO"].ToString()
                                };
                            });
                        }

                        this.dgvEventos.DataSource = lstEvento.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEvento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < this.dgvEventos.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        Variaveis.CodigoEvento = Convert.ToDecimal(this.dgvEventos.Rows[i].Cells[1].Value);
                        Variaveis.Evento = this.dgvEventos.Rows[i].Cells[2].Value.ToString();
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
        }
    }

    public class EventoSelecao
    {
        [DisplayName("Código")]
        public decimal decCodigo { get; set; }

        [DisplayName("Nome")]
        public string strNome { get; set; }

        [DisplayName("Data")]
        public string datData { get; set; }
    }
}
