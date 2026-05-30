using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class UserInputManager : IInputManager
    {
        public object TakeInput()
        {
            //taking input
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Mobile(01xxxxxxxxx): ");
            string mobile = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            User user = new User
            {
                UserID = IdGenerator.GenerateUserId(),
                Name = name,
                Mobile = mobile,
                Email = email
            };
            return user;
        }
    }
}