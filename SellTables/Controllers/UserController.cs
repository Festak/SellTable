﻿using SellTables.Models;
using SellTables.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellTables.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        CreativeService CreativeService;
        UserService UserService;

        public UserController() {
            CreativeService = new CreativeService(db);
            UserService = new UserService(db);
        }

        public ActionResult UserPage()
        {
            return View(UserService.GetCurrentUser(User.Identity.Name));
        }

        public ActionResult Settings()
        {

            return View();
        }

        public JsonResult GetCreativesByUser(string userName)
        {
            var creatives = CreativeService.GetCreativesByUser(userName);
            return Json(creatives, JsonRequestBehavior.AllowGet);
        }
      
    }
}