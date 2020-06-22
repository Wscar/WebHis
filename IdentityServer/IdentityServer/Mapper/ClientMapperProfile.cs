using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Security.Claims;
using YMB.IdentityServer.Entities;
using System.Security.Cryptography.X509Certificates;

namespace YMB.IdentityServer.Mapper
{
    public class ClientMapperProfile:Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Entities.ClientProperty, KeyValuePair<string, string>>()
               .ReverseMap();
               
            List<string> a = new List<string>();
          
            CreateMap<Entities.Client, IdentityServer4.Models.Client>()
                .ForMember(dest => dest.ProtocolType, opt =>opt.Condition(srs => srs != null))
                
                 .ReverseMap();              
            CreateMap<Entities.ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientClaim,  Claim>(MemberList.None)
                .ConstructUsing(src => new  Claim(src.Type, src.Value, ClaimValueTypes.String))
                .ReverseMap();
            
            CreateMap<Entities.ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));          
            CreateMap<Entities.ClientSecret, IdentityServer4.Models.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
            

        }
    }
    public class DictValueConvert : IValueConverter<List<Entities.Property>, Dictionary<String, String>>
    {
        public Dictionary<string, string> Convert(List<Property> sourceMember, ResolutionContext context)
        {
            var dict = new Dictionary<string, string>();
            foreach(var item  in sourceMember)
            {
                dict.Add(item.Id.ToString(), item.Value);
            }
            return dict;
        }
    }
}
