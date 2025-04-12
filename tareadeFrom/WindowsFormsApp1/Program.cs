using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.Clases;

namespace WindowsFormsApp1
{

    internal static class Program
    {
        private static Crud micrud = new Crud();


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            micrud.MostrarInformacion("0905 - 24 - 3068");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}