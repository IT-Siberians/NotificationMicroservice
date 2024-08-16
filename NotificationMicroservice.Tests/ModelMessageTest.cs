using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Entities;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelMessageTest
    {
        [Fact]
        public void Constructor_Should_Create_Message_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var text = "Test message";
            var direction = "Outgoing";
            var createDate = DateTime.Now;

            // Act
            var message = new Message(id, type, text, direction, createDate);

            // Assert
            Assert.Equal(id, message.Id);
            Assert.Equal(type, message.Type);
            Assert.Equal(text, message.Text);
            Assert.Equal(direction, message.Direction);
            Assert.Equal(createDate, message.CreateDate);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Text_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var direction = "Outgoing";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTextNullOrEmptyException>(() => new Message(id, type, string.Empty, direction, createDate));
            Assert.Equal(ExceptionString.ERROR_TEXT, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Text_WhiteSpace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var direction = "Outgoing";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTextNullOrEmptyException>(() => new Message(id, type, " ", direction, createDate));
            Assert.Equal(ExceptionString.ERROR_TEXT + " (Parameter ' ')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Direction_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var text = "Test message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageDirectionNullOrEmptyException>(() => new Message(id, type, text, string.Empty, createDate));
            Assert.Equal(ExceptionString.ERROR_DIRECTION, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Direction_Is_WhiteSpace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var text = "Test message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageDirectionNullOrEmptyException>(() => new Message(id, type, text, "  ", createDate));
            Assert.Equal(ExceptionString.ERROR_DIRECTION + " (Parameter '  ')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Direction_Exceeds_MaxLength()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var text = "Test message";
            var direction = new string('A', Message.MAX_DIRECTION_LENG + 1);
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageDirectionLengthException>(() => new Message(id, type, text, direction, createDate));
            Assert.Equal(ExceptionString.ERROR_DIRECTION_LENG + $" (Parameter '{Message.MAX_DIRECTION_LENG + 1}')", exception.Message);
        }


        private MessageType GetType()
        {
            return new MessageType(Guid.NewGuid(), "Тип сообщения", false, "Admin1", DateTime.UtcNow, null, null);
        }

    }
}
