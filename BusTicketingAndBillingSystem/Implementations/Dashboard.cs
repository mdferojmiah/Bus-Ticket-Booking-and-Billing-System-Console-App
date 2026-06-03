using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class Dashboard : IDashboardManager
    {
        private readonly IUserManager _userManager;
        private readonly IBusManager _busManager;
        private readonly IScheduleManager _scheduleManager;
        private readonly IInvoiceManager _invoiceManager;
        private readonly IBookingManger _bookingManger;

        public Dashboard(IUserManager userManager,
                         IBusManager busManager, 
                         IScheduleManager scheduleManager, 
                         IInvoiceManager invoiceManager,
                         IBookingManger bookingManger)
        {
            _userManager = userManager;
            _busManager = busManager;
            _scheduleManager = scheduleManager;
            _invoiceManager = invoiceManager;
            _bookingManger = bookingManger;
        }

        public void Show()
        {
            Console.Clear();
            while (true)
            {
                PrintMenu();
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        //exit
                        Console.Clear();
                        return;
                    case "1":
                        //create user
                        Console.Clear();
                        _userManager.CreateUser();
                        BackToMainMenuOption();
                        break;
                    case "2":
                        //show all users
                        Console.Clear();
                        _userManager.ShowAllUser();
                        BackToMainMenuOption();
                        break;
                    case "3":
                        //create bus
                        Console.Clear();
                        _busManager.CreateBus();
                        BackToMainMenuOption();
                        break;
                    case "4":
                        //show all buses
                        Console.Clear();
                        _busManager.ShowAllBus();
                        BackToMainMenuOption();
                        break;
                    case "5":
                        //create schedule
                        Console.Clear();
                        _scheduleManager.CreateSchedule();
                        BackToMainMenuOption();
                        break;
                    case "6":
                        //show sll schedules
                        Console.Clear();
                        _scheduleManager.ShowAllSchedule();
                        BackToMainMenuOption();
                        break;
                    case "7":
                        //show schedule details
                        Console.Clear();
                        _scheduleManager.ShowScheduleDetails();
                        BackToMainMenuOption();
                        break;
                    case "8":
                        //book ticket
                        Console.Clear();
                        _bookingManger.BookTicket();
                        BackToMainMenuOption();
                        break;
                    case "9":
                        //show user invoices
                        Console.Clear();
                        _invoiceManager.DisplayUsersInvoice();
                        BackToMainMenuOption();
                        break;
                    default:
                        //invalid input
                        Console.Clear();
                        Console.WriteLine("Invalid Command!\n");
                        break;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("Bus Ticket Booking & Billing System");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show All Users");
            Console.WriteLine("3. Create Bus");
            Console.WriteLine("4. Show All Buses");
            Console.WriteLine("5. Create Schedule");
            Console.WriteLine("6. Show All Schedules");
            Console.WriteLine("7. Show Schedule Details");
            Console.WriteLine("8. Book Ticket");
            Console.WriteLine("9. Show User Invoices");
            Console.WriteLine("0. Exit\n");
            Console.Write("> ");
        }

        private void BackToMainMenuOption()
        {
            while (true)
            {
                Console.WriteLine("\n0. Go back to Main Menu");
                Console.Write("> ");
                string input = Console.ReadLine() ?? string.Empty;
                
                if(input == "0")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}