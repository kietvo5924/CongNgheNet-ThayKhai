using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.Booking;
using CarRental.Customers;
using CarRental.GlobalClasses;
using CarRental.Login;
using CarRental.Main;
using CarRental.Return;
using CarRental.Vehicles;

namespace CarRental
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

            if (!clsGlobal.TryConnectToDatabase(out string errorMessage))
            {
                MessageBox.Show($"Unable to connect to the database.\n{errorMessage}",
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new frmLogin());
        }
    }
}
