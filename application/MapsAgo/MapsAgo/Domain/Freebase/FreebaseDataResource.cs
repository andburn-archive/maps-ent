using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain.Freebase
{
    class FreebaseDataResource : IDataResource
    {
        public int EventStartYear { get; set; }

        public int EventStartMonth { get; set; }

        public int EventStartDay { get; set; }

        public int? EventEndYear { get; set; }

        public int? EventEndMonth { get; set; }

        public int? EventEndDay { get; set; }

        public string EventName { get; set; }

        public string EventExcerpt { get; set; }

        public string EventDescription { get; set; }

        public string EventSource { get; set; }

        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

        public string LocationName { get; set; }

        public string LocationAlias { get; set; }

        public EventType Type { get; set; }
    }
}
