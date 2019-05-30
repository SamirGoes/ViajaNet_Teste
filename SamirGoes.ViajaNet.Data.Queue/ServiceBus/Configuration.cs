using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Infra.ServiceBus.ServiceBus
{
    public class Configuration
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
