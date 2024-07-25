namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeNameLengthException : ArgumentException
    {
        public MessageTypeNameLengthException()
        {
        }

        public MessageTypeNameLengthException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTypeNameLengthException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}