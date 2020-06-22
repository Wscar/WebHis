using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using YMB.Admin.Models;

namespace YMB.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task< IActionResult> Privacy()
        {
            ////var accessToken = await HttpContext.GetTokenAsync("access_token");

            ////var client = new HttpClient();
            ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            ////var content = await client.GetStringAsync("http://localhost:5001/identity");

            //// ViewBag.Json = JArray.Parse(content).ToString();
            //Dictionary<string, Dictionary<string, string>> props = new Dictionary<string, Dictionary<string, string>>();
            //var claims = new Dictionary<string, string>();
            //foreach (var claim in User.Claims)
            //{
            //    claims.Add(claim.Type, claim.Value);
            //}
            //props.Add("Claims", claims);
            //var xxx = new Dictionary<string, string>();
            //foreach (var prop in (await HttpContext.AuthenticateAsync()).Properties.Items)
            //{
            //    xxx.Add(prop.Key, prop.Value);
            //}
            //props.Add("prop", xxx);
            //var  json = Newtonsoft.Json.JsonConvert.SerializeObject(props);
            var name= this.User.Identity.Name;
            var x= this.User;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            return Content(idToken);
           // return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
