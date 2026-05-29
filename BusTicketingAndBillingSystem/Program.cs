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
            IUserManager userManager = new UserManager();
            IBusManager busManager = new BusManager();
            
            //initiating dashboard
            IDashboardManager dashboard = new Dashboard(userManager, busManager);

            //showing the dashboard
            dashboard.Show();
        }
    }
}