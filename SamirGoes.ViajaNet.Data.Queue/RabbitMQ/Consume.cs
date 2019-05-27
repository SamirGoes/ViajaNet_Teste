using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Data.Queue.RabbitMQ
{
    public class Consume
    {
        private readonly ConnectionFactory _factory;

        public Consume(ConnectionFactory factory)
        {
            this._factory = factory;
        }

        public void ConsumeMessage(string queueName)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, eventHandler) => Encoding.UTF8.GetString(eventHandler.Body);

                channel.BasicConsume(queue: queueName,
                     autoAck: true,
                     consumer: consumer);
            }
        }
    }
}
