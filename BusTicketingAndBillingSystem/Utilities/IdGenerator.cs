namespace BusTicketingAndBillingSystem.Utilities
{
    public static class IdGenerator
    {
        private static int _userId;
        private static int _busId;

        public static int GenerateUserId()
        {
            return ++_userId;
        }

        public static int GenerateBusId()
        {
            return ++_busId;
        }
    }
}