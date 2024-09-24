using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Application.Services;
using NotificationMicroservice.Application.Services.Abstractions;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Services
{
    public class EventControlService(SendService sendService, IUserApplicationService userService, IMapper mapper)
    {
        public async Task<bool> Process<T>(IDefaultEvent<T> eventRequest) where T : class
        {
            switch (eventRequest.Id)
            {
                case Event.ConfirmationEmail:
                    var id = Guid.Parse("4213dfcf-2b3e-46d6-8e09-1a90171091a6"); // пока не знаю как правильно/лучше реализовать связку события и типа, для получение Id
                    return await sendService.SendAsync(mapper.Map<GetMessageModel>(eventRequest.Data), id);
                case Event.CreateUser:
                    return await userService.AddAsync(mapper.Map<CreateUserModel>(eventRequest.Data)) != null;
                case Event.ChangeUser:
                    return await userService.UpdateAsync(mapper.Map<UpdateUserModel>(eventRequest.Data));
                default:
                    return false;
            }
        }
    }
}
