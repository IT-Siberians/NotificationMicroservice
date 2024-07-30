namespace NotificationMicroservice.Domain.Exception.MessageType
{
    public class MessageTypeNameNullOrEmptyException : ArgumentException
    {
        public MessageTypeNameNullOrEmptyException()
        {
        }

        public MessageTypeNameNullOrEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }

        public MessageTypeNameNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}