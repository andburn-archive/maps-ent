using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain
{
    public interface IDataResource
    {

        int EventStartYear { get; set; }

        int EventStartMonth { get; set; }

        int EventStartDay { get; set; }

        int? EventEndYear { get; set; }

        int? EventEndMonth { get; set; }

        int? EventEndDay { get; set; }

        string EventName { get; set; }

        string EventExcerpt { get; set; }

        string EventDescription { get; set; }

        string EventSource { get; set; }      

        Double Latitude { get; set; }

        Double Longitude { get; set; }

        string LocationName { get; set; }

        string LocationAlias { get; set; }

        EventType Type { get; set; }

    }
}
