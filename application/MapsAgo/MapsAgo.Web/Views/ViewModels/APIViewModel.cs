using System;
using MapsAgo.Model;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Collections.Generic;

namespace MapsAgo.Web.ViewModels
{
    public class APIViewModel
    {

        // private properties
        public Object point { get; set; }
        private String type { get; set; }
        private Object geometry { get; set; }
        private Object properties { get; set; }
        private String name { get; set; }
        private String description { get; set; }
        private String excerpt { get; set; }
        private Object location { get; set; }
        private Object startDate { get; set; }
        private Object endDate { get; set; }
        private Object resources { get; set; }
        private String category { get; set; }

        // constructor
        public APIViewModel(Event realEvent, Location location, String TypeName, IEnumerable<Resource> resources) 
        {
            this.geometry = new 
            {
                type = "Point",
                coordinates = new[] { 
                    location.Coordinates.Longitude, 
                    location.Coordinates.Latitude
                }
            };
            this.location = new {
                name = location.Name,
                alias = location.Alias,
                longitude = location.Coordinates.Longitude,
                latitude = location.Coordinates.Latitude
            };
            this.resources = new[]
            {
                //name = realEvent.ImageName,
                "tempResource",
                "tempResource"//realEvent.ImageUrl
            };
            this.startDate = new
            {
                day = realEvent.StartDate.Day,
                month = realEvent.StartDate.Month,
                year = realEvent.StartDate.Year
            };
            this.endDate = new
            {
                day = realEvent.EndDate.Day,
                month = realEvent.EndDate.Month,
                year = realEvent.EndDate.Year
            };
            this.name = realEvent.Name;
            this.description = realEvent.Description;
            this.excerpt = realEvent.Excerpt;
            this.category = TypeName;
            this.type = "Feature";
            this.resources = makeResources(resources);
            makeProperties();
            this.point = new
            {
                type = this.type,
                geometry = this.geometry,
                properties = this.properties
            };
        }


        private void makeProperties() 
        {
            this.properties = new
            {
                name = this.name,
                excerpt = this.excerpt,
                startDate = this.startDate,
                endDate = this.endDate,
                category = this.category,
                resouces = this.resources,
                location = this.location,
                description = this.description
            };
        }
        private Object makeResources(IEnumerable<Resource> resources)
        { 
            List<Object> resourcesList = new List<object>();
            foreach (var resource in resources) {
                var r = new
                {
                    name = resource.Name,
                    type = resource.Type,
                    url = resource.Url
                };
                resourcesList.Add(r);
            }
            return resourcesList;
        }
    }

}