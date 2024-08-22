using NotificationMicroservice.Application.Abstractions.Base;
using NotificationMicroservice.Application.Model.Template;

namespace NotificationMicroservice.Application.Abstractions
{
    public interface ITemplateApplicationService : IModifyService<TemplateModel, CreateTemplateModel, EditTemplateModel, Guid>
    {

    }
}
