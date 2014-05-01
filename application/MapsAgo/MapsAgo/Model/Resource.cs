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

        // TODO: what about regex validation?
        // (http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?
        // http://stackoverflow.com/questions/161738/what-is-the-best-regular-expression-to-check-if-a-string-is-a-valid-url
        [Required]
        [StringLength(2048)]
        public string Url { get; set; }
      
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}
