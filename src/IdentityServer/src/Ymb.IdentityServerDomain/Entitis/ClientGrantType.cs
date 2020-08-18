using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public class ClientGrantType
    {
        public int Id { get; set; }
        public string GrantType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
