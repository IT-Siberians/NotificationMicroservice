namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    [Serializable]
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