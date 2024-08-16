using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Exception.MessageTemplate;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelTemplateTest
    {
        [Fact]
        public void Constructor_Should_Create_MessageTemplate_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var language = "eng";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;

            // Act
            var messageTemplate = new MessageTemplate(id, type, language, template, false, userName, createDate, null, null);

            // Assert
            Assert.Equal(id, messageTemplate.Id);
            Assert.Equal(type, messageTemplate.MessageType);
            Assert.Equal(language, messageTemplate.Language);
            Assert.Equal(template, messageTemplate.Template);
            Assert.False(messageTemplate.IsRemove);
            Assert.Equal(userName, messageTemplate.CreateUserName);
            Assert.Equal(createDate, messageTemplate.CreateDate);
            Assert.Null(messageTemplate.ModifyUserName);
            Assert.Null(messageTemplate.ModifyDate);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_IdIsEmpty()
        {
            // Arrange
            var type = GetType();
            var language = "eng";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;

            // Act & Assert
            Assert.Throws<MessageTemplateGuidEmptyException>(() =>
                new MessageTemplate(Guid.Empty, type, language, template, false, userName, createDate, null, null));
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Language_IsNullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;

            // Act & Assert
            Assert.Throws<MessageTemplateLanguageNullOrEmptyException>(() =>
                new MessageTemplate(id, type, string.Empty, template, false, userName, createDate, null, null));
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Language_Length_IsInvalid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var language = "en";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;

            // Act & Assert
            Assert.Throws<MessageTemplateLanguageLengthException>(() =>
                new MessageTemplate(id, type, language, template, false, userName, createDate, null, null));
        }

        [Fact]
        public void Update_Should_Update_Fields_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var language = "eng";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;

            // Arrange
            var messageTemplate = new MessageTemplate(id, type, language, template, false, userName, createDate, null, null);
            var newMessageType = new MessageType(Guid.NewGuid(), "NewType", false, userName, createDate, null, null);
            var newLanguage = "fra";
            var newTemplate = "This is an updated template.";
            var newUserName = "NewUser";

            // Act
            messageTemplate.Update(newMessageType, newLanguage, newTemplate, true, newUserName, createDate);

            // Assert
            Assert.Equal(newMessageType, messageTemplate.MessageType);
            Assert.Equal(newLanguage, messageTemplate.Language);
            Assert.Equal(newTemplate, messageTemplate.Template);
            Assert.True(messageTemplate.IsRemove);
            Assert.Equal(newUserName, messageTemplate.ModifyUserName);
            Assert.Equal(createDate, messageTemplate.ModifyDate);
        }

        [Fact]
        public void Delete_Should_Set_IsRemove_ToTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var language = "eng";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;
            var messageTemplate = new MessageTemplate(id, type, language, template, false, userName, createDate, null, null);
            var newUserName = "NewUser";

            // Act
            messageTemplate.Delete(newUserName, createDate);

            // Assert
            Assert.True(messageTemplate.IsRemove);
            Assert.Equal(newUserName, messageTemplate.ModifyUserName);
            Assert.Equal(createDate, messageTemplate.ModifyDate);
        }

        [Fact]
        public void Delete_Should_ThrowException_When_UserName_IsNullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var type = GetType();
            var language = "eng";
            var template = "This is a test template.";
            var userName = "TestUser";
            var createDate = DateTime.Now;
            var messageTemplate = new MessageTemplate(id, type, language, template, false, userName, createDate, null, null);

            // Act & Assert
            var exception = Assert.Throws<MessageTemplateUserNameNullOrEmptyException>(() => messageTemplate.Delete(string.Empty, createDate));
            Assert.Equal(ExceptionStrings.ERROR_USERNAME, exception.Message);
        }

        private MessageType GetType()
        {
            return new MessageType(Guid.NewGuid(), "Тип сообщения", false, "Admin1", DateTime.UtcNow, null, null);
        }
    }
}
