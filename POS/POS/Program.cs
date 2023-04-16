using Autofac;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace POS
{
    static class Program
    {

        public static decimal gstPercentage = 12;
        public static decimal minSalePercentage = Common.DecimalConvert(ConfigurationManager.AppSettings["minSalePercentage"]);
        public static decimal mrpPercentage =Common.DecimalConvert( ConfigurationManager.AppSettings["mrpPercentage"]);
        public static string applicationName = "POS";
        public static string companyName= ConfigurationManager.AppSettings["companyName"].ToString();
        public static string address = ConfigurationManager.AppSettings["address"].ToString();
        public static string city = ConfigurationManager.AppSettings["city"].ToString();
        public static string pin = ConfigurationManager.AppSettings["pin"].ToString();

        public static string phoneNo = ConfigurationManager.AppSettings["phoneNo"].ToString();
        public static string contactNo = ConfigurationManager.AppSettings["contactNo"].ToString();
        public static string email = ConfigurationManager.AppSettings["email"].ToString();
        public static string gstNo = ConfigurationManager.AppSettings["gstNo"].ToString();

        public static int userId = 1;
        public static string userName = "Admin";
        public static string counterNo = "Counter-1";
        public static int FinacialYearId = 1;
        public static string FinacialYear = "2017-18";

















        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {











            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
