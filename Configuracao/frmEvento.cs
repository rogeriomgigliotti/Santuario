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

namespace Configuracao
{
    public partial class frmEvento : Form
    {
        public frmEvento()
        {
            InitializeComponent();

            EnableTab(tbcEvento.TabPages[1], false);

            this.CarregarEvento();
        }

        private void CarregarEvento()
        {
            IEnumerable<Evento> lstEvento;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine("SELECT CD_EVENTO,");
                            sql.AppendLine("       DS_EVENTO,");
                            sql.AppendLine("       CONVERT(VARCHAR, DT_EVENTO, 103) AS DATAEVENTO");
                            sql.AppendLine("  FROM EVENTO");
                            sql.AppendLine(" ORDER BY DT_EVENTO DESC");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstEvento = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new Evento
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_EVENTO"].ToString()),
                                    strNome = row["DS_EVENTO"].ToString(),
                                    datData = row["DATAEVENTO"].ToString()
                                };
                            });
                        }

                        this.dgvEvento.DataSource = lstEvento.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void ClearControls()
        {
            this.txtCodigo.Text = String.Empty;
            this.txtNome.Text = String.Empty;
            this.txtData.Text = String.Empty;
        }

        private void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }

        private void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbcEvento.SelectedIndex = 1;

            ClearControls();
            EnableTab(tbcEvento.TabPages[1], true);
            this.btnExcluir.Enabled = false;

            this.dgvEvento.Enabled =
                this.btnNovo.Enabled = false;

            this.txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EnableTab(tbcEvento.TabPages[1], false);
            tbcEvento.SelectedIndex = 0;

            this.dgvEvento.Enabled =
                this.btnNovo.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        conexao.Open();

                        StringBuilder stb = new StringBuilder();

                        using (SqlCommand comando = conexao.CreateCommand())
                        {
                            stb.Append("DELETE FROM EVENTO WHERE CD_EVENTO = " + this.txtCodigo.Text);

                            comando.CommandText = stb.ToString();

                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbcEvento.SelectedIndex = 0;

                    this.CarregarEvento();

                    EnableTab(tbcEvento.TabPages[1], false);

                    this.dgvEvento.Enabled =
                        this.btnNovo.Enabled = true;
                }
                catch (Exception ex)
                {
                    Mensagens.ExibirErro(ex);
                }
            }
        }

        private void dgvEvento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                    return;

                for (int i = 0; i < this.dgvEvento.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        this.txtCodigo.Text = this.dgvEvento.Rows[i].Cells[1].Value.ToString();
                        this.txtNome.Text = this.dgvEvento.Rows[i].Cells[2].Value.ToString();
                        this.txtData.Text = this.dgvEvento.Rows[i].Cells[3].Value.ToString();
                    }
                }

                tbcEvento.SelectedIndex = 1;

                EnableTab(tbcEvento.TabPages[1], true);

                this.dgvEvento.Enabled =
                    this.btnNovo.Enabled = false;

                this.txtNome.Focus();
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
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

                        if (this.txtCodigo.Text == string.Empty)
                        {
                            sql.Append("INSERT INTO EVENTO (DS_EVENTO, DT_EVENTO) VALUES ");
                            sql.Append("( '" + this.txtNome.Text + "'");
                            sql.Append(", CONVERT(DATETIME, '" + this.txtData.Value + "', 103))");
                        }
                        else
                        {
                            sql.Append("UPDATE EVENTO SET DS_EVENTO = '" + this.txtNome.Text + "',");
                            sql.Append("                  DT_EVENTO = CONVERT(DATETIME, '" + this.txtData.Value + "', 103)");
                            sql.Append(" WHERE CD_EVENTO = " + this.txtCodigo.Text);
                        }

                        comando.CommandText = sql.ToString();

                        comando.ExecuteNonQuery();
                    }

                    conexao.Close();
                }

                EnableTab(tbcEvento.TabPages[1], false);

                this.dgvEvento.Enabled =
                    this.btnNovo.Enabled = true;

                MessageBox.Show("Registro Salvo com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbcEvento.SelectedIndex = 0;

                this.CarregarEvento();
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }
    }

    public class Evento
    {
        [DisplayName("Código")]
        public decimal decCodigo { get; set; }

        [DisplayName("Nome")]
        public string strNome { get; set; }

        [DisplayName("Data")]
        public string datData { get; set; }
    }
}
