using RehersalReservation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Cities()
        {
            IEnumerable<Entity.City> data = await this.cityService.GetCities();
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
        public async Task<ActionResult> Create(City city)
        {
            cityService.InsertCity(new Entity.City
            {
                CityName = city.CityName
            });
            return RedirectToAction("Cities");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(City city)
        {
            cityService.UpdateCity(new Entity.City
            {
                CityID = city.CityID,
                CityName = city.CityName
            });
            return RedirectToAction("Cities");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Entity.City data = await this.cityService.GetCityByID(id);
            City city = new City
            {
                CityID = data.CityID,
                CityName = data.CityName
            };
            return View(city);

        }
        public async Task<ActionResult> Delete(int id)
        {
            await cityService.DeleteCity(id);
            return RedirectToAction("Cities");
        }
    }
}