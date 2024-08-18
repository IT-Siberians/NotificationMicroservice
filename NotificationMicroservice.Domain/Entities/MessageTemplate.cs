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
        /// <exception cref="MessageTemplateGuidEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public MessageTemplate(Guid id, MessageType type, string language, string template, bool isRemove, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageTemplateGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            ValidateData(language, template, createUserName);

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
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Update(MessageType messageType, string language, string template, bool isRemove, string modifyUserName, DateTime modifyDate)
        {
            ValidateData(language, template, modifyUserName);

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
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Delete(string modifyUserName, DateTime modifyDate)
        {

            ValidateUserName(modifyUserName);

            IsRemove = true;
            ModifyUserName = modifyUserName;
            ModifyDate = modifyDate;
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
            if (string.IsNullOrWhiteSpace(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionString.ERROR_LANG_CODE);
            }

            if (language.Length != LANGUAGE_LENG)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionString.ERROR_LANG_CODE_LENG, language.Length.ToString());
            }

            if (string.IsNullOrWhiteSpace(template))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionString.ERROR_TEMPLATE, template);
            }

            ValidateUserName(userName);
        }

    }
}
