using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class Dashboard : IDashboardManager
    {
        private  readonly IUserManager _userManager;

        public Dashboard(IUserManager userManager)
        {
            _userManager = userManager;
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