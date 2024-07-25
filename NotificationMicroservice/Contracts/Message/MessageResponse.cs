namespace NotificationMicroservice.Contracts.Message
{
    public record MessageResponse(
        Guid Id,
        string MessageTypeName,
        Guid MessageTypeId,
        string MessageText,
        string Direction,
        DateTime CreateDate
        );
}
