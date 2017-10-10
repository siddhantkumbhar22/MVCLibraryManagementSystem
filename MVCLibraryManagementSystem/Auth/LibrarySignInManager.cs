using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MVCLibraryManagementSystem.Models;

namespace MVCLibraryManagementSystem.Auth
{
    public class LibrarySignInManager : SignInManager<LibraryUser, string>
    {
        public LibrarySignInManager(LibraryUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        { }

        public static LibrarySignInManager Create(
            IdentityFactoryOptions<LibrarySignInManager> options, IOwinContext context)
        {
            return new LibrarySignInManager(context.GetUserManager<LibraryUserManager>(), context.Authentication);
        }
    }
}