namespace NotificationMicroservice.Domain.Helpers
{
    public class RegexValues
    {
        public const string EMAIL = @"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}";
        public const string QUEUENAME = @"^[A-Za-z0-9]+$";
    }
}
