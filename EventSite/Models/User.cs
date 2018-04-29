using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        [InverseProperty("AttendeeList")]
        public virtual ICollection<Event> Events { get; set; }

        [InverseProperty("UsersWaitlist")]
        public virtual ICollection<Event> WaitlistedEvents { get; set; } 
    }
}