using NotificationMicroservice.Domain.Interfaces.Model;
using System.Text;

namespace NotificationMicroservice.Domain.Models
{
    /// <summary>
    /// Шаблон сообщения
    /// </summary>
    public class MessageTemplate : IModifyEntity<string, Guid>
    {
        /// <summary>
        /// Длинна кодировки языка шаблона сообщения (ISO 639-3)
        /// </summary>
        public const int LANGUAGE_LENG = 3;

        private Guid _id;
        private MessageType _messageType;
        private string _language;
        private string _template;
        private bool _isActive;
        private string _createUserName;
        private DateTime _createDate;
        private string? _modifyUserName;
        private DateTime? _modifyDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType MessageType { get => _messageType; }

        /// <summary>
        /// Язык шаблона
        /// </summary>
        public string Language { get => _language; }

        /// <summary>
        /// Текс шаблона сообщений
        /// </summary>
        public string Template { get => _template; }

        /// <summary>
        /// Статус шаблона
        /// </summary>
        public bool IsActive { get => _isActive; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreateUserName { get => _createUserName; }

        /// <summary>
        /// Дата создания шаблона сообщения
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

        public MessageTemplate() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isActive">статус шаблона сообщения</param>
        /// <param name="createUserName">пользователь создавший шаблон сообщения</param>
        /// <param name="createDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        private MessageTemplate(Guid id, MessageType messageType, string language, string template, bool isActive, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {
            _id = id;
            _messageType = messageType;
            _language = language;
            _template = template;
            _isActive = isActive;
            _createUserName = createUserName;
            _createDate = createDate;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }

        /// <summary>
        /// Создание шаблона сообщения
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isActive">статус шаблона сообщения</param>
        /// <param name="createUserName">пользователь создавший шаблон сообщения</param>
        /// <param name="createDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        /// <returns>Кортеж (Сущность, Ошибки)</returns>
        public (MessageTemplate MessageTemplate, string Error) Create(Guid id, MessageType messageType, string language, string template, bool isActive, string createUserName, DateTime createDate, string? modifyUserName = null, DateTime? modifyDate = null)
        {
            var errorSb = new StringBuilder();

            if (id == Guid.Empty)
            {
                errorSb.AppendLine($"Identifier {id} cannot be empty");
            }

            if (string.IsNullOrEmpty(language) || language.Length != LANGUAGE_LENG)
            {
                errorSb.AppendLine($"Language code {language} cannot be empty or not match the encoding");
            }

            if (string.IsNullOrEmpty(template))
            {
                errorSb.AppendLine($"Template text cannot be empty");
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                errorSb.AppendLine($"CreateUser cannot be empty");
            }

            return (new MessageTemplate(id, messageType, language, template, isActive, createUserName, createDate, modifyUserName, modifyDate), errorSb.ToString());
        }

    }
}
