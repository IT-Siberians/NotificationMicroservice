namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeNameLengthException : System.Exception
    {
        public MessageTypeNameLengthException()
        {
        }

        public MessageTypeNameLengthException(string? name) : base($"The '{name}' cannot be longer than the maximum allowed value")
        {
        }

        public MessageTypeNameLengthException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}