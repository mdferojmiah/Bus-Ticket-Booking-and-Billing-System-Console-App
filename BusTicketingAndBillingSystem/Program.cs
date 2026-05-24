namespace BusTicketingAndBillingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bus Ticket Booking & Billing System");
            Console.WriteLine("-----------------------------------");

            while (true)
            {
                Console.WriteLine("0. Exit\n");
                Console.Write("> ");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Clear();
                        return;
                }
            }
        }
    }
}