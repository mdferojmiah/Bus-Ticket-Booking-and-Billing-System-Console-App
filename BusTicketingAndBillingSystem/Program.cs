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
            //user managemnet
            IInputManager userInputManager = new UserInputManager();
            IUserManager userManager = new UserManager(userInputManager);

            //bus management
            IInputManager busInputManager = new BusInputManager();
            IBusManager busManager = new BusManager(busInputManager);

            //schedule management
            IInputManager scheduleInputManager = new ScheduleInputManager(busManager);
            IScheduleManager scheduleManager = new ScheduleManager(scheduleInputManager);

            //ticket manager
            ITicketManager ticketManager = new TicketManager();

            //invoice manager
            IInvoiceManager invoiceManager = new InvoiceManager();

            //ticket booking management
            IInputManager bookingInputManager = new BookingInputManager(userManager, scheduleManager);
            IBookingManger bookingManger = new BookingManager(bookingInputManager, ticketManager, invoiceManager);

            //initiating dashboard
            IDashboardManager dashboard = new Dashboard(userManager, busManager, scheduleManager, invoiceManager, bookingManger);

            //showing the dashboard
            dashboard.Show();
        }
    }
}