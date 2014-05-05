using MapsAgo.Domain;
using MapsAgo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.Web.Views.ViewModels
{
    public class SearchAndCreate
    {
        public IList<ISearchResult> results { get; set; }
        public IDataResource details { get; set; }
        public NewEventViewModel newevent { get; set; }

        public SearchAndCreate(
            IList<ISearchResult> results,
            IDataResource details,
            NewEventViewModel newevent)
        {
            this.results = results;
            this.details = details;
            this.newevent = new NewEventViewModel(details);
        }

        public bool HasResults()
        {
            if (results != null && results.Count <= 0)
            {
                return false;
            }
            return true;
        }

        public bool HasDetails()
        {
            return details == null;
        }
    }
}