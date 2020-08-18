using SmartSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMB.IdentityServer.Entities;

namespace YMB.IdentityServer.Repository
{
    public class ClientRepository : IClientRepository
    {
        public ISqlMapper sqlMapper;
        public ClientRepository(ISqlMapper _sqlMapper)
        {
            sqlMapper = _sqlMapper;
        }
        public List<ClientClaim> GetAllClientClaim(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientClaims_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientClaim>(requestContent).ToList();
        }

        public List<ClientCorsOrigin> GetAllClientCorsOrigin(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientCorsOrigins_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientCorsOrigin>(requestContent).ToList();
        }

        public List<ClientGrantType> GetAllClientGrantType(string clientId)
        {

            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientGrantTypes_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientGrantType>(requestContent).ToList();
        }

        public List<ClientIdPRestriction> GetAllClientIdPRestriction(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientIdPRestrictions_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientIdPRestriction>(requestContent).ToList();
        }

        public List<ClientPostLogoutRedirectUri> GetAllClientPostLogoutRedirectUri(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientPostLogoutRedirectUris_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientPostLogoutRedirectUri>(requestContent).ToList();
        }

        public List<ClientProperty> GetAllClientProperty(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientProperties_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientProperty>(requestContent).ToList();
        }

        public List<ClientRedirectUri> GetAllClientRedirectUri(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientRedirectUris_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientRedirectUri>(requestContent).ToList();
        }

        public List<ClientScope> GetAllClientScope(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientScopes_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientScope>(requestContent).ToList();
        }

        public List<ClientSecret> GetAllClientSecret(string clientId)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "ClientSecrets_Query",
                Request = new { ClientId = clientId }
            };
            return sqlMapper.Query<ClientSecret>(requestContent).ToList();
        }

        public Client GetClient(string id)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Client_Query",
                Request = new { id }
            };
            return sqlMapper.QuerySingle<Client>(requestContent);
        }

        public void InsertClientClaim(ClientClaim clientClaim)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientClaim",
                Request = clientClaim

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:Insert_ClientClaim执行失败，受影响的行数小于等于0");
            }
        }

        public void InserClientCorsOrigin(ClientCorsOrigin corsOrigin)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientClaim",
                Request = corsOrigin

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:Insert_ClientClaim执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClient(Client client)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientClaim",
                Request = client

            };
            sqlMapper.BeginTransaction();
            try
            {
                var result = sqlMapper.Execute(requestContent);
                if (client.ClientSecrets.IsNotEmpty())
                {
                    foreach (var secret in client.ClientSecrets)
                    {
                        this.InsertClientSecret(secret);
                    }
                }
                if (client.AllowedGrantTypes.IsNotEmpty())
                {
                    foreach (var grantType in client.AllowedGrantTypes)
                    {
                        this.InsertClientGrantType(grantType);
                    }
                }
                if (client.RedirectUris.IsNotEmpty())
                {
                    foreach (var redirectUri in client.RedirectUris)
                    {
                        this.InsertClientRedirectUri(redirectUri);
                    }
                }
                if (client.PostLogoutRedirectUris.IsNotEmpty())
                {
                    foreach (var postLogoutUri in client.PostLogoutRedirectUris)
                    {
                        this.InsertClientPostLogoutRedirectUri(postLogoutUri);
                    }
                }
                if (client.AllowedScopes.IsNotEmpty())
                {
                    foreach (var scope in client.AllowedScopes)
                    {
                        this.InsertClientScope(scope);
                    }
                }
                if (client.IdentityProviderRestrictions.IsNotEmpty())
                {
                    foreach (var item in client.IdentityProviderRestrictions)
                    {
                        this.InsertClientIdPRestriction(item);
                    }
                }
                if (client.Claims.IsNotEmpty())
                {
                    foreach (var claim in client.Claims)
                    {
                        this.InsertClientClaim(claim);
                    }
                }
                if (client.AllowedCorsOrigins.IsNotEmpty())
                {
                    foreach (var cors in client.AllowedCorsOrigins)
                    {
                        this.InserClientCorsOrigin(cors);
                    }
                }
                if (client.Properties.IsNotEmpty())
                {
                    foreach (var prop in client.Properties)
                    {
                        this.InsertClientProperty(prop);
                    }
                }
            }catch(Exception ex)
            {
                sqlMapper.RollbackTransaction();
                throw ex;
            }



        }

        public void InsertClientGrantType(ClientGrantType clientGrantType)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientGrantType",
                Request = clientGrantType

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientIdPRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientIdPRestriction",
                Request = clientIdPRestriction

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientPostLogoutRedirectUri(ClientPostLogoutRedirectUri postLogoutRedirectUri)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientPostLogoutRedirectUri",
                Request = postLogoutRedirectUri

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientProperty(ClientProperty clientProperty)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientProperty",
                Request = clientProperty

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientRedirectUri(ClientRedirectUri clientRedirectUri)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientRedirectUri",
                Request = clientRedirectUri

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientScope(ClientScope scope)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientScopes",
                Request = scope

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void InsertClientSecret(ClientSecret ClientSecret)
        {
            var requestContent = new RequestContext
            {
                Scope = "Client",
                SqlId = "Insert_ClientSecret",
                Request = ClientSecret

            };
            var result = sqlMapper.Execute(requestContent);
            if (result <= 0)
            {
                throw new Exception($"sqlId:{requestContent.SqlId}执行失败，受影响的行数小于等于0");
            }
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
