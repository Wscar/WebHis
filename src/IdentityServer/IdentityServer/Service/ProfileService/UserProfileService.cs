using IdentityModel;
using IdentityServer4.Models;
using IdentityServerHost.Quickstart.UI;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace YMB.IdentityServer.Service
{
    public class UserProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.Claims.First(x => x.Type == "sub").Value;
           var user= TestUsers.Users.SingleOrDefault(x => x.SubjectId == subjectId);
            var claims = new List<Claim>
            {
                new Claim("Address",user.Claims.SingleOrDefault(x=>x.Type=="address").Value),
                new Claim("user_type","admin"),              
                new Claim(JwtClaimTypes.Role,"SkorubaIdentityAdminAdministrator"),
            };
          
            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject.Claims.First(x => x.Type == "sub").Value;
            var user = TestUsers.Users.SingleOrDefault(x => x.SubjectId == subjectId);
            if (user != null)
            {
                context.IsActive = true;
              
                return Task.CompletedTask;
            }
            else
            {
                context.IsActive = false;
                return Task.CompletedTask;
            }
        }
    }
}
