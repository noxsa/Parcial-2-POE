using ProyectoNotas.Formularios;
using System;
using System.Windows.Forms;

namespace ProyectoNotas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            RepoDb.SqlServerBootstrap.Initialize();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRegistrarNota());
        }
    }
}

