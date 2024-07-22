namespace NotificationMicroservice.Domain.Exception.MessageType
{
    [Serializable]
    internal class MessageTypeGuidEmptyException : System.Exception
    {
        public MessageTypeGuidEmptyException()
        {
        }

        public MessageTypeGuidEmptyException(string? name) : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageTypeGuidEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}