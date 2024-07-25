namespace NotificationMicroservice.Contracts.Type
{
    public record TypeResponse(
        Guid Id,
        string Name,
        bool IsRemove,
        string CreateUserName,
        DateTime CreateDate,
        string? ModifyUserName,
        DateTime? ModifyDate
        );

}
