using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using SmartSql;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace Ymb.Infrastructure
{
    public class SmartSqlModule : AbpModule
    {       
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var service = context.Services;
            var serviceProvider = context.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            service.AddSmartSql(builder=> builder.UseProperties(configuration));
           
        }
    }
}
