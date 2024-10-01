using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с шаблонами
    /// </summary>
    public interface ITemplateApplicationService : IFullModifyService<TemplateModel, CreateTemplateModel, UpdateTemplateModel, DeleteTemplateModel, Guid>
    {
        /// <summary>
        /// Получение списка шаблонов по типу сообщения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<TemplateModel>> GetByTypeIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получение шаблона по типу сообщения и языку
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TemplateModel?> GetByQueueAndLanguageAsync(string queue, string language, CancellationToken cancellationToken);
    }
}
