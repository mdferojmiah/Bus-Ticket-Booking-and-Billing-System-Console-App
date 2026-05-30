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
            IInputManager userInputManager = new UserInputManager();
            IInputManager busInputManager = new BusInputManager();

            IUserManager userManager = new UserManager(userInputManager);
            IBusManager busManager = new BusManager(busInputManager);
            
            //initiating dashboard
            IDashboardManager dashboard = new Dashboard(userManager, busManager);

            //showing the dashboard
            dashboard.Show();
        }
    }
}