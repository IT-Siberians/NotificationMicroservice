using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Exception.MessageTemplate;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Шаблон сообщения
    /// </summary>
    public class MessageTemplate : IModifyEntity<User, Guid>
    {
        /// <summary>
        /// Длинна кодировки языка шаблона сообщения (ISO 639-3)
        /// </summary>
        public const int LANGUAGE_LENGTH = 3;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

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
        public User CreatedUser { get; }

        /// <summary>
        /// Дата создания шаблона сообщения
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public User? ModifiedUser { get; private set; }

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
        /// <param name="type">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="createdUser">пользователь создавший шаблон сообщения</param>
        /// <param name="creationDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifiedUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public MessageTemplate(MessageType type, string language, string template, bool isRemoved, User createdUser, DateTime creationDate, User? modifiedUser, DateTime? modifiedDate)
        {
            ValidateData(language, template, createdUser);

            Type = type;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            CreatedUser = createdUser;
            CreationDate = creationDate;
            ModifiedUser = modifiedUser;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Обновление класса
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="modifiedUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateLanguageNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateLanguageLengthException"></exception>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Update(MessageType messageType, string language, string template, bool isRemoved, User modifiedUser, DateTime modifiedDate)
        {

            ValidateData(language, template, modifiedUser);

            Type = messageType;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            ModifiedUser = modifiedUser;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Деактивация "Удаление"
        /// </summary>
        /// <param name="modifiedUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modifiedDate">дата и время изменения шаблона сообщения</param>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        public void Delete(User modifiedUser, DateTime modifiedDate)
        {

            ValidateUserName(modifiedUser);

            IsRemoved = true;
            ModifiedUser = modifiedUser;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Валидация имени пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="MessageTemplateUserNameNullOrEmptyException"></exception>
        private static void ValidateUserName(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                throw new MessageTemplateUserNameNullOrEmptyException(ExceptionMessages.ERROR_USERNAME, user.UserName);
            }
        }

        /// <summary>
        /// Валидация входных данных
        /// </summary>
        /// <param name="template"></param>
        /// <exception cref="MessageTemplateNullOrEmptyException"></exception>
        private static void ValidateData(string language, string template, User user)
        {
            if (string.IsNullOrWhiteSpace(template))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionMessages.ERROR_TEMPLATE, template);
            }

            if (string.IsNullOrWhiteSpace(language))
            {
                throw new MessageTemplateLanguageNullOrEmptyException(ExceptionMessages.ERROR_LANG_CODE);
            }

            if (language.Length != LANGUAGE_LENGTH)
            {
                throw new MessageTemplateLanguageLengthException(ExceptionMessages.ERROR_LANG_CODE_LENGTH, language.Length.ToString());
            }

            ValidateUserName(user);
        }
    }
}
