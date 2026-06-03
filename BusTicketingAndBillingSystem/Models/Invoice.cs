using BusTicketingAndBillingSystem.Enums;

namespace BusTicketingAndBillingSystem.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        //public int UserID { get; set; }
        public required Ticket Ticket { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceGenerationDate { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
    }
}