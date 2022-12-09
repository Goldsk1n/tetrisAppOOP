using System;
using System.Windows.Forms;
using TetrisOOP.Data.GUI.StartScreen;

namespace TetrisOOP
{
    static class Program
    {
        /// <summary>Головна точка входу для додатку.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen());
        }
    }
}
