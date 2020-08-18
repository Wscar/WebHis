using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Entities
{
    public class ApiResourceProperty: Property
    {
         public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
