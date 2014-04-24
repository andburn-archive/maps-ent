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

        public string Source { get; set; } 

        [Column(TypeName = "datetime2")]        
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public DateTime DateCreated { get; set; }

        // TODO: need to find out how to convert this for display
        [Timestamp]
        public byte[] LastModified { get; set; }                 

        // Links to other tables

        public int LocationId { get; set; }

        public int EventTypeId { get; set; }

        public virtual ICollection<Medium> Media { get; set; }

        // Link to User table is dealt with in 'IdentityModels.cs'

    }
}
