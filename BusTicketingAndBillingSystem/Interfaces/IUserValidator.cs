namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IUserValidator
    {
        bool ValidateName(string name);
        bool ValidateMobile(string mobile);
        bool ValidateEmail(string email);
    }
}