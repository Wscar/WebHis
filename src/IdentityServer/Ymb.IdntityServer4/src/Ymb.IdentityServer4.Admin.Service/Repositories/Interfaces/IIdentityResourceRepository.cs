using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
namespace Ymb.IdentityServer4.Admin.Service.Repositories
{
    public interface IIdentityResourceRepository
    {
        Task<PagedList<IdentityResource>> GetIdentityResourceAsync(string search, int page, int pageSize = 10);
        Task<IdentityResource> GetIdentityResourceAsync(int identityResourceId);
        Task<int> AddIdentityResourceAsync(IdentityResource identityResource);
        Task<int> UpdateIdentityResourceAsync(IdentityResource identityResource);

        Task<int> DeleteIdentityResourceAsync(IdentityResource identityResource);
        Task<PagedList<IdentityResourceProperty>> GetIdentityResourcePropertiesAsync(int identityResourceId,
          int page = 1, int pageSize = 10);

        Task<IdentityResourceProperty> GetIdentityResourcePropertyAsync(int identityResourcePropertyId);
        Task<int> AddIdentityResourcePropertyAsync(int identityResourceId,
           IdentityResourceProperty identityResourceProperty);

        Task<int> DeleteIdentityResourcePropertyAsync(IdentityResourceProperty identityResourceProperty);
    }
}
