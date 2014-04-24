using MapsAgo.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MapsAgo.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Connect User with Events table
        public virtual ICollection<Event> Events { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    }
}