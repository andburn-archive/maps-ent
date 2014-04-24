﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Model
{
    public class EventType
    {

        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

    }
}
