using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IInvoiceManager
    {
        Invoice CreateInvoice(Schedule schedule, Ticket ticket);
        Invoice? GetInvoiceById(int invoiceId);
        List<Invoice> GetInvoicesByUserId(int userId);
        void ProcessInvoice();
        void DisplayUsersInvoice();
    }
}