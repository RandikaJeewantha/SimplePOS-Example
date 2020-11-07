using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketECommerceWebApp.Models;

namespace SuperMarketECommerceWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext _userContext;

        public AccountController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        private bool ValidateLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else {
                return true;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ValidateLogin(userName, password))
            {
                if (userName != "" && password != "" && userName != null && password != null) {
                    
                    var user = _userContext.Users.FromSqlRaw("SELECT * From Users Where Email = {0} And Password = {1}", userName, password).FirstOrDefault();

                    if (user != null) {

                        HttpContext.Session.SetInt32("id", user.AccountId);
                        HttpContext.Session.SetString("email", user.Email);

                        var claims = new List<Claim> {
                            new Claim("user", user.FirstName),
                            new Claim("role", user.Position)
                        };

                        await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "user", "role")));
                    }
                }

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
