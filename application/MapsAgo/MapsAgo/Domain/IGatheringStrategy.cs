using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain
{
    public interface IGatheringStrategy
    {

        IList<ISearchResult> Search(string query, string type);

        IDataResource Details(string id);

    }
}
