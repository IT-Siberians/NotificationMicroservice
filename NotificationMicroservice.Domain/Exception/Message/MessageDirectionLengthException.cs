namespace NotificationMicroservice.Domain.Exception.Message
{
    [Serializable]
    internal class MessageDirectionLengthException : System.Exception
    {
        public MessageDirectionLengthException()
        {
        }

        public MessageDirectionLengthException(string? name) : base($"Direction '{name}' cannot be empty.")
        {
        }

        public MessageDirectionLengthException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}