using RehersalReservation.Models;
using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace RehersalReservation.Controllers
{
    public class HomeController : Controller
    {
        private IRehersalService rehersalService;
        private IRoomService roomService;     
        public HomeController(IRehersalService rehersalService, IRoomService roomService)
        {
            this.rehersalService = rehersalService;
            this.roomService = roomService;
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<Entity.RehersalSpase> data = await this.rehersalService.GetRehersals();
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
            if (data.Count() == 0)
            {
                await rehersalService.DeleteRehersal(id);
            }
            else
            {
                return Content(@"<script language='javascript' type='text/javascript'>
                    alert('Нельзя удалить связанный объект'); 
                    let url = document.getElementById('RedirectTo').val();
                    location.href = url;
                    </script>");
            }          
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RehersalSpace rehersalSpace)
        {
            await rehersalService.UpdateRehersal(new RehersalSpase
            {
                Adress = rehersalSpace.Adress,
                CityID = rehersalSpace.CityID,
                RehersalSpaseID = rehersalSpace.RehersalSpaseID,
                RehersalSpaseName = rehersalSpace.RehersalSpaseName
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Entity.RehersalSpase data = await this.rehersalService.GetRehersalByID(id);
            RehersalSpace rehersalSpace= new RehersalSpace
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
            await rehersalService.InsertRehersal(new RehersalSpase
            {
                Adress = rehersalSpace.Adress,
                CityID = rehersalSpace.CityID,
                RehersalSpaseID = rehersalSpace.RehersalSpaseID,
                RehersalSpaseName = rehersalSpace.RehersalSpaseName
            });
            return RedirectToAction("Index");
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