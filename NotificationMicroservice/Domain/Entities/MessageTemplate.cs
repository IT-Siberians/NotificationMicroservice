/// <summary>
/// Шаблон сообщения
/// </summary>
namespace NotificationMicroservice.Domain.Entities
{
    public class MessageTemplate<T>
    {
        public T _id;
        public string _template;
        public string _createUserName;
        public DateTime _createDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public T Id { get => _id; }

        /// <summary>
        /// Название шаблона сообщений
        /// </summary>
        public string Template { get => _template; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreateUserName { get => _createUserName; }

        /// <summary>
        /// Дата создания шаблона сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

        public MessageTemplate(T id, string template, string createUserName, DateTime createDate)
        { 
            _id = id;
            _template = template;
            _createUserName = createUserName;
            _createDate = createDate;
        }
        public void NewMessageTemplate(string template, string createUserName, DateTime createDate)
        {
            _template = template;
            _createUserName = createUserName;
            _createDate = createDate;
        }
    }
}
