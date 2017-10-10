using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MVCLibraryManagementSystem.DAL;
using MVCLibraryManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using MVCLibraryManagementSystem.Auth;
using System.Threading.Tasks;

namespace MVCLibraryManagementSystem.App_Start
{
    /// <summary>
    /// This class is used by OWIN, which Identity is based on.
    /// </summary>
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new LibraryContext());
            
            // This should have a ApplicationUserManager that extends UserManager
            // and has a static Create methods
            // that sets up requirements for users like password validation and things like that.

            app.CreatePerOwinContext<LibraryUserManager>(LibraryUserManager.Create);
            app.CreatePerOwinContext<LibrarySignInManager>(LibrarySignInManager.Create);


            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Home/Login")
                });
        }

        public async static void CreateDefaultUser()
        {
            LibraryContext context = new LibraryContext();

            var userManager = new LibraryUserManager(new UserStore<LibraryUser>(context));

            var user = new LibraryUser();
            user.UserName = "admin";

            Task<IdentityResult> result = null;
            try
            {
                result =  userManager.CreateAsync(user, "admin123");
            }
            finally
            {

            }

            IdentityResult res = await result;

            if (!res.Succeeded)
            {
                Debug.WriteLine("NOT SUCCEEDED");
                foreach(var error in res.Errors)
                {
                    Debug.WriteLine(error.ToString());
                }
            }
        }
    }
}