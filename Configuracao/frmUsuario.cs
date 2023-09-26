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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();

            EnableTab(tbcUsuario.TabPages[1], false);

            this.CarregarUsuario();
            this.CarregarTipoUsuario();
        }

        private void CarregarUsuario()
        {
            IEnumerable<Usuario> lstUsuario;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT U.CD_USUARIO, ");
                            sql.AppendLine("        U.NM_USUARIO, ");
                            sql.AppendLine("        (SELECT TU.DS_TIPOUSUARIO ");
                            sql.AppendLine("           FROM TIPOUSUARIO TU ");
                            sql.AppendLine("          WHERE TU.CD_TIPOUSUARIO = U.CD_TIPOUSUARIO) AS DS_TIPOUSUARIO, ");
                            sql.AppendLine("        U.DS_LOGIN, ");
                            sql.AppendLine("        U.DS_SENHA, ");
                            sql.AppendLine("        CASE U.ATIVO WHEN 1 THEN 'Sim' ");
                            sql.AppendLine("             ELSE 'Não' ");
                            sql.AppendLine("        END AS ATIVO ");
                            sql.AppendLine("   FROM USUARIO U ");
                            sql.AppendLine("  ORDER BY U.NM_USUARIO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstUsuario = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new Usuario
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_USUARIO"].ToString()),
                                    strNome = row["NM_USUARIO"].ToString(),
                                    strTipo = row["DS_TIPOUSUARIO"].ToString(),
                                    strLogin = row["DS_LOGIN"].ToString(),
                                    strSenha = row["DS_SENHA"].ToString(),
                                    strAtivo = row["ATIVO"].ToString(),
                                };
                            });
                        }

                        this.dgvUsuario.DataSource = lstUsuario.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void CarregarTipoUsuario()
        {
            IEnumerable<TipoUsuario> lstTipoUsuario;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT CD_TIPOUSUARIO, ");
                            sql.AppendLine("        DS_TIPOUSUARIO ");
                            sql.AppendLine("   FROM TIPOUSUARIO ");
                            sql.AppendLine("  ORDER BY DS_TIPOUSUARIO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstTipoUsuario = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new TipoUsuario
                                {
                                    decCodigoTipoUsuario = Convert.ToDecimal(row["CD_TIPOUSUARIO"].ToString()),
                                    strDescricaoTipoUsuario = row["DS_TIPOUSUARIO"].ToString(),
                                };
                            });
                        }
                    }
                }

                this.cmbTipo.DataSource = lstTipoUsuario.ToList();
                this.cmbTipo.ValueMember = "decCodigoTipoUsuario";
                this.cmbTipo.DisplayMember = "strDescricaoTipoUsuario";
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
            this.txtLogin.Text = String.Empty;
            this.txtSenha.Text = String.Empty;
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
            tbcUsuario.SelectedIndex = 1;

            ClearControls();
            EnableTab(tbcUsuario.TabPages[1], true);
            this.btnExcluir.Enabled = false;

            this.dgvUsuario.Enabled =
                this.btnNovo.Enabled = false;

            this.txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EnableTab(tbcUsuario.TabPages[1], false);
            tbcUsuario.SelectedIndex = 0;

            this.dgvUsuario.Enabled =
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
                            stb.Append("DELETE FROM USUARIO WHERE CD_USUARIO = " + this.txtCodigo.Text);

                            comando.CommandText = stb.ToString();

                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbcUsuario.SelectedIndex = 0;

                    this.CarregarUsuario();

                    EnableTab(tbcUsuario.TabPages[1], false);

                    this.dgvUsuario.Enabled =
                        this.btnNovo.Enabled = true;
                }
                catch (Exception ex)
                {
                    Mensagens.ExibirErro(ex);
                }
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                    return;

                for (int i = 0; i < this.dgvUsuario.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        this.txtCodigo.Text = this.dgvUsuario.Rows[i].Cells[1].Value.ToString();
                        this.txtNome.Text = this.dgvUsuario.Rows[i].Cells[2].Value.ToString();
                        this.cmbTipo.SelectedIndex = this.cmbTipo.FindStringExact(this.dgvUsuario.Rows[i].Cells[3].Value.ToString());
                        this.txtLogin.Text = this.dgvUsuario.Rows[i].Cells[4].Value.ToString();
                        this.txtSenha.Text = this.dgvUsuario.Rows[i].Cells[5].Value.ToString();
                        this.ckbAtivo.Checked = (this.dgvUsuario.Rows[i].Cells[6].Value.ToString() == "Sim");
                    }
                }

                tbcUsuario.SelectedIndex = 1;

                EnableTab(tbcUsuario.TabPages[1], true);

                this.dgvUsuario.Enabled =
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
                            sql.Append("INSERT INTO USUARIO (NM_USUARIO, CD_TIPOUSUARIO, DS_LOGIN, DS_SENHA, ATIVO) VALUES ");
                            sql.Append("('" + this.txtNome.Text + "'");
                            sql.Append("," + this.cmbTipo.SelectedValue);
                            sql.Append(",'" + this.txtLogin.Text + "'");
                            sql.Append(",'" + this.txtSenha.Text + "'");
                            sql.Append("," + (this.ckbAtivo.Checked ? "1" : "0") + ")");
                        }
                        else
                        {
                            sql.Append("UPDATE USUARIO SET NM_USUARIO = '" + this.txtNome.Text + "',");
                            sql.Append("                   CD_TIPOUSUARIO = " + this.cmbTipo.SelectedValue + ",");
                            sql.Append("                   DS_LOGIN = '" + this.txtLogin.Text + "',");
                            sql.Append("                   DS_SENHA = '" + this.txtSenha.Text + "',");
                            sql.Append("                   ATIVO = " + (this.ckbAtivo.Checked ? "1" : "0"));
                            sql.Append(" WHERE CD_USUARIO = " + this.txtCodigo.Text);
                        }

                        comando.CommandText = sql.ToString();

                        comando.ExecuteNonQuery();
                    }

                    conexao.Close();
                }

                EnableTab(tbcUsuario.TabPages[1], false);

                this.dgvUsuario.Enabled =
                    this.btnNovo.Enabled = true;

                MessageBox.Show("Registro Salvo com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbcUsuario.SelectedIndex = 0;

                this.CarregarUsuario();
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }
    }

    public class Usuario
    {
        [DisplayName("Código")]
        public decimal decCodigo { get; set; }

        [DisplayName("Nome")]
        public string strNome { get; set; }

        [DisplayName("Tipo")]
        public string strTipo { get; set; }

        [DisplayName("Login")]
        public string strLogin { get; set; }

        [DisplayName("Senha")]
        public string strSenha { get; set; }

        [DisplayName("Ativo")]
        public string strAtivo { get; set; }
    }

    public class TipoUsuario
    {
        public decimal decCodigoTipoUsuario { get; set; }
        public string strDescricaoTipoUsuario { get; set; }
    }
}
