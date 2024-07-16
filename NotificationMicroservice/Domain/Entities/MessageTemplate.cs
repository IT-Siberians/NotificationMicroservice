/// <summary>
/// Шаблон сообщения
/// </summary>
namespace NotificationMicroservice.Domain.Entities
{
    public class MessageTemplate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название шаблона сообщений
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreateUserName { get; private set; }

        /// <summary>
        /// Дата создания шаблона сообщения
        /// </summary>
        public DateTime CreateDate { get; private set; }

        public MessageTemplate(Guid id, string name, string createUserName, DateTime createDate)
        { 
            Id = id;
            Name = name;
            CreateUserName = createUserName;
            CreateDate = createDate;
        }
    }
}
