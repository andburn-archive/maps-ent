using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MapsAgo.Web.ViewModels
{
    public class NewEventViewModel
    {

        // Mapping
        public Event MapToEvent()
        {
            var ev = new Event();

            ev.Name = this.EventName;
            ev.Excerpt = this.EventExcerpt;
            ev.Description = this.EventDescription;
            ev.StartDate = this.StartDate;
            ev.EndDate = this.EndDate;
            ev.DateCreated = DateTime.Now;
            ev.EventTypeId = this.EventTypeId;

            return ev;
        }
        public Location MapToLocation()
        {
            var loc = new Location();

            loc.Name = this.LocationName;
            loc.Alias = this.LocationAlias;
            loc.Coordinates = this.LocationCoordinates;


            return loc;
        }




        [Column(TypeName = "datetime2")]
        public DateTime StartDate
        {
            get
            {
                DateTime d = Convert.ToDateTime(EventStartYear.ToString() + "-" + EventStartMonth.ToString() + "-" + EventStartDay.ToString());
                return d;
            }
        }
        [Column(TypeName = "datetime2")]
        public DateTime EndDate
        {
            get
            {
                DateTime d = Convert.ToDateTime(
                    this.EventEndYear.ToString() + "-" +
                    this.EventEndMonth.ToString() + "-" +
                    this.EventEndDay.ToString());
                return d;
            }
        }

        public DbGeography LocationCoordinates
        {
            get
            {
                return DbGeography.FromText("POINT(" +
                this.Longitude +
                " " +
                this.Latitude +
                ")");
            }
        }

        // Properties
        public int EventStartYear { get; set; }
        public int EventStartMonth { get; set; }
        public int EventStartDay { get; set; }

        public int EventEndYear { get; set; }
        public int EventEndMonth { get; set; }
        public int EventEndDay { get; set; }

        [Required]
        public string EventName { get; set; }

        [StringLength(128)]
        public string EventExcerpt { get; set; }

        public string EventDescription { get; set; }

        [StringLength(512)]
        public string EventSource { get; set; }

        [Timestamp]
        public byte[] LastModified { get; set; }

        // Foreign Keys and Navigation Properties

        public int Latitude { get; set; }
        public int Longitude { get; set; }

        [Required]
        [StringLength(128)]
        public string LocationName { get; set; }

        [StringLength(128)]
        public string LocationAlias { get; set; }

        [Required]
        public int EventTypeId { get; set; }
        public virtual EventType Type { get; set; }

    }
}