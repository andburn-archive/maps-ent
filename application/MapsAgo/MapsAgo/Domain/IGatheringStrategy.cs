using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain
{
    public interface IGatheringStrategy
    {

        Task<IList<ISearchResult>> Search(string query, string type);

        Task<IDataResource> Details(string id);

    }
}
