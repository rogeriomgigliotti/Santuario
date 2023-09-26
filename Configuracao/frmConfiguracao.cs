using Comuns.Classes;
using Comuns.Janelas;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Configuracao
{
    public partial class frmConfiguracao : Form
    {
        public frmConfiguracao()
        {
            InitializeComponent();
        }

        private void AbrirFormulario<T>(bool selecionarEvento = false) where T : Form
        {
            var child = MdiChildren.FirstOrDefault(f => f.GetType() == typeof(T));

            if (child == null)
            {
                if (selecionarEvento)
                {
                    var fEventoSelecao = new frmEventoSelecao();
                    if (fEventoSelecao.ShowDialog() != DialogResult.OK)
                        return;
                }

                var form = (T)Activator.CreateInstance(typeof(T));
                form.MdiParent = this;
                form.Show();
            }
            else
                child.Activate();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmEvento>();
        }

        private void listaDePrecosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmListaPreco>(true);
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmProduto>();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmUsuario>();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmEstoque>(true);
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fEventoSelecao = new frmEventoSelecao();
            if (fEventoSelecao.ShowDialog() == DialogResult.OK)
                Relatorios.Vendas(Variaveis.CodigoEvento, Variaveis.Evento);
        }

        private void estoqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fEventoSelecao = new frmEventoSelecao();
            if (fEventoSelecao.ShowDialog() == DialogResult.OK)
                Relatorios.Estoque(Variaveis.CodigoEvento, Variaveis.Evento);
        }
    }
}
