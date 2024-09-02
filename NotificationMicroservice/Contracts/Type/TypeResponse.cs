namespace NotificationMicroservice.Contracts.Type
{
    public record TypeResponse(
        Guid Id,
        string Name,
        bool IsRemoved,
        Guid CreatedUserId,
        DateTime CreationDate,
        Guid? ModifiedUserId,
        DateTime? ModifiedDate
        );

}
