using NotificationMicroservice.DataAccess.ValueObject;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.DataAccess.Models
{
    public class BusQueue : IModifyEntity<Guid>
    {
        /// <summary>
        /// Минимальная длина QueueName
        /// </summary>
        public const int MIN_QUEUENAME_LENGTH = 5;

        /// <summary>
        /// Максимальная длина QueueName
        /// </summary>
        public const int MAX_QUEUENAME_LENGTH = 30;

        /// <summary>
        /// Идентификатор очереди.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Тип очереди сообщений.
        /// </summary>
        public QueueName QueueName { get; }

        /// <summary>
        /// Тип сообщения.
        /// </summary>
        public MessageType Type { get; private set; }

        /// <summary>
        /// Статус удаления шаблона.
        /// </summary>
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Пользователь, создавший шаблон сообщения.
        /// </summary>
        public User CreatedByUser { get; }

        /// <summary>
        /// Дата создания шаблона сообщения.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пользователь, изменивший шаблон сообщения.
        /// </summary>
        public User? ModifiedByUser { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения.
        /// </summary>
        public DateTime? ModificationDate { get; private set; }

        /// <summary>
        /// Пустой конструктор для EF Core.
        /// </summary>
#pragma warning disable CS8618
        protected BusQueue() { }
#pragma warning disable CS8618

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Message"/>.
        /// </summary>
        /// <param name="queueName">Тип очереди сообщений.</param>
        /// <param name="type">Тип сообщения.</param>
        /// <param name="isRemoved">Статус удаления шаблона.</param>
        /// <param name="createdByUser">Пользователь, создавший шаблон сообщения.</param>
        /// <param name="creationDate">Дата создания шаблона сообщения.</param>
        /// <param name="modifiedByUser">Пользователь, изменивший шаблон сообщения.</param>
        /// <param name="modificationDate">Дата изменения шаблона сообщения.</param>
        public BusQueue(QueueName queueName, MessageType type, bool isRemoved, User createdByUser, DateTime creationDate, User? modifiedByUser, DateTime? modificationDate)
        {
            this.QueueName = queueName;
            Type = type;
            IsRemoved = isRemoved;
            CreatedByUser = createdByUser;
            CreationDate = creationDate;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Обновление типа сообщения.
        /// </summary>
        /// <param name="type">Название типа сообщения.</param>
        /// <param name="isRemoved">Статус удаления шаблона.</param>
        /// <param name="modifiedByUser">Пользователь, изменивший тип сообщения.</param>
        /// <param name="modificationDate">Дата и время изменения типа сообщения.</param>
        public void Update(MessageType type, bool isRemoved, User modifiedByUser, DateTime modificationDate)
        {
            Type = type;
            IsRemoved = isRemoved;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Деактивация типа сообщения (пометить как удалённый).
        /// </summary>
        /// <param name="modifiedByUser">Пользователь, изменивший шаблон сообщения.</param>
        /// <param name="modificationDate">Дата и время изменения шаблона сообщения.</param>
        public void Delete(User modifiedByUser, DateTime modificationDate)
        {
            IsRemoved = true;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }
    }
}
