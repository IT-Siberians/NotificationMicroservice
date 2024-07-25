namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateUserNameNullOrEmptyException : ArgumentException
    {
        public MessageTemplateUserNameNullOrEmptyException()
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}