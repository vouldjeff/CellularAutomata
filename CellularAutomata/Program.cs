using System;
using System.Windows.Forms;

namespace CellularAutomata
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TODO: fix the path
            ApplicationManager.LoadPatterns("F:/Projects/CellularAutomata/CellularAutomata/Patterns.xml");
            ApplicationManager.LoadMainForm();
        }
    }
}