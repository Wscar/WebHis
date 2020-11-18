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
    public class ApiScopeReppsitory<TDbContext> : IApiScopeRepostory where TDbContext : DbContext, IYmbIdsDbContext
    {

        private readonly TDbContext _dbContext;
        private readonly UnitOfWork<TDbContext> _unitOfWork;

        public ApiScopeReppsitory(TDbContext dbContext, UnitOfWork<TDbContext> unitOfWork)
        {
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> AddApiScopeAsync(ApiScope apiScope)
        {
            await this._dbContext.ApiScopes.AddAsync(apiScope);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> AddApiScopeClaimAsync(ApiScopeClaim claim)
        {
            await this._dbContext.ApiScopeClaims.AddAsync(claim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> AddApiScopePropertyAsync(ApiScopeProperty property)
        {
            await this._dbContext.ApiScopeProperties.AddAsync(property);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiScopeAsync(ApiScope apiScope)
        {
            this._dbContext.ApiScopes.Remove(apiScope);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiScopeClaimAsync(ApiScopeClaim claim)
        {
            this._dbContext.ApiScopeClaims.Remove(claim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteApiScopePropertyAsync(ApiScopeProperty property)
        {
            this._dbContext.ApiScopeProperties.Remove(property);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<ApiScope> GetApiScopeAsync(int id)
        {
            return await this._dbContext.ApiScopes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ApiScopeClaim> GetApiScopeClaimAsync(int id)
        {
            return await this._dbContext.ApiScopeClaims.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync(int apiScopeId)
        {
            return await this._dbContext.ApiScopeClaims.Where(x => x.ScopeId == apiScopeId).ToListAsync();
        }

        public async Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync()
        {
            return await this._dbContext.ApiScopeClaims.ToListAsync();
        }

        public async Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync(int? apiScopeId, int pageIndex = 1, int count = 20)
        {
            if (apiScopeId.HasValue)
            {
                return await this._dbContext.ApiScopeClaims.Where(x => x.ScopeId == apiScopeId.Value).Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiScopeClaims.Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }

        }

        public async Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync(int apiScopeId)
        {
            return await this._dbContext.ApiScopeProperties.Where(x => x.ScopeId == apiScopeId).ToListAsync();
        }

        public async Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync()
        {
            return await this._dbContext.ApiScopeProperties.ToListAsync();
        }

        public async Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync(int? apiScopeId, int pageIndex = 1, int count = 20)
        {
            if (apiScopeId.HasValue)
            {
                return await this._dbContext.ApiScopeProperties.Where(x => x.ScopeId == apiScopeId.Value).Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
            else
            {
                return await this._dbContext.ApiScopeProperties.Take(count).Skip((pageIndex - 1) * count).ToListAsync();
            }
        }

        public async Task<ApiScopeProperty> GetApiScopePropertyAsync(int id)
        {
            return await this._dbContext.ApiScopeProperties.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ApiScope>> GetApiScopesAsync(string apiName)
        {

            return await this._dbContext.ApiScopes.Where(x => x.DisplayName.Contains(apiName) || x.Name.Contains(apiName)).ToListAsync();
                
        }

        public async Task<List<ApiScope>> GetApiScopesAsync(int pageIndex = 1, int count = 20)
        {
            return await this._dbContext.ApiScopes.Take(count).Skip((pageIndex - 1) * count).ToListAsync();
        }

        public async Task<List<ApiScope>> GetApiScopesAsync()
        {
            return await this._dbContext.ApiScopes.ToListAsync();
        }

        public async Task<int> UpdateApiScopeAsync(ApiScope apiScope)
        {
            this._dbContext.ApiScopes.Update(apiScope);
            return  await this._unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateApiScopeClaimAsync(ApiScopeClaim claim)
        {
            this._dbContext.ApiScopeClaims.Update(claim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateApiScopePropertyAsync(ApiScopeProperty property)
        {
            this._dbContext.ApiScopeProperties.Update(property);
            return await this._unitOfWork.CommitAsync();
        }
    }
}
