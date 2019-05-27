using SamirGoes.ViajaNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamirGoes.ViajaNet.Domain.AppServices
{
    public interface IContentAppService
    {
        void Register(Content contentViewModel);
    }
}
