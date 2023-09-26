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
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();

            EnableTab(tbcProduto.TabPages[1], false);

            this.CarregarProduto();
            this.CarregarTipoProduto();
        }

        private void CarregarProduto()
        {
            IEnumerable<Produto> lstProduto;

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
                            sql.AppendLine("        (SELECT TP.DS_TIPOPRODUTO ");
                            sql.AppendLine("           FROM TIPOPRODUTO TP ");
                            sql.AppendLine("          WHERE TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) AS DS_TIPOPRODUTO, ");
                            sql.AppendLine("        CASE P.ATIVO WHEN 1 THEN 'Sim' ");
                            sql.AppendLine("             ELSE 'Não' ");
                            sql.AppendLine("        END ATIVO ");
                            sql.AppendLine("   FROM PRODUTO P ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstProduto = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new Produto
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_PRODUTO"].ToString()),
                                    strNome = row["NM_PRODUTO"].ToString(),
                                    strTipo = row["DS_TIPOPRODUTO"].ToString(),
                                    strAtivo = row["ATIVO"].ToString(),
                                };
                            });
                        }

                        this.dgvProduto.DataSource = lstProduto.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void CarregarTipoProduto()
        {
            IEnumerable<TipoProduto> lstTipoProduto;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT CD_TIPOPRODUTO, ");
                            sql.AppendLine("        DS_TIPOPRODUTO ");
                            sql.AppendLine("   FROM TIPOPRODUTO ");
                            sql.AppendLine("  ORDER BY DS_TIPOPRODUTO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstTipoProduto = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new TipoProduto
                                {
                                    decCodigoTipoProduto = Convert.ToDecimal(row["CD_TIPOPRODUTO"].ToString()),
                                    strDescricaoTipoProduto = row["DS_TIPOPRODUTO"].ToString(),
                                };
                            });
                        }
                    }
                }

                this.cmbTipo.DataSource = lstTipoProduto.ToList();
                this.cmbTipo.ValueMember = "decCodigoTipoProduto";
                this.cmbTipo.DisplayMember = "strDescricaoTipoProduto";
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
            this.cmbTipo.SelectedIndex = -1;
            this.ckbAtivo.Checked = true;
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
            tbcProduto.SelectedIndex = 1;

            ClearControls();
            EnableTab(tbcProduto.TabPages[1], true);
            this.btnExcluir.Enabled = false;

            this.dgvProduto.Enabled =
                this.btnNovo.Enabled = false;

            this.txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EnableTab(tbcProduto.TabPages[1], false);
            tbcProduto.SelectedIndex = 0;

            this.dgvProduto.Enabled =
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
                            stb.Append("DELETE FROM PRODUTO WHERE CD_PRODUTO = " + this.txtCodigo.Text);

                            comando.CommandText = stb.ToString();

                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbcProduto.SelectedIndex = 0;

                    this.CarregarProduto();

                    EnableTab(tbcProduto.TabPages[1], false);

                    this.dgvProduto.Enabled =
                        this.btnNovo.Enabled = true;
                }
                catch (Exception ex)
                {
                    Mensagens.ExibirErro(ex);
                }
            }
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                    return;

                for (int i = 0; i < this.dgvProduto.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        this.txtCodigo.Text = this.dgvProduto.Rows[i].Cells[1].Value.ToString();
                        this.txtNome.Text = this.dgvProduto.Rows[i].Cells[2].Value.ToString();
                        this.cmbTipo.SelectedIndex = this.cmbTipo.FindStringExact(this.dgvProduto.Rows[i].Cells[3].Value.ToString());
                        this.ckbAtivo.Checked = (this.dgvProduto.Rows[i].Cells[4].Value.ToString() == "Sim");
                    }
                }

                tbcProduto.SelectedIndex = 1;

                EnableTab(tbcProduto.TabPages[1], true);

                this.dgvProduto.Enabled =
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

                    using (SqlCommand comando = conexao.CreateCommand())
                    {
                        var sql = new StringBuilder();

                        if (this.txtCodigo.Text == string.Empty)
                        {
                            sql.Append("INSERT INTO PRODUTO (NM_PRODUTO, CD_TIPOPRODUTO, ATIVO) VALUES ");
                            sql.Append("( '" + this.txtNome.Text + "'");
                            sql.Append("," + this.cmbTipo.SelectedValue);
                            sql.Append("," + (this.ckbAtivo.Checked ? "1" : "0") + ")");
                        }
                        else
                        {
                            sql.Append("UPDATE PRODUTO SET NM_PRODUTO = '" + this.txtNome.Text + "',");
                            sql.Append("                   CD_TIPOPRODUTO = " + this.cmbTipo.SelectedValue + ",");
                            sql.Append("                   ATIVO = " + (this.ckbAtivo.Checked ? "1" : "0"));
                            sql.Append(" WHERE CD_PRODUTO = " + this.txtCodigo.Text);
                        }

                        comando.CommandText = sql.ToString();

                        comando.ExecuteNonQuery();
                    }

                    conexao.Close();
                }

                EnableTab(tbcProduto.TabPages[1], false);

                this.dgvProduto.Enabled =
                    this.btnNovo.Enabled = true;

                MessageBox.Show("Registro Salvo com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbcProduto.SelectedIndex = 0;

                this.CarregarProduto();
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }
    }

    public class Produto
    {
        [DisplayName("Código")]
        public decimal decCodigo { get; set; }

        [DisplayName("Nome")]
        public string strNome { get; set; }

        [DisplayName("Tipo")]
        public string strTipo { get; set; }

        [DisplayName("Ativo")]
        public string strAtivo { get; set; }
    }

    public class TipoProduto
    {
        public decimal decCodigoTipoProduto { get; set; }
        public string strDescricaoTipoProduto { get; set; }
    }
}
