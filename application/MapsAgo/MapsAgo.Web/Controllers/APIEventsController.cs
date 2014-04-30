using MapsAgo.Model;
using MapsAgo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
//using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace MapsAgo.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class APIEventsController : ApiController
    {
        // Set up
        private MapsAgoDbContext db = new MapsAgoDbContext();

        // Public Actions

        // $.getJSON("http://localhost:9190/api/5/5/5?startdate=01-01-1560&enddate=01-01-1950", function(data){g=$.parseJSON(data);console.log(g)})
        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IHttpActionResult GetClosest(int zoom, Double lat, Double lon, string startdate, string enddate)
        {
            // POINT(Long Lat)
            var s = DateTime.Parse(startdate);
            var e = DateTime.Parse(enddate);
            var rs = jsonResponse(GetEventsByTime(s, e));

            return Json(rs);

        }

        public IEnumerable<Event> GetEventsByCategory(string category)
        {

            if (category != null)
            {

                var categoryId = (from cat in db.EventTypes
                                  where cat.Name == category
                                  select cat).First().Id;

                var events = from e in db.Events
                             where e.EventTypeId == categoryId
                             select e;
                return events;
            }

            return db.Events;
        }

        public IEnumerable<Event> GetEventsByName(string name)
        {
            var events = from e in db.Events
                         select e;

            if (name != null)
            {
                var evs = events.Where((ep) => ep.Name.Contains(name));
                return evs;
            }
            return events;
        }

        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IEnumerable<Event> GetClosest(int zoom, Double lat, Double lon)
        {
            // POINT(Long Lat)

            var searchRef = formatLoc(lat, lon);

            var nearest = (from h in db.Events
                           let geo = searchRef
                           orderby geo.Distance(h.Location.Coordinates)
                           select h).Take(2);
            return nearest;


        }

        [Route("api/events")]
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            var events = (from e in db.Events
                          select e)
                         .Take(4); // How many to take from matched entries

            return events;
        }











        #region Helpers
        private DbGeography formatLoc(double lat, double lon)
        {
            return DbGeography.FromText("POINT(" + lon.ToString().Replace(",", ".") + " " + lat.ToString().Replace(",", ".") + ")", 4326);
        }

        private IEnumerable<Event> GetEventsByTime(DateTime StartTime, DateTime EndTime)
        {
            IEnumerable<Event> evs = db.Events
                            .Include(e => e.Location)
                            .Include(e => e.Type).ToList();
            IEnumerable<Location> locations = db.Locations.ToList();
            
            var es = (from e in evs
                        where e.EndDate < EndTime
                        where e.StartDate > StartTime
                        select e).Take(2);
            return es;
        }
        private Object getPointList(IEnumerable<Event> results)
        {
            //List<APIViewModel> list = new List<APIViewModel>();
            List<Object> pointlist = new List<Object>();
            foreach (var result in results)
            {
                var res = result.Resources.ToList();

                var r = new APIViewModel(result, result.Location, result.Type.Name, res);

                pointlist.Add(r.point);
            }
            return pointlist;
        }
        private string jsonResponse(IEnumerable<Event> results)
        {
            JavaScriptSerializer s = new JavaScriptSerializer();
            Object pointlist = getPointList(results);
            Object response = new
            {
                type = "FeatureCollection",
                features = pointlist
            };
            return s.Serialize(response);
        }
        #endregion
    }
}
