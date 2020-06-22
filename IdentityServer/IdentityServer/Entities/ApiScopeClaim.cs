using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Entities
{
    public class ApiScopeClaim:UserClaim
    {
         public int ScopeId { get; set; }
        public ApiScope Scope { get; set; }
    }
}
