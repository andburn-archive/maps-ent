using MapsAgo.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapsAgo.Common
{
    // custom Authorize Attribute to allow use of enum types
    // requires replaceing the use of:
    //      [Authorize(Role="Admin")]
    // with
    //      [AuthorizeByRole(RoleType.Admin)]
    // takes multiple params also.
    public class AuthorizeByRole : AuthorizeAttribute
    {
        private RoleType[] roles;

        public AuthorizeByRole(params RoleType[] roles)
        {
            this.roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) 
            {
                throw new ArgumentNullException("httpContext");
            }                

            // First check current user is authenticated
            if (!httpContext.User.Identity.IsAuthenticated) 
            {
                return false;
            }
            // Get the current user Id
            string userId = httpContext.User.Identity.GetUserId();

            // Get the associate user roles
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new MapsAgoDbContext()));
            var RoleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new MapsAgoDbContext()));
            ApplicationUser user =  userManager.FindById(userId);

            IEnumerable<string> roleNames =
                from r in user.Roles
                select RoleManager.FindById(r.RoleId).Name;
            IEnumerable<string> authRoles =
                from n in roleNames
                from r in roles
                where r.ToString() == n
                select n;

            return authRoles.Count() > 0 ? true : false;
        }
    }
}
