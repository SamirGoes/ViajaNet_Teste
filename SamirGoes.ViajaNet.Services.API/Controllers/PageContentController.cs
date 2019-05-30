using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamirGoes.Viajanet.Domain.Core.Bus;
using SamirGoes.ViajaNet.Domain.AppServices;
using SamirGoes.ViajaNet.Domain.Event;
using SamirGoes.ViajaNet.Domain.Models;

namespace SamirGoes.ViajaNet.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentController : ControllerBase
    {
        private readonly IContentAppService _contentAppService;
        private readonly IServiceBus _eventBus;

        public PageContentController(IContentAppService contentAppService, IServiceBus eventBus)
        {
            _contentAppService = contentAppService;
            _eventBus = eventBus;
        }

        [HttpPost]
        public void Post([FromBody] Content content)
        {
            var @event = new ContentCollectedEvent(content.IP, content.PageName, content.Browser, content.PageParameters);

            _eventBus.Publish(@event);
        }
    }
}