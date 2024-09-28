using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Template
{
    public class DeleteTemplateModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public Guid ModifiedByUserId { get; set; }
    }
}
