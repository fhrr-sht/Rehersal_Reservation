using RehersalReservation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RehersalReservation.Controllers
{
    public class CityController : Controller
    {
        private ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        // GET: City
        public ActionResult Cities()
        {
            IEnumerable<Entity.City> data = this.cityService.GetCities();
            IEnumerable<City> cities = data.Select(o =>
            new City
            {
                CityID = o.CityID,
                CityName = o.CityName
            }).ToList();
            return View(cities);
        }
    }
}