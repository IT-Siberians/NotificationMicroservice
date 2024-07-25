namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageDirectionNullOrEmptyException : ArgumentException
    {
        public MessageDirectionNullOrEmptyException()
        {
        }

        public MessageDirectionNullOrEmptyException(string? name) : base($"Direction '{name}' cannot be empty")
        {
        }

        public MessageDirectionNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}