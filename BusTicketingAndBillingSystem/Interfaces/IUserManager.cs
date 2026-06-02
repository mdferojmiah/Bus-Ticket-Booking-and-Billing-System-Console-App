using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IUserManager
    {
        void CreateUser();
        void ShowAllUser();
        User? GetUserById(int userId);
    }
}