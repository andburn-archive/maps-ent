using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.WebUI.Models
{
    public class Event
    {
        // Primary key
        public int EventID { get; set; }

        // Properties
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // Foreign key 
        public int LocationID { get; set; }

        // Navigation properties 
        public virtual Location Location { get; set; }
    }
}