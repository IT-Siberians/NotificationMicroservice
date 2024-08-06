using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Domain.Interfaces.Services;

namespace NotificationMicroservice.Application.Interface
{
    public interface IMessageApplicationService : IBaseService<MessageModel, CreateMessageModel, Guid>
    {
    }
}
