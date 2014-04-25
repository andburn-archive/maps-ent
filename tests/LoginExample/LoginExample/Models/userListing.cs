using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginExample.Models
{
    public class UserListing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean Approved  { get; set; }

    }
}