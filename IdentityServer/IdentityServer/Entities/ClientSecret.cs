using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Entities
{
    public class ClientSecret:Secret
    {
         public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
