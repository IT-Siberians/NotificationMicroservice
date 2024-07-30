using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Models;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelTemplateTest
    {
        private readonly Guid _guidEmpty = Guid.Empty;
        private readonly Guid _guidTest = Guid.NewGuid();
        private readonly string _name = "Тип сообщения";
        private readonly string _nameNext = "Тип сообщения изменение";
        private readonly string _createUser = "Admin1";
        private readonly string _modifyUser = "Admin 2";
        private readonly DateTime _now = DateTime.Now;
        private readonly DateTime _nowNext = DateTime.Now;
        private readonly string _language = "rus";
        private readonly string _template = "Какой-то текст уведомления";

        [Fact]
        public void TemplateCreateOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);
            var template = new MessageTemplate(_guidTest, type, _language, _template, false, _createUser, _now, null, null);

            Assert.Equal(_guidTest, template.Id);
            Assert.Equal(type, template.MessageType);
            Assert.Equal(_language, template.Language);
            Assert.Equal(_template, template.Template);
            Assert.False(template.IsRemove);
            Assert.Equal(_createUser, template.CreateUserName);            
            Assert.Equal(_now, template.CreateDate);
            Assert.Equal(null, template.ModifyUserName);
            Assert.Equal(null, template.ModifyDate);

        }

        [Fact]
        public void TemplateCreateNotNull()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);
            var template = new MessageTemplate(_guidTest, type, _language, _template, false, _createUser, _now, null, null);

            Assert.NotNull(template);
        }

        [Fact]
        public void TemplateCreateTypeOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);
            var template = new MessageTemplate(_guidTest, type, _language, _template, false, _createUser, _now, null, null);

            Assert.IsType<MessageTemplate>(template);
        }

        [Fact]
        public void TemplateUpdateOk()
        {
            var type = new MessageType(_guidTest, _name, false, _modifyUser, _nowNext, null, null);
            var template = new MessageTemplate(_guidTest, type, _language, _template, false, _createUser, _now, null, null);

            template.Update(type,_language, _template, false, _modifyUser, _nowNext);

            Assert.Equal(type, template.MessageType);
            Assert.Equal(_language, template.Language);
            Assert.Equal(_template, template.Template);
            Assert.False(template.IsRemove);
            Assert.Equal(_createUser, template.CreateUserName);
            Assert.Equal(_now, template.CreateDate);
            Assert.Equal(_modifyUser, template.ModifyUserName);
            Assert.Equal(_nowNext, template.ModifyDate);
        }

        [Fact]
        public void TemplateDeleteOk()
        {
            var type = new MessageType(_guidTest, _name, false, _createUser, _now, null, null);
            var template = new MessageTemplate(_guidTest, type, _language, _template, false, _createUser, _now, null, null);

            template.Delete(_createUser, _nowNext);

            Assert.True(template.IsRemove);
            Assert.Equal(_createUser, template.ModifyUserName);
            Assert.Equal(_nowNext, template.ModifyDate);
        }

        [Fact]
        public async Task ExceptionGuidEmpty()
        {
            await Assert.ThrowsAsync<MessageTemplateGuidEmptyException>(() => MethodGuidEmpty());
        }

        [Fact]
        public async Task ExceptionTemplateLanguageLength()
        {
            await Assert.ThrowsAsync<MessageTemplateLanguageLengthException>(() => MethodMessageTemplateLanguageLength());
        }

        [Fact]
        public async Task ExceptionTemplateLanguageNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTemplateLanguageNullOrEmptyException>(() => MethodMessageTemplateLanguageNullOrEmpty());
        }

        [Fact]
        public async Task ExceptionTemplateNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTemplateNullOrEmptyException>(() => MethodMessageTemplateNullOrEmpty());
        }

        [Fact]
        public async Task ExceptionUserNameNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTemplateUserNameNullOrEmptyException>(() => MethodMessageTemplateUserNameNullOrEmpty());
        }

        private Task MethodGuidEmpty()
        {
            throw new MessageTemplateGuidEmptyException("Null GUID", _guidTest.ToString());
        }
        private Task MethodMessageTemplateLanguageLength()
        {
            throw new MessageTemplateLanguageLengthException("Big Length Language", _language.Length.ToString());
        }
        private Task MethodMessageTemplateLanguageNullOrEmpty()
        {
            throw new MessageTemplateLanguageNullOrEmptyException("Null Language", _language);
        }
        private Task MethodMessageTemplateNullOrEmpty()
        {
            throw new MessageTemplateNullOrEmptyException("Null Template", _template);
        }
        private Task MethodMessageTemplateUserNameNullOrEmpty()
        {
            throw new MessageTemplateUserNameNullOrEmptyException("Null UserName", _modifyUser);
        }
    }
}
