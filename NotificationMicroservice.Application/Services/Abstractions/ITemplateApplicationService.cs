using NotificationMicroservice.Application.Services.Abstractions.Base;
using NotificationMicroservice.Application.Model.Template;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с шаблонами
    /// </summary>
    public interface ITemplateApplicationService : IModifyService<TemplateModel, CreateTemplateModel, EditTemplateModel, Guid>
    {
    }
}
