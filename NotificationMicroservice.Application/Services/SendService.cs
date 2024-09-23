using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Domain.Enums;
using System.Globalization;

namespace NotificationMicroservice.Application.Services
{
    public class SendService(RMQProducerService sender, ITemplateApplicationService templateService, IMessageApplicationService messageService)
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        private readonly string _lang = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;

        public async Task<bool> SendAsync(GetMessageModel message, Guid typeId)
        {

            var templates = await templateService.GetByTypeId(typeId);

            var template = templates.FirstOrDefault(i => i.Language == _lang);

            if (template is null)
            {
                return false;
            }

            var messageText = string.Format(template.Template, message.Username, message.Link, _nameSite);
            var messageSend = new SendMessageModel(message.Username, message.Email, template.Type.Name, messageText);

            sender.SendMessage(messageSend, Direction.Email);

            var messageSave = new CreateMessageModel(typeId, messageText, Direction.Email);

            await messageService.AddAsync(messageSave);

            return true;
        }
    }
}
