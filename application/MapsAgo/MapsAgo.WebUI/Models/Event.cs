using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.WebUI.Models
{
    public class Event
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}