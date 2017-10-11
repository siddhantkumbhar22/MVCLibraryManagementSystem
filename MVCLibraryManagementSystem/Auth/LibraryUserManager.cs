using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibraryManagementSystem.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCLibraryManagementSystem.DAL;

namespace MVCLibraryManagementSystem.Auth
{
    public class LibraryUserManager : UserManager<LibraryUser>
    {
        public LibraryUserManager(IUserStore<LibraryUser> store)
            : base(store)
        { }

        public static LibraryUserManager Create(
            IdentityFactoryOptions<LibraryUserManager> options, IOwinContext context)
        {
            var manager = new LibraryUserManager(new UserStore<LibraryUser>(context.Get<LibraryContext>()));

            return manager;
        }
    }
}