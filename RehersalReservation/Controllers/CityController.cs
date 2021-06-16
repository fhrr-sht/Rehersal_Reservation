using RehersalReservation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RehersalReservation.Controllers
{
    [AllowAnonymous]
    public class CityController : Controller
    {
        private ICityService cityService;
        private IRehersalService rehersalService;
        public CityController(ICityService cityService, IRehersalService rehersalService)
        {
            this.cityService = cityService;
            this.rehersalService = rehersalService;
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
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await cityService.InsertCity(new Entity.City
            {
                CityName = city.CityName
            });
            return RedirectToAction("Cities");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(City city)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await cityService.UpdateCity(new Entity.City
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
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            City city = new City
            {
                CityID = data.CityID,
                CityName = data.CityName
            };
            return View(city);

        }
        public async Task<ActionResult> Delete(int id)
        {
            IEnumerable<Entity.RehersalSpase> data = await this.rehersalService.GetRehersalByCityID(id);
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            if (data.Count() == 0)
            {
                await cityService.DeleteCity(id);
            }
            else
            {
                return Content(@"Нельзя удалить связанный объект");
            }
            return RedirectToAction("Cities");
        }
    }
}