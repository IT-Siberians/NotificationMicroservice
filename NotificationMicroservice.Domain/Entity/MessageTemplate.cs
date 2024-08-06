using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Exception.Resources;
using NotificationMicroservice.Domain.Interfaces.Model;

namespace NotificationMicroservice.Domain.Entity
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
        public bool IsRemove { get; private set; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreateUserName { get; }

        /// <summary>
        /// Дата создания шаблона сообщения
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
        /// <param name="isRemove">признак удаления типа сообщения</param>
        /// <param name="createUserName">пользователь создавший шаблон сообщения</param>
        /// <param name="createDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifyDate">дата и время изменения шаблона сообщения</param>
        public MessageTemplate(Guid id, MessageType type, string language, string template, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageTemplateGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionString.ERROR_LANG_CODE, language);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionString.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }

            if (string.IsNullOrEmpty(template))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionString.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, createUserName);
            }

            Id = id;
            Type = type;
            Language = language;
            Template = template;
            IsRemove = isRemove;
            CreateUserName = createUserName;
            CreateDate = createDate;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
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
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionString.ERROR_LANG_CODE, language);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionString.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }

            if (string.IsNullOrEmpty(template))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionString.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrEmpty(modifyUserName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, modifyUserName);
            }

            Type = messageType;
            Language = language;
            Template = template;
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
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionString.ERROR_USERNAME, modifyUserName);
            }

            IsRemove = true;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
        }
    }
}
