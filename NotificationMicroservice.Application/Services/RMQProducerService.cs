using Microsoft.Extensions.Configuration;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Domain.Enums;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NotificationMicroservice.Application.Services
{
    public class RMQProducerService(IConfiguration configuration)
    {
        private string _connectionString = string.Empty;
        private string _queueName = string.Empty;

        public void SendMessage(SendMessageModel message, Direction direction)
        {
            switch (direction)
            {
                case Direction.Email:
                    _connectionString = configuration["RabbitMQ:ConnectionStringEmail"]
                        ?? throw new ArgumentNullException("Connection string for RabbitMQ is not configured.");

                    _queueName = configuration["RabbitMQ:QueueNameEmail"]
                        ?? throw new ArgumentNullException("Queue name for RabbitMQ is not configured.");

                    break;
                default:
                    throw new ArgumentNullException();
            }

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_connectionString)
            };

            var messageString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageString);

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }
    }
}
