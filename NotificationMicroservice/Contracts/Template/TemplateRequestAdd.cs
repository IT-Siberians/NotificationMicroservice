﻿namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateRequestAdd(
        Guid MessageTypeId,
        string Language,
        string Template,
        string CreateUserName
        );

}
