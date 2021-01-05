using Ymb.IdntityServer4.Shared.Configuration.Identity;
using Ymb.IdntityServer4.STS.Identity.Configuration.Interfaces;

namespace Ymb.IdntityServer4.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





