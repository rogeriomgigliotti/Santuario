using Comuns.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace Vendas
{
    public partial class frmVenda : Form
    {
        private IEnumerable<Itens> _lstItens;
        private List<Itens> _lstVendas;
        private Font _font;

        public frmVenda()
        {
            this._lstVendas = new List<Itens>();
            this._font = new Font("Arial", 10);

            InitializeComponent();

            this.lblEvento.Text = "Vendas - " + Variaveis.Evento;

            CarregarProduto();
        }

        private void frmVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnAdicionar_Click(null, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnConfirmar_Click(null, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnCancelar_Click(null, null);
                e.Handled = true;
            }
        }

        private void CarregarProduto()
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
                            sql.AppendLine(" SELECT EP.CD_PRODUTO, ");
                            sql.AppendLine("        P.NM_PRODUTO, ");
                            sql.AppendLine("        TP.DS_TIPOPRODUTO, ");
                            sql.AppendLine("        EP.VL_PRODUTO ");
                            sql.AppendLine("   FROM EVENTOPRODUTO EP ");
                            sql.AppendLine("  INNER JOIN PRODUTO P ON (P.CD_PRODUTO = EP.CD_PRODUTO) ");
                            sql.AppendLine("  INNER JOIN TIPOPRODUTO TP ON (TP.CD_TIPOPRODUTO = P.CD_TIPOPRODUTO) ");
                            sql.AppendLine($"  WHERE EP.CD_EVENTO = {Variaveis.CodigoEvento} ");
                            sql.AppendLine("  ORDER BY P.NM_PRODUTO ");

                            comando.CommandText = sql.ToString();
                            da.SelectCommand = comando;

                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            _lstItens = ds.Tables[0].AsEnumerable().Select(row =>
                            {
                                return new Itens
                                {
                                    decProduto = Convert.ToDecimal(row["CD_PRODUTO"].ToString()),
                                    strProduto = row["NM_PRODUTO"].ToString(),
                                    strTipoProduto = row["DS_TIPOPRODUTO"].ToString(),
                                    dblValor = Convert.ToDouble(row["VL_PRODUTO"].ToString())
                                };
                            });
                        }

                    }

                    conexao.Close();
                }

                this.cmbItem.DataSource = _lstItens.ToList();
                this.cmbItem.ValueMember = "decProduto";
                this.cmbItem.DisplayMember = "strProduto";
                this.cmbItem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                    return;

                var decProduto = Convert.ToDecimal(this.txtCodigo.Text);

                var item = (from i in _lstItens
                            where i.decProduto == decProduto
                            select i).FirstOrDefault();

                if (item == null)
                {
                    MessageBox.Show("Produto não encontrado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCodigo.Focus();

                    return;
                }

                this.cmbItem.SelectedIndex = this.cmbItem.FindStringExact(item.strProduto);
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (this.txtQuantidade.Text == "")
            {
                MessageBox.Show("Informe a Quantidade!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtQuantidade.Focus();
                return;
            }

            if (this.txtQuantidade.Text == "0")
            {
                MessageBox.Show("Quantidade não pode ser igual a zero!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtQuantidade.Focus();
                return;
            }

            var decProduto = Convert.ToDecimal(cmbItem.SelectedValue);

            if (_lstVendas.Any(a => a.decProduto == decProduto))
            {
                MessageBox.Show("Esse produto já está adicionado ao pedido.\nCaso queira alterar, remova o produto e adicione novamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = _lstItens.FirstOrDefault(f => f.decProduto == decProduto);
            item.intQtde = Convert.ToInt32(this.txtQuantidade.Text);
            item.dblTotal = item.dblValor * item.intQtde;

            _lstVendas.Add(item);

            this.dgvVendas.DataSource = _lstVendas.ToList();

            LimparCampos(false);
        }

        private void dgvVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    for (int i = 0; i < this.dgvVendas.Rows.Count; i++)
                    {
                        if (e.RowIndex == i)
                        {
                            var decProduto = Convert.ToDecimal(this.dgvVendas.Rows[i].Cells[1].Value);

                            _lstVendas = (from item in _lstVendas
                                          where item.decProduto != decProduto
                                          select item).ToList();

                            this.dgvVendas.DataSource = _lstVendas;

                            LimparCampos(false);
                            break;
                        }
                    }
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVendas.RowCount == 0)
                {
                    MessageBox.Show("Nenhum item selecionado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Confirmar o pedido?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (var transacao = new TransactionScope())
                    {
                        using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                        {
                            conexao.Open();

                            using (var comando = conexao.CreateCommand())
                            {
                                for (int i = 0; i < this.dgvVendas.Rows.Count; i++)
                                {
                                    var sql = new StringBuilder();
                                    sql.AppendLine(" INSERT INTO VENDA (CD_EVENTOPRODUTO, CD_USUARIO, DT_VENDA, QT_VENDA, VL_VENDA) ");
                                    sql.AppendLine(" SELECT CD_EVENTOPRODUTO, ");
                                    sql.AppendLine($"        {Variaveis.CodigoUsuario} AS CD_USUARIO, ");
                                    sql.AppendLine("        GETDATE() AS DT_VENDA, ");
                                    sql.AppendLine($"        {this.dgvVendas.Rows[i].Cells[5].Value} AS QT_VENDA, ");
                                    sql.AppendLine($"        {this.dgvVendas.Rows[i].Cells[6].Value.ToString().Replace(".", "").Replace(",", ".")} AS VL_VENDA ");
                                    sql.AppendLine("   FROM EVENTOPRODUTO ");
                                    sql.AppendLine($"  WHERE CD_EVENTO = {Variaveis.CodigoEvento} ");
                                    sql.AppendLine($"    AND CD_PRODUTO = {this.dgvVendas.Rows[i].Cells[1].Value} ");

                                    comando.CommandText = sql.ToString();
                                    comando.ExecuteNonQuery();

                                    sql.Clear();
                                    sql.AppendLine(" SELECT COALESCE(SUM(T.ESTOQUE), 0) - COALESCE(SUM(T.VENDA), 0) AS SALDOFINAL ");
                                    sql.AppendLine("   FROM (SELECT SUM(E.QT_MOVIMENTO * CASE E.CD_TIPOMOVIMENTOESTOQUE ");
                                    sql.AppendLine("                                          WHEN 1 THEN 1  -- Entrada ");
                                    sql.AppendLine("                                          WHEN 2 THEN -1 -- Estorno ");
                                    sql.AppendLine("                                     END) AS ESTOQUE, ");
                                    sql.AppendLine("                0 AS VENDA ");
                                    sql.AppendLine("           FROM EVENTOPRODUTO EP ");
                                    sql.AppendLine("          INNER JOIN ESTOQUE E ON (E.CD_EVENTOPRODUTO = EP.CD_EVENTOPRODUTO) ");
                                    sql.AppendLine($"          WHERE EP.CD_EVENTO = {Variaveis.CodigoEvento} ");
                                    sql.AppendLine($"            AND EP.CD_PRODUTO = {this.dgvVendas.Rows[i].Cells[1].Value} ");
                                    sql.AppendLine("          UNION ALL ");
                                    sql.AppendLine("         SELECT 0 AS ESTOQUE, ");
                                    sql.AppendLine("                V.QT_VENDA AS VENDA ");
                                    sql.AppendLine("           FROM EVENTOPRODUTO EP ");
                                    sql.AppendLine("          INNER JOIN VENDA V ON (V.CD_EVENTOPRODUTO = EP.CD_EVENTOPRODUTO) ");
                                    sql.AppendLine($"          WHERE EP.CD_EVENTO = {Variaveis.CodigoEvento} ");
                                    sql.AppendLine($"            AND EP.CD_PRODUTO = {this.dgvVendas.Rows[i].Cells[1].Value} ");
                                    sql.AppendLine("        ) T ");

                                    comando.CommandText = sql.ToString();
                                    var saldoFinal = Convert.ToDecimal(comando.ExecuteScalar());

                                    if (saldoFinal < 0)
                                    {
                                        var saldoDisponivel = saldoFinal + Convert.ToDecimal(this.dgvVendas.Rows[i].Cells[5].Value);

                                        throw new Exception($"O saldo disponível em estoque do produto \"{this.dgvVendas.Rows[i].Cells[2].Value}\" é {saldoDisponivel} unidade(s).\nRemova este item do pedido e se for o caso, ajuste a quantidade antes de confirmar.");
                                    }
                                }
                            }

                            conexao.Close();
                        }

                        transacao.Complete();
                    }

                    for (int i = 0; i < this.dgvVendas.Rows.Count; i++)
                    {
                        for (int j = 1; j <= Convert.ToDecimal(this.dgvVendas.Rows[i].Cells[5].Value); j++)
                        {
                            var textoParaImpressao = new string[10];
                            textoParaImpressao[0] = "**  Paróquia Nossa Senhora Aparecida  **";
                            textoParaImpressao[1] = " ";
                            textoParaImpressao[2] = " Data: " + DateTime.Now.ToString();
                            textoParaImpressao[3] = " ";
                            textoParaImpressao[4] = " Ficha valendo 1: " + this.dgvVendas.Rows[i].Cells[2].Value.ToString();
                            textoParaImpressao[5] = " ";
                            textoParaImpressao[6] = " Obrigado!!!";

                            var doc = new ImprimirDocumento(textoParaImpressao);
                            doc.PrintPage += this.pd_PrintPageBebida;
                            doc.Print();
                        }
                    }

                    LimparCampos(true);
                }
            }
            catch (Exception ex)
            {
                Mensagens.ExibirErro(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente CANCELAR o pedido?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                LimparCampos(true);
        }

        private void AtualizarTotal()
        {
            if (_lstVendas.Any())
            {
                var dblTotal = _lstVendas.Sum(s => s.dblTotal);

                this.lblTotal.Text = "Valor Total (R$): " + dblTotal.ToString("n2");
            }
            else
                this.lblTotal.Text = "Valor Total (R$):";
        }

        private void LimparCampos(bool limparVendas)
        {
            this.txtCodigo.Text = string.Empty;
            this.cmbItem.SelectedIndex = -1;
            this.txtQuantidade.Text = string.Empty;

            if (limparVendas)
            {
                _lstVendas = new List<Itens>();

                this.dgvVendas.DataSource = _lstVendas.ToList();
            }

            AtualizarTotal();

            this.txtCodigo.Focus();
        }

        private void pd_PrintPageBebida(object sender, PrintPageEventArgs e)
        {
            float linhasPorPagina;
            float PosicaoY = 0;
            int count = 0;
            float MargemEsquerda = e.MarginBounds.Left;
            float MargemTopo = 25; //e.MarginBounds.Top;
            string Linha = null;

            ImprimirDocumento doc = (ImprimirDocumento)sender;

            // Define a fonte e determina a altura da linha
            using (Font fonte = new Font("Verdana", 10))
            {
                float alturaLinha = fonte.GetHeight(e.Graphics);

                // Cria as variáveis para tratar a posição na página
                //float x = e.MarginBounds.Left;
                //float y = 25;// e.MarginBounds.Top;

                // Incrementa o contador de página para refletir 
                // a página que esta sendo impressa
                doc.NumeroPagina += 1;

                linhasPorPagina = e.MarginBounds.Height / _font.GetHeight(e.Graphics);

                while (count < linhasPorPagina && ((Linha = doc.Texto[count]) != null))
                {
                    PosicaoY = MargemTopo + (count * _font.GetHeight(e.Graphics));
                    e.Graphics.DrawString(Linha, _font, Brushes.Black, 0, PosicaoY, new StringFormat());

                    if (Linha == " Obrigado!!!")
                        break;

                    count++;
                }
            }
        }

        private void pd_PrintPageComida(object sender, PrintPageEventArgs e)
        {
            float linhasPorPagina;
            float PosicaoY = 0;
            int count = 0;
            float MargemEsquerda = e.MarginBounds.Left;
            float MargemTopo = 25; //e.MarginBounds.Top;
            string Linha = null;

            ImprimirDocumento doc = (ImprimirDocumento)sender;

            // Define a fonte e determina a altura da linha
            using (Font fonte = new Font("Verdana", 10))
            {
                float alturaLinha = fonte.GetHeight(e.Graphics);

                // Cria as variáveis para tratar a posição na página
                //float x = e.MarginBounds.Left;
                //float y = 25;// e.MarginBounds.Top;

                // Incrementa o contador de página para refletir 
                // a página que esta sendo impressa
                doc.NumeroPagina += 1;

                linhasPorPagina = e.MarginBounds.Height / _font.GetHeight(e.Graphics);

                while (count < linhasPorPagina && ((Linha = doc.Texto[count]) != null))
                {
                    PosicaoY = MargemTopo + (count * _font.GetHeight(e.Graphics));
                    e.Graphics.DrawString(Linha, _font, Brushes.Black, 0, PosicaoY, new StringFormat());

                    if (Linha == " Obrigado!!!")
                        break;

                    count++;
                }
            }
        }
    }

    public class ImprimirDocumento : PrintDocument
    {
        private string[] texto;
        private int numeroPagina;

        public string[] Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public int NumeroPagina
        {
            get { return numeroPagina; }
            set { numeroPagina = value; }
        }

        public ImprimirDocumento(string[] _texto)
        {
            this.Texto = _texto;
        }
    }

    public class Itens
    {
        [DisplayName("Código Produto")]
        public decimal decProduto { get; set; }

        [DisplayName("Produto")]
        public string strProduto { get; set; }

        [DisplayName("Tipo Produto")]
        public string strTipoProduto { get; set; }

        [DisplayName("Valor Unitário (R$)")]
        public double dblValor { get; set; }

        [DisplayName("Quantidade")]
        public int intQtde { get; set; }

        [DisplayName("Valor Total (R$)")]
        public double dblTotal { get; set; }
    }
}
