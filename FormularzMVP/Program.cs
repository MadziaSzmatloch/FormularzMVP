using FormularzMVP.Presenters;
using FormularzMVP.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularzMVP
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
            IEmployeeView view = new EmployeeView();
            _ = new EmployeePresenter(view);
            Application.Run((Form)view);
        }
    }
}
