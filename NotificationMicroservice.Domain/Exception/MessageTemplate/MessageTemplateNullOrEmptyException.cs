namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateNullOrEmptyException : ArgumentException
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