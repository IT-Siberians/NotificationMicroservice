/// <summary>
/// Тип шаблона сообщения
/// </summary>
namespace NotificationMicroservice.Domain.Entities
{
    public class MessageType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreateUserName { get; private set; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreateDate { get; private set; }

        public MessageType(Guid id, string name, string createUserName, DateTime createDate)
        {
            Id = id;
            Name = name;
            CreateUserName = createUserName;
            CreateDate = createDate;
        }
    }

}
