using System.Security.Cryptography.X509Certificates;
using BusTicketingAndBillingSystem.Implementations;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Models.HelperModels;

namespace BusTicketingAndBillingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //user managemnet
            IUserValidator userValidator = new UserValidator();
            IInputManager<User> userInputManager = new UserInputManager(userValidator);
            IUserManager userManager = new UserManager(userInputManager);

            //bus management
            IInputManager<Bus> busInputManager = new BusInputManager();
            IBusManager busManager = new BusManager(busInputManager);

            //schedule management
            IInputManager<Schedule> scheduleInputManager = new ScheduleInputManager(busManager);
            IScheduleManager scheduleManager = new ScheduleManager(scheduleInputManager);

            //ticket manager
            ITicketManager ticketManager = new TicketManager();

            //invoice manager
            IInvoiceManager invoiceManager = new InvoiceManager();

            //ticket booking management
            IBookingValidator bookingValidator = new BookingValidator(userManager, scheduleManager);
            IInputManager<BookingInputHelper> bookingInputManager = new BookingInputManager(userManager, scheduleManager, bookingValidator);
            IBookingManger bookingManger = new BookingManager(bookingInputManager, ticketManager, invoiceManager);

            //initiating dashboard
            IDashboardManager dashboard = new Dashboard(userManager, busManager, scheduleManager, invoiceManager, ticketManager, bookingManger);

            //showing the dashboard
            dashboard.Show();
        }
    }
}