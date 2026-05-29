using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly List<User> _users;

        public UserManager()
        {
            _users = new List<User>();
        }
        public void CreateUser()
        {
            //taking input
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Mobile(01xxxxxxxxx): ");
            string mobile = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            //creating new user
            User user = new User
            {   
                UserID = _users.Count + 1,
                Name = name,
                Mobile = mobile,
                Email = email
            };

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