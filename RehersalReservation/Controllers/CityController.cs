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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            cityService.InsertCity(new Entity.City
            {
                CityName = city.CityName
            });
            return RedirectToAction("Cities");
        }
        [HttpPost]
        public ActionResult Edit(City city)
        {
            cityService.UpdateCity(new Entity.City
            {
                CityID = city.CityID,
                CityName = city.CityName
            });
            return RedirectToAction("Cities");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Entity.City data = this.cityService.GetCityByID(id);
            City city = new City
            {
                CityID = data.CityID,
                CityName = data.CityName
            };
            return View(city);

        }
        public ActionResult Delete(int id)
        {
            cityService.DeleteCity(id);
            return RedirectToAction("Cities");
        }
    }
}