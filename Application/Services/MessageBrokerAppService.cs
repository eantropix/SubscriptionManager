using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SubscriptionManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Application.Interfaces.Services;

namespace Application.Services
{
    public abstract class MessageBrokerAppService<T> : IMessageBrokerAppService<T> where T : class
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly string _exchangeName;



        public MessageBrokerAppService(string queueName)
        {
            _exchangeName = $"ex.{queueName}";
            _factory = new ConnectionFactory { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            _channel.ExchangeDeclare(_exchangeName, "fanout");
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += HandleConsumer;
            _channel.BasicConsume(queueName, true, _consumer);
            _channel.QueueBind(queueName, _exchangeName, "", arguments: null);
        }

        public void Publish(T body, string routeKey = "")
        {
            var message = JsonConvert.SerializeObject(body);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            
            _channel.BasicPublish(exchange: _exchangeName, routingKey: routeKey, basicProperties: null, body: messageBytes, mandatory: true);

        }

        public void Publish(int id, string routeKey = "")
        {
            var message = JsonConvert.SerializeObject(id);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: _exchangeName, routingKey: routeKey, basicProperties: null, body: messageBytes, mandatory: true);
        }

        protected abstract void Consume(T message, string routeKey);

        private void HandleConsumer(object? sender, BasicDeliverEventArgs e)
        {
            var messageBytes = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(messageBytes);
            var body = JsonConvert.DeserializeObject<T>(message);
            Consume(body, e.RoutingKey);
        }
        // message -> messageBytes -> body -> messageBytes -> message

    }
}
