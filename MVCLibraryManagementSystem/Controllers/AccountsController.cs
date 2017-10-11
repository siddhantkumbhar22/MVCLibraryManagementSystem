using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCLibraryManagementSystem.Auth;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace MVCLibraryManagementSystem.Controllers
{
    // This attribute makes all action methods require 
    // authorization in this controller, except the ones marked
    // AllowAnonymous
    [Authorize]
    public class AccountsController : Controller
    {
        // First we create the dependencies
        private LibrarySignInManager _signInManager;
        private LibraryUserManager _userManager;

        public AccountsController()
        {
        }

        public AccountsController(LibraryUserManager userManager, LibrarySignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public LibrarySignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<LibrarySignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public LibraryUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<LibraryUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, shouldLockout: true);

            switch(result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

    }
}