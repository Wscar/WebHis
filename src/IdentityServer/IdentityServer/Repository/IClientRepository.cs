using SmartSql.DyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YMB.IdentityServer.Entities;
namespace YMB.IdentityServer.Repository
{
    public interface IClientRepository
    { 
        Client GetClient(string id);
        List<ClientSecret> GetAllClientSecret(string clientId);
        List<ClientGrantType> GetAllClientGrantType(string clientId);
        List<ClientRedirectUri> GetAllClientRedirectUri(string clientId);
        List<ClientPostLogoutRedirectUri> GetAllClientPostLogoutRedirectUri(string clientId);
        List<ClientScope> GetAllClientScope(string clientId);
        List<ClientIdPRestriction> GetAllClientIdPRestriction(string clientId);
        List<ClientClaim> GetAllClientClaim(string clientId);
        List<ClientCorsOrigin> GetAllClientCorsOrigin(string clientId);
        List<ClientProperty> GetAllClientProperty(string clientId);
         void  InsertClient(Client client);
        void InsertClientSecret(ClientSecret ClientSecret);
        void InsertClientGrantType(ClientGrantType clientGrantType);
        void InsertClientRedirectUri(ClientRedirectUri clientRedirectUri);
        void InsertClientPostLogoutRedirectUri(ClientPostLogoutRedirectUri postLogoutRedirectUri);
        void InsertClientScope(ClientScope scope);
        void InsertClientIdPRestriction(ClientIdPRestriction clientIdPRestriction);
        void InsertClientClaim(ClientClaim clientClaim);
        void InserClientCorsOrigin(ClientCorsOrigin corsOrigin);
        void InsertClientProperty(ClientProperty clientProperty);
      
        void UpdateClient(Client client);
    }
}
