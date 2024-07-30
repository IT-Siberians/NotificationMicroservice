namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    public class MessageTemplateLanguageLengthException : ArgumentException
    {
        public MessageTemplateLanguageLengthException()
        {
        }

        public MessageTemplateLanguageLengthException(string? message, string? value) 
            : base(message, value)
        {
        }

        public MessageTemplateLanguageLengthException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}