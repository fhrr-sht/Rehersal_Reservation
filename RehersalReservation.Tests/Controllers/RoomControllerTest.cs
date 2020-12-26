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
        [TestMethod]
        public async Task Rooms()
        {
            // Arrange
            RoomController controller = new RoomController(roomService.Object);
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
            // Arrange
            RoomController controller = new RoomController(roomService.Object);

            // Act
            RedirectToRouteResult result = await controller.Delete(IdOne) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rooms", result.RouteValues["action"]);
        }
    }

}
