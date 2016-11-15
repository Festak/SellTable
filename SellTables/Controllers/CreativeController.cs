﻿using Microsoft.AspNet.Identity;
using MultilingualSite.Filters;
using SellTables.Models;
using SellTables.Services;
using SellTables.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SellTables.Controllers
{
    [Culture]
    [Authorize]
    public class CreativeController : Controller
    {
       ApplicationDbContext dataBaseConnection = new ApplicationDbContext();

        CreativeService CreativeService;

        public CreativeController()
        {
            CreativeService = new CreativeService(dataBaseConnection);
        }

        // GET: Creative
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterCreativeModel creativemodel)
        {
            if (ModelState.IsValid)
            {
              creativemodel.Creative.User = FindUser();
                CreativeService.AddCreative(creativemodel);
                return RedirectToAction("Index");
            }

            return View(creativemodel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creative creative = CreativeService.GetCreative(id ?? 0);
            if (creative == null)
            {
                return HttpNotFound();
            }
            return View(creative);
        }

        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Creative creative = await dataBaseConnection.Creatives.FindAsync(id);
            RegisterCreativeModel model = new RegisterCreativeModel();
            model.Creative = creative;
            
            model.Chapters = creative.Chapters;

            if (creative == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // TODO
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(RegisterCreativeModel registerCreativeModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dataBaseConnection.Entry(creative).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(creative);
        //}
        
        public void GetRatingFromView(int rating, CreativeViewModel creative) {
           CreativeService.SetRatingToCreative(rating, creative, FindUser());
        }
        
        public void GetRatingFromViewModel(int rating, Creative creative)
        {
           // CreativeService.SetRatingToCreative(rating, creative, FindUser());
        }

        private ApplicationUser FindUser()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return null;
            return dataBaseConnection.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        public ActionResult Search(string query) {
            if (query == null) {
                return RedirectToAction("Index", "Home");
            }
            var listOfLuceneObjectsByTags = Lucene.CreativeSearch.Search(query, "Tags");
            var listOfLuceneObjectsByName = Lucene.CreativeSearch.Search(query, "Names");

            var listOfCreativeViewModelObjects = CreativeService.GetCreativesBySearch(listOfLuceneObjectsByTags);
            ViewBag.listOfLuceneObjectsByName = listOfLuceneObjectsByName;

            return View(listOfCreativeViewModelObjects.ToList());
        }

        public JsonResult GetCreativesByUser(string userName) {
            var creatives = CreativeService.GetCreativesByUser(userName);
            return Json(creatives, JsonRequestBehavior.AllowGet);
        }

    }
}