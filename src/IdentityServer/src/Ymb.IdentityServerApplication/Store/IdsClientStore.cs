using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Ymb.IdentityServerApplication.Store
{
    public class IdsClientStore : IClientStore
    {
        public readonly IClientService _ClientService;
        public readonly IObjectMapper<IdentityServerAppModule> _objectMapper;
        private readonly Logger<IdsClientStore> _logger;
        public IdsClientStore(IClientService clientService,IObjectMapper<IdentityServerAppModule> objectMapper)
        {
            this._ClientService = clientService;
            this._objectMapper = objectMapper;
        }
        public  async Task<Client> FindClientByIdAsync(string clientId)
        {
           var  client=await  this._ClientService.QuerySingleAsync(clientId);
            var idsClient= this._objectMapper.Map<IdentityServerDomain.Client, Client>(client);
            return idsClient;
        }
    }
}
