﻿using Microsoft.AspNet.Identity;
using MultilingualSite.Filters;
using SellTables.Models;
using SellTables.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellTables.Controllers
{
    [Authorize(Roles = "admin")]
    [Culture]
    public class AdminController : DefaultController
    {
        ApplicationDbContext DataBaseConnection = new ApplicationDbContext();

        CreativeService CreativeService;
        UserService UserService;

        public AdminController()
        {
            CreativeService = new CreativeService(DataBaseConnection);
            UserService = new UserService(DataBaseConnection);
        }


        public ActionResult Index()
        {

            return View(GetUsers());
        }

        [HttpPost]
        public ActionResult DeleteUser(string userName)
        {
            if (userName != null)
            {
                UserService.DeleteUser(userName);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public void BanUser(string userName)
        {
            UserService.BanUser(userName);
        }

        [HttpPost]
        public void UnbanUser(string userName)
        {
            UserService.UnbanUser(userName);
        }

        private ICollection<ApplicationUser> GetUsers() {
            return UserService.GetAllUsers();
        }

        [HttpGet]
        public ActionResult UserPage(string username) {
            return View(UserService.GetUserByName(username));
        }

    }
}