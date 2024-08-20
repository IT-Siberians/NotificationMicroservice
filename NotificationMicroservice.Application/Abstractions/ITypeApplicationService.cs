using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Abstractions
{
    public interface ITypeApplicationService : IModifyService<TypeModel, CreateTypeModel, EditTypeModel, Guid>
    {

    }
}
