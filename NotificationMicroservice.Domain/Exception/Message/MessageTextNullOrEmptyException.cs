namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageTextNullOrEmptyException : ArgumentException
    {
        public MessageTextNullOrEmptyException()
        {
        }

        public MessageTextNullOrEmptyException(string? name) : base($"Message text '{name}' cannot be empty")
        {
        }

        public MessageTextNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}