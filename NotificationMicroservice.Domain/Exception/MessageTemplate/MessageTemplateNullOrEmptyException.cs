namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    public class MessageTemplateNullOrEmptyException : ArgumentException
    {
        public MessageTemplateNullOrEmptyException()
        {
        }

        public MessageTemplateNullOrEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }

        public MessageTemplateNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}