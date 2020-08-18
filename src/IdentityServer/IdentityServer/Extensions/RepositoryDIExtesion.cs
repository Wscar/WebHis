using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMB.IdentityServer.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryDIExtesion
    {
        public static void AddRespositry( this IServiceCollection services)
        {
            services.AddScoped<IClientRepository,ClientRepository>();
            
        }
    }
}
