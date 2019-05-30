using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.Viajanet.Domain.Core.Bus
{
    public interface IConnectionBus
    {
        ConnectionFactory GetConnection();
    }
}
