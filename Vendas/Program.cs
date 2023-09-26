using Comuns.Classes;
using Comuns.Janelas;
using System;
using System.Windows.Forms;

namespace Vendas
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BancoDados.Inicializar();

            var fLogin = new frmLogin(TipoUsuarioEnum.Vendas);
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                var fEventoSelecao = new frmEventoSelecao();
                if (fEventoSelecao.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmVenda());
            }
        }
    }
}
