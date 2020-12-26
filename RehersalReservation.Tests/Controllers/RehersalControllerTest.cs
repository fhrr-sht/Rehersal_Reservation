﻿using System;
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

namespace RehersalReservation.Tests.Controllers
{
    [TestClass]
    public class RehersalControllerTest
    {
        Mock<IRehersalService> rehersalService = new Mock<IRehersalService>();
        Mock<IRoomService> roomService = new Mock<IRoomService>();
        const int IdOne = 1;
        const int IdTwo = 2;
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<RehersalSpace>));
        }

        [TestMethod]
        public async Task DeleteSuccessful()
        {
            roomService.Setup(delete => delete.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>() {
               });
            // Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            RedirectToRouteResult result = await controller.Delete(IdOne) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task DeleteFail()
        {
            roomService.Setup(delete => delete.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>() {
                new Entity.Room()
                {
                    RehersalRoomID = IdOne
                }
            });
            // Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            ContentResult result = await controller.Delete(IdOne) as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Нельзя удалить связанный объект", result.Content);
        }
        [TestMethod]
        public async Task DeleteNotFound()
        {
            roomService.Setup(delete => delete.GetRoomByRehersalID(IdOne)).
                ReturnsAsync(new List<Entity.Room>() {
                new Entity.Room()
                {
                    RehersalRoomID = IdOne
                }
            });
            // Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            HttpStatusCodeResult result = await controller.Delete(IdTwo) as HttpStatusCodeResult; ;

            // Assert
            Assert.IsNotNull(result);
           Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void About()
        {
            // Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //Arrange
            RehersalController controller = new RehersalController(rehersalService.Object, roomService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}