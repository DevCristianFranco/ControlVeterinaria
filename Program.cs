using CRUDWindFormsMVP.Views;
using CRUDWindFormsMVP.Models;
using CRUDWindFormsMVP.Presenters;
using CRUDWindFormsMVP._Repositories;
using System.Configuration;
using System;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUDWindFormsMVP
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IMainView view = new MainView();
            new MainPresenter (view,sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}
