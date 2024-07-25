namespace NotificationMicroservice.DataAccess.Entities
{
    public class TypeEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Признак уведомления
        /// </summary>
        public bool IsRemove { get; set; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public string CreateUserName { get; set; } = string.Empty;

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public string? ModifyUserName { get; set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        public virtual IEnumerable<MessageEntity>? Messages { get; set; }
        public virtual IEnumerable<TemplateEntity>? Templates { get; set; }
    }
}
