using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
    }
}