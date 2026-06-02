using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface ITicketManager
    {
        Ticket CreateTicket(User user, Schedule schedule, string seatNo);
        Ticket? GetTicketById(int ticketId);
    }
}