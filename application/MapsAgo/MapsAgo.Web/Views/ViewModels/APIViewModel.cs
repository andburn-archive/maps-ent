using System;
using MapsAgo.Model;
using System.Data.Entity.Spatial;

namespace MapsAgo.Web.ViewModels
{
    public class APIViewModel
    {
        
        // properties


        public String name { get; set; }
        public String description { get; set; }
        public String excerpt { get; set; }
        public Object location { get; set; }
        public Object startDate { get; set; }
        public Object endDate { get; set; }
        public Object images { get; set; }
        public String category { get; set; }

        // constructor

        public APIViewModel(Event realEvent, Object location, String TypeName) 
        {
            this.location = location;
            this.images = new
            {
                //name = realEvent.ImageName,
                url = "tempResource"//realEvent.ImageUrl
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
        }

    }
}