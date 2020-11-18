using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.IdentityServer4.Admin.EF.Repositories.Interface
{
    public interface IApiScopeRepostory
    {
        #region ApiScope 增删改查
        Task<int> AddApiScopeAsync(ApiScope apiScope);
        Task<int> UpdateApiScopeAsync(ApiScope apiScope);
        Task<int> DeleteApiScopeAsync(ApiScope apiScope);

        Task<ApiScope> GetApiScopeAsync(int id);

        Task<List<ApiScope>> GetApiScopesAsync(string apiName);
        Task<List<ApiScope>> GetApiScopesAsync(int pageIndex = 1, int count=20);
        Task<List<ApiScope>> GetApiScopesAsync();
        #endregion
        #region ApiScopeClaim 增删改查
        Task<int> AddApiScopeClaimAsync(ApiScopeClaim claim);
        Task<int> UpdateApiScopeClaimAsync(ApiScopeClaim claim);
        Task<int> DeleteApiScopeClaimAsync(ApiScopeClaim claim);

        Task<ApiScopeClaim> GetApiScopeClaimAsync(int id);

        Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync(int apiScopeId);

        Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync();

        Task<List<ApiScopeClaim>> GetApiScopeClaimsAsync( int?  apiScopeId,int pageIndex = 1, int count = 20);
        #endregion


        Task<int> AddApiScopePropertyAsync(ApiScopeProperty property);
        Task<int> UpdateApiScopePropertyAsync(ApiScopeProperty property);
        Task<int> DeleteApiScopePropertyAsync(ApiScopeProperty property);

        Task<ApiScopeProperty> GetApiScopePropertyAsync(int id);

        Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync(int apiScopeId);

        Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync();

        Task<List<ApiScopeProperty>> GetApiScopePropertiesAsync( int? apiScopeId, int pageIndex = 1, int count = 20);
    }
}
