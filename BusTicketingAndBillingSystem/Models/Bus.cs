using BusTicketingAndBillingSystem.Enums;

namespace BusTicketingAndBillingSystem.Models
{
    public class Bus
    {
        public int BusId { get; set; }
        public string CoachNumber { get; set; } = string.Empty;
        public BusType BusType { get; set; }
        public int TotalSeats { get; set; }
    }
}