using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Models.HelperModels;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BookingManager : IBookingManger
    {
        private readonly IInputManager<BookingInputHelper> _inputManager;
        private readonly ITicketManager _ticketManager;
        private readonly IInvoiceManager _invoiceManager;
        
        public BookingManager(IInputManager<BookingInputHelper> inputManager, ITicketManager ticketManager, IInvoiceManager invoiceManager)
        {
            _inputManager = inputManager;
            _ticketManager = ticketManager;
            _invoiceManager = invoiceManager;
        }
        public void BookTicket()
        {
            BookingInputHelper input = _inputManager.TakeInput();

            //making a ticket
            Ticket ticket = _ticketManager.CreateTicket(input.User, input.Schedule, input.SeatNo);

            //making an invoice
            Invoice invoice = _invoiceManager.CreateInvoice(input.Schedule, ticket);

            Console.WriteLine("Ticket booked successfully!!!");
            Console.WriteLine("A Invoice has been genereated. Please complete the payment process to confirm the booking.");
            Console.WriteLine();

            Console.WriteLine("Booking Details:");
            Console.WriteLine($"Ticket ID: {ticket.TicketId} | Seat No: {ticket.SeatNo} | Status: {ticket.Status}");
            Console.WriteLine($"Schedule ID: {invoice.InvoiceId}| Amount: {invoice.Amount} | Status: {invoice.Status}");
        }
    }
}