using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MapsAgo.Model
{
    public class MapsAgoDbContext : IdentityDbContext<ApplicationUser>
    {
        public MapsAgoDbContext() : base("DefaultConnection") {}

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Resource> Resources { get; set; }        

    }
}
