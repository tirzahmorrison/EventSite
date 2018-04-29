using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}