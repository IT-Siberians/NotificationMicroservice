using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Exception.Resources;
using NotificationMicroservice.Domain.Interfaces.Model;

namespace NotificationMicroservice.Domain.Entity
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
        public MessageType(Guid id, string name, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {
            if (id == Guid.Empty)
            {
                throw new MessageTypeGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionString.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENG)
            {
                throw new MessageTypeNameLengthException(ExceptionString.ERROR_TYPE_NAME_LENG, name.Length.ToString());
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, createUserName);
            }

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
        public void Update(string name, bool isRemove, string modifyUserName, DateTime modifyDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionString.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENG)
            {
                throw new MessageTypeNameLengthException(ExceptionString.ERROR_TYPE_NAME_LENG, name.Length.ToString());
            }

            if (string.IsNullOrEmpty(modifyUserName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, modifyUserName);
            }

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
        public void Delete(string modifyUserName, DateTime modifyDate)
        {
            if (string.IsNullOrEmpty(modifyUserName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, modifyUserName);
            }

            IsRemove = true;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
        }

    }

}
