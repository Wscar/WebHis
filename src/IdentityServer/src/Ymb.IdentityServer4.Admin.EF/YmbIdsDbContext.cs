using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EF
{
    public class YmbIdsDbContext : ConfigurationDbContext<YmbIdsDbContext>, IYmbIdsDbContext
    {   

        public YmbIdsDbContext(DbContextOptions<YmbIdsDbContext> options, ConfigurationStoreOptions storeOptions ) : base(options, storeOptions)
        {

        }

       
        public DbSet<ClientSecret> ClientSecrets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientGrantType> ClientGrantTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientRedirectUri> ClientRedirectUris { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientScope> ClientScopes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientClaim> ClientClaims { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ClientProperty> ClientProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiResourceSecret> ApiResourceSecrets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiResourceScope> ApiResourceScopes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiResourceClaim> ApiResourceClaims { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiResourceProperty> ApiResourceProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiScopeClaim> ApiScopeClaims { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiScopeProperty> ApiScopeProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<IdentityResourceClaim> IdentityResourceClaims { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
