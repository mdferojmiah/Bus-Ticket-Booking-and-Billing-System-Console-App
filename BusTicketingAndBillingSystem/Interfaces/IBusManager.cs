using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IBusManager
    {
        void CreateBus();
        void ShowAllBus();
        Bus? GetBusById(int BusId);
    }
}