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
    public class CityControllerTest
    {
        Mock<IRehersalService> rehersalService = new Mock<IRehersalService>();
        Mock<ICityService> cityService = new Mock<ICityService>();
        const int IdOne = 1;
        const int IdTwo = 2;
        [TestMethod]
        public async Task Cities()
        {
            // Arrange
            CityController controller = new CityController(cityService.Object, rehersalService.Object);
            cityService.Setup(city => city.GetCities()).
    ReturnsAsync(new List<Entity.City>()
    {
    });
            // Act
            ViewResult result = await controller.Cities() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<City>));
        }
        [TestMethod]
        public async Task DeleteSuccessful()
        {
            rehersalService.Setup(rehersal => rehersal.GetRehersalByCityID(IdOne)).
                ReturnsAsync(new List<Entity.RehersalSpase>()
                {
                });
            // Arrange
            CityController controller = new CityController(cityService.Object, rehersalService.Object);

            // Act
            RedirectToRouteResult result = await controller.Delete(IdOne) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.RouteValues.ContainsKey("controller"));
            Assert.AreEqual("", result.RouteName);
            Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            Assert.AreEqual("Cities", result.RouteValues["action"]);
        }
        [TestMethod]
        public async Task DeleteFail()
        {
            rehersalService.Setup(rehersal => rehersal.GetRehersalByCityID(IdOne)).
                ReturnsAsync(new List<Entity.RehersalSpase>() {
                new Entity.RehersalSpase()
                {
                    RehersalSpaseID = IdOne
                }
            });
            // Arrange
            CityController controller = new CityController(cityService.Object, rehersalService.Object);

            // Act
            ContentResult result = await controller.Delete(IdOne) as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Нельзя удалить связанный объект", result.Content);
        }
        [TestMethod]
        public async Task DeleteNotFound()
        {
            rehersalService.Setup(rehersal => rehersal.GetRehersalByCityID(IdOne)).
                ReturnsAsync(new List<Entity.RehersalSpase>() {
                new Entity.RehersalSpase()
                {
                    RehersalSpaseID = IdOne
                }
            });
            // Arrange
            CityController controller = new CityController(cityService.Object, rehersalService.Object);

            // Act
            HttpStatusCodeResult result = await controller.Delete(IdTwo) as HttpStatusCodeResult; ;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
