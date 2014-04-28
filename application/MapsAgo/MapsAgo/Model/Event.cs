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

        // TODO: could possibly generate this from description
        [StringLength(128)]
        public string Excerpt { get; set; }

        public string Description { get; set; }

        [StringLength(512)]
        public string Source { get; set; } 

        // TODO: dates could be just Date type ?
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]        
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        // TODO: need to find out how to convert this for display
        [Timestamp]
        public byte[] LastModified { get; set; }                 

        // Foreign Keys and Navigation Properties

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType Type { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

    }
}
