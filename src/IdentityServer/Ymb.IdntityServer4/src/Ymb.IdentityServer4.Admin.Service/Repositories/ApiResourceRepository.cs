using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServer4.Admin.Service.Repositories;
using Ymb.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

using Microsoft.Extensions.Logging;
using Ymb.IdentityServer4.Admin.EntityFramework.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ymb.IdentityServer4.Admin.Service.Repostotories
{
    public class ApiResourceRepository : IApiResourceRepository
    {

        private readonly IdentityServerConfigurationDbContext _dbContext;
        private readonly ILogger<ApiResourceRepository> _logger;
        private readonly IUnitOfWork<IdentityServerConfigurationDbContext> _unitOfWork;

        public ApiResourceRepository(IdentityServerConfigurationDbContext dbContext, ILogger<ApiResourceRepository> logger, IUnitOfWork<IdentityServerConfigurationDbContext> unitOfWork)
        {
            this._dbContext = dbContext;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> AddApiResourceAsync(ApiResource apiResource)
        {
             await this._dbContext.ApiResources.AddAsync(apiResource);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<int> AddApiResourcePropertyAsync(int apiResourceId, ApiResourceProperty apiResourceProperty)
        {
            var apiResource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResourceId);
            if (apiResource == null)
            {
                var errorMsg = $"方法AddApiResourcePropertyAsync无法找到id为{apiResourceId}的apiResource";
               return  this.LoggerError(errorMsg);
            }
           await  this._dbContext.ApiResourceProperties.AddAsync(apiResourceProperty);
            return this._unitOfWork.Commit();
        }

        public async Task<int> AddApiScopeAsync(int apiResourceId, ApiScope apiScope)
        {
            var apiResource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResourceId);
            if (apiResource == null)
            {
                var errorMsg = $"方法AddApiScopeAsync无法找到id为{apiResourceId}的apiResource";
                return this.LoggerError(errorMsg);
            }
            await this._dbContext.ApiScopes.AddAsync(apiScope);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<bool> CanInsertApiResourceAsync(ApiResource apiResource)
        {
           var existsApiResource=await  this._dbContext.ApiResources.SingleAsync(x => x.Name == apiResource.Name);
            if (existsApiResource == null)
            {
                return true;
            }
            else
            {
                return true;
            }

        }

        public async Task<bool> CanInsertApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty)
        {
            var existsApiResourceProp = await this._dbContext.ApiResourceProperties.SingleOrDefaultAsync(x => x.ApiResource.Id == apiResourceProperty.ApiResourceId
             && x.Key == apiResourceProperty.Key);
            if (existsApiResourceProp == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CanInsertApiScopeAsync(ApiScope apiScope)
        {
            var existsApiScope = await this._dbContext.ApiScopes.SingleOrDefaultAsync(x => x.Name == apiScope.Name);
            if (existsApiScope == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> DeleteApiResourceAsync(ApiResource apiResource)
        {
            var deleteApiResource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id== apiResource.Id);
              this._dbContext.ApiResources.Remove(deleteApiResource);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<int> DeleteApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty)
        {
            var deleteProp = await this._dbContext.ApiResourceProperties.SingleOrDefaultAsync(x => x.Id == apiResourceProperty.Id);
            if (deleteProp == null)
            {
                var message =  $"方法DeleteApiResourcePropertyAsync,，没有找到id为：{apiResourceProperty.Id}的 ApiResourceProperty";
                return this.LoggerError(message);
            }
            this._dbContext.Remove(apiResourceProperty);
          return await   this._unitOfWork.CommitAsnyc();
        }

        public async Task<int> DeleteApiScopeAsync(ApiScope apiScope)
        {
            var deleteToApiScope = await this._dbContext.ApiScopes.SingleOrDefaultAsync(x => x.Id == apiScope.Id);
            if (deleteToApiScope == null)
            {
                var message = $"方法DeleteApiScopeAsync没有找到id为：{apiScope.Id}的apiScope";
            }
            this._dbContext.ApiScopes.Remove(deleteToApiScope);
            return await this._unitOfWork.CommitAsnyc();
        }

        public async Task<ApiResource> GetApiResourceAsync(int apiResourceId)
        {
            var apiResource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResourceId);
            return apiResource;
        }

        public async Task<string> GetApiResourceNameAsync(int apiResourceId)
        {
            var apiResource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResourceId);
            if (apiResource== null)
            {
                return "";
            }
            else
            {
                return apiResource.Name;
            }
        }

        public async Task<PagedList<ApiResourceProperty>> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1, int pageSize = 10)
        {
            var properties =await this._dbContext.ApiResourceProperties.Where(x => x.ApiResourceId == apiResourceId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageList = new PagedList<ApiResourceProperty> { Data = properties, PageSize = properties.Count };
            return pageList;
        }

        public async Task<ApiResourceProperty> GetApiResourcePropertyAsync(int apiResourcePropertyId)
        {
            var prop = await this._dbContext.ApiResourceProperties.SingleOrDefaultAsync(x => x.Id == apiResourcePropertyId);
            return prop;
        }

        public async Task<PagedList<ApiResource>> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10)
        {
            var resources = new List<ApiResource>();
            if (string.IsNullOrEmpty(search))
            {

                resources = await this._dbContext.ApiResources.OrderByDescending(x => x.Created).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                resources = await this._dbContext.ApiResources.Where(x=>x.Name==search||x.DisplayName==search).OrderByDescending(x => x.Created).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            var pageList = new PagedList<ApiResource> { Data = resources, PageSize = resources.Count };
            return pageList;
        }

        public async Task<ApiScope> GetApiScopeAsync(int apiResourceId, int apiScopeId)
        {
            var scope = await this._dbContext.ApiScopes.SingleOrDefaultAsync(x => x.Id == apiScopeId);
            return scope;
        }

        public async Task<PagedList<ApiScope>> GetApiScopesAsync(string search, int page = 1, int pageSize = 10)
        {
            var apiScopes = new List<ApiScope>();
            if (string.IsNullOrEmpty(search))
            {
                apiScopes = await this._dbContext.ApiScopes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                apiScopes = await this._dbContext.ApiScopes.Where(x=>x.Name==search||x.DisplayName==search).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            var pageList = new PagedList<ApiScope> { Data = apiScopes, PageSize = apiScopes.Count };
            return pageList;
        }

      
        public async Task<int> UpdateApiResourceAsync(ApiResource apiResource)
        {
            var resource = await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResource.Id);
            if (resource == null)
            {
                var msg = $"方法UpdateApiResourceAsync无法找到id为{apiResource.Id}的apiResource";
                return this.LoggerError(msg);
            }
            else
            {
                this._dbContext.ApiResources.Update(apiResource);
               return await this._unitOfWork.CommitAsnyc();
            }
        }

        public async Task<int> UpdateApiScopeAsync( ApiScope apiScope)
        {
            var scope = await this._dbContext.ApiScopes.SingleOrDefaultAsync(x => x.Id == apiScope.Id);
            if (scope == null)
            {
                var msg = $"方法UpdateApiScopeAsync无法找到id为{scope.Id}的apiScope";
                return this.LoggerError(msg);
            }
            else
            {
                this._dbContext.ApiScopes.Update(apiScope);
                return await this._unitOfWork.CommitAsnyc();
            }
        }
        private int LoggerError(string message)
        {
          
            var curdException = new IdentityServerCudException(message);
            this._logger.LogError(curdException,message);
            return CudOperationCommitStatus.FAIL;
        }
    }
}
