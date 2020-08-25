using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Ymb.IdentityServerDomain;
namespace Ymb.IdentityServerApplication
{  
    [DependsOn(typeof(IdentityServerDomainModule))]
    public class IdentityServerAppModule:AbpModule
    {
    }
}
