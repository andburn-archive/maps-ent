using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    public class Location
    {

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Alias { get; set; }

        // For adding a point on map use "POINT(Longitude Latitude)"
        [Required]
        public DbGeography Coordinates { get; set; }

        //----- Foreign Keys and Navigation Properties

        public virtual ICollection<Event> Events { get; set; }

    }
}
