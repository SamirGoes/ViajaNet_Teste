using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Data.Queue.RabbitMQ
{
    public class Publish
    {
        private readonly ConnectionFactory _factory;

        public Publish(ConnectionFactory factory)
        {
            this._factory = factory;
        }

        public object PublishMessage(string queueName, string message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }

            return new
            {
                Resultado = "Mensagem encaminhada com sucesso"
            };
        }
    }
}
