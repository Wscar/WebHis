using System.Collections.Generic;
using Ymb.IdntityServer4.Admin.Configuration.Identity;

namespace Ymb.IdntityServer4.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






