namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeNameLengthException : ArgumentException
    {
        public MessageTypeNameLengthException()
        {
        }

        public MessageTypeNameLengthException(string? name) : base($"The '{name}' cannot be longer than the maximum allowed value")
        {
        }

        public MessageTypeNameLengthException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}