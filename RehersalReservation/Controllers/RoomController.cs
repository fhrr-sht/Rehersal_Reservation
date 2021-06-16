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
    //[Authorize(Roles = "admin")]
    public class RoomController : Controller
    {
        private IRoomService roomService;
        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        // GET: Room
        public async Task<ActionResult> Rooms()
        {
            {
                IEnumerable<Entity.Room> data = await this.roomService.GetRooms();
                IEnumerable<Room> rooms = data.Select(o =>
                new Room
                {
                    RehersalRoomID = o.RehersalRoomID,
                    RehersalSpaseID = o.RehersalSpaseID,
                    RehersalRoomName = o.RehersalRoomName,
                    RehersalRoomSize = o.RehersalRoomSize
                }).ToList();
                return View(rooms);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Room room)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await roomService.InsertRoom(new Entity.Room
            {
                RehersalSpaseID = room.RehersalSpaseID,
                RehersalRoomName = room.RehersalRoomName,
                RehersalRoomSize = room.RehersalRoomSize
            });
            return RedirectToAction("Rooms");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Room room)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Model is bad");
            }
            await roomService.UpdateRoom(new Entity.Room
            {
                RehersalRoomID = room.RehersalRoomID,
                RehersalSpaseID = room.RehersalSpaseID,
                RehersalRoomName = room.RehersalRoomName,
                RehersalRoomSize = room.RehersalRoomSize
            });
            return RedirectToAction("Rooms");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Entity.Room data = await this.roomService.GetRoomByID(id);
            if (data == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
            }
            Room room = new Room
            {
                RehersalRoomID = data.RehersalRoomID,
                RehersalSpaseID = data.RehersalSpaseID,
                RehersalRoomName = data.RehersalRoomName,
                RehersalRoomSize = data.RehersalRoomSize
            };
            return View(room);
        }
        public async Task<ActionResult> Delete(int id)
        {
            await roomService.DeleteRoom(id);
            return RedirectToAction("Rooms");
        }
        [HttpGet]
        public async Task<ActionResult> GetRoomByRehersalID(int rehersalSpaceID)
        {
            {
                IEnumerable<Entity.Room> data = await this.roomService.GetRoomByRehersalID(rehersalSpaceID);
                if (data == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Data not found");
                }
                IEnumerable<Room> rooms = data.Select(o =>
                new Room
                {
                    RehersalRoomID = o.RehersalRoomID,
                    RehersalSpaseID = o.RehersalSpaseID,
                    RehersalRoomName = o.RehersalRoomName,
                    RehersalRoomSize = o.RehersalRoomSize
                }).ToList();
                return View(rooms);
            }
        }
    }
}