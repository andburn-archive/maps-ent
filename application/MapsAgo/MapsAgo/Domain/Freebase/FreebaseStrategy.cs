using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections;

namespace MapsAgo.Domain.Freebase
{
    public class FreebaseStrategy : IGatheringStrategy
    {
        public FreebaseStrategy()
        {            
            
        }        

        public IList<ISearchResult> Search(string query, string type)
        {
            // type is a filter like '(all type:/military/military_conflict)'
            // TODO: make it relate to EventType??
            
            Uri baseUri = new Uri("https://www.googleapis.com/freebase/v1/");
            UriTemplate template = new UriTemplate(
                "{service}/?query={query}&filter={filter}&indent={indent}" 
                + "&limit={limit}&cursor={cursor}");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            Uri queryUrl = template.BindByPosition(baseUri, 
                "search", query, type, "true", "10", "0");

            HttpResponseMessage response = client.GetAsync(queryUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                // request should be a success
                // parse raw JSON first
                JsonSearchResult jsonResponse = 
                    response.Content.ReadAsAsync<JsonSearchResult>().Result;
                IList<ISearchResult> searchResults = 
                    new List<ISearchResult>();
                foreach (var r in jsonResponse.result)
                {
                    searchResults.Add(new FreebaseSearchResult(r.Mid, r.Name));
                }
                return searchResults;
            }
            else
            {
                // request failed, return empty list
                return new List<ISearchResult>();
            }
        }

        public IDataResource Details(string id)
        {
            // -- MQL part
            Uri baseUri = new Uri("https://www.googleapis.com/freebase/v1/");
            UriTemplate template = new UriTemplate(
                "{service}/?query={query}");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // TOOD need somewhere to store these
            string mql = "[{ \"mid\": \""+ id + "\", \"type\": \"/military/military_conflict\", \"name\": null, \"/common/topic/alias\": [], \"/common/topic/description\": { }, \"/time/event/end_date\": [], \"/time/event/start_date\": [], \"/time/event/locations\": [{ \"type\": \"/location/location\", \"name\": null, \"id\": null, \"/common/topic/alias\": [], \"/location/location/geolocation\": { \"latitude\": null, \"longitude\": null } }], \"/common/topic/image\": [{ \"name\": null, \"id\": null, \"/type/content/source\": [{ \"id\": null, \"/type/content_import/uri\": null }] }] }]";

            Uri queryUrl = template.BindByPosition(baseUri,
                "mqlread", mql);

            HttpResponseMessage response = client.GetAsync(queryUrl).Result;
            IDataResource dataresource  = new FreebaseDataResource();

            if (response.IsSuccessStatusCode)
            {
                JsonMqlResult result = response.Content.ReadAsAsync<JsonMqlResult>().Result;
                IList<JsonMqlItem> items = result.result;
                JsonMqlItem detail = new JsonMqlItem();
                if (items.Count >= 0)
                {
                    detail = items[0];
                }

                dataresource.EventName = detail.Name;
                dataresource.EventDescription = detail.Description;

                dataresource.EventStartMonth = ExtractDate(detail.StartDate).Month;
                dataresource.EventStartDay = ExtractDate(detail.StartDate).Day;
                dataresource.EventStartYear = ExtractDate(detail.EndDate).Year;
                dataresource.EventEndMonth = ExtractDate(detail.EndDate).Month;
                dataresource.EventEndDay = ExtractDate(detail.EndDate).Day;
                dataresource.EventEndYear = ExtractDate(detail.EndDate).Year;
                    
                //EventSource = result.EventSource,

                dataresource.Latitude = Double.Parse(ExtractLocation(detail.Location)["Latitude"].ToString());
                dataresource.Longitude = Double.Parse(ExtractLocation(detail.Location)["Longitude"].ToString());
                dataresource.LocationName = (string) ExtractLocation(detail.Location)["Name"];
                dataresource.LocationAlias = (string) ExtractLocation(detail.Location)["Alias"];

                // TODO: should create this mid
                // Mid = detail.Mid,
                // TODO: need to map MQL type to EventType
                // Type = result.Type;
            }
            else
            {
                // error
                return (IDataResource) new FreebaseDataResource();
            }

            // -- Topic part

            string filter = "(/common/topic/description /common/topic/topic_equivalent_webpage)";

            UriTemplate topicTemplate = new UriTemplate(
                "{id}?filter={filter}&key={key}");
            Uri topicUrl = topicTemplate.BindByPosition(baseUri, 
                id, filter, "AIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI");

            HttpClient topicClient = new HttpClient();
            topicClient.BaseAddress = new Uri("https://www.googleapis.com/freebase/v1/topic" + id);
            topicClient.DefaultRequestHeaders.Accept.Clear();
            topicClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            response = topicClient.GetAsync("?filter=/common/topic/description"
               + "&filter=/common/topic/topic_equivalent_webpage"
               + "&keyAIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI").Result;

            if (response.IsSuccessStatusCode)
            {
                JsonTopicResult topicResult = response.Content.ReadAsAsync<JsonTopicResult>().Result;
                dataresource.EventDescription = ExtractDescription(topicResult)[1];
                dataresource.EventExcerpt = ExtractDescription(topicResult)[0];
                return dataresource;
            }
            else
            {
                // error
                return (IDataResource)new FreebaseDataResource();
            }

        }

        private string[] ExtractDescription(JsonTopicResult topicResult)
        {
            var descp = topicResult.Property.Description;
            if (descp.Values.Count > 0)
            {
                return new string[]{
                    descp.Values[0].Text,
                    descp.Values[0].Value
                };
            }
            return new string[] { "Not Found", "Not Found" };
        }

        private static DateTime ExtractDate(DateTime[] dates)
        {
            if (dates.Length >= 0)
            {
                return dates[0];
            }
            // Error value if no dates found
            return DateTime.Now;
        }

        private static Hashtable ExtractLocation(JsonLocationItem[] item)
        {
            if (item.Length >= 0)
            {
                var Alias = "";
                var lat = 0.0;
                var lon = 0.0;
                if (item[0].Alias.Length >= 0)
                {
                    Alias = item[0].Alias[0];
                }
                if (item[0].Location != null)
                {
                    lat = item[0].Location.Latitude;
                    lon = item[0].Location.Longitude;
                }

                Hashtable loc = new Hashtable();
                loc.Add("Name", item[0].Name);
                loc.Add("Type", item[0].Type);
                loc.Add("Id", item[0].Id);
                loc.Add("Alias", Alias);
                loc.Add("Latitude", lat.ToString());
                loc.Add("Longitude", lon.ToString());
                return loc;
            }
            return null;
        }
    }
}
