namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageDirectionNullOrEmptyException : System.Exception
    {
        public MessageDirectionNullOrEmptyException()
        {
        }

        public MessageDirectionNullOrEmptyException(string? name) : base($"Direction '{name}' cannot be empty")
        {
        }

        public MessageDirectionNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}