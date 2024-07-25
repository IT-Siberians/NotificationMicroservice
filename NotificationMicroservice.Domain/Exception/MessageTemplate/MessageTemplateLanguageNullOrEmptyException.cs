namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateLanguageNullOrEmptyException : ArgumentException
    {
        public MessageTemplateLanguageNullOrEmptyException()
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? name) : base($"Language code '{name}' cannot be empty")
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}