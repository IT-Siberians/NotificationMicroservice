namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateGuidEmptyException : ArgumentException
    {
        public MessageTemplateGuidEmptyException()
        {
        }

        public MessageTemplateGuidEmptyException(string? name) : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageTemplateGuidEmptyException(string? message, ArgumentException? innerException) : base(message, innerException)
        {
        }
    }
}