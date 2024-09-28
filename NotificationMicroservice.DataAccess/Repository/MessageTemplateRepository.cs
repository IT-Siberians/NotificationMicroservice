﻿using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Репозиторий для работы с шаблонами сообщений в базе данных.
    /// Реализует интерфейс <see cref="IMessageTemplateRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сообщениями.</param>
    public class MessageTemplateRepository(NotificationMicroserviceDbContext context) : BaseRepository<MessageTemplate, Guid>(context), IMessageTemplateRepository
    {
        /// <summary>
        /// Добавляет новый шаблон сообщения в базу данных.
        /// </summary>
        /// <param name="template">Сущность шаблона сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного шаблона сообщения.</returns>
        public async Task<Guid> AddAsync(MessageTemplate template, CancellationToken cancellationToken = default)
        {
            context.Entry(template.Type).State = EntityState.Modified;
            context.Types.Attach(template.Type);
            context.Users.Attach(template.CreatedByUser);
            context.Templates.Add(template);
            await context.SaveChangesAsync(cancellationToken);

            return template.Id;
        }

        /// <summary>
        /// Обновляет существующий шаблон сообщения в базе данных.
        /// </summary>
        /// <param name="template">Сущность шаблона сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c>, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(MessageTemplate template, CancellationToken cancellationToken = default)
        {
            context.Entry(template).State = EntityState.Modified;
            context.Entry(template.Type).State = EntityState.Modified;
            context.Types.Attach(template.Type);
            context.Entry(template.ModifiedByUser!).State = EntityState.Modified;
            context.Users.Attach(template.ModifiedByUser!);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Помечает шаблон сообщения как удаленный в базе данных.
        /// </summary>
        /// <param name="template">Сущность шаблона сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c>, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(MessageTemplate template, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(template, cancellationToken);
        }
    }
}
