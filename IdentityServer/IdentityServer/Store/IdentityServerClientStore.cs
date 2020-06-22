using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSql;
using YMB.IdentityServer.Repository;
using AutoMapper;
using YMB.IdentityServer.Mapper;

namespace YMB.IdentityServer.Store
{
    public class IdentityServerClientStore : IClientStore
    {
        private readonly IClientRepository clientRepository;
        public IdentityServerClientStore(IClientRepository _clientRepository)
        {
            this.clientRepository = _clientRepository;
        }
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = this.clientRepository.GetClient(clientId);
            if (client != null)
            {
                client.ClientSecrets = this.clientRepository.GetAllClientSecret(clientId);
                client.AllowedGrantTypes = this.clientRepository.GetAllClientGrantType(clientId);
                client.RedirectUris = this.clientRepository.GetAllClientRedirectUri(clientId);
                client.PostLogoutRedirectUris = this.clientRepository.GetAllClientPostLogoutRedirectUri(clientId);
                client.AllowedScopes = this.clientRepository.GetAllClientScope(clientId);
                client.IdentityProviderRestrictions = this.clientRepository.GetAllClientIdPRestriction(clientId);
                client.Claims = this.clientRepository.GetAllClientClaim(clientId);
                client.AllowedCorsOrigins = this.clientRepository.GetAllClientCorsOrigin(clientId);
                client.Properties = this.clientRepository.GetAllClientProperty(clientId);
                var identyServerClient = client.ToModel();
                return Task.FromResult(identyServerClient);
            }
            else
            {
                throw new NullReferenceException($"没有查询到当前clientId为：{clientId}的数据");
            }
            
        }
        
    }
}
