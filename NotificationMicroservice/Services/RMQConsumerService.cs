using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NotificationMicroservice.Services
{
    public class RMQConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _connectionString;
        private readonly string[] _queuesName;

        public RMQConsumerService(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;

            var rabbitMqConfig = configuration.GetSection("RabbitMQ")
                ?? throw new ArgumentNullException("RabbitMQ configuration section is not found.");

            _connectionString = rabbitMqConfig["ConnectionString"]
                ?? throw new ArgumentNullException("Connection string for RabbitMQ is not configured.");

            _queuesName = rabbitMqConfig.GetSection("ConsumerQueues").Get<string[]>()
                ?? throw new ArgumentNullException("No consumer queues are configured.");

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_connectionString)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            foreach (var queue in _queuesName)
            {
                _channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    using var scope = _serviceScopeFactory.CreateScope();
                    var notificationControlService = scope.ServiceProvider.GetRequiredService<NotificationControlService>();
                    await notificationControlService.WorckAsync(message, queue, cancellationToken);

                    await Task.CompletedTask;
                };

                _channel.BasicConsume(
                    queue: queue,
                    autoAck: true,
                    consumer: consumer);
            }

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            _connection.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}
