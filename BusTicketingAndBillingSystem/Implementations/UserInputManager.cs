using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class UserInputManager : IInputManager<User>
    {
        private readonly IUserValidator _userValidator;
        public UserInputManager(IUserValidator userValidator)
        {
            _userValidator = userValidator;
        }
        public User TakeInput()
        {
            string name, mobile, email;

            //taking name input
            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine() ?? string.Empty;
                if(_userValidator.ValidateName(name)) break;
            }

            //taking mobile number input
            while (true)
            {
                Console.Write("Enter Mobile(01xxxxxxxxx): ");
                mobile = Console.ReadLine() ?? string.Empty;
                if(_userValidator.ValidateMobile(mobile)) break;
            }
            
            //taking email input
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine() ?? string.Empty;   
                if(_userValidator.ValidateEmail(email)) break;
            }

            User user = new User()
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