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
        /// Максимальная длинна назнания для типа сообщения
        /// </summary>
        public const int MAX_NAME_LENG = 50;

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
        public bool IsRemove { get; private set; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreateUserName { get; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifyUserName { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifyDate { get; private set; }

        /// <summary>
        /// Основной конструктор класса (новая сущность)
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemove">признак удаления типа сообщения</param>
        /// <param name="createUserName">пользователь создавший тип сообщения</param>
        /// <param name="createDate">дата и время создания типа сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifyDate">дата и время изменения типа сообщения</param>
        /// <returns>Сущность</returns>
        /// <exception cref="MessageTypeGuidEmptyException"></exception>
        /// <exception cref="MessageTypeNameNullOrEmptyException"></exception>
        /// <exception cref="MessageTypeNameLengthException"></exception>
        /// <exception cref="MessageTypeUserNameNullOrEmptyException"></exception>
        public MessageType(Guid id, string name, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {
            if (id == Guid.Empty)
            {
                throw new MessageTypeGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            ValidateData(name, createUserName);

            Id = id;
            Name = name;
            IsRemove = isRemove;
            CreateUserName = createUserName;
            CreateDate = createDate;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
        }

        /// <summary>
        /// Обновление типа сообщения
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemove">признак удаления типа сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifyDate">дата и время изменения типа сообщения</param>
        /// <exception cref="MessageTypeNameNullOrEmptyException"></exception>
        /// <exception cref="MessageTypeNameLengthException"></exception>
        /// <exception cref="MessageTypeUserNameNullOrEmptyException"></exception>
        public void Update(string name, bool isRemove, string modifyUserName, DateTime modifyDate)
        {
            ValidateData(name, modifyUserName);

            Name = name;
            IsRemove = isRemove;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
        }

        /// <summary>
        /// Деактивация "Удаление"
        /// </summary>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTypeUserNameNullOrEmptyException"></exception>
        public void Delete(string modifyUserName, DateTime modifyDate)
        {
            ValidateUserName(modifyUserName);

            IsRemove = true;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
        }

        /// <summary>
        /// Валидация входных данных
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="MessageTypeNameNullOrEmptyException"></exception>
        /// <exception cref="MessageTypeNameLengthException"></exception>
        private static void ValidateData(string name, string userName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionString.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENG)
            {
                throw new MessageTypeNameLengthException(ExceptionString.ERROR_TYPE_NAME_LENG, name.Length.ToString());
            }

            ValidateUserName(userName);
        }

        /// <summary>
        /// Валидация имени пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="MessageTypeUserNameNullOrEmptyException"></exception>
        private static void ValidateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, userName);
            }
        }

    }

}
