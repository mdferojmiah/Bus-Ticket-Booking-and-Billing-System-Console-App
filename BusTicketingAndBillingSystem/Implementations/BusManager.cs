using System.Transactions;
using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BusManager : IBusManager
    {
        private readonly List<Bus> _buses;
        private const int BusinessSeats = 20;
        private const int EconomySeats = 40;

        public BusManager()
        {
            _buses = new List<Bus>();
        }

        public void CreateBus()
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

            //creating bus
            Bus bus = new Bus
            {
                BusId = _buses.Count + 1,
                CoachNumber = coachNumber,
                BusType = busType,
                TotalSeats = busType == BusType.Business ? BusinessSeats : EconomySeats
            };

            //adding to the list
            _buses.Add(bus);
            Console.WriteLine("\nBus created successfully!");
        }

        public void ShowAllBus()
        {
            Console.WriteLine("All Buses List:");
            Console.WriteLine("--------------");
            
            foreach(var bus in _buses)
            {
                Console.WriteLine($"{bus.BusId}. {bus.CoachNumber} | {bus.BusType} | {bus.TotalSeats}");
            }
        }
    }
}