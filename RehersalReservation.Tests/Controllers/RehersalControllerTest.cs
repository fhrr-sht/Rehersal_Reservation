using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RehersalReservation;
using System.Threading.Tasks;
using RehersalReservation.Controllers;
using RehersalReservation.Models;
using Services;
using Entity;

namespace RehersalReservation.Tests.Controllers
{
    [TestClass]
    public class RehersalControllerTest
    {

        Mock<IRehersalService> rehersalService = new Mock<IRehersalService>();
        Mock<IRoomService> roomService = new Mock<IRoomService>();
        RehersalController controller = null;
        const int IdOne = 1;
        const int IdTwo = 2;
        public RehersalControllerTest()
        {
            controller = new RehersalController(rehersalService.Object, roomService.Object);
        }
        [TestMethod]
        public async Task Rehersals()
        {
            // Act
            ViewResult result = await controller.Rehersals() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<RehersalSpace>));
        }

        [TestMethod]
        public async Task DeleteSuccessful()
        {
            // Arrange
            roomService.Setup(room => room.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>()
                {
                });
            // Act
            RedirectToRouteResult result = await controller.Delete(IdOne) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rehersals", result.RouteValues["action"]);
            roomService.VerifyAll();
        }
        [TestMethod]
        public async Task DeleteFail()
        {
            // Arrange
            roomService.Setup(room => room.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>() {
                new Entity.Room()
                {
                    RehersalRoomID = IdOne
                }
            });
            // Act
            ContentResult result = await controller.Delete(IdOne) as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Нельзя удалить связанный объект", result.Content);
            roomService.VerifyAll();
        }
        [TestMethod]
        public async Task DeleteNotFound()
        {
            // Arrange
            roomService.Setup(room => room.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>() {
                new Entity.Room()
                {
                    RehersalRoomID = IdOne
                }
            });

            // Act
            HttpStatusCodeResult result = await controller.Delete(IdTwo) as HttpStatusCodeResult; ;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task EditSuccessful()
        {
            //Arrange
            RehersalSpace rehersalSpace = new RehersalSpace();
            // Act
            RedirectToRouteResult result = await controller.Edit(rehersalSpace) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rehersals", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task EditFail()
        {
            //Arrange
            RehersalSpace rehersalSpace = new RehersalSpace();
            controller.ModelState.AddModelError("error", "error");
            // Act
            HttpStatusCodeResult result = await controller.Edit(rehersalSpace) as HttpStatusCodeResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task AddSuccessful()
        {
            //Arrange
            RehersalSpace rehersalSpace = new RehersalSpace();
            // Act
            RedirectToRouteResult result = await controller.Add(rehersalSpace) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Rehersals", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task AddFail()
        {
            //Arrange
            RehersalSpace rehersalSpace = new RehersalSpace();
            controller.ModelState.AddModelError("error", "error");
            // Act
            HttpStatusCodeResult result = await controller.Add(rehersalSpace) as HttpStatusCodeResult; ;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task EditByIDSuccessful()
        {
            // Arrange
            rehersalService.Setup(rehersal => rehersal.GetRehersalByID(IdOne)).
                ReturnsAsync(new Entity.RehersalSpase() { });
            // Act
            ViewResult result = await controller.Edit(IdOne) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(RehersalSpace));
            rehersalService.VerifyAll();
        }
        [TestMethod]
        public async Task EditByIDFail()
        {
            // Arrange
            rehersalService.Setup(rehersal => rehersal.GetRehersalByID(IdOne)).
                  ReturnsAsync(new Entity.RehersalSpase() { });
            // Act
            HttpStatusCodeResult result = await controller.Edit(IdTwo) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void Add()
        {
            // Act
            ViewResult result = controller.Add() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task GetRehersalByCityIDSuccessful()
        {
            // Arrange
            rehersalService.Setup(rehersal => rehersal.GetRehersalByCityID(IdOne)).
                  ReturnsAsync(new List<RehersalSpase>() { new RehersalSpase() {} });
            // Act
            ViewResult result = await controller.GetRehersalByCityID(IdOne) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<RehersalSpace>));
            rehersalService.VerifyAll();
        }
        [TestMethod]
        public async Task GetRehersalByCityIDFail()
        {
            // Arrange
            rehersalService.Setup(rehersal => rehersal.GetRehersalByCityID(IdOne)).
                  ReturnsAsync(new List<RehersalSpase>() { new RehersalSpase() { } });
            // Act
            HttpStatusCodeResult result = await controller.GetRehersalByCityID(IdTwo) as HttpStatusCodeResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
