using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymb.IdentityServerDomain;

namespace Ymb.IdentityServerDomain
{
    public class ApiResourceScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
