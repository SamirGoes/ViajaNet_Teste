using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamirGoes.ViajaNet.Domain.AppServices;
using SamirGoes.ViajaNet.Domain.Models;

namespace SamirGoes.ViajaNet.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentController : ControllerBase
    {
        private readonly IContentAppService _contentAppService;

        [HttpPost]
        public void Post([FromBody] Content content)
        {

        }
    }
}