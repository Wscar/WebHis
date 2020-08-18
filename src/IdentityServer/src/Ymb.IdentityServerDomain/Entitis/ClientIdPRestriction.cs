using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymb.IdentityServerDomain
{
    public class ClientIdPRestriction
    {
        public int Id { get; set; }
        public string Provider { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
