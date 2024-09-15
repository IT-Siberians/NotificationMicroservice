namespace NotificationMicroservice.Contracts.Type
{
    public record AddTypeRequest(
        string Name,
        Guid CreatedByUserId
        );

}
