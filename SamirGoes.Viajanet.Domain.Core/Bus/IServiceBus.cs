using SamirGoes.Viajanet.Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.Viajanet.Domain.Core.Bus
{
    public interface IServiceBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T>()
            where T : IntegrationEvent;
    }
}
