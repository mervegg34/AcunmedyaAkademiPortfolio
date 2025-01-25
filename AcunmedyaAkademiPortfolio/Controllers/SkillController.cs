using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class SkillController : Controller
    {
        Genericrepository<TblSkill> repo = new Genericrepository<TblSkill>(); 
        public ActionResult Index()
        {
            var skill = repo.List();
            return View(skill);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.SkillId == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            TblSkill p = repo.Find(x => x.SkillId == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult GetSkill(TblSkill t)
        {
            TblSkill p = repo.Find(x => x.SkillId == t.SkillId);
            p.Name = t.Name;
            p.Percentage = t.Percentage;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}