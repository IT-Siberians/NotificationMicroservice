namespace NotificationMicroservice.Contracts.Type
{
    public record TypeResponse(
        Guid Id,
        string Name,
        bool IsRemoved,
        Guid CreatedByUserId,
        DateTime CreationDate,
        Guid? ModifiedByUserId,
        DateTime? ModificationDate);

}
