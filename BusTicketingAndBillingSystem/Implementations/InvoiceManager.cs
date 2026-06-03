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

        public List<Invoice> GetInvoicesByUserId(int userId)
        {
            return _invoices.Where(x => x.Ticket.User.UserID == userId).ToList();
        }

        public void DisplayUsersInvoice()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine() ?? string.Empty);
            List<Invoice> userInvoices = GetInvoicesByUserId(userId);
            if(userInvoices == null)
            {
                Console.WriteLine($"\nNo invoices for user Id: {userId}\n");
                return;
            }

            //printing invoices
            foreach (Invoice invoice in userInvoices)
            {
                Console.WriteLine($"Invoice ID: {invoice.InvoiceId} | Ticket ID: {invoice.Ticket.TicketId} | Amount: {invoice.Amount} | Status: {invoice.Status}");
            }
        }

        public void ProcessInvoice()
        {
            Console.Write("Enter Invoice ID to process: ");
            int invoiceId = int.Parse(Console.ReadLine() ?? string.Empty);

            Invoice? invoice = GetInvoiceById(invoiceId);

            if(invoice != null)
            {
                Ticket ticket = invoice.Ticket;
                Schedule schedule = ticket.Schedule;

                if (schedule.ReservedSeat.Contains(ticket.SeatNo))
                {
                    Console.WriteLine("Seat is already booked!");
                    return;
                }
                //reserving the seat
                schedule.ReservedSeat.Add(ticket.SeatNo);
                //confirming the ticket
                ticket.Status = TicketStatus.Confirmed;
                //invoice paid successfully
                invoice.Status = PaymentStatus.Paid;

                Console.WriteLine("\nInvoice paid successfully!!!\n");
            }
        }
    }
}