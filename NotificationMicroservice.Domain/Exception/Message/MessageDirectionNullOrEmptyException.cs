﻿namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageDirectionNullOrEmptyException : ArgumentException
    {
        public MessageDirectionNullOrEmptyException()
        {
        }

        public MessageDirectionNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageDirectionNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}