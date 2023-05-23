using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Service;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
           var user = _userService.Login(model);
           if (user.Data is not null)
           {
                 var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Data.Id),
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.Name, user.Data.Name),
                    // new Claim(ClaimTypes.Role, user.Data.Roles.Name),
                    
                };
                foreach (var item in user.Data.Roles)
                {
                    claims.Add(
                        new Claim(ClaimTypes.Role, item.Name)
                    );
                }
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                HttpContext.SignInAsync(claimsPrincipal);
                TempData["success"] = user.Message;
                if (user.Status == true)
                {
                     if (user.Data.Roles.Select(r => r.Name).Contains("Super Admin"))
                     {
                        return RedirectToAction("Super");
                     }
                     else if (user.Data.Roles.Select(r => r.Name).Contains("Manager"))
                     {
                        return RedirectToAction("Manager");
                     }
                     else if (user.Data.Roles.Select(r => r.Name).Contains("Principal"))
                     {
                        return RedirectToAction("Principal");
                     }
                     else if (user.Data.Roles.Select(r => r.Name).Contains("Client"))
                     {
                        return RedirectToAction("Client");
                     }
                     else if (user.Data.Roles.Select(r => r.Name).Contains("Agent"))
                     {
                        return RedirectToAction("Agent");
                     }
                }

           }
           else if(user.Status == false )
           {
                var user = _userService;
           }
            return View();
        }

        public IActionResult Super()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Client()
        {
            return View();
        }
        public IActionResult Agent()
        {
            return View();
        }
         public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        
    }
}