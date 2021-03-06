﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public enum AgeGroup
    {
        EVERYONE = 0,
        TEEN,
        ADULT,
        DRINKINGADULT,
        SENIOR,
    }
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string KeyWord { get; set; }
        public int? AttendeeCount { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public  int? CityId { get; set; }
        public virtual City City { get; set; }

        public int? OrganizerId { get; set; }
        public User Organizer { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 

        public virtual ICollection<User> UsersWaitlist { get; set; }

        public virtual ICollection<User> AttendeeList { get; set; } 
    }
}