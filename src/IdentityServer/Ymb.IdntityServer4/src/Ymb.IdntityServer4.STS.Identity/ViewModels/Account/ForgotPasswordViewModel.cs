using Ymb.IdntityServer4.STS.Identity.Configuration;
using System.ComponentModel.DataAnnotations;
using Ymb.IdntityServer4.Shared.Configuration.Identity;

namespace Ymb.IdntityServer4.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}






