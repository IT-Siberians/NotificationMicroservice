using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Exception.MessageType;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Тип шаблона сообщения
    /// </summary>
    public class MessageType : IModifyEntity<string, Guid>
    {
        /// <summary>
        /// Максимальная длина названия для типа сообщения
        /// </summary>
        public const int MAX_NAME_LENGTH = 50;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Статус удаления типа
        /// </summary>
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreatedUserName { get; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifiedUserName { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifiedDate { get; private set; }

        /// <summary>
        /// Основной конструктор класса (новая сущность)
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="createdUserName">пользователь создавший тип сообщения</param>
        /// <param name="creationDate">дата и время создания типа сообщения</param>
        /// <param name="modifiedUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifiedDate">дата и время изменения типа сообщения</param>
        public MessageType(Guid id, string name, bool isRemoved, string createdUserName, DateTime creationDate, string? modifiedUserName, DateTime? modifiedDate)
        {
            if (id == Guid.Empty)
            {
                throw new MessageTypeGuidEmptyException(ExceptionMessages.ERROR_ID, id.ToString());
            }

            ValidateData(name, createdUserName);

            Id = id;
            Name = name;
            IsRemoved = isRemoved;
            CreatedUserName = createdUserName;
            CreationDate = creationDate;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Обновление типа сообщения
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="modifiedUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifiedDate">дата и время изменения типа сообщения</param>
        public void Update(string name, bool isRemoved, string modifiedUserName, DateTime modifiedDate)
        {
            ValidateData(name, modifiedUserName);

            Name = name;
            IsRemoved = isRemoved;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Деактивация типа сообщения (пометить как удалённый)
        /// </summary>
        /// <param name="modifiedUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        public void Delete(string modifiedUserName, DateTime modifiedDate)
        {
            ValidateUserName(modifiedUserName);

            IsRemoved = true;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Валидация входных данных
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="userName">имя пользователя</param>
        private static void ValidateData(string name, string userName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionMessages.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                throw new MessageTypeNameLengthException(ExceptionMessages.ERROR_TYPE_NAME_LENGTH, name.Length.ToString());
            }

            ValidateUserName(userName);
        }

        /// <summary>
        /// Валидация имени пользователя
        /// </summary>
        /// <param name="userName">имя пользователя</param>
        private static void ValidateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionMessages.ERROR_USERNAME, userName);
            }
        }
    }

}
