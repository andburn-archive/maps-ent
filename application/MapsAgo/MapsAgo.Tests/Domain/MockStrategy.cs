using MapsAgo.Domain;
using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Tests.Domain
{
    class MockStrategy : IGatheringStrategy
    {
        public async Task<IList<ISearchResult>> Search(string query, string type)
        {
            return new List<ISearchResult> {
                new MockSearchResult
                {
                    Id = "/m/0c55s",
                    Name = "Battle of Hastings"
                },
                new MockSearchResult
                {
                    Id = "/m/0fk48",
                    Name = "Battle of Little Bighorn"
                }
            };
        }

        public async Task<IDataResource> Details(string id)
        {
            return new MockDataResource
            {
                EventStartYear = 0,
                EventStartMonth = 0,
                EventStartDay = 0,
                EventEndYear = 0,
                EventEndMonth = 0,
                EventEndDay = 0,
                EventName = "",
                EventExcerpt = "",
                EventDescription = "",
                EventSource = "",
                Latitude = 0.0,
                Longitude = 0.0,
                LocationName = "",
                LocationAlias = "",
                Type = null
            };
        }
    }

    class MockSearchResult : ISearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    class MockDataResource : IDataResource
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
