using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServer4.Admin.EF.Repositories.Interface;
using System.Linq.Expressions;
namespace Ymb.IdentityServer4.Admin.EF.Repositories
{
    public class ClientRepository<TDbConetnt> : IClientRepository where TDbConetnt : DbContext, IYmbIdsDbContext
    {
        private readonly TDbConetnt _dbContext;

        private readonly UnitOfWork<TDbConetnt> _unitOfWork;

        public ClientRepository(TDbConetnt dbConetnt, UnitOfWork<TDbConetnt> unitOfWork)
        {
            this._dbContext = dbConetnt;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> AddClientAsync(Client client)
        {
            var entity = await this._dbContext.Clients.AddAsync(client);
            await this._unitOfWork.CommitAsync();
            return entity.Entity.Id;
        }

        public async Task<int> DeleteClientAsync(int clientId)
        {
            var client = await this._dbContext.Clients.FirstOrDefaultAsync(x => x.Id == clientId);
            if (client == null)
            {
                throw new NullReferenceException($"没有找到ID是{clientId}的client数据");
            }
            else
            {
                this._dbContext.Clients.Remove(client);
                await this._unitOfWork.CommitAsync();
                return clientId;
            }

        }

        public async Task<int> DeleteClientClaim(ClientClaim clientClaim)
        {
            this._dbContext.ClientClaims.Remove(clientClaim);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientCorsOrigin(ClientCorsOrigin clientCorsOrigin)
        {
            this._dbContext.ClientCorsOrigins.Remove(clientCorsOrigin);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientGrantType(ClientGrantType clientGrantType)
        {
            this._dbContext.ClientGrantTypes.Remove(clientGrantType);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientIdPRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            this._dbContext.ClientIdPRestrictions.Remove(clientIdPRestriction);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientProperty(ClientProperty clientProperty)
        {
            this._dbContext.ClientProperties.Remove(clientProperty);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientRedirectUrl(ClientRedirectUri uri)
        {
            this._dbContext.ClientRedirectUris.Remove(uri);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientScope(ClientScope scope)
        {
            this._dbContext.ClientScopes.Remove(scope);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteClientSecret(ClientSecret clientSecret)
        {
            this._dbContext.ClientSecrets.Remove(clientSecret);
            return await this._unitOfWork.CommitAsync();
        }

        public async Task<List<Client>> GetAllClientAsync()
        {
           return await  this._dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            return await this._dbContext.Clients.SingleOrDefaultAsync(x => x.Id == clientId);
        }

        public  Task<List<Client>> GetClientByPage(string search = "", int pageIndex = 1, int count = 20)
        {
            var clients=  this._dbContext.Clients.Take(count).Skip(pageIndex * count).ToList();
            return  Task.FromResult(clients);
        }

        public async Task<List<ClientClaim>> GetClientClaims(int clientId)
        {
            return await  this._dbContext.ClientClaims.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientCorsOrigin>> GetClientCorsOrigins(int clientId)
        {
            return await this._dbContext.ClientCorsOrigins.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientGrantType>> GetClientGrantTypes(int clientId)
        {
            return await this._dbContext.ClientGrantTypes.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public  async Task<List<ClientIdPRestriction>> GetClientIdPRestrictions(int clientId)
        {
            return await this._dbContext.ClientIdPRestrictions.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientPostLogoutRedirectUri>> GetClientPostLogoutRedirectUris(int clientId)
        {
            return await this._dbContext.ClientPostLogoutRedirectUris.Where(x => x.ClientId == clientId).ToListAsync();

        }

        public async Task<List<ClientProperty>> GetClientProperties(int clientId)
        {
            return await this._dbContext.ClientProperties.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientRedirectUri>> GetClientRedirectUris(int clientId)
        {
            return await this._dbContext.ClientRedirectUris.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientScope>> GetClientScopes(int clientId)
        {
            return await this._dbContext.ClientScopes.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<List<ClientSecret>> GetClientSecrets(int clientId)
        {
            return await this._dbContext.ClientSecrets.Where(x => x.ClientId == clientId).ToListAsync() ;
           
        }

        public async Task<int> UpdateClientAsync(Client client)
        {
              this._dbContext.Clients.Update(client);
          return await   this._unitOfWork.CommitAsync();
        }
    }
}
