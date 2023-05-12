﻿using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Application.Interfaces.Services;

namespace Application.Services
{
    public abstract class Publisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private string _exchangeName;
        private string _queueName;

        public Publisher(IConnectionFactory factory)
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish<T>(T body, string routeKey = "")
        {
            _queueName = typeof(T).Name;
            _exchangeName = $"ex.{_queueName}";
            _channel.ExchangeDeclare(_exchangeName, "fanout");
            var message = JsonConvert.SerializeObject(body);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: _exchangeName, routingKey: routeKey, basicProperties: null, body: messageBytes, mandatory: true);

        }
    }
}