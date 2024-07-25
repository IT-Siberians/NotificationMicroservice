﻿namespace NotificationMicroservice.Domain.Exception.MessageType
{
    internal class MessageTypeUserNameNullOrEmptyException : ArgumentException
    {
        public MessageTypeUserNameNullOrEmptyException()
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }

        public MessageTypeUserNameNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}