using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Consumers
{
    public class MessageBrokerConsumerAppService<T> : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private EventingBasicConsumer _consumer;
        private readonly string _exchangeName;
        private readonly string _queueName;
        public MessageBrokerConsumerAppService(IConnectionFactory factory)
        {
            _queueName = typeof(T).Name;
            _exchangeName = $"ex.{_queueName}";
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                               queue: _queueName,
                               durable: true,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);
            _channel.ExchangeDeclare(_exchangeName, "fanout");
            _channel.QueueBind(_queueName, _exchangeName, "", arguments: null);
        }
        private void HandleConsumer(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var messageObject = JsonConvert.DeserializeObject<T>(message);
            Consume(messageObject, e.RoutingKey);
        }
        protected virtual void Consume(T message, string routeKey)
        {
            throw new NotImplementedException();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += HandleConsumer;
            _channel.BasicConsume(_queueName, true, _consumer);

            return Task.CompletedTask;
        }


        // message -> messageBytes -> body -> messageBytes -> message
    }
}
