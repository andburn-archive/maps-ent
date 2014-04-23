using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    class Location
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}
