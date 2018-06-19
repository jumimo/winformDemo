using System;
using System.Windows.Forms;

namespace Winform_Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            View.DemoForm MainForm = new View.DemoForm();
            Controller.DemoController Controller = new Controller.DemoController(MainForm);

            Application.Run(MainForm);
        }
    }
}
