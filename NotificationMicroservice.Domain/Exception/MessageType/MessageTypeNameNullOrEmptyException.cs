namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeNameNullOrEmptyException : ArgumentException
    {
        public MessageTypeNameNullOrEmptyException()
        {
        }

        public MessageTypeNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTypeNameNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}