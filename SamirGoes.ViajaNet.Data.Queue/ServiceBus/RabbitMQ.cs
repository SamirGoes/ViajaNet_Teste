using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SamirGoes.Viajanet.Domain.Core.Bus;
using SamirGoes.Viajanet.Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Infra.ServiceBus.ServiceBus
{
    public class RabbitMQ : IServiceBus
    {
        private readonly IConnectionBus connectionBus;

        private readonly string _queueName;
        
        public RabbitMQ(IConnectionBus connection)
        {
            this.connectionBus = connection;
        }

        public void Publish(IntegrationEvent @event)
        {
            using (var connection = connectionBus.GetConnection().CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 2; // persistent

                var eventName = @event.GetType().Name;
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: properties,
                                     body: body);
            }
        }

        public void Subscribe<T>() where T : IntegrationEvent
        {
            using (var connection = connectionBus.GetConnection().CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, e) => {
                    //return JsonConvert.DeserializeObject< e.Body;
                };
                channel.BasicConsume(queue: _queueName,
                     autoAck: true,
                     consumer: consumer);
            }
        }
    }
}
