namespace NotificationMicroservice.DataAccess.Entities
{
    public class MessageEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string MessageText { get; set; } = string.Empty;

        /// <summary>
        /// Напрвление отправки
        /// </summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get; set; }

        public virtual TypeEntity Type { get; set; }
    }
}
