using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Domain.Freebase
{

    class Notable
    {
        public string name { get; set; }
        public string id { get; set; }

        public override string ToString()
        {
            return "name: " + name + "; id: " + id;
        }
    }

    class SearchItem
    {
        public string mid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Notable notable { get; set; }
        public string lang { get; set; }
        public float score { get; set; }
    }

    class SearchResult
    {
        public string status { get; set; }
        public IList<SearchItem> result { get; set; }
        public int cursor { get; set; }
        public int cost { get; set; }
        public int hits { get; set; }
    }

    class UriItem
    {
        public string Id { get; set; }

        [JsonProperty("/type/content_import/uri")]
        public Uri Uri { get; set; }
    }

    class ImageItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public UriItem[] Source { get; set; }
    }

    class GeoLocation
    {
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }
    }

    class LocationItem
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        [JsonProperty("/common/topic/alias")]
        public string[] Alias { get; set; }

        [JsonProperty("/location/location/geolocation")]
        public GeoLocation Location { get; set; }
    }

    class MqlItem
    {
        public string Mid { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        [JsonProperty("/time/event/end_date")]
        public DateTime[] EndDate { get; set; }

        [JsonProperty("/time/event/start_date")]
        public DateTime[] StartDate { get; set; }

        // doesn't work should be removed from MQL
        [JsonProperty("/common/topic/description")]
        public string Description { get; set; }

        [JsonProperty("/common/topic/image")]
        public ImageItem[] Image { get; set; }

        [JsonProperty("/time/event/locations")]
        public LocationItem[] Location { get; set; }

        public override string ToString()
        {
            return String.Format("mid:{0}\ntype: {1}\nname: {2}\nstart: {3}\nend: {4}",
                Mid, Type, Name, StartDate[0], EndDate[0]);
        }
    }

    class MqlResult
    {
        public IList<MqlItem> result { get; set; }
    }

    class Values
    {
        public string Text { get; set; }
        public string Lang { get; set; }
        public string Value { get; set; }
    }

    class Record
    {
        public string ValueType { get; set; }
        public List<Values> Values { get; set; }
    }

    class Description
    {
        public string ValueType { get; set; }
        public Values[] Values { get; set; }
    }

    class Property
    {
        [JsonProperty("/common/topic/description")]
        public Record Description { get; set; }

        [JsonProperty("/common/topic/topic_equivalent_webpage")]
        public Record WebPage { get; set; }
    }

    class TopicResult
    {
        public string Id { get; set; }
        public Property Property { get; set; }

        public override string ToString()
        {
            return Id + ", " + Property.Description.Values[0].Text;
        }
    }

}
