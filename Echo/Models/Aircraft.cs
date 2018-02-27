using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echo.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Model { get; set; }
        public string FlightNumber { get; set; }
        public string Asal { get; set; }
        public string Tujuan { get; set; }
        public string Gate_asal { get; set; }
        public string Gate_tujuan { get; set; }
        public DateTime Berangkat { get; set; }
        public DateTime Tiba { get; set; }
        public int Menit_terbang { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Status { get; set; }
        public DateTime LostContactTime { get; set; }
        public List<Passenger> PassengerList { get; set; }
    }
}