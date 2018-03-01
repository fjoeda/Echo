using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Timers;
using Echo.Models;
namespace Echo.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        //Informationlnkl info = new Informationlnkl();
        List<Aircraft> daftarPesawat = new List<Aircraft>();
        List<Passenger> daftarPenumpang = new List<Passenger>();

        Aircraft pesawat = new Aircraft()
        {
            Nama = "Garuda Indonesia Airways",
            FlightNumber = "GA-201",
            Model = "B737-800",
            Asal = "Yogyakarta (JOG)",
            Tujuan = "Jakarta (CGK)",
            Latitude = -5.670402f,
            Longitude = 108.176275f,
            Status = "Contact Lost 15 Minutes Ago"

        };

        

        public ActionResult UpdateListPassenger()
        {
            daftarPenumpang.Clear();
            daftarPenumpang.Add(new Passenger()
            {
                name = "Victima",
                id = 1,
                heartrate = 87,
                temperature = 26,
                latitude = -6.2223623f,
                longitude = 106.8052861f,
                condition = "Alive"
            });


            return Json(daftarPenumpang, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowPassengerInfo(int _id, string _name, int _heartrate, float _temperature,
            float _latitude, float _longitude, string _condition)
        {
            var JsonList = new List<Passenger>()
            {
                new Passenger()
                {
                    id = _id,
                    name = _name,
                    heartrate = _heartrate,
                    temperature = _temperature,
                    latitude = _latitude,
                    longitude = _longitude,
                    condition = _condition,
                }
            };

            return Json(JsonList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MapAircraft()
        {
            
            var JsonList = new List<Aircraft>()
            {
                pesawat
            };

            //ShowAircraft(pesawat);
            return Json(JsonList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowAircraft()
        {
            
            return PartialView("_Information", pesawat);
        }

        
    }
}