using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IBookingValidator
    {
        bool ValidateUser(int userId, out User? user);
        bool ValidateSchedule(int scheduleId, out Schedule? schedule);
        bool ValidateSeat(string seatNo, Schedule schedule);
    }
}