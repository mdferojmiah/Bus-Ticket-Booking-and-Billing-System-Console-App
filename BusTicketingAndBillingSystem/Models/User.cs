namespace BusTicketingAndBillingSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; }  = string.Empty;

        //public List<Ticket> Tickets { get; set; } = new();
    }
}