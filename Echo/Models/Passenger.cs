using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echo.Models
{
    public class Passenger
    {
        public string info = "Passenger Information";
        public int id { get; set; }
        public string name { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int heartrate { get; set; }
        public float temperature { get; set; }
        public string condition { get; set; }
        public Location location { get; set; }
    }

}