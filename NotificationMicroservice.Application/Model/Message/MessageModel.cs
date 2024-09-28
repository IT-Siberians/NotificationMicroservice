using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Application.Model.Message
{
    public record MessageModel(
        Guid Id,
        string Text,
        Direction Direction,
        DateTime CreationDate,
        TypeModel Type) : IBaseModel<Guid>;
}
