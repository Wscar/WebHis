using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
namespace Ymb.IdentityServer4.Admin.EF.Repositories.Interface
{
    public interface IClientRepository
    {

        Task<int> AddClientAsync(Client client);
        Task<int> UpdateClientAsync(Client client);
        Task<int> DeleteClientAsync(int clientId);

        Task<Client> GetClientAsync(int clientId);
        Task<List<Client>> GetAllClientAsync();
        Task<List<Client>> GetClientByPage(string search="", int pageIndex=1, int count=20);

        Task<List<ClientSecret>> GetClientSecrets(int clientId);

        Task<List<ClientGrantType>> GetClientGrantTypes(int clientId);

        Task<List<ClientRedirectUri>> GetClientRedirectUris(int clientId);

        Task<List<ClientPostLogoutRedirectUri>> GetClientPostLogoutRedirectUris(int clientId);

        Task<List<ClientScope>> GetClientScopes(int clientId);

        Task<List<ClientIdPRestriction>> GetClientIdPRestrictions(int clientId);

        Task<List<ClientClaim>> GetClientClaims(int clientId);
        Task<List<ClientCorsOrigin>> GetClientCorsOrigins(int clientId);
        Task<List<ClientProperty>> GetClientProperties(int clientId);
        Task<int> DeleteClientSecret(ClientSecret clientSecret);
        Task<int> DeleteClientGrantType(ClientGrantType clientGrantType);
        Task<int> DeleteClientRedirectUrl(ClientRedirectUri uri);
        Task<int> DeleteClientScope(ClientScope scope);

        Task<int> DeleteClientIdPRestriction(ClientIdPRestriction clientIdPRestriction);

        Task<int> DeleteClientClaim(ClientClaim clientClaim);

        Task<int> DeleteClientCorsOrigin(ClientCorsOrigin clientCorsOrigin);

        Task<int> DeleteClientProperty(ClientProperty clientProperty);

    }
}
