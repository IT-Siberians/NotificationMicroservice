namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    [Serializable]
    internal class MessageTemplateNullOrEmptyException : System.Exception
    {
        public MessageTemplateNullOrEmptyException()
        {
        }

        public MessageTemplateNullOrEmptyException(string? name) : base($"The '{name}' text cannot be empty")
        {
        }

        public MessageTemplateNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}