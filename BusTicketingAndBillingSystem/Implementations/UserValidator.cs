using BusTicketingAndBillingSystem.Interfaces;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class UserValidator : IUserValidator
    {
        public bool ValidateEmail(string email)
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                return true;
            }
            Console.WriteLine("\nInvalid Email!!!\n");
            return false;
        }

        public bool ValidateMobile(string mobile)
        {
            if(mobile.Length > 11 || mobile.Length < 11)
            {
                Console.WriteLine("\nInvalid Mobile!!! Mobile number must contains 11 characters.\n");
                return false;
            }
            return true;
        }

        public bool ValidateName(string name)
        {
            if(name.Length < 3)
            {
                Console.WriteLine("\nToo short name!!!\n");
                return false;
            }
            return true;
        }
    }
}