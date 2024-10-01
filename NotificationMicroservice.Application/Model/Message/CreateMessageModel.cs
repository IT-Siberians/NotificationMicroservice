﻿using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Application.Model.Message
{
    public record CreateMessageModel(
        Guid MessageTypeId,
        string MessageText,
        Direction Direction) : ICreateModel;
}
