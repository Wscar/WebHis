using Microsoft.Extensions.Logging;
using SmartSql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServerDomain;
using Ymb.Infrastructure;
using SmartSql;
using SmartSql.AOP;

namespace Ymb.IdentityServerApplication
{
    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger<ClientService> _logger;

        public ClientService(IClientRepository clientRepository, ILogger<ClientService> logger)
        {
            this._clientRepository = clientRepository;
            this._logger = logger;
        }
        /// <summary>
        /// 添加Client
        /// </summary>
        /// <param name="client"></param>
        [Transaction]
        public void AddClient(Client client)
        {
            var requestContennt = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientClaim",
                Request = client
            };
            this._clientRepository.ExcuteNoQuery(requestContennt);
            if (client.ClientSecrets.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientSecret";
                foreach (var item in client.ClientSecrets)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }
            else
            {
                throw new ArgumentNullException("ClientSecrets", "ClientSecrets can not null or empty");
            }

            if (client.AllowedGrantTypes.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientGrantType";
                foreach (var item in client.AllowedGrantTypes)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }
            else
            {
                throw new ArgumentNullException("ClientSecrets", "AllowedGrantTypes can not null or empty");
            }

            if (client.RedirectUris.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientRedirectUri";
                foreach (var item in client.RedirectUris)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }

            if (client.PostLogoutRedirectUris.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientPostLogoutRedirectUri";
                foreach (var item in client.PostLogoutRedirectUris)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }

            if (client.AllowedScopes.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientScopes";
                foreach (var item in client.AllowedScopes)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }

            if (client.IdentityProviderRestrictions.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientIdPRestriction";
                foreach (var item in client.IdentityProviderRestrictions)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }

            if (client.Claims.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientClaim";
                foreach (var item in client.Claims)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }

            if (client.AllowedCorsOrigins.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientCorsOrigin";
                foreach (var item in client.AllowedCorsOrigins)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }
            if (client.Properties.IsNullOrEmpty())
            {
                requestContennt.SqlId = "Insert_ClientProperty";
                foreach (var item in client.AllowedCorsOrigins)
                {
                    requestContennt.Request = item;
                    this._clientRepository.ExcuteNoQuery(requestContennt);
                }
            }
        }

        public Task AddClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> QueryAll(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> QueryAllAsync(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> QueryPage(int indexPage, int skipPageCount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> QueryPageAsync(int indexPage, int skipPageCount)
        {
            throw new NotImplementedException();
        }

        public Client QuerySingle(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> QuerySingleAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
