using MapsAgo.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MapsAgo.Web.ViewModels
{
    public class NewEventViewModel
    {

        #region Public Methods
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
        #endregion

        #region Properties
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
                try
                {
                    DateTime d = Convert.ToDateTime(
                        this.EventEndYear.ToString() + "-" +
                        this.EventEndMonth.ToString() + "-" +
                        this.EventEndDay.ToString());
                    return d;
                }
                catch (NullReferenceException)
                {
                    return this.StartDate;
                }
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
        #endregion

        // Properties
        [Range(0001, 2050, ErrorMessage = "Must be four digits YYYY")]
        public int EventStartYear { get; set; }

        [Range(1, 12, ErrorMessage = "Must be four digits MM")]
        public int EventStartMonth { get; set; }
        [Range(1, 31, ErrorMessage = "Must be four digits DD")]
        public int EventStartDay { get; set; }

        [Range(0001, 2050, ErrorMessage = "Must be four digits YYYY")]
        public int? EventEndYear { get; set; }
        [Range(1, 12, ErrorMessage = "Must be four digits MM")]
        public int? EventEndMonth { get; set; }
        [Range(1, 31, ErrorMessage = "Must be four digits DD")]
        public int? EventEndDay { get; set; }

        [Required]
        [DisplayName("Title")]
        public string EventName { get; set; }

        [StringLength(128)]
        [DisplayName("Short Description")]
        public string EventExcerpt { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Full Description")]
        public string EventDescription { get; set; }

        [StringLength(512)]
        [DisplayName("Source URL")]
        public string EventSource { get; set; }

        [Timestamp]
        public byte[] LastModified { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Id { get; set; }

        // Foreign Keys and Navigation Properties
        [DisplayName("Latitude")]
        [Range(-90, 90, ErrorMessage = "Use signed degree format")]
        public Nullable<Double> Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Use signed degree format")]
        public Double? Longitude { get; set; }

        [StringLength(128)]
        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [StringLength(128)]
        [DisplayName("Longitude Alias")]
        public string LocationAlias { get; set; }
        
        [Required]
        [DisplayName("Event Category")]
        public int EventTypeId { get; set; }
        public virtual EventType Type { get; set; }


        #region Private Methods

        private bool newLocation()
        {
            return (this.Latitude != null &&
                this.Longitude != null &&
                this.LocationName != null);
        }

        private bool existingLication()
        {
            return this.LocationId != null;
        }


        #endregion
    }
}