using System;
using System.Windows.Forms;

namespace Comuns.Classes
{
    public static class Mensagens
    {
        public static void ExibirErro(Exception exception)
        {
            MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
