using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EF
{
    public interface IYmbIdsDbContext : IConfigurationDbContext
    {
        DbSet<ClientSecret> ClientSecrets { get; set; }

        DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        DbSet<ClientScope> ClientScopes { get; set; }

        DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        DbSet<ClientClaim> ClientClaims { get; set; }

        DbSet<ClientProperty> ClientProperties { get; set; }
        DbSet <ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; }

        DbSet<ApiResourceScope> ApiResourceScopes { get; set; }
        DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
        DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

        DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }

        DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }

        DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
    }
}
