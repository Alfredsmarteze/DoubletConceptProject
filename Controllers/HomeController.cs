using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoubletConceptProject.Models;
using DoubletConceptProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DoubletConceptProject.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DoubletContext _doublet;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly UserManager<IdentityUser> UserManager;
        public IEnumerable<YourMessage> yourMessages { get; private set; }

        public HomeController(ILogger<HomeController> logger, DoubletContext doublet, UserManager<IdentityUser> userManager,
                                        SignInManager<IdentityUser> signInManager)

        {
            this._logger = logger;
            this._doublet = doublet;
            this.UserManager = userManager;
            this._SignInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult YourOrder() 
        {
            YourMessage yourMessage = new YourMessage()

            //var asd = new YourMessage
            {
                Date = DateTime.Today
            };

                return View(yourMessage);
        }

        [HttpPost]
        public async Task<IActionResult> YourOrder(YourMessage mss) 
        {
            if (ModelState.IsValid)
            {
                _doublet.yourMessages.Add(mss);
                await _doublet.SaveChangesAsync();
                ModelState.Clear();
                RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "");
                return View();
            }

            return View();
           
        }

        public IActionResult LandingPage()
        {
            return View();
        }


        // [HttpGet]
        //// [Authorize]
        // public IActionResult Register( string returnUrl) 
        // {
        //     if (!string.IsNullOrEmpty(returnUrl))
        //     {
        //         return LocalRedirect(returnUrl);
        //     }
        //     else
        //     {
        //         return View();
        //     }

        // }

        //[HttpPost]
        //public async Task<IActionResult> Register (Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser { UserName = admin.UserName, Email = admin.Email };
        //        var userdata = await UserManager.CreateAsync(user, admin.Password);
        //        if (userdata.Succeeded)
        //        {
        //          await  _SignInManager.SignInAsync(user, isPersistent:false);
        //          return RedirectToAction("Login", "Home");
        //        }

        //        foreach (var err in userdata.Errors)
        //        {
        //            ModelState.AddModelError("", err.Description);
        //        }

        //    }
        //else
        //{
        //    ModelState.AddModelError(string.Empty, "Please Make Your Login Details are Correct.");
        //    return View();
        //}

        //    return View(admin);
        //}


        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        ////[AllowAnonymous]
        //public async Task<IActionResult> Login(LoginInfo dmin, string Url)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var sign = await _SignInManager.PasswordSignInAsync(dmin.Username, dmin.Password,
        //            dmin.RememberMe, false);
        //        if (sign.Succeeded)
        //        {

        //            if (!string.IsNullOrEmpty(Url))
        //            {
        //                return LocalRedirect(Url);
        //            }
        //            else
        //            {
        //                return RedirectToAction("CustomerDetails", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid Login Details");
        //        }
        //    }
        //    return View(dmin);


        //}
        //[HttpGet]
        // [Authorize]
        //public IActionResult CustomerDetails( string Url)
        //{
        //    if (!string.IsNullOrEmpty(Url))
        //    {
        //        return LocalRedirect(Url);
        //    }
        //    else
        //    {
        //        var CustDetails = _doublet.yourMessages.ToList();
        //        return View(CustDetails);
        //    }

        //}

        [Authorize]
        public IActionResult Details(int? id, string returnUrl)
        {
            var details = _doublet.yourMessages.FirstOrDefault(e=>e.Id==id);/*.ToList()[id];*/
            //if (!string.IsNullOrEmpty(returnUrl))
            //{
              //  return LocalRedirect(returnUrl);
            //}
            //else {
                if (details != null)
                {
                    return View("Details", details);
                }
                return View("CustomerDetails");
            //}
        }
    }
}
