using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Application.Services.Abstractions;
using NotificationMicroservice.Contracts.Rabbit;
using NotificationMicroservice.Contracts.Rabbit.Events;
using NotificationMicroservice.Domain.Enums;
using System.Globalization;
using System.Text.Json;

namespace NotificationMicroservice.Services
{
    public class NotificationControlService(RMQProducerService sender, ITemplateApplicationService templateService, IMessageApplicationService messageService, IUserApplicationService userService, IBusQueueApplicationService queueApplicationService, IMapper mapper)
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        private readonly string _lang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.ThreeLetterISOLanguageName);

        public async Task<bool> WorckAsync(string message, string queue, CancellationToken cancellationToken)
        {
            switch (queue)
            {
                case "ConfirmationEmail":

                    var template = await templateService.GetByQueueAndLanguageAsync(queue, _lang, cancellationToken);

                    if (template is null)
                    {
                        return false;
                    }

                    var confirmationEmail = JsonSerializer.Deserialize<ConfirmationEmailEvent>(message);
                    var messageText = string.Format(template.Template, confirmationEmail!.Username, confirmationEmail.Link, _nameSite);
                    var messageSend = new SendMessageResponse(confirmationEmail.Username, confirmationEmail.Email, template.Type.Name, messageText);

                    sender.SendMessage(messageSend, Direction.Email);

                    var messageSave = new CreateMessageModel(template.Type.Id, messageText, Direction.Email);

                    await messageService.AddAsync(messageSave, cancellationToken);

                    return true;
                case "CreateUser":
                    var createUser = JsonSerializer.Deserialize<CreateUserEvent>(message);
                    return await userService.AddAsync(mapper.Map<CreateUserModel>(createUser), cancellationToken) != null;
                case "UpdateUser":
                    var updateUser = JsonSerializer.Deserialize<UpdateUserEvent>(message);
                    return await userService.UpdateAsync(mapper.Map<UpdateUserModel>(updateUser), cancellationToken);
            }
            return false;
        }
    }
}
