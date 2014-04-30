using MapsAgo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

    public class EventItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Excerpt { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public bool Flagged { get; set; }

        public EventItemViewModel() {}

        public EventItemViewModel(Event e)
        {
            Id = e.Id;
            Name = e.Name;
            Excerpt = e.Excerpt;
            Date = e.StartDate.Date;
            Flagged = e.Flagged;
        }        
    }
       
    public class UserListViewModel
    {
        public string Id { get; set; }
        [DisplayName("User")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Authorized { get; set; }
        [DisplayName("Events")]
        public int NumberOfEvents { get; set; }
        [DisplayName("Flagged")]
        public int FlaggedEvents { get; set; }
    }

    // TODO: need to see what else going to include here
    // relates to register login etc.
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IEnumerable<RoleItemViewModel> UserRoles { get; set; }
        public IEnumerable<EventItemViewModel> UserEvents { get; set; }
    }


    
}