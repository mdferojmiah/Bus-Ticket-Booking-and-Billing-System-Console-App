using BusTicketingAndBillingSystem.Enums;

namespace BusTicketingAndBillingSystem.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public required Ticket Ticket { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
    }
}