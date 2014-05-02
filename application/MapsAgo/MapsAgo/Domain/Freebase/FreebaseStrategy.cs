using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain.Freebase
{
    public class FreebaseStrategy : IGatheringStrategy
    {
        public IList<ISearchResult> Search(string query, string type)
        {
            throw new NotImplementedException();
        }

        public IDataResource Details(string id)
        {
            throw new NotImplementedException();
        }
    }
}
