using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Ymb.Infrastructure;
namespace Ymb.IdentityServerDomain
{   
    [DependsOn(typeof(SmartSqlModule))]
     public class IdentityServerDomainModule:AbpModule
    {
    }
}
