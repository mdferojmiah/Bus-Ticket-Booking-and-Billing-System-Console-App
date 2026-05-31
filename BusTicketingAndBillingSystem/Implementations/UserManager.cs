using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly List<User> _users;
        private readonly IInputManager _inputManager;

        public UserManager(IInputManager inputManager)
        {
            _users = new List<User>();
            _inputManager = inputManager;
        }
        public void CreateUser()
        {
            User user = (User)_inputManager.TakeInput();
            //adding user to the users list
            _users.Add(user);
            Console.WriteLine("\nUser created successfully!");
        }

        public void ShowAllUser()
        {
            Console.WriteLine("All User List:");
            Console.WriteLine("-------------");
            
            foreach(var user in _users)
            {
                Console.WriteLine($"{user.UserID}. {user.Name} | {user.Mobile} | {user.Email}");
            }
        }
    }
}