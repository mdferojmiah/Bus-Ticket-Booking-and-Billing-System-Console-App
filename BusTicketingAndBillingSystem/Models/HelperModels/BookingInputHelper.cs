namespace BusTicketingAndBillingSystem.Models.HelperModels
{
    public class BookingInputHelper
    {
        public required User User { get; set; }
        public required Schedule Schedule { get; set; }
        public string SeatNo { get; set; } = string.Empty;
    }
}