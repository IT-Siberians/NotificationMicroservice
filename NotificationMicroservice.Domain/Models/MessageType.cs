using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Exception.Resources;
using NotificationMicroservice.Domain.Interfaces.Model;

namespace NotificationMicroservice.Domain.Models
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

        private Guid _id;
        private string _name;
        private bool _isRemove;
        private string _createUserName;
        private DateTime _createDate;
        private string? _modifyUserName;
        private DateTime? _modifyDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get => _name; }

        /// <summary>
        /// Статус удаления типа
        /// </summary>
        public bool IsRemove { get => _isRemove; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreateUserName { get => _createUserName; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifyUserName { get => _modifyUserName; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifyDate { get => _modifyDate; }

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
                throw new MessageTypeGuidEmptyException(ExceptionStrings.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionStrings.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENG)
            {
                throw new MessageTypeNameLengthException(ExceptionStrings.ERROR_TYPE_NAME_LENG, name.Length.ToString());
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionStrings.ERROR_USERNAME, createUserName);
            }

            _id = id;
            _name = name;
            _isRemove = isRemove;
            _createUserName = createUserName;
            _createDate = createDate;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
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
                throw new MessageTypeNameNullOrEmptyException(ExceptionStrings.ERROR_TYPE_NAME, name);
            }

            if (name.Length > MAX_NAME_LENG)
            {
                throw new MessageTypeNameLengthException(ExceptionStrings.ERROR_TYPE_NAME_LENG, name.Length.ToString());
            }

            if (string.IsNullOrEmpty(modifyUserName))
            {
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionStrings.ERROR_USERNAME, modifyUserName);
            }

            _name = name;
            _isRemove = isRemove;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
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
                throw new MessageTypeUserNameNullOrEmptyException(ExceptionStrings.ERROR_USERNAME, modifyUserName);
            }

            _isRemove = true;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }

    }

}
