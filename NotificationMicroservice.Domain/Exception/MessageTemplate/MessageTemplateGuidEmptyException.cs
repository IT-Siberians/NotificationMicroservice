namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    public class MessageTemplateGuidEmptyException : ArgumentException
    {
        public MessageTemplateGuidEmptyException()
        {
        }

        public MessageTemplateGuidEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }

        public MessageTemplateGuidEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}