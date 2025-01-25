using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        } 

        public ActionResult DeleteExperience(int id)
        {
            TblExperience t = repo.Find(x => x.EducationId == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience t = repo.Find(x => x.EducationId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.EducationId == p.EducationId);
            t.Title = p.Title;
            t.Description = p.Description;
            t.StartYear = p.StartYear;
            t.EndYear = p.EndYear;
            t.SchoolCompany = p.SchoolCompany;
            t.Department = p.Department;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}