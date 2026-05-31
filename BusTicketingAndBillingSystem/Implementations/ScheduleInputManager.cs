using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Utilities;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class ScheduleInputManager : IInputManager
    {
        private readonly IBusManager _busManager;
        
        public ScheduleInputManager(IBusManager busManager)
        {
            _busManager = busManager;
        }

        public object TakeInput()
        {
            Console.Write("Enter Departure City: ");
            string departureCity =  Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Arrival City: ");
            string arrivalCity = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Departure Date(dd-mm-yyyy): ");
            string departureDate = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Departure Time(hh:mm): ");
            string departureTime = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Ticket Price: ");
            decimal ticketPrice = decimal.Parse(Console.ReadLine() ?? string.Empty);

            Bus? bus;
            while (true)
            {
                Console.Write("Enter Bus Id: ");
                int busId = int.Parse(Console.ReadLine() ?? string.Empty);

                bus = _busManager.GetBusById(busId);
                if(bus != null)
                {
                    break;
                }
            }
            
            Schedule schedule = new Schedule()
            {
                ScheduleId = IdGenerator.GenerateScheduleId(),
                DepartureCity = departureCity,
                ArrivalCity = arrivalCity,
                DepartureDate = departureDate,
                DepartureTime = departureTime,
                TicketPrice = ticketPrice,
                Bus = bus
            };

            return schedule;
        }
    }
}