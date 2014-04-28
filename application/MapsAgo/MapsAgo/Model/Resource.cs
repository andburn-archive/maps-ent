using MapsAgo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    public class Resource
    {

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        [StringLength(2048)]
        public string Url { get; set; }

        // (http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?

        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }


        public bool IsValid { get; set; }
    }
}
