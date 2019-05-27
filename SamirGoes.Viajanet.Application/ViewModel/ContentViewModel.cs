using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.Viajanet.Application.ViewModel
{
    public class ContentViewModel
    {
        public Guid Id { get; set; }

        public string IP { get; set; }

        public string PageName { get; set; }

        public string Browser { get; set; }

        public string[] PageParameters { get; set; }
    }
}
