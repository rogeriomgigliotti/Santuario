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
    public partial class frmEstoque : Form
    {
        private decimal _CodigoEvento;
        private string _Evento;

        public frmEstoque()
        {
            InitializeComponent();

            this.SelecionarEvento();
            this.CarregarProduto();
            this.CarregarTipoMovimento();
        }

        private void frmEstoque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                btnConfirmar_Click(null, null);
                e.Handled = true;
            }
        }

        private void SelecionarEvento()
        {
            _CodigoEvento = Variaveis.CodigoEvento;
            _Evento = Variaveis.Evento;

            this.lblEvento.Text = "Movimentos de Estoque - " + _Evento;

            this.CarregarEstoque();
        }

        private void CarregarProduto()
        {
            try
            {
                IEnumerable<EventoProduto> listEventoProduto;

                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT EP.CD_EVENTOPRODUTO, ");
                            sql.AppendLine("        P.NM_PRODUTO ");
                            sql.AppendLine("   FROM EVENTOPRODUTO EP ");
                            sql.AppendLine("  INNER JOIN PRODUTO P ON (P.CD_PRODUTO = EP.CD_PRODUTO) ");
                            sql.AppendLine($"  WHERE EP.CD_EVENTO = {_CodigoEvento} ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            listEventoProduto = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new EventoProduto
                                {
                                    decCodigo = Convert.ToDecimal(row["CD_EVENTOPRODUTO"].ToString()),
                                    strNome = row["NM_PRODUTO"].ToString(),
                                };
                            });
                        }
                    }
                }

                this.cmbProduto.DataSource = listEventoProduto.ToList();
                this.cmbProduto.ValueMember = "decCodigo";
                this.cmbProduto.DisplayMember = "strNome";
                this.cmbProduto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void CarregarTipoMovimento()
        {
            IEnumerable<TipoMovimento> lstTipoMovimento;

            try
            {
                using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.AppendLine(" SELECT CD_TIPOMOVIMENTOESTOQUE, ");
                            sql.AppendLine("        DS_TIPOMOVIMENTOESTOQUE ");
                            sql.AppendLine("   FROM TIPOMOVIMENTOESTOQUE ");
                            sql.AppendLine("  ORDER BY DS_TIPOMOVIMENTOESTOQUE ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            lstTipoMovimento = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new TipoMovimento
                                {
                                    decCodigoTipoMovimento = Convert.ToDecimal(row["CD_TIPOMOVIMENTOESTOQUE"].ToString()),
                                    strDescricaoTipoMovimento = row["DS_TIPOMOVIMENTOESTOQUE"].ToString(),
                                };
                            });
                        }
                    }
                }

                this.cmbTipoMovimento.DataSource = lstTipoMovimento.ToList();
                this.cmbTipoMovimento.ValueMember = "decCodigoTipoMovimento";
                this.cmbTipoMovimento.DisplayMember = "strDescricaoTipoMovimento";
                this.cmbTipoMovimento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void CarregarEstoque()
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
                            sql.AppendLine(" SELECT P.NM_PRODUTO, ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO, ");
                            sql.AppendLine("        E.DT_MOVIMENTO, ");
                            sql.AppendLine("        U.NM_USUARIO, ");
                            sql.AppendLine("        TME.DS_TIPOMOVIMENTOESTOQUE, ");
                            sql.AppendLine("        E.QT_MOVIMENTO ");
                            sql.AppendLine("   FROM EVENTOPRODUTO EP ");
                            sql.AppendLine("  INNER JOIN PRODUTO P ON (P.CD_PRODUTO = EP.CD_PRODUTO) ");
                            sql.AppendLine("  INNER JOIN TIPOPRODUTO TP ON (TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) ");
                            sql.AppendLine("  INNER JOIN ESTOQUE E ON (E.CD_EVENTOPRODUTO = EP.CD_EVENTOPRODUTO) ");
                            sql.AppendLine("  INNER JOIN USUARIO U ON (U.CD_USUARIO = E.CD_USUARIO) ");
                            sql.AppendLine("  INNER JOIN TIPOMOVIMENTOESTOQUE TME ON (TME.CD_TIPOMOVIMENTOESTOQUE = E.CD_TIPOMOVIMENTOESTOQUE) ");
                            sql.AppendLine($"  WHERE EP.CD_EVENTO = {_CodigoEvento} ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO, ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO ");

                            comando.CommandText = sql.ToString();
                            adaptador.SelectCommand = comando;

                            var ds = new DataSet();
                            adaptador.Fill(ds);

                            var lstEstoque = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new Estoque
                                {
                                    strProduto = row["NM_PRODUTO"].ToString(),
                                    strTipo = row["DS_TIPOPRODUTO"].ToString(),
                                    strMovimento = row["DS_TIPOMOVIMENTOESTOQUE"].ToString(),
                                    decQuantidade = Convert.ToDecimal(row["QT_MOVIMENTO"].ToString()),
                                    strUsuario = row["NM_USUARIO"].ToString(),
                                    dtDataMovimento = Convert.ToDateTime(row["DT_MOVIMENTO"].ToString())
                                };
                            });

                            this.dgvEstoque.DataSource = lstEstoque.ToList();
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente realizar a movimentação de estoque?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        conexao.Open();

                        using (var comando = conexao.CreateCommand())
                        {
                            var sql = new StringBuilder();
                            sql.Append("INSERT INTO ESTOQUE (CD_EVENTOPRODUTO, CD_USUARIO, CD_TIPOMOVIMENTOESTOQUE, DT_MOVIMENTO, QT_MOVIMENTO) VALUES ");
                            sql.Append("( " + this.cmbProduto.SelectedValue);
                            sql.Append("," + Variaveis.CodigoUsuario);
                            sql.Append("," + this.cmbTipoMovimento.SelectedValue);
                            sql.Append(",GETDATE()");
                            sql.Append("," + this.txtQuantidade.Text + ")");

                            comando.CommandText = sql.ToString();

                            comando.ExecuteNonQuery();
                        }

                        conexao.Close();
                    }

                    MessageBox.Show("Movimentação de Estoque Realizada com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.cmbProduto.SelectedIndex =
                        this.cmbTipoMovimento.SelectedIndex = -1;

                    this.txtQuantidade.Text = string.Empty;

                    CarregarEstoque();
                }
                catch (Exception ex)
                {
                    Mensagens.ExibirErro(ex);
                }
            }
        }
    }

    public class EventoProduto
    {
        public decimal decCodigo { get; set; }
        public string strNome { get; set; }
    }

    public class TipoMovimento
    {
        public decimal decCodigoTipoMovimento { get; set; }
        public string strDescricaoTipoMovimento { get; set; }
    }

    public class Estoque
    {
        [DisplayName("Produto")]
        public string strProduto { get; set; }

        [DisplayName("Tipo")]
        public string strTipo { get; set; }

        [DisplayName("Movimento")]
        public string strMovimento { get; set; }

        [DisplayName("Quantidade")]
        public decimal decQuantidade { get; set; }

        [DisplayName("Usuário")]
        public string strUsuario { get; set; }

        [DisplayName("Data")]
        public DateTime dtDataMovimento { get; set; }
    }
}
