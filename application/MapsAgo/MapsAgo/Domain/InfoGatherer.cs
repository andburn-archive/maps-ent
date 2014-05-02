using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain
{
    public class InfoGatherer
    {
        private IGatheringStrategy strategy;

        public InfoGatherer(IGatheringStrategy strategy)
        {
            this.strategy = strategy;
        }

        public IList<ISearchResult> Search(string query, string type)
        {
            //return strategy.Search(query, type);
            return null;
        }

        public IDataResource Details(string id)
        {
            //return strategy.Details(id);
            return null;
        }
    }
}
