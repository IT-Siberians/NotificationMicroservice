using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с типами
    /// </summary>
    public interface ITypeApplicationService : IFullModifyService<TypeModel, CreateTypeModel, UpdateTypeModel, DeleteTypeModel, Guid>
    {
    }
}
