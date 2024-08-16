using NotificationMicroservice.Application.Model.Template;

namespace NotificationMicroservice.Application.Abstractions
{
    public interface ITemplateApplicationService : IService<TemplateModel, CreateTemplateModel, Guid>
    {
        Task<bool> UpdateAsync(EditTemplateModel messageTemplate);
        Task<bool> DeleteAsync(EditTemplateModel messageTemplate);
    }
}
