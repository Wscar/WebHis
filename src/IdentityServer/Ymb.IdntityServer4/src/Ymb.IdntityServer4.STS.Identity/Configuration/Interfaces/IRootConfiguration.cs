using Ymb.IdntityServer4.Shared.Configuration.Identity;

namespace Ymb.IdntityServer4.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}





