using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SamirGoes.Viajanet.Domain.Core.Bus;

namespace SamirGoes.ViajaNet.Infra.ServiceBus.ServiceBus
{
    public class ConnectionBus : IConnectionBus
    {
        private IConfiguration _configuration;

        private Configuration _rabbitMQConfigurations;

        public ConnectionBus()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();

            _rabbitMQConfigurations = new Configuration();
            new ConfigureFromConfigurationOptions<Configuration>(
                _configuration.GetSection("Configurations"))
                    .Configure(_rabbitMQConfigurations);
        }

        public ConnectionFactory GetConnection()
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
