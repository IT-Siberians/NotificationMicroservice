/// <summary>
/// Тип шаблона сообщения
/// </summary>
namespace NotificationMicroservice.Domain.Entities
{
    public class MessageType<T>
    {
        public T _id;
        public string _name;
        public string _createUserName;
        public DateTime _createDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public T Id { get => _id; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get => _name; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreateUserName { get => _createUserName; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

        public MessageType(T id, string name, string createUserName, DateTime createDate)
        {
            _id = id;
            _name = name;
            _createUserName = createUserName;
            _createDate = createDate;
        }
        public void NewMessageType(string name, string createUserName, DateTime createDate)
        {
            _name = name;
            _createUserName = createUserName;
            _createDate = createDate;
        }
    }

}
