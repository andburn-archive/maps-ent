using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapsAgo.Web.ViewModels
{
    public class RoleItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
    
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<RoleItemViewModel> UserRoles { get; set; }
    }
    
}