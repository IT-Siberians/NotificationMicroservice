﻿using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Domain.Interfaces.Services;

namespace NotificationMicroservice.Application.Interface
{
    public interface ITemplateApplicationService : IService<TemplateModel, CreateTemplateModel, Guid>
    {
        Task<bool> UpdateAsync(EditTemplateModel messageTemplate);
        Task<bool> DeleteAsync(EditTemplateModel messageTemplate);
    }
}
