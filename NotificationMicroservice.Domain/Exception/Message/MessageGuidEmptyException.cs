namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageGuidEmptyException : ArgumentException
    {
        public MessageGuidEmptyException()
        {
        }

        public MessageGuidEmptyException(string? name) : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageGuidEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}