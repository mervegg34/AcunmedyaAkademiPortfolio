using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbAcunmedyaAkademiPortfolioEntities db = new DbAcunmedyaAkademiPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var categoryList = db.TblCategories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text= x.CategoryName,
                                                   Value= x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProject model)
        {
            var categoryList = db.TblCategories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;


            if (ModelState.IsValid)
            {
                db.TblProjects.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
            
        }


        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var categoryList = db.TblCategories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;
            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            var categoryList = db.TblCategories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;

            var value = db.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.GithubUrl = model.GithubUrl;
            value.ImageUrl = model.ImageUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}