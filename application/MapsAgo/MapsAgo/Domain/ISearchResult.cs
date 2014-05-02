using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain
{
    public interface ISearchResult
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}
