using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.WebUI.Models
{
    public class Location
    {
        // Primary Key
        public int LocationID { get; set; }

        // Properties
        // TODO float/double best for lat/long
        public double Latitude { get; set; }
        public double Longitdude { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Event> Events { get; set; }
    }
}