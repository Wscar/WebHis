using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymb.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

namespace Ymb.IdentityServer4.Admin.Service.Repostotories
{
    public class ClientRepository : IClientRepository
    {

        public readonly IdentityServerConfigurationDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;
        public ClientRepository(IdentityServerConfigurationDbContext dbContext, ILogger<ClientRepository> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }
        public bool AutoSaveChanges { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<int> AddClientAsync(Client client)
        {
            await this._dbContext.Clients.AddAsync(client);
            return await this.CommitAsync();
        }

        public async Task<int> AddClientClaimAsync(int clientId, ClientClaim clientClaim)
        {
            var client = await this._dbContext.Clients.SingleOrDefaultAsync(x => x.Id == clientId);
            if (client != null)
            {
                clientClaim.Client = client;
                await this._dbContext.ClientClaims.AddAsync(clientClaim);
                return await this.CommitAsync();
            }
            else
            {
                string error = $"方法：AddClientClaimAsync,无法通过clientId找到Client";
                var cudException = new IdentityServerCudException(error);
                _logger.LogError(cudException, error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
        }

        public async Task<int> AddClientPropertyAsync(int clientId, ClientProperty clientPropertiy)
        {
            var client = await this._dbContext.Clients.SingleOrDefaultAsync(x => x.Id == clientId);
            if (client != null)
            {
                clientPropertiy.Client = client;
                await this._dbContext.ClientProperties.AddAsync(clientPropertiy);
                return await this.CommitAsync();
            }
            else
            {
                string error = $"方法：AddClientPropertyAsync,无法通过clientId找到Client";
                var cudException = new IdentityServerCudException(error);
                _logger.LogError(cudException, error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
        }

        public async Task<int> AddClientSecretAsync(int clientId, ClientSecret clientSecret)
        {
            var client = await this._dbContext.Clients.SingleOrDefaultAsync(x => x.Id == clientId);
            if (client != null)
            {
                clientSecret.Client = client;
                await this._dbContext.ClientSecrets.AddAsync(clientSecret);
                return await this.CommitAsync();
            }
            else
            {
                string error = $"方法：AddClientSecretAsync,无法通过clientId找到Client";
                var cudException = new IdentityServerCudException(error);
                _logger.LogError(cudException, error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
        }

        public async Task<bool> CanInsertClientAsync(Client client, bool isCloned = false)
        {
            var currentClient = await this._dbContext.Clients.SingleOrDefaultAsync(x => x.ClientId == client.ClientId);
            if (currentClient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> CloneClientAsync(Client client, bool cloneClientCorsOrigins = true,
            bool cloneClientGrantTypes = true,
            bool cloneClientIdPRestrictions = true,
            bool cloneClientPostLogoutRedirectUris = true,
            bool cloneClientScopes = true,
            bool cloneClientRedirectUris = true,
            bool cloneClientClaims = true,
            bool cloneClientProperties = true)
        {
            var newClient = await this._dbContext.Clients
                .Include(x => x.AllowedGrantTypes)
                  .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.Properties)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == client.Id);
            if (newClient == null)
            {
                string error = $"方法：CloneClientAsync,无法通过d找到Client";
                var cudException = new IdentityServerCudException(error);
                _logger.LogError(cudException, error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }

            newClient.Id = 0;
            newClient.AllowedCorsOrigins.ForEach(x => x.Id = 0);
            newClient.RedirectUris.ForEach(x => x.Id = 0);
            newClient.PostLogoutRedirectUris.ForEach(x => x.Id = 0);
            newClient.AllowedScopes.ForEach(x => x.Id = 0);
            newClient.ClientSecrets.ForEach(x => x.Id = 0);
            newClient.IdentityProviderRestrictions.ForEach(x => x.Id = 0);
            newClient.Claims.ForEach(x => x.Id = 0);
            newClient.AllowedGrantTypes.ForEach(x => x.Id = 0);
            newClient.Properties.ForEach(x => x.Id = 0);
            if (!cloneClientCorsOrigins)
            {
                newClient.AllowedCorsOrigins.Clear();
            }
            if (!cloneClientGrantTypes)
            {
                newClient.AllowedGrantTypes.Clear();
            }
            if (!cloneClientIdPRestrictions)
            {
                newClient.IdentityProviderRestrictions.Clear();
            }
            if (!cloneClientPostLogoutRedirectUris)
            {
                newClient.PostLogoutRedirectUris.Clear();
            }
            if (!cloneClientScopes)
            {
                newClient.AllowedScopes.Clear();
            }
            if (!cloneClientRedirectUris)
            {
                newClient.RedirectUris.Clear();
            }
            if (!cloneClientClaims)
            {
                newClient.Claims.Clear();
            }
            if (!cloneClientProperties)
            {
                newClient.Properties.Clear();
            }
            await this._dbContext.Clients.AddAsync(newClient);
            return await this.CommitAsync();
        }

        public async Task<int> DeleteClientClaimAsync(ClientClaim clientClaim)
        {
            var deleteClaim = await this._dbContext.ClientClaims.SingleOrDefaultAsync(x => x.Id == clientClaim.Id);
            if (deleteClaim == null)
            {
                var error = $"方法DeleteClientClaimAsync,没有找到id为:{clientClaim.Id}的cliaim";
                this.LogError(error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
            else
            {
                this._dbContext.ClientClaims.Remove(clientClaim);
                return await this.CommitAsync();
            }

        }

        public async Task<int> DeleteClientPropertyAsync(ClientProperty clientProperty)
        {
            var deletePropery = await this._dbContext.ClientProperties.SingleOrDefaultAsync(x => x.Id == clientProperty.Id);
            if (deletePropery == null)
            {
                var error = $"方法DeleteClientPropertyAsync,没有找到id为:{clientProperty.Id}的ClientProperty";
                this.LogError(error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
            else
            {
                this._dbContext.ClientProperties.Remove(deletePropery);
                return await this.CommitAsync();
            }
        }

        public async Task<int> DeleteClientSecretAsync(ClientSecret clientSecret)
        {
            var deleteSecret = await this._dbContext.ClientSecrets.SingleOrDefaultAsync(x => x.Id == clientSecret.Id);
            if (deleteSecret == null)
            {
                var error = $"方法DeleteClientSecretAsync,没有找到id为:{clientSecret.Id}的ClientSecret";
                this.LogError(error);
                return await Task.FromResult(CudOperationCommitStatus.FAIL);
            }
            else
            {
                this._dbContext.ClientSecrets.Remove(deleteSecret);
                return await this.CommitAsync();
            }
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            return await this._dbContext.Clients.Include(x => x.AllowedGrantTypes)
                 .Include(x => x.RedirectUris)
                 .Include(x => x.PostLogoutRedirectUris)
                 .Include(x => x.AllowedCorsOrigins)
                 .Include(x => x.Claims)
                 .Include(x => x.Properties)
                 .Include(x => x.RedirectUris)
                 .Include(x => x.AllowedScopes)
                 .Include(x => x.ClientSecrets)
                 .Include(x => x.IdentityProviderRestrictions)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == clientId);
        }

        public async Task<ClientClaim> GetClientClaimAsync(int clientClaimId)
        {
            return await this._dbContext.ClientClaims.Include(x => x.Client)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == clientClaimId);
        }

        public async Task<PagedList<ClientClaim>> GetClientClaimsAsync(int clientId, int page = 1, int pageSize = 10)
        {
            var claims = await this._dbContext.ClientClaims.Where(x => x.Id == clientId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<ClientClaim> { Data = claims, PageSize = claims.Count };
        }

        public Task<(string ClientId, string ClientName)> GetClientIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<ClientProperty>> GetClientPropertiesAsync(int clientId, int page = 1, int pageSize = 10)
        {
            var properties = await this._dbContext.ClientProperties.Where(x => x.ClientId == clientId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<ClientProperty> { Data = properties, PageSize = properties.Count };
        }

        public async Task<ClientProperty> GetClientPropertyAsync(int clientPropertyId)
        {
            return await this._dbContext.ClientProperties.SingleOrDefaultAsync(x => x.Id == clientPropertyId);
        }

        public async Task<PagedList<Client>> GetClientsAsync(string search = "", int page = 1, int pageSize = 10)
        {
            var clients = await this._dbContext.Clients.Include(x => x.AllowedGrantTypes)
                 .Include(x => x.RedirectUris)
                 .Include(x => x.PostLogoutRedirectUris)
                 .Include(x => x.AllowedCorsOrigins)
                 .Include(x => x.Claims)
                 .Include(x => x.Properties)
                 .Include(x => x.RedirectUris)
                 .Include(x => x.AllowedScopes)
                 .Include(x => x.ClientSecrets)
                 .Include(x => x.IdentityProviderRestrictions)
                 .AsNoTracking()
                 .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<Client> { Data = clients, PageSize = clients.Count };

        }

        public async Task<ClientSecret> GetClientSecretAsync(int clientSecretId)
        {
            return await this._dbContext.ClientSecrets.SingleOrDefaultAsync(x => x.Id == clientSecretId);
        }

        public async Task<PagedList<ClientSecret>> GetClientSecretsAsync(int clientId, int page = 1, int pageSize = 10)
        {
            var secrets = await this._dbContext.ClientSecrets.Where(x => x.ClientId == clientId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<ClientSecret> { Data = secrets, PageSize = secrets.Count };
        }

        public List<string> GetGrantTypes(string grant, int limit = 0)
        {
            if (limit <= 0)
            {
                throw new InvalidOperationException("方法GetGrantTypes的参数limit必须大于0");
            }
            if (string.IsNullOrEmpty(grant))
            {
                return ClientConsts.GetGrantTypes();
            }
            else
            {
                return ClientConsts.GetGrantTypes().Where(x => x.Contains(grant)).Take(limit).ToList();
            }
        }

        public async Task<List<string>> GetScopesAsync(string scope, int limit = 0)
        {
            if (limit <= 0)
            {
                throw new InvalidOperationException("方法GetGrantTypes的参数limit必须大于0");
            }
            var scopes = new List<string>();
            var identityResources = new List<string>();
            var apiScopes = new List<string>();
            if (string.IsNullOrEmpty(scope))
            {
                identityResources = await this._dbContext.IdentityResources.Take(limit).Select(x => x.Name).ToListAsync();
                apiScopes = await this._dbContext.ApiScopes.Take(limit).Select(x => x.Name).ToListAsync(); ;
            }
            else
            {
                identityResources = await this._dbContext.IdentityResources.Where(x => x.Name.Contains(scope)).Take(limit).Select(x => x.Name).ToListAsync(); ;
                apiScopes = await this._dbContext.ApiScopes.Where(x => x.Name.Contains(scope)).Take(limit).Select(x => x.Name).ToListAsync();
            }
            scopes.AddRange(identityResources);
            scopes.AddRange(apiScopes);
            return scopes;
        }

        public List<string> GetStandardClaims(string claim, int limit = 0)
        {
            if (limit <= 0)
            {
                throw new InvalidOperationException("方法GetGrantTypes的参数limit必须大于0");
            }
            if (!string.IsNullOrEmpty(claim))
            {
                return ClientConsts.GetStandardClaims().Where(x => x.Contains(claim)).Take(limit).ToList();
            }
            else
            {
                return ClientConsts.GetStandardClaims().Take(limit).ToList();
            }

        }

        public async Task<int> RemoveClientAsync(Client client)
        {
           await  this.RemoveClientRelationsAsync(client);
            this._dbContext.Clients.Remove(client);
            return await CommitAsync();
        }

        public Task<int> SaveAllChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateClientAsync(Client client)
        {
            await this.RemoveClientRelationsAsync(client);
            this._dbContext.Clients.Update(client);
            return await this.CommitAsync();
        }
        private async Task<int> CommitAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }
        private void LogError(string message)
        {

            var cudException = new IdentityServerCudException(message);
            _logger.LogError(cudException, message);
        }
        private async Task RemoveClientRelationsAsync(Client client)
        {
            //Remove old allowed scopes
            var clientScopes = await _dbContext.ClientScopes.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientScopes.RemoveRange(clientScopes);

            //Remove old grant types
            var clientGrantTypes = await _dbContext.ClientGrantTypes.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientGrantTypes.RemoveRange(clientGrantTypes);

            //Remove old redirect uri
            var clientRedirectUris = await _dbContext.ClientRedirectUris.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientRedirectUris.RemoveRange(clientRedirectUris);

            //Remove old client cors
            var clientCorsOrigins = await _dbContext.ClientCorsOrigins.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientCorsOrigins.RemoveRange(clientCorsOrigins);

            //Remove old client id restrictions
            var clientIdPRestrictions = await _dbContext.ClientIdPRestrictions.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientIdPRestrictions.RemoveRange(clientIdPRestrictions);

            //Remove old client post logout redirect
            var clientPostLogoutRedirectUris = await _dbContext.ClientPostLogoutRedirectUris.Where(x => x.Client.Id == client.Id).ToListAsync();
            _dbContext.ClientPostLogoutRedirectUris.RemoveRange(clientPostLogoutRedirectUris);
        }
    }
}
