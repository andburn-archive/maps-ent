using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain.Freebase
{
    public class FreebaseSearchResult : ISearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public FreebaseSearchResult(string mid, string name)
        {
            Id = mid;
            Name = name;
        }
    }
}
