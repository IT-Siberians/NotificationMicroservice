namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    [Serializable]
    internal class MessageTemplateLanguageLengthException : System.Exception
    {
        public MessageTemplateLanguageLengthException()
        {
        }

        public MessageTemplateLanguageLengthException(string? name) : base($"Language code '{name}' not match the encoding")
        {
        }

        public MessageTemplateLanguageLengthException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}