using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Echo.Models;

namespace Echo.Controllers
{
    public class HomeController : Controller
    {
        //Informationlnkl info = new Informationlnkl();

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
        public ActionResult Index()
        {
            //info.NamaInfo = "Information Field";
            return View(pesawat);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}