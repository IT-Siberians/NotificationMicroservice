using NotificationMicroservice.Application.Services.Abstractions.Base;
using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с типами
    /// </summary>
    public interface ITypeApplicationService : IModifyService<TypeModel, CreateTypeModel, EditTypeModel, DeleteTypeModel, Guid>
    {
    }
}
