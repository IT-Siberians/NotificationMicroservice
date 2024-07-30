using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Models;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelTypeTest
    {
        private readonly Guid _guidEmpty = Guid.Empty;
        private readonly Guid _guidTest = Guid.NewGuid();
        private readonly string _name = "Тип сообщения";
        private readonly string _nameNext = "Тип сообщения изменение";
        private readonly string _createUser = "Admin1";
        private readonly string _modifyUser = "Admin 2";
        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _nowNext = DateTime.Now;


        [Fact]
        public void TypeCreateOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);

            Assert.Equal(_guidTest, type.Id);
            Assert.Equal(_name, type.Name);
            Assert.Equal(_createUser, type.CreateUserName);
            Assert.False(type.IsRemove);
            Assert.Equal(_now, type.CreateDate);
            Assert.Equal(null, type.ModifyUserName);
            Assert.Equal(null, type.ModifyDate);
        }
        
        [Fact]
        public void TypeCreateNotNull()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);

            Assert.NotNull(type);
        }

        [Fact]
        public void MessageCreateTypeOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);

            Assert.IsType<MessageType>(type);
        }

        [Fact]
        public void TypeUpdateOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);

            type.Update(_nameNext, false, _modifyUser, _nowNext);

            Assert.Equal(_nameNext, type.Name);
            Assert.False(type.IsRemove);
            Assert.Equal(_modifyUser, type.ModifyUserName);
            Assert.Equal(_nowNext, type.ModifyDate);
        }

        [Fact]
        public void TypeDeleteOk()
        {
            var type = new MessageType(_guidTest, _nameNext, false, _createUser, _now, null, null);

            type.Delete(_createUser, _nowNext);

            Assert.True(type.IsRemove);
            Assert.Equal(_createUser, type.ModifyUserName);
            Assert.Equal(_nowNext, type.ModifyDate);
        }

        [Fact]
        public async Task ExceptionGuidEmpty()
        {
            await Assert.ThrowsAsync<MessageTypeGuidEmptyException>(() => MethodGuidEmpty());
        }

        [Fact]
        public async Task ExceptionNameLength()
        {
            await Assert.ThrowsAsync<MessageTypeNameLengthException>(() => MethodMessageTypeNameLength());
        }

        [Fact]
        public async Task ExceptionNameNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTypeNameNullOrEmptyException>(() => MethodMessageTypeNameNullOrEmpty());
        }
        [Fact]
        public async Task ExceptionUserNameNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTypeUserNameNullOrEmptyException>(() => MethodMessageTypeUserNameNullOrEmpty());
        }

        private Task MethodGuidEmpty()
        {
            throw new MessageTypeGuidEmptyException("Null GUID", _guidTest.ToString());
        }
        private Task MethodMessageTypeNameLength()
        {
            throw new MessageTypeNameLengthException("Big Length TypeName", _name.Length.ToString());
        }
        private Task MethodMessageTypeNameNullOrEmpty()
        {
            throw new MessageTypeNameNullOrEmptyException("Null TypeName", _name);
        }
        private Task MethodMessageTypeUserNameNullOrEmpty()
        {
            throw new MessageTypeUserNameNullOrEmptyException("Null UserName", _createUser);
        }

    }
}
