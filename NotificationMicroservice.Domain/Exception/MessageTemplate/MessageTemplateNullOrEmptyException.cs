namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateNullOrEmptyException : ArgumentException
    {
        public MessageTemplateNullOrEmptyException()
        {
        }

        public MessageTemplateNullOrEmptyException(string? name) : base($"The '{name}' text cannot be empty")
        {
        }

        public MessageTemplateNullOrEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}