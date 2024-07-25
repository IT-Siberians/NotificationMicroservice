namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateLanguageNullOrEmptyException : ArgumentException
    {
        public MessageTemplateLanguageNullOrEmptyException()
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTemplateLanguageNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}