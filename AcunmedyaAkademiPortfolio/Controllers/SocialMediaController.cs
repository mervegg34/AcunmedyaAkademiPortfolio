using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        Genericrepository<TblSocialMedia> repo = new Genericrepository<TblSocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var n = repo.List();
            return View(n);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            TblSocialMedia t = repo.Find(x => x.SocialMediaId == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            TblSocialMedia t = repo.Find(x => x.SocialMediaId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x => x.SocialMediaId == p.SocialMediaId);
            t.Name = p.Name;
            t.Url = p.Url;
            t.Icon = p.Icon;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
