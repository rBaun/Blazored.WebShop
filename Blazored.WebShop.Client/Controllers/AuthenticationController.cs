using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blazored.WebShop.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string user, [FromQuery] string password)
        {
            if (user != "admin" || password != "admin") 
                return Unauthorized();

            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Email, "admin@blazoredWebshop.com"),
                new Claim(ClaimTypes.HomePhone, "12341234")
            };

            var userIdentity = new ClaimsIdentity(userClaims, "Blazored.WebShop.CookieAuth");

            var userClaimsPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("Blazored.WebShop.CookieAuth", userClaimsPrincipal);

            return Redirect("/orders-in-progress");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/orders-in-progress");
        }
    }
}
