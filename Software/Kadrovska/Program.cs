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
using System.Drawing;
using Evaluation_Manager.staticrepositories;
using Kadrovska.models;

namespace Evaluation_Manager
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///

        public static string g_strAppDataFolder = "kadrovska.evidencija";
        public static string g_strAuthFolder = "auth";

        private static void InitialiseStaticRepositories()
        {
			StaticRepositories.VrstaZahtjevaRepository.FetchData();
			StaticRepositories.StatusZahtjevaRepository.FetchData();
		}

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBLayer.DB.SetConfiguration("IPS23_vbohnec21", "vbohnec21", "mGiJ_$JR");

            InitialiseStaticRepositories();

			Application.Run(new FrmLogin());
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
