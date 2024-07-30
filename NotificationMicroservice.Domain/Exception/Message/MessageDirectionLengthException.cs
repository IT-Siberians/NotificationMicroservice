namespace NotificationMicroservice.Domain.Exception.Message
{
    public class MessageDirectionLengthException : ArgumentException
    {
        public MessageDirectionLengthException()
        {
        }

        public MessageDirectionLengthException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageDirectionLengthException(string? message, ArgumentException? innerException)
            : base(message, innerException)
        {
        }
    }
}