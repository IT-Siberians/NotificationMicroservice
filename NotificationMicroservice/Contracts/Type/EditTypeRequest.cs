namespace NotificationMicroservice.Contracts.Type
{
    public record EditTypeRequest(
        string Name,
        Guid ModifiedUserId
        );

}
