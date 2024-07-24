namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    internal class MessageTemplateGuidEmptyException : System.Exception
    {
        public MessageTemplateGuidEmptyException()
        {
        }

        public MessageTemplateGuidEmptyException(string? name) : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageTemplateGuidEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}