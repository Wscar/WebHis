using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ymb.IdentityServerDomain;
namespace Ymb.IdentityServer.Test
{
    public class TestBase
    {
        private readonly IServiceCollection services;
        public IServiceProvider ServiceProvider { get; private set; }
        public TestBase()
        {
            services = new ServiceCollection();     
        }
        private void Init()
        {
            this.LoadDefaultConfigFile();
            this.ConfigService();
        }
        private void ConfigService()
        {
            this.services.AddScoped<IClientRepository, ClientRepository>();
            this.services.AddScoped<IApiResourceRepository, ApiResourceRepository>();
            this.ServiceProvider = this.services.BuildServiceProvider();
             var config=   this.ServiceProvider.GetRequiredService<IConfiguration>();
            this.services.AddSmartSql(builder =>
            {
                builder.UseProperties(config);
            });
        }
        private void LoadDefaultConfigFile()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettion.json");
            var config= builder.Build();
            services.AddSingleton<IConfiguration>(config);           
        }
    }
}
