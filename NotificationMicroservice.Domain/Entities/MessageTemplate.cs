using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Exception.MessageTemplate;

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
        public const int LANGUAGE_LENGTH = 3;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType Type { get; private set; }

        /// <summary>
        /// Язык шаблона
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// Текс шаблона сообщений
        /// </summary>
        public string Template { get; private set; }

        /// <summary>
        /// Статус удаления шааблона
        /// </summary>
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreatedUserName { get; }

        /// <summary>
        /// Дата создания шаблона сообщения
        /// </summary>
        public DateTime CreatedDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifiedUserName { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifiedDate { get; private set; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
        protected MessageTemplate() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="type">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="createdUserName">пользователь создавший шаблон сообщения</param>
        /// <param name="createdDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifiedUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateGuidEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public MessageTemplate(Guid id, MessageType type, string language, string template, bool isRemoved, string createdUserName, DateTime createdDate, string? modifiedUserName, DateTime? modifiedDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageTemplateGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            ValidateData(language, template, createdUserName);

            Id = id;
            Type = type;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            CreatedUserName = createdUserName;
            CreatedDate = createdDate;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Обновление класса
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="modifiedUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Update(MessageType messageType, string language, string template, bool isRemoved, string modifiedUserName, DateTime modifiedDate)
        {

            ValidateData(language, template, modifiedUserName);

            Type = messageType;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Деактивация "Удаление"
        /// </summary>
        /// <param name="modifiedUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Delete(string modifiedUserName, DateTime modifiedDate)
        {

            ValidateUserName(modifiedUserName);

            IsRemoved = true;
            ModifiedUserName = modifiedUserName;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Валидация имени пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        private static void ValidateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, userName);
            }
        }

        /// <summary>
        /// Валидация входных данных
        /// </summary>
        /// <param name="template"></param>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        private static void ValidateData(string language, string template, string userName)
        {
            if (string.IsNullOrWhiteSpace(template))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionString.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrWhiteSpace(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionString.ERROR_LANG_CODE);
            }

            if (language.Length != LANGUAGE_LENGTH)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionString.ERROR_LANG_CODE_LENGTH, language.Length.ToString());
            }

            ValidateUserName(userName);
        }
    }
}
