using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nahamaleo.Models
{
    public class property
    {
        public int id { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string rooms { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string rent_or_buy { get; set; }
        public int cost { get; set; }
        public string image { get; set; }
    }
}