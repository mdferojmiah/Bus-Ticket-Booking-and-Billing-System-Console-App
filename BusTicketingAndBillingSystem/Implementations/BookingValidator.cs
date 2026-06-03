using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class BookingValidator : IBookingValidator
    {
        private readonly char[] _economySeatsInARow = {'A', 'B', 'C', 'D'};
        private readonly char[] _businessSeatsInARow =  {'A', 'B', 'C'};
        private readonly IUserManager _userManager;
        private readonly IScheduleManager _scheduleManager;

        public BookingValidator(IUserManager userManager, IScheduleManager scheduleManager)
        {
            _userManager = userManager;
            _scheduleManager = scheduleManager;
        }
        public bool ValidateSchedule(int scheduleId, out Schedule? schedule)
        {
            schedule = _scheduleManager.GetScheduleById(scheduleId);
            return schedule != null;
        }

        public bool ValidateSeat(string seatNo, Schedule schedule)
        {
            if(!isSeatInRange(seatNo, schedule))
            {
                Console.WriteLine("\nYou choose an Invalid Seat!!!\n");
            }
            
            if(isSeatReserved(seatNo, schedule))
            {
                Console.WriteLine($"\n{seatNo} is already booked! Try different seats.\n");
            }

            return isSeatInRange(seatNo, schedule) && !isSeatReserved(seatNo, schedule);
        }

        public bool ValidateUser(int userId, out User? user)
        {
            user = _userManager.GetUserById(userId);
            return user != null;
        }

        private bool isSeatReserved(string seatNo, Schedule schedule)
        {
            return schedule.ReservedSeat.Contains(seatNo);
        }

        private bool isSeatInRange(string seatNo, Schedule schedule)
        {
            var seats = schedule.Bus.BusType == BusType.Business ? _businessSeatsInARow : _economySeatsInARow;
            
            //seat length must have length of 2
            if (seatNo.Length < 2 || seatNo.Length > 2)
            {
                return false;
            }
            
            //extracting row [ex: 1,2,3..]
            string rowInString = seatNo.Substring(0, seatNo.Length - 1);
            
            //checking if row is interger
            if (!int.TryParse(rowInString, out int row))
            {
                return false;
            }

            //extracting col [ex: A, B, C]
            char col = seatNo[seatNo.Length - 1];

            //maxrows = totalseats/ seats in a row [ex: total seat = 24 / seat in a row = 3 for businees class]
            int maxRows = schedule.Bus.TotalSeats / seats.Length;
            
            if(row >= 1 && row <= maxRows && seats.Contains(col))
            {
                return true;
            }
            return false;
        }
    }
}