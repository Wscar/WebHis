using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Ymb.IdentityServerDomain;
using Ymb.Infrastructure;
namespace Ymb.IdentityServerDomain
{
    [DependsOn(typeof(SmartSqlModule))]
    public class IdentityServerDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var service = context.Services;
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IApiResourceRepository, ApiResourceRepository>();
        }
    }
}
