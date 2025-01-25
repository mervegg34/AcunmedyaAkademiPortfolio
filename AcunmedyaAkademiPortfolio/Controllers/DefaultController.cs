using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbAcunmedyaAkademiPortfolioEntities db = new DbAcunmedyaAkademiPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values = db.TblBanners.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultStatistics()
        {
            ViewBag.projectCount = db.TblProjects.Count();
            ViewBag.skillCount = db.TblSkills.Count();
            ViewBag.testimonialCount = db.TblTestimonials.Count();
            ViewBag.serviceCount = db.TblServices.Count();

            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult DefaultExperiences()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
       
        public PartialViewResult DefaultTestimonial()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultContact()
        {
            var values = db.TblContacts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSkill()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultService()
        {
            var values = db.TblServices.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProject()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public PartialViewResult ProjectName()
        {
            var values = db.TblCategories.ToList();
            return PartialView(values);
        }
    }
}