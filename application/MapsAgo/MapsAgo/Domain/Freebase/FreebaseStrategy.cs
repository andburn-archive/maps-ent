using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MapsAgo.Domain.Freebase
{
    public class FreebaseStrategy : IGatheringStrategy
    {
        private UriTemplate searchTemplate;

        public FreebaseStrategy()
        {            
            
        }

        public async Task<IList<ISearchResult>> Search(string query, string type)
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
            
            Uri queryUrl = searchTemplate.BindByPosition(baseUri, 
                "search", query, type, "true", "10", "0");

            HttpResponseMessage response = await client.GetAsync(queryUrl);

            if (response.IsSuccessStatusCode)
            {
                // request should be a success
                // parse raw JSON first
                JsonSearchResult jsonResponse = 
                    await response.Content.ReadAsAsync<JsonSearchResult>();
                IList<ISearchResult> searchResults = 
                    (IList<ISearchResult>) new List<FreebaseSearchResult>();
                foreach (var r in jsonResponse.result)
                {
                    searchResults.Add(new FreebaseSearchResult(r.Mid, r.Name));
                }
                return searchResults;
            }
            else
            {
                // request failed, return empty list
                // TODO: why is the cast necessary? and above
                return (IList<ISearchResult>) new List<FreebaseSearchResult>();
            }
        }

        public async Task<IDataResource> Details(string id)
        {
            // -- MQL part
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.googleapis.com/freebase/v1/mqlread/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // TOOD need somewhere to store these
            string mql = "[{ \"mid\": \"/m/0c55s\", \"type\": \"/military/military_conflict\", \"name\": null, \"/common/topic/alias\": [], \"/common/topic/description\": { }, \"/time/event/end_date\": [], \"/time/event/start_date\": [], \"/time/event/locations\": [{ \"type\": \"/location/location\", \"name\": null, \"id\": null, \"/common/topic/alias\": [], \"/location/location/geolocation\": { \"latitude\": null, \"longitude\": null } }], \"/common/topic/image\": [{ \"name\": null, \"id\": null, \"/type/content/source\": [{ \"id\": null, \"/type/content_import/uri\": null }] }] }]";

            HttpResponseMessage response = await client.GetAsync("?query=" + mql);

            if (response.IsSuccessStatusCode)
            {
                string r = await response.Content.ReadAsStringAsync();
                Console.WriteLine(r);

                JsonMqlResult products = await response.Content.ReadAsAsync<JsonMqlResult>();

                foreach (var product in products.result)
                {
                    Console.WriteLine(product.ToString());
                }

                return null;
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
                return null;
            }

            // -- Topic part

            //Uri topicAddress = new Uri("https://www.googleapis.com/freebase/v1/topic" + mid);
            //UriTemplate topicTemplate = new UriTemplate(
            //    "{mid}?filter={filter}&key={key}");
            //Uri queryUrl = topicTemplate.BindByPosition(topicAddress, "/m/0c55s",
            //    "(/common/topic/description /common/topic/topic_equivalent_webpage)",
            //    "AIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI");

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            //response = await client.GetAsync("?filter=/common/topic/description"
            //   + "&filter=/common/topic/topic_equivalent_webpage"
            //   + "&keyAIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI");

            ////Console.WriteLine(queryUrl);

            //if (response.IsSuccessStatusCode)
            //{
            //    string r = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(r);

            //    JsonTopicResult products = await response.Content.ReadAsAsync<JsonTopicResult>();

            //    Console.WriteLine(products.ToString());

            //    return null;
            //}
            //else
            //{
            //    Console.WriteLine("Error: " + response.ReasonPhrase);
            //    return null;
            //}

        }
    }
}
