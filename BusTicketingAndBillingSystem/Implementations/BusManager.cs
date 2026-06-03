using System.Runtime.InteropServices.Marshalling;
using System.Transactions;
using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BusManager : IBusManager
    {
        private readonly List<Bus> _buses;
        private readonly IInputManager<Bus> _inputManager;

        public BusManager(IInputManager<Bus> inputManager)
        {
            _buses = new List<Bus>();
            _inputManager = inputManager;
        }

        public void CreateBus()
        {
            Bus bus = _inputManager.TakeInput();
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

        public Bus? GetBusById(int BusId)
        {
            Bus? bus = _buses.FirstOrDefault(x => x.BusId == BusId);
            if (bus == null)
            {
                Console.WriteLine($"\nNo Bus found with Id: {BusId}");
            }
            return bus;
        }
    }
}