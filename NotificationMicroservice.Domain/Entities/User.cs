using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя в системе уведомлений.
    /// </summary>
    public class User : IEntity<Guid>
    {
        /// <summary>
        /// Минимальная длина Username
        /// </summary>
        public const int MIN_USERNAME_LENGTH = 3;

        /// <summary>
        /// Максимальная длина Username
        /// </summary>
        public const int MAX_USERNAME_LENGTH = 30;

        /// <summary>
        /// Минимальная длина FullName
        /// </summary>
        public const int MIN_FULLNAME_LENGTH = 5;

        /// <summary>
        /// Максимальная длина FullName
        /// </summary>
        public const int MAX_FULLNAME_LENGTH = 100;

        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает имя пользователя.
        /// </summary>
        public Username Username { get; }

        /// <summary>
        /// Получает ФИО пользователя.
        /// </summary>
        public FullName FullName { get; private set; }

        /// <summary>
        /// Получает адрес электронной почты пользователя.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Получает дату и время создания пользователя.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected User() { }
#pragma warning disable CS8618

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/> с указанными параметрами.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="fullName">Имя пользователя.</param>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        public User(Guid id, Username username, FullName fullName, Email email)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Обновление экземпляра класса <see cref="User"/> с указанными параметрами.
        /// </summary>
        /// <param name="fullName">Имя пользователя.</param>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        public void Update(FullName fullName, Email email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
