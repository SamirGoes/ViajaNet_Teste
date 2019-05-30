using SamirGoes.Viajanet.Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Domain.Event
{
    public class ContentCollectedEvent : IntegrationEvent
    {
        public string IP { get; private set; }

        public string PageName { get; private set; }

        public string Browser { get; private set; }

        public string[] PageParameters { get; private set; }

        public ContentCollectedEvent(string ip, string pageName, string browser, string[] pageParameters) : base()
        {
            IP = ip;
            PageName = pageName;
            Browser = browser;
            PageParameters = pageParameters;
        }
    }
}
