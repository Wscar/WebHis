using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMB.IdentityServer.Mapper;

namespace YMB.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ValuesController()
        {

        }
        public string Get()
        {
            var client = ClientMapper.ToModel(new Entities.Client());
            return "hello";

        }
    }
}
