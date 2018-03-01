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
        Information info = new Information();
        List<Aircraft> daftarPesawat = new List<Aircraft>();
        List<Passenger> daftarPenumpang = new List<Passenger>();

        

        public ActionResult _Information(string str)
        {
            info.NamaInfo = str;
            
            return View(info);
            
        }

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
    }
}