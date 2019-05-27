using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SamirGoes.ViajaNet.Data.Queue.RabbitMQ
{
    public class Connection
    {
        private static IConfiguration _configuration;

        private static Configurations _rabbitMQConfigurations;

        public Connection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();

             _rabbitMQConfigurations = new Configurations();
            new ConfigureFromConfigurationOptions<Configurations>(
                _configuration.GetSection("Configurations"))
                    .Configure(_rabbitMQConfigurations);
        }

        public static ConnectionFactory GetConnection()
        {
            return new ConnectionFactory()
            {
                HostName = _rabbitMQConfigurations.HostName,
                Port = _rabbitMQConfigurations.Port,
                UserName = _rabbitMQConfigurations.UserName,
                Password = _rabbitMQConfigurations.Password
            };
        }
    }
}
