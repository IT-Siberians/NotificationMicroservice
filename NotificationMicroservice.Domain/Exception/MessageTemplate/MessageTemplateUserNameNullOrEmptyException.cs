namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateUserNameNullOrEmptyException : ArgumentException
    {
        public MessageTemplateUserNameNullOrEmptyException()
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTemplateUserNameNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}