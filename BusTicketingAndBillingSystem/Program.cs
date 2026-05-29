using System.Security.Cryptography.X509Certificates;
using BusTicketingAndBillingSystem.Implementations;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserManager userManager = new UserManager();
            //initiating dashboard
            IDashboardManager dashboard = new Dashboard(userManager);

            //showing the dashboard
            dashboard.Show();
        }
    }
}