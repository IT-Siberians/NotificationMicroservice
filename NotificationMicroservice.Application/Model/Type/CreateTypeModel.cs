using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Type
{
    public record CreateTypeModel(
        string Name,
        Guid CreatedByUserId) : ICreateModel;
}
