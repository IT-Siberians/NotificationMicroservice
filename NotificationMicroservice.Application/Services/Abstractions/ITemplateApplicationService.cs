using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с шаблонами
    /// </summary>
    public interface ITemplateApplicationService : IFullModifyService<TemplateModel, CreateTemplateModel, UpdateTemplateModel, DeleteTemplateModel, Guid>
    {
    }
}
