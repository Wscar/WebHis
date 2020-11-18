using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServer4.Admin.EF.Repositories.Interface;
namespace Ymb.IdentityServer4.Admin.EF.Repositories
{
    public class ApiResourceRepository<TDbContext> : IAipResourceRepository where TDbContext : DbContext, IYmbIdsDbContext
    {
        private readonly TDbContext _dbContext;
        private readonly UnitOfWork<TDbContext> _unitOfWork;

        public ApiResourceRepository(TDbContext dbContext, UnitOfWork<TDbContext> unitOfWork)
        {
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> AddAipResourceAsync(ApiResource apiResource)
        {
            var resource = await this._dbContext.ApiResources.AddAsync(apiResource);
            await this._unitOfWork.CommitAsync();
            return resource.Entity.Id;
        }

        public async Task<int> AddApiResourceClaim(ApiResourceClaim claim)
        {
            await this._dbContext.ApiResourceClaims.AddAsync(claim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> AddApiResourceProperties(ApiResourceProperty property)
        {
            await this._dbContext.ApiResourceProperties.AddAsync(property);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> AddApiResourceScope(ApiResourceScope scope)
        {
            await this._dbContext.ApiResourceScopes.AddAsync(scope);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> AddApiResourceSecretAsync(ApiResourceSecret secret)
        {
            await this._dbContext.ApiResourceSecrets.AddAsync(secret);
            return await this._unitOfWork.CommitAsync();
        }

        public Task<ApiResourceProperty> GetApiApiResourceProperty(int apiResourceId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResourceClaim> GetApiResourceClaim(int apiResourceId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteApiResourceAsync(ApiResource apiResource)
        {
            this._dbContext.ApiResources.Remove(apiResource);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiResourceClaim(ApiResourceClaim claim)
        {
            this._dbContext.ApiResourceClaims.Remove(claim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiResourceProperties(ApiResourceProperty property)
        {
            this._dbContext.ApiResourceProperties.Remove(property);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiResourceScope(ApiResourceScope scope)
        {
            this._dbContext.ApiResourceScopes.Remove(scope);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiResourceSecretAsync(ApiResourceSecret secret)
        {
            this._dbContext.ApiResourceSecrets.Remove(secret);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<ApiResource> GetApiResource(int apiResourceId)
        {
            return await this._dbContext.ApiResources.SingleOrDefaultAsync(x => x.Id == apiResourceId);
        }

        public async Task<List<ApiResourceClaim>> GetApiResourceClaims(int? apiResourceId)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceClaims.Where(x => x.ApiResourceId == apiResourceId.Value).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceClaims.ToListAsync();
            }
        }

        public async Task<List<ApiResourceClaim>> GetApiResourceClaims(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceClaims.Where(x => x.ApiResourceId == apiResourceId.Value).Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceClaims.Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
            }
        }

        public async Task<List<ApiResourceProperty>> GetApiResourceProperties(int? apiResourceId)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceProperties.Where(x => x.ApiResourceId == apiResourceId.Value).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceProperties.ToListAsync();
            }
        }

        public async Task<List<ApiResourceProperty>> GetApiResourceProperties(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceProperties.Where(x => x.ApiResourceId == apiResourceId.Value).Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceProperties.Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
            }
        }

        public  async Task<List<ApiResource>> GetApiResourcesAsync()
        {
            return await this._dbContext.ApiResources.ToListAsync();
        }

        public async Task<List<ApiResource>> GetApiResourcesAsync(string search = "", int pageIndex = 1, int count = 20)
        {
            return await this._dbContext.ApiResources.Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
        }

        public async Task<ApiResourceScope> GetApiResourceScope(int apiResourceId, int scopeId)
        {
            return await this._dbContext.ApiResourceScopes.SingleOrDefaultAsync(x => x.Id == scopeId);
        }

        public async Task<List<ApiResourceScope>> GetApiResourceScopes(int? apiResourceId)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceScopes.Where(x => x.ApiResourceId == apiResourceId.Value).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceScopes.ToListAsync();
            }
        }

        public async Task<List<ApiResourceScope>> GetApiResourceScopes(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20)
        {
            if (apiResourceId.HasValue)
            {
                return await this._dbContext.ApiResourceScopes.Where(x => x.ApiResourceId == apiResourceId.Value).Take(count).Skip((pageIndex - 1) * 20).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiResourceScopes.Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
        }

        public  Task<ApiResourceSecret> GetApiResourceSecretAsync(int apiResourceId, int secretId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApiResourceSecret>> GetApiResourcesSecretAsync(int? apiResourceId)
        {
            if (apiResourceId.HasValue)
            {
               return   this._dbContext.ApiResourceSecrets.Where(x => x.ApiResourceId == apiResourceId.Value).ToListAsync();
            }
            else
            {
               return  this._dbContext.ApiResourceSecrets.ToListAsync();
            }
        }

        public Task<List<ApiResourceSecret>> GetApiResourcesSecretAsync(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20)
        {
            if (apiResourceId.HasValue)
            {
               return  this._dbContext.ApiResourceSecrets.Where(x => x.ApiResourceId == apiResourceId.Value).Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
            else
            {
               return   this._dbContext.ApiResourceSecrets.Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
        }

        public async Task<int> UpdateResourceAsync(ApiResource apiResource)
        {
            this._dbContext.ApiResources.Update(apiResource);
            return await this._unitOfWork.CommitAsync();
        }
    }
}
