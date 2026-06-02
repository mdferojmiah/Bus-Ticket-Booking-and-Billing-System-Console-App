namespace BusTicketingAndBillingSystem.Utilities
{
    public static class IdGenerator
    {
        private static int _userId;
        private static int _busId;
        private static int _ScheduleId;
        private static int _ticketId;

        public static int GenerateUserId()
        {
            return ++_userId;
        }

        public static int GenerateBusId()
        {
            return ++_busId;
        }

        public static int GenerateScheduleId()
        {
            return ++_ScheduleId;
        }

        public static int GenerateTicketId()
        {
            return ++_ticketId;
        }
    }
}