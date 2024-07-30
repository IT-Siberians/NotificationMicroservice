namespace NotificationMicroservice.Domain.Exception.MessageType
{
    public class MessageTypeGuidEmptyException : ArgumentException
    {
        public MessageTypeGuidEmptyException()
        {
        }

        public MessageTypeGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTypeGuidEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}