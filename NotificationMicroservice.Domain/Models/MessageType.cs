using NotificationMicroservice.Domain.Interfaces.Model;
using System.Text;

namespace NotificationMicroservice.Domain.Models
{
    /// <summary>
    /// Тип шаблона сообщения
    /// </summary>
    public class MessageType : IModifyEntity<string, Guid>
    {
        /// <summary>
        /// Максимальная длинна назнания для типа сообщения
        /// </summary>
        public const int MAX_NAME_LENG = 50;

        private Guid _id;
        private string _name;
        private string _createUserName;
        private DateTime _createDate;
        private string? _modifyUserName;
        private DateTime? _modifyDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

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

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifyUserName { get => _modifyUserName; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifyDate { get => _modifyDate; }

        public MessageType() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">название типа сообщения</param>
        /// <param name="createUserName">пользователь создавший тип сообщения</param>
        /// <param name="createDate">дата и время создания типа сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifyDate">дата и время изменения типа сообщения</param>
        private MessageType(Guid id, string name, string createUserName, DateTime createDate, string? modifyUserName, DateTime? modifyDate)
        {
            _id = id;
            _name = name;
            _createUserName = createUserName;
            _createDate = createDate;
            _modifyUserName = modifyUserName;
            _modifyDate = modifyDate;
        }

        /// <summary>
        /// Создание типа сообщения
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">название типа сообщения</param>
        /// <param name="createUserName">пользователь создавший тип сообщения</param>
        /// <param name="createDate">дата и время создания типа сообщения</param>
        /// <param name="modifyUserName">пользователь изменивший тип сообщения</param>
        /// <param name="modifyDate">дата и время изменения типа сообщения</param>
        /// <returns>Кортеж (Сущность, Ошибки)</returns>
        public (MessageType MessageType, string Error) Create(Guid id, string name, string createUserName, DateTime createDate, string? modifyUserName = null, DateTime? modifyDate = null)
        {
            var errorSb = new StringBuilder();

            if (id == Guid.Empty)
            {
                errorSb.AppendLine($"Identifier {id} cannot be empty");
            }

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENG)
            {
                errorSb.AppendLine($"Type name: {name} cannot be empty or more than {MAX_NAME_LENG} characters");
            }

            if (string.IsNullOrEmpty(createUserName))
            {
                errorSb.AppendLine($"CreateUser cannot be empty");
            }

            return (new MessageType(id, name, createUserName, createDate, modifyUserName, modifyDate), errorSb.ToString());
        }

    }

}
