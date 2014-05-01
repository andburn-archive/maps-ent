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

        [Required]
        public string Name { get; set; }

        [StringLength(128)]
        public string Excerpt { get; set; }

        public string Description { get; set; }

        [StringLength(512)]
        public string Source { get; set; } 

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", 
            ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]        
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", 
            ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        // TODO: Is this strictly necessary
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}",
            ApplyFormatInEditMode = false)]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", 
            ApplyFormatInEditMode = false)]
        public DateTime LastModified { get; set; }

        public bool Flagged { get; set; }

        // Only for managing concurrency in DB
        [Timestamp]
        public byte[] Timestamp { get; set; }                 
         
        //----- Foreign Keys and Navigation Properties

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType Type { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

    }
}
