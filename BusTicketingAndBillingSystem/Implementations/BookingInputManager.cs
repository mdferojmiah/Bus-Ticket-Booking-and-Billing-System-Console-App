using System.Security.Cryptography.X509Certificates;
using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;
using BusTicketingAndBillingSystem.Models.HelperModels;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BookingInputManager : IInputManager<BookingInputHelper>
    {
        private readonly IUserManager _userManager;
        private readonly IScheduleManager _scheduleManager;

        public BookingInputManager(IUserManager userManager, IScheduleManager scheduleManager)
        {
            _userManager = userManager;
            _scheduleManager = scheduleManager;
        }
        public BookingInputHelper TakeInput()
        {
            User? user;
            Schedule? schedule;
            string seatNo;

            while (true)
            {
                Console.Write("Enter User ID: ");
                int userId = int.Parse(Console.ReadLine() ?? string.Empty);
                user = _userManager.GetUserById(userId);
                if(user != null) break;
            }

            while (true)
            {
                Console.Write("Enter Schedule ID: ");
                int scheduleId = int.Parse(Console.ReadLine() ?? string.Empty);
                schedule = _scheduleManager.GetScheduleById(scheduleId);
                if(schedule != null) break;
            }
            
            while (true)
            {
                Console.Write("Enter the Seat No(Ex: 5A, 3B, 1C): ");
                seatNo = Console.ReadLine() ?? string.Empty;
                
                bool isBooked =  schedule.ReservedSeat.Contains(seatNo);
                if (isBooked)
                {
                    Console.WriteLine($"\n{seatNo} is already booked! Try differnt seats.\n");
                }
                else
                {
                    break;
                }
            }

            BookingInputHelper bookingInput = new BookingInputHelper()
            {
                User = user,
                Schedule  = schedule,
                SeatNo = seatNo
            };

            return bookingInput;
        }
    }
}