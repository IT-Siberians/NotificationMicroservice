namespace NotificationMicroservice.DataAccess.Entities
{
    public class TemplateEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор типа сообщения
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Код языка
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// Название шаблона сообщений
        /// </summary>
        public string Template { get; set; } = string.Empty;

        /// <summary>
        /// Признак уведомления
        /// </summary>
        public bool IsRemove { get; set; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public string CreateUserName { get; set; } = string.Empty;

        /// <summary>
        /// Дата создания шаблона сообщения
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

        public virtual TypeEntity Type { get; set; }
    }
}
