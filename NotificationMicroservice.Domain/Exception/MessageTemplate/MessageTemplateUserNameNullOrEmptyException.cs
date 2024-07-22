namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    [Serializable]
    internal class MessageTemplateUserNameNullOrEmptyException : System.Exception
    {
        public MessageTemplateUserNameNullOrEmptyException()
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}