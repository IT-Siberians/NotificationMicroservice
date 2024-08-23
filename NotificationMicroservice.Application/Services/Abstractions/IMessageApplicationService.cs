using NotificationMicroservice.Application.Services.Abstractions.Base;
using NotificationMicroservice.Application.Model.Message;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с сообщениями
    /// </summary>
    public interface IMessageApplicationService : IService<MessageModel, CreateMessageModel, Guid>
    {
    }
}
