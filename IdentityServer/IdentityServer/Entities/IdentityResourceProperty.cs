using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Entities
{
    public class IdentityResourceProperty:Property
    {
         public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}
