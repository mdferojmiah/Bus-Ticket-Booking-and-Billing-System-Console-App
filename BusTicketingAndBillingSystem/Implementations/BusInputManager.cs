using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BusInputManager : IInputManager
    {
        private const int BusinessSeats = 20;
        private const int EconomySeats = 40;
        public object TakeInput()
        {
            Console.Write("Enter Coach Number: ");
            string coachNumber = Console.ReadLine() ?? string.Empty;

            BusType busType;
            while (true)
            {
                Console.WriteLine("Enter a Bus Type:");
                Console.WriteLine("E/e. Economy");
                Console.WriteLine("B/b. Business");
                Console.Write("\t> ");
                string tempBusType = Console.ReadLine() ?? string.Empty;
                if(tempBusType.ToLower() == "e")
                {
                    busType = BusType.Economy;
                    break;
                }else if(tempBusType.ToLower() == "b")
                {
                    busType = BusType.Business;
                    break;
                }else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Bus bus = new Bus
            {
                BusId = IdGenerator.GenerateBusId(),
                CoachNumber = coachNumber,
                BusType = busType,
                TotalSeats = busType == BusType.Business ? BusinessSeats : EconomySeats
            };

            return bus;
        }
    }
}