using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSite.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
    }
}