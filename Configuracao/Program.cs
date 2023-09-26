using Comuns.Classes;
using Comuns.Janelas;
using System;
using System.Windows.Forms;

namespace Configuracao
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BancoDados.Inicializar();

            var fLogin = new frmLogin(TipoUsuarioEnum.Administrador);
            if (fLogin.ShowDialog() == DialogResult.OK)
                Application.Run(new frmConfiguracao());
        }
    }
}
