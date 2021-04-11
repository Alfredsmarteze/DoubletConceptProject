using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoubletConceptProject.Data;
using DoubletConceptProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoubletConceptProject.Controllers
{
    public class Account : Controller
    {
        private readonly DoubletContext doubletContext;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        public Account(DoubletContext doubletContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.doubletContext = doubletContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }




        [HttpGet]
        [Authorize]
        public IActionResult Register(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = admin.UserName, Email = admin.Email };
                var userdata = await userManager.CreateAsync(user, admin.Password);
                if (userdata.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var err in userdata.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }

            }
           
            return View(admin);
        }






        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginInfo dmin, string ReturnUrl)
        {
           
            if (ModelState.IsValid)
            {
                var sign = await signInManager.PasswordSignInAsync(dmin.Username, dmin.Password,
                    dmin.RememberMe, false);
                if (sign.Succeeded)
                {
                   if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("CustomerDetails", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Details");
                }
            }
            return View(dmin);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CustomerDetails(string returnUrl)
        {
            var CustDetails = doubletContext.yourMessages.ToList();
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
               // return RedirectToAction("CustomerDetails", "Account");
                return View(CustDetails);
            }
            
            
        }
    }
}
