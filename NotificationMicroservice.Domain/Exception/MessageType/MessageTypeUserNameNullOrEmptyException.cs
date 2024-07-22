namespace NotificationMicroservice.Domain.Exception.MessageType
{
    [Serializable]
    internal class MessageTypeUserNameNullOrEmptyException : System.Exception
    {
        public MessageTypeUserNameNullOrEmptyException()
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}