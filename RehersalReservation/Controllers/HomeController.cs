﻿using RehersalReservation.Models;
using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RehersalReservation.Controllers
{
    public class HomeController : Controller
    {
        private IRehersalService rehersalService;
        public HomeController(IRehersalService rehersalService)
        {
            this.rehersalService = rehersalService;
        }
        public ActionResult Index()
        {
            IEnumerable<Entity.RehersalSpase> data = this.rehersalService.GetRehersals();
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
    }
}