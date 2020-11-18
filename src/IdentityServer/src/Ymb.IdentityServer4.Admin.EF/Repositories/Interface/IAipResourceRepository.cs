using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
namespace Ymb.IdentityServer4.Admin.EF.Repositories.Interface
{
    public interface IAipResourceRepository
    {
        #region ApiResource增删改查
        Task<int> AddAipResourceAsync(ApiResource apiResource);
        Task<int> UpdateResourceAsync(ApiResource apiResource);

        Task<int> DeleteApiResourceAsync(ApiResource apiResource);
        Task<ApiResource> GetApiResource(int apiResourceId);
        Task<List<ApiResource>> GetApiResourcesAsync();
        Task<List<ApiResource>> GetApiResourcesAsync(string search = "", int pageIndex = 1, int count = 20);
        #endregion
        #region   ApiResourceSecret 增删查
        Task<int> AddApiResourceSecretAsync(ApiResourceSecret secret);
        Task<int> DeleteApiResourceSecretAsync(ApiResourceSecret secret);
        Task<ApiResourceSecret> GetApiResourceSecretAsync(int apiResourceId, int secretId);
        Task<List<ApiResourceSecret>> GetApiResourcesSecretAsync(int? apiResourceId);
        Task<List<ApiResourceSecret>> GetApiResourcesSecretAsync(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20);
        #endregion
        #region  ApiResourceScope 增删差
        Task<int> AddApiResourceScope(ApiResourceScope scope);
        Task<int> DeleteApiResourceScope(ApiResourceScope scope);

        Task<ApiResourceScope> GetApiResourceScope(int apiResourceId, int scopeId);

        Task<List<ApiResourceScope>> GetApiResourceScopes(int? apiResourceId);
        Task<List<ApiResourceScope>> GetApiResourceScopes(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20);
        #endregion
        #region ApiResourceClaim 增删查
        Task<int> AddApiResourceClaim(ApiResourceClaim claim);
        Task<int> DeleteApiResourceClaim(ApiResourceClaim claim);

        Task<ApiResourceClaim> GetApiResourceClaim(int apiResourceId);

        Task<List<ApiResourceClaim>> GetApiResourceClaims(int? apiResourceId);
        Task<List<ApiResourceClaim>> GetApiResourceClaims(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20);
        #endregion
        #region ApiResourceProperty 增删查
        Task<int> AddApiResourceProperties(ApiResourceProperty property);
        Task<int> DeleteApiResourceProperties(ApiResourceProperty property);

        Task<ApiResourceProperty> GetApiApiResourceProperty(int apiResourceId);

        Task<List<ApiResourceProperty>> GetApiResourceProperties(int? apiResourceId);
        Task<List<ApiResourceProperty>> GetApiResourceProperties(int? apiResourceId, string search = "", int pageIndex = 1, int count = 20);
        #endregion

    }
}
