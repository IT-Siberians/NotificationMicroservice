using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя в системе уведомлений.
    /// </summary>
    public class User : IEntity<Guid>
    {
        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает имя пользователя.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Получает ФИО пользователя.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Получает адрес электронной почты пользователя.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Получает дату и время создания пользователя.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
        protected User() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/> с указанными параметрами.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="userName">Имя пользователя.</param>
        /// <param name="fullName">Имя пользователя.</param>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        public User(Guid id, string userName, string fullName, string email)
        {
            Id = id;
            UserName = userName;
            FullName = fullName;
            Email = email;
            CreationDate = DateTime.Now;
        }
    }
}
