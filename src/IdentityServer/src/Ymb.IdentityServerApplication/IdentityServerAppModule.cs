using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Ymb.IdentityServerDomain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;

namespace Ymb.IdentityServerApplication
{
    [DependsOn(typeof(IdentityServerDomainModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class IdentityServerAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var service = context.Services;
            service.AddScoped<IClientService, ClientService>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ClientMapperProfile>(true);
            });
        }
    }
}
