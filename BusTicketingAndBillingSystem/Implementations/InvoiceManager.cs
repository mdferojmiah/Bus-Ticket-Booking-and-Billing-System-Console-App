using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class InvoiceManager : IInvoiceManager
    {
        public readonly List<Invoice> _invoices;

        public InvoiceManager()
        {
            _invoices = new List<Invoice>();
        }

        public Invoice CreateInvoice(Schedule schedule, Ticket ticket)
        {
            Invoice invoice =  new Invoice()
            {
                InvoiceId = IdGenerator.GenerateInvoiceId(),
                Ticket = ticket,
                Amount = schedule.TicketPrice,
                Status = PaymentStatus.Unpaid
            };

            _invoices.Add(invoice);
            return invoice;
        }

        public Invoice? GetInvoiceById(int invoiceId)
        {
            Invoice? invoice = _invoices.FirstOrDefault(x => x.InvoiceId == invoiceId);
            if(invoice == null)
            {
                Console.WriteLine($"\nNo invoice found with ID: {invoiceId}\n");
            }
            return invoice;
        }
    }
}