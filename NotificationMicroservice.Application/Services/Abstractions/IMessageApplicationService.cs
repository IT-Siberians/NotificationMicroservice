using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с сообщениями
    /// </summary>
    public interface IMessageApplicationService : IService<MessageModel, CreateMessageModel, Guid>
    {
    }
}
