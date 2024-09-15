namespace NotificationMicroservice.Application.Model.Type
{
    public record CreateTypeModel(
        string Name,
        Guid CreatedByUserId);
}
