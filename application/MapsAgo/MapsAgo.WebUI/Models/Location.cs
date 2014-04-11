using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.WebUI.Models
{
    public class Location
    {
        // TODO float/double best for lat/long
        public double latitude { get; set; }
        public double longitdude { get; set; }
        public string name { get; set; }
    }
}