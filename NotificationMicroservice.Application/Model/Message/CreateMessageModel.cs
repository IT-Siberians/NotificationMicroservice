namespace NotificationMicroservice.Application.Model.Message
{
    public record CreateMessageModel(
        Guid MessageTypeId,
        string MessageText,
        string Direction
        );
}
