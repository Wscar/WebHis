using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMB.IdentityServer.Entities;

namespace YMB.IdentityServer.Mapper
{
    public static class ClientMapper
    {     
         static ClientMapper()
        {
            Mapper = new MapperConfiguration(x => x.AddProfile<ClientMapperProfile>()).CreateMapper();
        }
         internal static IMapper Mapper { get; }

        public static IdentityServer4.Models.Client ToModel(this Entities.Client client)
        {
            return Mapper.Map<IdentityServer4.Models.Client>(client);
        }
        public static Entities.Client ToEntity(this IdentityServer4.Models.Client client)
        {
            return Mapper.Map<Entities.Client>(client);
        }
    }
   
}
