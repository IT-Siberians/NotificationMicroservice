using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Exception.Resources;
using NotificationMicroservice.Domain.Models;
using Xunit;

namespace NotificationMicroservice.Tests
{
    public class ModelTypeTest
    {
        [Fact]
        public void Constructor_Should_Create_MessageType_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "TestType";
            var isRemove = false;
            var createUserName = "Creator";
            var createDate = DateTime.Now;
            var modifyUserName = "Modifier";
            var modifyDate = DateTime.Now;

            // Act
            var messageType = new MessageType(id, name, isRemove, createUserName, createDate, modifyUserName, modifyDate);

            // Assert
            Assert.Equal(id, messageType.Id);
            Assert.Equal(name, messageType.Name);
            Assert.Equal(isRemove, messageType.IsRemove);
            Assert.Equal(createUserName, messageType.CreateUserName);
            Assert.Equal(createDate, messageType.CreateDate);
            Assert.Equal(modifyUserName, messageType.ModifyUserName);
            Assert.Equal(modifyDate, messageType.ModifyDate);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Id_Is_Empty()
        {
            // Arrange
            var name = "TestType";
            var isRemove = false;
            var createUserName = "Creator";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeGuidEmptyException>(() =>
                new MessageType(Guid.Empty, name, isRemove, createUserName, createDate, null, null));
            Assert.Equal(ExceptionStrings.ERROR_ID + $" (Parameter '{Guid.Empty}')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Name_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var isRemove = false;
            var createUserName = "Creator";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeNameNullOrEmptyException>(() =>
                new MessageType(id, string.Empty, isRemove, createUserName, createDate, null, null));
            Assert.Equal(ExceptionStrings.ERROR_TYPE_NAME, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Name_Exceeds_MaxLength()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new string('A', MessageType.MAX_NAME_LENG + 1);
            var isRemove = false;
            var createUserName = "Creator";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeNameLengthException>(() =>
                new MessageType(id, name, isRemove, createUserName, createDate, null, null));
            Assert.Equal(ExceptionStrings.ERROR_TYPE_NAME_LENG + $" (Parameter '{MessageType.MAX_NAME_LENG + 1}')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_CreateUserName_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "TestType";
            var isRemove = false;
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeUserNameNullOrEmptyException>(() =>
                new MessageType(id, name, isRemove, string.Empty, createDate, null, null));
            Assert.Equal(ExceptionStrings.ERROR_USERNAME, exception.Message);
        }

        [Fact]
        public void Update_Should_Update_MessageType_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var messageType = new MessageType(id, "OldName", false, "Creator", DateTime.Now, null, null);
            var newName = "NewName";
            var isRemove = true;
            var modifyUserName = "Modifier";
            var modifyDate = DateTime.Now;

            // Act
            messageType.Update(newName, isRemove, modifyUserName, modifyDate);

            // Assert
            Assert.Equal(newName, messageType.Name);
            Assert.Equal(isRemove, messageType.IsRemove);
            Assert.Equal(modifyUserName, messageType.ModifyUserName);
            Assert.Equal(modifyDate, messageType.ModifyDate);
        }

        [Fact]
        public void Update_Should_ThrowException_When_Name_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var messageType = new MessageType(id, "OldName", false, "Creator", DateTime.Now, null, null);

            // Act & Assert
            var exception = Assert.Throws<MessageTypeNameNullOrEmptyException>(() =>
                messageType.Update(string.Empty, false, "Modifier", DateTime.Now));
            Assert.Equal(ExceptionStrings.ERROR_TYPE_NAME, exception.Message);
        }

        [Fact]
        public void Delete_Should_Set_IsRemove_To_True_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var messageType = new MessageType(id, "TestType", false, "Creator", DateTime.Now, null, null);
            var modifyUserName = "Modifier";
            var modifyDate = DateTime.Now;

            // Act
            messageType.Delete(modifyUserName, modifyDate);

            // Assert
            Assert.True(messageType.IsRemove);
            Assert.Equal(modifyUserName, messageType.ModifyUserName);
            Assert.Equal(modifyDate, messageType.ModifyDate);
        }

        [Fact]
        public void Delete_Should_ThrowException_When_ModifyUserName_Is_NullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var messageType = new MessageType(id, "TestType", false, "Creator", DateTime.Now, null, null);

            // Act & Assert
            var exception = Assert.Throws<MessageTypeUserNameNullOrEmptyException>(() =>
                messageType.Delete(string.Empty, DateTime.Now));
            Assert.Equal(ExceptionStrings.ERROR_USERNAME, exception.Message);
        }
    }
}
