using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Domain.Interfaces.Services;

namespace NotificationMicroservice.Application.Interface
{
    public interface ITypeApplicationService : IBaseService<TypeModel, CreateTypeModel, Guid>
    {
        Task<bool> UpdateAsync(EditTypeModel messageType);
        Task<bool> DeleteAsync(EditTypeModel messageType);
    }
}
