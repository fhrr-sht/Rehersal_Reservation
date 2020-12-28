using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RehersalReservation.Controllers;
using RehersalReservation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RehersalReservation.Tests.Controllers
{
    [TestClass]
    public class RoomControllerTest
    {
        Mock<IRoomService> roomService = new Mock<IRoomService>();
        const int IdOne = 1;
        const int IdTwo = 2;
        RoomController controller = null;
        public RoomControllerTest()
        {
            controller = new RoomController(roomService.Object);
        }
        [TestMethod]
        public async Task Rooms()
        {
            // Arrange
            roomService.Setup(room => room.GetRooms()).
            ReturnsAsync(new List<Entity.Room>()
                {
                });
            // Act
            ViewResult result = await controller.Rooms() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<Room>));
        }
        [TestMethod]
        public async Task DeleteSuccessful()
        {
            // Act
            RedirectToRouteResult result = await controller.Delete(IdOne) as RedirectToRouteResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rooms", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task EditSuccessful()
        {
            //Arrange
            Room room = new Room();
            // Act
            RedirectToRouteResult result = await controller.Edit(room) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rooms", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task EditFail()
        {
            //Arrange
            Room room = new Room(); 
            controller.ModelState.AddModelError("error", "error");
            // Act
            HttpStatusCodeResult result = await controller.Edit(room) as HttpStatusCodeResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task AddSuccessful()
        {
            //Arrange
            Room room = new Room();
            // Act
            RedirectToRouteResult result = await controller.Create(room) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rooms", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task AddFail()
        {
            //Arrange
            Room room = new Room();
            controller.ModelState.AddModelError("error", "error");
            // Act
            HttpStatusCodeResult result = await controller.Create(room) as HttpStatusCodeResult; ;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }

}
