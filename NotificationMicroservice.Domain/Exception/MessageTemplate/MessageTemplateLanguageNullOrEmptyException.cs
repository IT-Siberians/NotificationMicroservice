namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    [Serializable]
    internal class MessageTemplateLanguageNullOrEmptyException : System.Exception
    {
        public MessageTemplateLanguageNullOrEmptyException()
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? name) : base($"Language code '{name}' cannot be empty")
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}