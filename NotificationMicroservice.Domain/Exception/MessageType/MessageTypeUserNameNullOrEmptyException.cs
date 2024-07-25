namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeUserNameNullOrEmptyException : ArgumentException
    {
        public MessageTypeUserNameNullOrEmptyException()
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}