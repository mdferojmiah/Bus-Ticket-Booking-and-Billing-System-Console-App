namespace BusTicketingAndBillingSystem.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public required Bus Bus { get; set; }
        public string DepartureCity { get; set; } = string.Empty; //from
        public string ArrivalCity { get; set; } = string.Empty; //to
        public string DepartureDate { get; set; } = string.Empty;
        public string DepartureTime { get; set; } = string.Empty;
        public decimal TicketPrice { get; set; }

        public List<string> ReservedSeat { get; set; } = new();
    }
}