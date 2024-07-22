using System.Xml.Linq;

namespace NotificationMicroservice.Domain.Exception.MessageType
{
    [Serializable]
    internal class MessageTypeNameNullOrEmptyException : System.Exception
    {
        public MessageTypeNameNullOrEmptyException()
        {
        }

        public MessageTypeNameNullOrEmptyException(string? name) : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTypeNameNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}