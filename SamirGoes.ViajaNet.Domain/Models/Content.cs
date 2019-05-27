using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Domain.Models
{
    public class Content
    {
        public string IP { get; set; }

        public string PageName { get; set; }

        public string Browser { get; set; }

        public string[] PageParameters { get; set; }
    }
}
