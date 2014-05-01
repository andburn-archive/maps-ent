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
    [EnableCors("*", "*", "*")]
    public class APIEventsController : ApiController
    {
        // Set up
        private MapsAgoDbContext db = new MapsAgoDbContext();

        // Public Actions

        // $.getJSON("http://localhost:9190/api/5/5/5?startdate=01-01-1560&enddate=01-01-1950", function(data){g=$.parseJSON(data);console.log(g)})
        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IHttpActionResult GetByAreaAndClosest(int zoom, Double lat, Double lon, string startdate, string enddate, string keywords, string categories)
        {
            // POINT(Long Lat)
            
            var s = DateTime.Parse(startdate);
            var e = DateTime.Parse(enddate);
            var rs = GetEventsByTime(s, e);

            if (categories != "")
            {
                string[] cats = categories.Split('|');

                var dbCategories = (from cat in db.EventTypes
                                  where cats.Contains(cat.Name)
                                  select cat.Id);
                var events = from ev in rs
                             where dbCategories.Contains(ev.Type.Id)
                             select ev;
                rs = events;
            }

            if (keywords != ""){
                string[] keys = keywords.Split('|');
                List<Event> events = new List<Event>();
                foreach (var key in keys) {
                    events.Concat(from ev in rs
                                  where String.Equals(ev.Description, key, StringComparison.OrdinalIgnoreCase)
                                  select ev);

                    //events.Add (rs.Any (x => (String.Equals(x.Description, key, StringComparison.OrdinalIgnoreCase)) ));
                }
                
                rs = events;
            }
            
            return Json(jsonResponse(rs));
        }


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

        public IHttpActionResult GetEventsByCategory(int zoom, Double lat, Double lon, string categories)
        {

            if (categories != null)
            {
                var categoryId = (from cat in db.EventTypes
                                  where cat.Name == categories
                                  select cat).First().Id;
                var events = from e in db.Events
                             where e.EventTypeId == categoryId
                             select e;
                return Json(jsonResponse(events));
            }
            return Json(jsonResponse(db.Events));
        }

        public IHttpActionResult GetEventsByName(int zoom, Double lat, Double lon, string name)
        {
            var events = from e in db.Events
                         select e;

            if (name != null)
            {
                var evs = events.Where((ep) => ep.Name.Contains(name));
                return Json(jsonResponse(evs));
            }
            return Json(jsonResponse(events));
        }

        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IHttpActionResult GetClosest(int zoom, Double lat, Double lon)
        {
            // POINT(Long Lat)

            var searchRef = formatLoc(lat, lon);

            var nearest = from h in db.Events
                           let geo = searchRef
                           orderby geo.Distance(h.Location.Coordinates)
                           select h;
            return Json(jsonResponse(nearest));
        }

        [Route("api/events")]
        [HttpGet]
        public IHttpActionResult GetAllEvents()
        {
            var events = (from e in db.Events
                          select e)
                         .Take(4); // How many to take from matched entries

            return Json(jsonResponse(events));
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
            
            var es = from e in evs
                    where e.EndDate < EndTime
                    where e.StartDate > StartTime
                    select e;
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
