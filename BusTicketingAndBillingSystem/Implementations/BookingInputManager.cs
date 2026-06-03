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
        private readonly IBookingValidator _bookingValidator;

        public BookingInputManager(IUserManager userManager, 
                                   IScheduleManager scheduleManager,
                                   IBookingValidator bookingValidator)
        {
            _userManager = userManager;
            _scheduleManager = scheduleManager;
            _bookingValidator = bookingValidator;
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

                if(_bookingValidator.ValidateUser(userId, out user))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Schedule ID: ");
                int scheduleId = int.Parse(Console.ReadLine() ?? string.Empty);

                if(_bookingValidator.ValidateSchedule(scheduleId, out schedule))
                {
                    break;
                }
            }
            
            while (true)
            {
                Console.Write("Enter the Seat No(Ex: 5A, 3B, 1C): ");
                seatNo = Console.ReadLine() ?? string.Empty;
                
                if(_bookingValidator.ValidateSeat(seatNo, schedule!))
                {
                    break;
                }
            }

            BookingInputHelper bookingInput = new BookingInputHelper()
            {
                User = user!,
                Schedule  = schedule!,
                SeatNo = seatNo
            };

            return bookingInput;
        }
    }
}