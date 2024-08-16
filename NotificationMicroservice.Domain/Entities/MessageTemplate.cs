using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Entities.Base;
using System.Xml.Linq;

namespace NotificationMicroservice.Domain.Entities
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
        /// <exception cref="MessageTemplateGuidEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public MessageTemplate(Guid id, MessageType messageType, string language, string template, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageTemplateGuidEmptyException(ExceptionStrings.ERROR_ID, id.ToString());
            }

            ValidateLanguage(language);

            ValidateTemplate(template);

            ValidateUserName(createUserName);

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
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Update(MessageType messageType, string language, string template, bool isRemove, string modifyUserName, DateTime modifyDate)
        {

            ValidateLanguage(language);

            ValidateTemplate(template);            

            ValidateUserName(modifyUserName);

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
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Delete(string modifyUserName, DateTime modifyDate)
        {

            ValidateUserName(modifyUserName);

            _isRemove = true;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }


        /// <summary>
        /// Валидация имени пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        private static void ValidateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName) || userName.Trim().Length == 0)
            {
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionStrings.ERROR_USERNAME, userName);
            }
        }

        /// <summary>
        /// Валидация текста шаблона
        /// </summary>
        /// <param name="template"></param>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        private static void ValidateTemplate(string template)
        {
            if (string.IsNullOrEmpty(template) || template.Trim().Length == 0)
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionStrings.ERROR_TEMPLATE, template);
            }
        }

        /// <summary>
        /// Валидация значения кодирования языка
        /// </summary>
        /// <param name="language"></param>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        private static void ValidateLanguage(string language)
        {
            if (string.IsNullOrEmpty(language) || language.Trim().Length == 0)
            {
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionStrings.ERROR_LANG_CODE);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionStrings.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }
        }
    }
}
