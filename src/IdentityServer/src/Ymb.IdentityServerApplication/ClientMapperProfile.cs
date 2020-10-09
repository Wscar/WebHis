﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Ymb.IdentityServerDomain;
namespace Ymb.IdentityServerApplication
{
    public class ClientMapperProfile:Profile
    {
         public ClientMapperProfile()
        {
            CreateMap<ClientProperty, KeyValuePair<string, string>>()
               .ReverseMap();
               
         
          
            CreateMap<Client, IdentityServer4.Models.Client>()
                .ForMember(dest => dest.ProtocolType, opt =>opt.Condition(srs => srs != null))
                
                 .ReverseMap();              
            CreateMap<ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<ClientClaim, IdentityServer4.Models.ClientClaim>(MemberList.None)
                .ConstructUsing(src =>new  IdentityServer4.Models.ClientClaim(src.Type, src.Value,ClaimValueTypes.String))
                .ReverseMap();

            CreateMap<ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));          
            CreateMap<ClientSecret, IdentityServer4.Models.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
            

        }
    }
}
