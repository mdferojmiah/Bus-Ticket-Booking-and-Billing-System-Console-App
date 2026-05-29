using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class Dashboard : IDashboardManager
    {
        private IUserManager userManager = new UserManager();

        public void Show()
        {
            Console.WriteLine("Bus Ticket Booking & Billing System");
            Console.WriteLine("-----------------------------------");

            while (true)
            {
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show All Users");
                Console.WriteLine("0. Exit\n");
                Console.Write("> ");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Clear();
                        return;
                    case "1":
                        Console.Clear();
                        userManager.CreateUser();
                        BackToMainMenuOption();
                        break;
                    case "2":
                        Console.Clear();
                        userManager.ShowAllUser();
                        BackToMainMenuOption();
                        break;
                }
            }
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