﻿using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.Service.Repositories
{
   public interface IApiResourceRepository
    {
        Task<PagedList<ApiResource>> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10);

        Task<ApiResource> GetApiResourceAsync(int apiResourceId);

        Task<PagedList<ApiResourceProperty>> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1, int pageSize = 10);

        Task<ApiResourceProperty> GetApiResourcePropertyAsync(int apiResourcePropertyId);

        Task<int> AddApiResourcePropertyAsync(int apiResourceId, ApiResourceProperty apiResourceProperty);

        Task<int> DeleteApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty);

        Task<bool> CanInsertApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty);

        Task<int> AddApiResourceAsync(ApiResource apiResource);

        Task<int> UpdateApiResourceAsync(ApiResource apiResource);

        Task<int> DeleteApiResourceAsync(ApiResource apiResource);

        Task<bool> CanInsertApiResourceAsync(ApiResource apiResource);

        Task<PagedList<ApiScope>> GetApiScopesAsync(string search, int page = 1, int pageSize = 10);

        Task<ApiScope> GetApiScopeAsync(int apiResourceId, int apiScopeId);

        Task<int> AddApiScopeAsync(int apiResourceId, ApiScope apiScope);

        Task<int> UpdateApiScopeAsync( ApiScope apiScope);

        Task<int> DeleteApiScopeAsync(ApiScope apiScope);

        Task<bool> CanInsertApiScopeAsync(ApiScope apiScope);

    
    

        Task<string> GetApiResourceNameAsync(int apiResourceId);
    }
}
