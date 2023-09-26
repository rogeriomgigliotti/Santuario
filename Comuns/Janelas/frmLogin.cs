using Comuns.Classes;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Comuns.Janelas
{
    public partial class frmLogin : Form
    {
        private readonly TipoUsuarioEnum _tipoUsuario;

        public frmLogin(TipoUsuarioEnum tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;

            InitializeComponent();

            if (_tipoUsuario == TipoUsuarioEnum.Administrador)
                this.lblAcesso.Text = "Acesso ao Sistema de Configurações";
            else if (_tipoUsuario == TipoUsuarioEnum.Vendas)
                this.lblAcesso.Text = "Acesso ao Sistema de Vendas";

            this.txtLogin.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var logou = false;

                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conexao.Open();

                    using (var comando = conexao.CreateCommand())
                    {
                        var sql = new StringBuilder();
                        sql.AppendLine(" SELECT CD_USUARIO, ");
                        sql.AppendLine("        NM_USUARIO ");
                        sql.AppendLine("   FROM USUARIO ");
                        sql.AppendLine($"  WHERE CD_TIPOUSUARIO = {(decimal)_tipoUsuario} ");
                        sql.AppendLine("    AND DS_LOGIN = @DS_LOGIN ");
                        sql.AppendLine("    AND DS_SENHA = @DS_SENHA ");

                        comando.CommandText = sql.ToString();
                        comando.Parameters.AddWithValue("@DS_LOGIN", txtLogin.Text);
                        comando.Parameters.AddWithValue("@DS_SENHA", txtSenha.Text);

                        using (var leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                Variaveis.CodigoUsuario = Convert.ToDecimal(leitor["CD_USUARIO"]);
                                Variaveis.NomeUsuario = Convert.ToString(leitor["NM_USUARIO"]);

                                logou = true;
                            }

                            leitor.Close();
                        }
                    }

                    conexao.Close();
                }

                if (logou)
                {
                    DialogResult = DialogResult.OK;
                    return;
                }

                MessageBox.Show("Credenciais inválidas!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public enum TipoUsuarioEnum
    {
        Administrador = 1,
        Vendas = 2
    }
}
