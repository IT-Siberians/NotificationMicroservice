namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeGuidEmptyException : ArgumentException
    {
        public MessageTypeGuidEmptyException()
        {
        }

        public MessageTypeGuidEmptyException(string? name) : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageTypeGuidEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}