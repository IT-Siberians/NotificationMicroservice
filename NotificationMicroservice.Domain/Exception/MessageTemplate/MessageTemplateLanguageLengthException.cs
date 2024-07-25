namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateLanguageLengthException : ArgumentException
    {
        public MessageTemplateLanguageLengthException()
        {
        }

        public MessageTemplateLanguageLengthException(string? name) : base($"Language code '{name}' not match the encoding")
        {
        }

        public MessageTemplateLanguageLengthException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}