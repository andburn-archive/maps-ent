using MapsAgo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    public class Medium
    {

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public MediaType Type { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

    }
}
