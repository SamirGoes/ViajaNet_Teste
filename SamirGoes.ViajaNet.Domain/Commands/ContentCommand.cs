using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Domain.Commands
{
    public class ContentCommand
    {
        public Guid Id { get; set; }

        public string IP { get; set; }

        public string PageName { get; set; }

        public string Browser { get; set; }

        public string[] PageParameters { get; set; }
    }
}
