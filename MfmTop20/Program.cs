using MfmTop20.App_Start;
using MfmTop20.App_Start.Testing;
using Ninject;
using System;
using System.Windows.Forms;

namespace MfmTop20
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = NinjectKernel.CreateKernel(args); 
            //var kernel = new StandardKernel(new RegisterModule());
            var form = kernel.Get<MainForm>();
            Application.Run(form);
        }
    }
}
