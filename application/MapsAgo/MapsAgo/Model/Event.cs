using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MapsAgo.Model
{
    public class Event
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Excerpt { get; set; }

        public string Description { get; set; }    

        [Column(TypeName = "datetime2")]        
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        // TODO: need this to link to User table?
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        // TODO: could this be an annotated Timestamp field?
        public DateTime LastModified { get; set; }

        public string Source { get; set; }          

        // Foreign key 
        public int LocationID { get; set; }

        public virtual ICollection<Media> MediaList { get; set; }

        // TODO: self referencing?
        //public virtual ICollection<Event> RelatedEvents { get; set; }
    }
}
