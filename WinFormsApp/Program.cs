using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string filePath = $"{Application.StartupPath}/MyAppFiles/StartupSettings.txt";
            if (!File.Exists(filePath))
            {
                Application.Run(new SettingsForm());
            }
            Application.Run(new MainForm());


            //Application.Run(new DataLayerTestForm());
        }
    }
}
