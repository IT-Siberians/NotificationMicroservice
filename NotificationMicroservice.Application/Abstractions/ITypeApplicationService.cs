using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Abstractions
{
    public interface ITypeApplicationService : IService<TypeModel, CreateTypeModel, Guid>
    {
        Task<bool> UpdateAsync(EditTypeModel messageType);
        Task<bool> DeleteAsync(EditTypeModel messageType);
    }
}
