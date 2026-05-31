using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Interfaces
{
    public interface IScheduleManager
    {
        void CreateSchedule();
        void ShowAllSchedule();
        Schedule? GetScheduleById(int scheduleId);
        void ShowScheduleDetails();
    }
}