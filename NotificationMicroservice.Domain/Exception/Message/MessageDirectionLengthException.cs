namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageDirectionLengthException : ArgumentException
    {
        public MessageDirectionLengthException()
        {
        }

        public MessageDirectionLengthException(string? name) : base($"Direction '{name}' cannot be empty.")
        {
        }

        public MessageDirectionLengthException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}