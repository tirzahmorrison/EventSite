using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSite.ViewModels
{
    public enum AgeGroup
    {
        EVERYONE = 0,
        TEEN,
        ADULT,
        DRINKINGADULT,
        SENIOR,
    }
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string KeyWord { get; set; }
        public int AttendeeCount { get; set; }
    }
}