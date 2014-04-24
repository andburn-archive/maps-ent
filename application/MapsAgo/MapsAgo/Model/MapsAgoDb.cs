using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    public class MapsAgoDb : DbContext
    {
        public MapsAgoDb() : base("DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Medium> Media { get; set; }

    }
}
