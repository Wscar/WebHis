using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ymb.IdentityServerApplication;

namespace Ymb.IdentityServerCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
         private readonly IClientService _clientService;
         public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var client = await this._clientService.QuerySingleAsync("1");
            return Ok(client);
        }
    }
}
