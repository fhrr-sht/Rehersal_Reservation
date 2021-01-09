using RehersalReservation.Models;
using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace RehersalReservation.Controllers
{
    public class RehersalController : Controller
    {
        private IRehersalService rehersalService;
        private IRoomService roomService;
        public RehersalController(IRehersalService rehersalService, IRoomService roomService)
        {
            this.rehersalService = rehersalService;
            this.roomService = roomService;
        }
        public async Task<ActionResult> Rehersals()
        {
            IEnumerable<Entity.RehersalSpase> data = await this.rehersalService.GetRehersals();
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            IEnumerable<RehersalSpace> rehersalSpaces = data.Select(o =>
            new RehersalSpace
            {
                Adress = o.Adress,
                CityID = o.CityID,
                RehersalSpaseID = o.RehersalSpaseID,
                RehersalSpaseName = o.RehersalSpaseName
            }).ToList();
            return View(rehersalSpaces);
        }
        public async Task<ActionResult> Delete(int id)
        {
            IEnumerable<Entity.Room> data = await this.roomService.GetRoomByRehersalID(id);
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            if (data.Count() == 0)
            {
                await rehersalService.DeleteRehersal(id);
            }
            else
            {
                return Content(@"Нельзя удалить связанный объект");
            }
            return RedirectToAction("Rehersals");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RehersalSpace rehersalSpace)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await rehersalService.UpdateRehersal(new RehersalSpase
            {
                Adress = rehersalSpace.Adress,
                CityID = rehersalSpace.CityID,
                RehersalSpaseID = rehersalSpace.RehersalSpaseID,
                RehersalSpaseName = rehersalSpace.RehersalSpaseName
            });
            return RedirectToAction("Rehersals");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Entity.RehersalSpase data = await this.rehersalService.GetRehersalByID(id);
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            RehersalSpace rehersalSpace = new RehersalSpace
            {
                Adress = data.Adress,
                CityID = data.CityID,
                RehersalSpaseID = data.RehersalSpaseID,
                RehersalSpaseName = data.RehersalSpaseName
            };
            return View(rehersalSpace);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(RehersalSpace rehersalSpace)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await rehersalService.InsertRehersal(new RehersalSpase
            {
                Adress = rehersalSpace.Adress,
                CityID = rehersalSpace.CityID,
                RehersalSpaseID = rehersalSpace.RehersalSpaseID,
                RehersalSpaseName = rehersalSpace.RehersalSpaseName
            });
            return RedirectToAction("Rehersals");
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
        [HttpGet]
        public async Task<ActionResult> GetRehersalByCityID(int cityID)
        {
            IEnumerable<Entity.RehersalSpase> data = await this.rehersalService.GetRehersalByCityID(cityID);
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            IEnumerable<RehersalSpace> rehersalSpaces = data.Select(o =>
            new RehersalSpace
            {
                Adress = o.Adress,
                CityID = o.CityID,
                RehersalSpaseID = o.RehersalSpaseID,
                RehersalSpaseName = o.RehersalSpaseName
            }).ToList();
            return View(rehersalSpaces);
        }
    }
}