using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class TicketManager : ITicketManager
    {
        private readonly List<Ticket> _tickets;

        public TicketManager()
        {
            _tickets = new List<Ticket>();
        }
        public Ticket CreateTicket(User user, Schedule schedule, string seatNo)
        {
            Ticket ticket = new Ticket()
            {
                TicketId = IdGenerator.GenerateTicketId(),
                User = user,
                Schedule = schedule,
                SeatNo = seatNo,
                BookingTime = DateTime.UtcNow.ToString(),
                Status = TicketStatus.Pending
            };

            _tickets.Add(ticket);
            return ticket;
        }

        public Ticket? GetTicketById(int ticketId)
        {
            Ticket? ticket = _tickets.FirstOrDefault(x => x.TicketId == ticketId);
            if(ticket == null)
            {
                Console.WriteLine($"\nNo ticket found with Id: {ticketId}\n");
            }
            return ticket;
        }

        public List<Ticket> GetTicketsByUserId(int userId)
        {
            return _tickets.Where(x => x.User.UserID == userId).ToList();
        }

        public void DisplayUserTicket()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine() ?? string.Empty);
            List<Ticket> allTickets = GetTicketsByUserId(userId);
            if(allTickets != null)
            {
                List<Ticket> confirmedTickets = allTickets.Where(x => x.Status == TicketStatus.Confirmed).ToList();
                Console.WriteLine("Tickets:");
                Console.WriteLine("-------");
                foreach(Ticket ticket in confirmedTickets)
                {
                    Console.WriteLine($"Ticket ID: {ticket.TicketId} | Coach: {ticket.Schedule.Bus.CoachNumber} | Date: {ticket.Schedule.DepartureDate} {ticket.Schedule.DepartureTime} | Seat: {ticket.SeatNo}");
                }
                return;
            }
            Console.WriteLine("\nDo not have nay paid tickets!!!\n");
        }
    }
}