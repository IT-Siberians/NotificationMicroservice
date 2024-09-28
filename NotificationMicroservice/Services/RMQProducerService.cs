using NotificationMicroservice.Contracts.Rabbit;
using NotificationMicroservice.Domain.Enums;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NotificationMicroservice.Services
{
    public class RMQProducerService
    {
        private readonly string _connectionString;
        private readonly Dictionary<Direction, string> _queuesName;
        private readonly ConnectionFactory _connectionFactory;

        public RMQProducerService(IConfiguration configuration)
        {
            var rabbitMqConfig = configuration.GetSection("RabbitMQ")
                ?? throw new ArgumentNullException("Connection string for RabbitMQ is not configured.");

            _connectionString = rabbitMqConfig["ConnectionString"]
                ?? throw new ArgumentNullException("Connection string for RabbitMQ is not configured.");

            var queues = rabbitMqConfig.GetSection("ProducerQueues").Get<string[]>();

            _queuesName = Enum.GetValues(typeof(Direction))
                .Cast<Direction>()
                .ToDictionary(d => d, d => queues[(int)d - 1]);

            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(_connectionString)
            };
        }

        public void SendMessage(SendMessageResponse message, Direction direction)
        {
            var messageString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageString);

            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queuesName[direction], durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: _queuesName[direction], basicProperties: null, body: body);
        }
    }
}
