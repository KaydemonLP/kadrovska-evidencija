using System;
using System.Windows.Forms;
using Kadrovska.staticrepositories;

namespace Kadrovska
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
