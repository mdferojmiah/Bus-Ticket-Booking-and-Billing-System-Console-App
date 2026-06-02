using BusTicketingAndBillingSystem.Enums;

namespace BusTicketingAndBillingSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public required User User { get; set; }
        public required Schedule Schedule { get; set; }
        public string SeatNo { get; set; } = string.Empty;
        public string BookingTime { get; set; } = string.Empty;
        public TicketStatus Status { get; set; }
    }
}