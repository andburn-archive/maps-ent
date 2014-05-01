using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MapsAgo.Model
{
    // EF DbContext inherits IdentityDbContext so we get all benefits 
    // of user management while only having one DbContext
    public class MapsAgoDbContext : IdentityDbContext<ApplicationUser>
    {
        public MapsAgoDbContext() : base("DefaultConnection") {}

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Resource> Resources { get; set; }

        // NOTE: Identity stuff like Users and Roles (and others no doubt) 
        // are included here too implicitly

    }
}
