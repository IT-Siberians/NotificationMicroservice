using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Interfaces.Model;
using NotificationMicroservice.Domain.Resources;

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
        /// Статус удаления шааблона
        /// </summary>
        public bool IsRemove { get => _isRemove; }

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

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemove">признак удаления типа сообщения</param>
        /// <param name="createUserName">пользователь создавший шаблон сообщения</param>
        /// <param name="createDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        public MessageTemplate(Guid id, MessageType messageType, string language, string template, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageTemplateGuidEmptyException(StringResources.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(StringResources.ERROR_LANG_CODE, language);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(StringResources.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }

            if (string.IsNullOrEmpty(template))
            {
                throw new MessageTemplateNullOrEmptyException(StringResources.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(StringResources.ERROR_USERNAME, createUserName);
            }

            _id = id;
            _messageType = messageType;
            _language = language;
            _template = template;
            _isRemove = isRemove;
            _createUserName = createUserName;
            _createDate = createDate;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }

        /// <summary>
        /// Обновление класса
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemove">признак удаления типа сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        public void Update(MessageType messageType, string language, string template, bool isRemove, string modifyUserName, DateTime modifyDate)
        {
            if (string.IsNullOrEmpty(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(StringResources.ERROR_LANG_CODE, language);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(StringResources.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }

            if (string.IsNullOrEmpty(template))
            {
                throw new MessageTemplateNullOrEmptyException(StringResources.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrEmpty(modifyUserName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(StringResources.ERROR_USERNAME, modifyUserName);
            }

            _messageType = messageType;
            _language = language;
            _template = template;
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
                throw new MessageTemplateUserNameNullOrEmptyException(StringResources.ERROR_USERNAME, modifyUserName);
            }

            _isRemove = true;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }
    }
}
