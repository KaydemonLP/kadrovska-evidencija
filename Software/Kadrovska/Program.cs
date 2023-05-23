using Evaluation_Manager.repositories;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

            DBLayer.DB.SetConfiguration("IPS23_vbohnec21", "vbohnec21", "mGiJ_$JR");
            // SQL Server data tools
            // add sql server
            // naziv servera 
            // SQL server authentification
            // username/pass na mail
            // Baza evaluation manager
            // ClientID: 
            // Secret: 
        }
    }
}
