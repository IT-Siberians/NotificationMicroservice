using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Models;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelMessageTest
    {
        private readonly Guid _guidEmpty = Guid.Empty;
        private readonly Guid _guidTest = Guid.NewGuid();
        private readonly string _name = "Тип сообщения";
        private readonly string _nameNext = "Тип сообщения изменение";
        private readonly string _createUser = "Admin1";
        private readonly string _modifyUser = "Admin 2";
        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _nowNext = DateTime.Now;
        private readonly string _direction = "Email";
        private readonly string _messageText = "Какой-то текст уведомления";

        [Fact]
        public void MessageCreateOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);
            var message = new Message(_guidTest, type, _messageText, _direction, _now);

            Assert.Equal(_guidTest, message.Id);
            Assert.Equal(type, message.MessageType);
            Assert.Equal(_messageText, message.MessageText);
            Assert.Equal(_direction, message.Direction);
            Assert.Equal(_now, message.CreateDate);

        }

        [Fact]
        public async Task ExceptionGuidEmpty()
        {
            await Assert.ThrowsAsync<MessageGuidEmptyException>(() => MethodGuidEmpty());
        }

        [Fact]
        public async Task ExceptionDirectionLength()
        {
            await Assert.ThrowsAsync<MessageDirectionLengthException>(() => MethodMessageDirectionLength());
        }

        [Fact]
        public async Task ExceptionDirectionNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageDirectionNullOrEmptyException>(() => MethodMessageDirectionNullOrEmpty());
        }
        [Fact]
        public async Task ExceptionTextNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTextNullOrEmptyException>(() => MethodMessageTextNullOrEmpty());
        }

        private Task MethodGuidEmpty()
        {
            throw new MessageGuidEmptyException("Null GUID", _guidTest.ToString());
        }
        private Task MethodMessageDirectionLength()
        {
            throw new MessageDirectionLengthException("Big Length Direction", _direction.Length.ToString());
        }
        private Task MethodMessageDirectionNullOrEmpty()
        {
            throw new MessageDirectionNullOrEmptyException("Null Direction", _direction);
        }
        private Task MethodMessageTextNullOrEmpty()
        {
            throw new MessageTextNullOrEmptyException("Null Text", _messageText);
        }
    }
}
