using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nahamaleo.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string property_location { get; set; }
        public string  property_type{ get; set; }
        public string no_of_rooms { get; set; }
        public string rent_or_buy { get; set; }
        public int property_cost { get; set; }
        public string image { get; set; }
    }
}