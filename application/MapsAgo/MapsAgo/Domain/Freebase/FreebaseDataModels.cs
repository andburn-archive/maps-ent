using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain.Freebase
{

    class JsonNotable
    {
        public string name { get; set; }
        public string id { get; set; }

        public override string ToString()
        {
            return "name: " + name + "; id: " + id;
        }
    }

    class JsonSearchItem
    {
        public string Mid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public JsonNotable Notable { get; set; }
        public string Lang { get; set; }
        public float Score { get; set; }
    }

    class JsonSearchResult
    {
        public string status { get; set; }
        public IList<JsonSearchItem> result { get; set; }
        public int cursor { get; set; }
        public int cost { get; set; }
        public int hits { get; set; }
    }

    class JsonUriItem
    {
        public string Id { get; set; }

        [JsonProperty("/type/content_import/uri")]
        public Uri Uri { get; set; }
    }

    class JsonImageItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public JsonUriItem[] Source { get; set; }
    }

    class JsonGeoLocation
    {
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }
    }

    class JsonLocationItem
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        [JsonProperty("/common/topic/alias")]
        public string[] Alias { get; set; }

        [JsonProperty("/location/location/geolocation")]
        public JsonGeoLocation Location { get; set; }
    }

    class JsonMqlItem
    {
        public string Mid { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        [JsonProperty("/time/event/end_date")]
        public string[] EndDate { get; set; }

        [JsonProperty("/time/event/start_date")]
        public string[] StartDate { get; set; }

        // doesn't work should be removed from MQL
        //[JsonProperty("/common/topic/description")]
        //public string Description { get; set; }

        [JsonProperty("/common/topic/image")]
        public JsonImageItem[] Image { get; set; }

        [JsonProperty("/time/event/locations")]
        public JsonLocationItem[] Location { get; set; }

        public override string ToString()
        {
            return String.Format("mid:{0}\ntype: {1}\nname: {2}\nstart: {3}\nend: {4}",
                Mid, Type, Name, StartDate[0], EndDate[0]);
        }
    }

    class JsonMqlResult
    {
        public IList<JsonMqlItem> result { get; set; }
    }

    class JsonValues
    {
        public string Text { get; set; }
        public string Lang { get; set; }
        public string Value { get; set; }
    }

    class JsonRecord
    {
        public string ValueType { get; set; }
        public List<JsonValues> Values { get; set; }
    }

    class JsonDescription
    {
        public string ValueType { get; set; }
        public JsonValues[] Values { get; set; }
    }

    class JsonTopicProperty
    {
        [JsonProperty("/common/topic/description")]
        public JsonRecord Description { get; set; }

        [JsonProperty("/common/topic/topic_equivalent_webpage")]
        public JsonRecord WebPage { get; set; }
    }

    class JsonTopicResult
    {
        public string Id { get; set; }
        public JsonTopicProperty Property { get; set; }

        public override string ToString()
        {
            return Id + ", " + Property.Description.Values[0].Text;
        }
    }

}
