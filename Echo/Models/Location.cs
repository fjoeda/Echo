using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echo.Models
{
    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}