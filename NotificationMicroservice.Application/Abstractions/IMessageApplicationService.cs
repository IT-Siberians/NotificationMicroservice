using NotificationMicroservice.Application.Model.Message;

namespace NotificationMicroservice.Application.Abstractions
{
    public interface IMessageApplicationService : IService<MessageModel, CreateMessageModel, Guid>
    {
    }
}
