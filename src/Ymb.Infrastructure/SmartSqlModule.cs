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
        private readonly IConfiguration Configuration;
        public SmartSqlModule(IConfiguration _configuration)
        {
            this.Configuration = _configuration;
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var service = context.Services;
           
            service.AddSmartSql(builder=>builder.UseProperties(Configuration));
            
        }
    }
}
