﻿using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Тип шаблона сообщения
    /// </summary>
    public class MessageType : IModifyEntity<User, Guid>
    {
        /// <summary>
        /// Минимальная длина названия для типа сообщения
        /// </summary>
        public const int MIN_NAME_LENGTH = 20;

        /// <summary>
        /// Максимальная длина названия для типа сообщения
        /// </summary>
        public const int MAX_NAME_LENGTH = 50;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название типа сообщения
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Статус удаления типа
        /// </summary>
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Пользователь создавший тип сообщения
        /// </summary>
        public User CreatedByUser { get; }

        /// <summary>
        /// Дата создания типа сообщения
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public User? ModifiedByUser { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModificationDate { get; private set; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected MessageType() { }
#pragma warning disable CS8618

        /// <summary>
        /// Основной конструктор класса (новая сущность)
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="createdByUser">пользователь создавший тип сообщения</param>
        /// <param name="creationDate">дата и время создания типа сообщения</param>
        /// <param name="modifiedByUser">пользователь изменивший тип сообщения</param>
        /// <param name="modificationDate">дата и время изменения типа сообщения</param>
        public MessageType(string name, bool isRemoved, User createdByUser, DateTime creationDate, User? modifiedByUser, DateTime? modificationDate)
        {
            ValidateData(name, createdByUser);

            Name = name;
            IsRemoved = isRemoved;
            CreatedByUser = createdByUser;
            CreationDate = creationDate;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Обновление типа сообщения
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="modifiedByUser">пользователь изменивший тип сообщения</param>
        /// <param name="modificationDate">дата и время изменения типа сообщения</param>
        public void Update(string name, bool isRemoved, User modifiedByUser, DateTime modificationDate)
        {
            ValidateData(name, modifiedByUser);

            Name = name;
            IsRemoved = isRemoved;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Деактивация типа сообщения (пометить как удалённый)
        /// </summary>
        /// <param name="modifiedByUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modificationDate">дата и время изменения шаблона сообщения</param>
        public void Delete(User modifiedByUser, DateTime modificationDate)
        {
            IsRemoved = true;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Валидация входных данных
        /// </summary>
        /// <param name="name">название типа сообщения</param>
        /// <param name="user">имя пользователя</param>
        private static void ValidateData(string name, User user)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionMessages.ERROR_TYPE_NAME, name);
            }

            if (name.Length < MIN_NAME_LENGTH && name.Length > MAX_NAME_LENGTH)
            {
                throw new MessageTypeNameLengthException(ExceptionMessages.ERROR_TYPE_NAME_LENGTH, MIN_NAME_LENGTH, MAX_NAME_LENGTH, name.Length.ToString());
            }
        }
    }
}
