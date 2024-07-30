﻿namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Исключение ограничения длинны кодировки языка
    /// </summary>
    public class MessageTemplateLanguageNullOrEmptyException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public MessageTemplateLanguageNullOrEmptyException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTemplateLanguageNullOrEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public MessageTemplateLanguageNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}