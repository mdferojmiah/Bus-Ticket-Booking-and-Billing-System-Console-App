using System.Reflection.Metadata.Ecma335;
using BusTicketingAndBillingSystem.Enums;
using BusTicketingAndBillingSystem.Interfaces;
using BusTicketingAndBillingSystem.Models;

namespace BusTicketingAndBillingSystem.Implementations
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly List<Schedule> _schedules;
        private readonly char[] _economySeatsInARow = {'A', 'B', 'C', 'D'};
        private readonly char[] _businessSeatsInARow =  {'A', 'B', 'C'};
        private readonly IInputManager _inputManager;
        
        public ScheduleManager(IInputManager inputManager)
        {
            _schedules = new List<Schedule>();
            _inputManager = inputManager;
        }

        public void CreateSchedule()
        {
            Schedule schedule = (Schedule)_inputManager.TakeInput();
            //adding to the list
            _schedules.Add(schedule);
            Console.WriteLine("\nSchedule created successfully!");
        }

        public void ShowAllSchedule()
        {
            Console.WriteLine("All Schedules List:");
            Console.WriteLine("-------------------");
            
            foreach(var schedule in _schedules)
            {
                Console.WriteLine($"{schedule.ScheduleId}. BusId: {schedule.Bus.BusId} | {schedule.DepartureCity} -> {schedule.ArrivalCity} | Date: {schedule.DepartureDate} | Time: {schedule.DepartureTime} | Price: {schedule.TicketPrice}");
            }
        }

        public Schedule? GetScheduleById(int scheduleId)
        {
            Schedule? schedule = _schedules.FirstOrDefault(x => x.ScheduleId == scheduleId);

            if(schedule == null)
            {
                Console.WriteLine("\nNo Schedule found!!!\n");
                return null;
            }
            return schedule;        
        }

        public void ShowScheduleDetails()
        {
            Console.Write("Enter Schedule Id: ");
            int scheduleId = int.Parse(Console.ReadLine() ?? string.Empty);
            Schedule? schedule = GetScheduleById(scheduleId);

            if(schedule != null)
            {
                Console.WriteLine();
                Console.WriteLine("Schedule Details:");
                Console.WriteLine("----------------");
                Console.WriteLine($"Bus Id: {schedule.Bus.BusId} | Coach Number: {schedule.Bus.CoachNumber} | Bus Type: {schedule.Bus.BusType}");
                Console.WriteLine($"From: {schedule.DepartureCity} | To: {schedule.ArrivalCity}");
                Console.WriteLine($"Date: {schedule.DepartureDate} | Time: {schedule.DepartureTime}");
                Console.WriteLine($"Ticket Price: {schedule.TicketPrice} | Available Seat: {GetAvailableSeat(schedule)}");
                ShowSeatLayout(schedule);
            }
        }

        private int GetAvailableSeat(Schedule schedule)
        {
            return schedule.Bus.TotalSeats - schedule.ReservedSeat.Count;
        }

        private void ShowSeatLayout(Schedule schedule)
        {
            Console.WriteLine();
            Console.WriteLine("Seat Layout(X = booked, [ ] = available): ");
            var seats = schedule.Bus.BusType == BusType.Business ? _businessSeatsInARow : _economySeatsInARow;
            int rows = schedule.Bus.TotalSeats / seats.Count();

            for(int i = 1; i <= rows; i++)
            {
                foreach(var seat in seats)
                {
                    string seatNo = $"{i}{seat}";

                    bool booked = schedule.ReservedSeat.Contains(seatNo);

                    if (booked)
                    {
                        Console.Write($"[X:{seatNo}]\t");
                    }
                    else
                    {
                        Console.Write($"[ :{seatNo}]\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}