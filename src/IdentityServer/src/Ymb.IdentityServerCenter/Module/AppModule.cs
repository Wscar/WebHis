using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Ymb.IdentityServerApplication;
using Swashbuckle.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ymb.IdentityServerCenter.Module
{

    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(IdentityServerAppModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var service = context.Services;         
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ymb.identityServerCenter api ",
                    Version = "v1"
                });
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
             app.UseSwagger();
            app.UseSwaggerUI(c=> { 
             c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
