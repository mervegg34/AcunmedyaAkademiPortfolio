using AcunmedyaAkademiPortfolio.Repositories;
using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Genericrepository<TblAbout> repo = new Genericrepository<TblAbout>();
        public ActionResult Index()
        { 
            var abouut = repo.List();
            return View(abouut);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            TblAbout t = repo.Find(x=>x.AboutId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            TblAbout t = repo.Find(x => x.AboutId == p.AboutId);
            t.Title = p.Title;
            t.Description = p.Description;
            t.City = p.City;
            t.Email = p.Email;
            t.Phone = p.Phone;
            t.Birthday = p.Birthday;
            t.Age = p.Age;
            t.Degree = p.Degree;
            t.Freelance = p.Freelance;
            t.Website = p.Website;
            t.ImageUrl = p.ImageUrl;
            t.Title2 = p.Title2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}