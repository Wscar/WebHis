using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMB.IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="mvc",
                    ClientName="myMvc",
                    ClientSecrets=new List<Secret>{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RedirectUris={ "http://localhost:9000/signin-oidc" },
                    RequireConsent=false,
                    //RequirePkce = true,
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        },
                       AllowOfflineAccess=true,
                       AlwaysIncludeUserClaimsInIdToken=true
                },
                new Client
                {
                    ClientId="Ymb_IdentityServer4_Admin",
                    ClientName="Ymb_IdentityServer4_Admin",
                    ClientSecrets=new List<Secret>{new Secret("Ymb_IdentityServer4_Admin_Secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RedirectUris={ "https://localhost:44303/signin-oidc" },
                    RequireConsent=false,
                    //RequirePkce = true,
                   // PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                   PostLogoutRedirectUris={ "https://localhost:44303/signout-callback-oidc" },
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                          
                            "api1"
                        },
                       AllowOfflineAccess=true,
                       AlwaysIncludeUserClaimsInIdToken=true
                },
                // vue客户端
                new Client
                {
                    ClientId="vue-client",
                    ClientName="vue客户端",
                    ClientUri="http://localhost:4000",
                    AllowedGrantTypes=GrantTypes.Code,
                    AllowAccessTokensViaBrowser=true,
                    RequireConsent=true,
                    AccessTokenLifetime=60,
                    
                    //登陆和刷新token的地址
                    RedirectUris={"http://localhost:4000/signin-oidc", "http://localhost:4000/redirect-silentrenew" },
                    //退出地址
                    PostLogoutRedirectUris={"http://localhost:4000" },
                    //跨域 
                    AllowedCorsOrigins={"http://localhost:4000" },
                    AllowedScopes=  new List<string>
                        {   "api1",
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        }
                }

            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","test_api1")
            };
        }
        public static List<TestUser> Users()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="yemobai",
                    Password="123"                
                    
                }
            };
        }
    }
}

