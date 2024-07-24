﻿namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageTextNullOrEmptyException : System.Exception
    {
        public MessageTextNullOrEmptyException()
        {
        }

        public MessageTextNullOrEmptyException(string? name) : base($"Message text '{name}' cannot be empty")
        {
        }

        public MessageTextNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}