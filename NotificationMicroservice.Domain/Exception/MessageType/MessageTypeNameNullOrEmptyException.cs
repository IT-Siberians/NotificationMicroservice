namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeNameNullOrEmptyException : ArgumentException
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