namespace NotificationMicroservice.Contracts.Type
{
    public record TypeResponse(
        Guid Id,
        string Name,
        bool IsRemoved,
        string CreatedUserName,
        DateTime CreatedDate,
        string? ModifiedUserName,
        DateTime? ModifiedDate
        );

}
