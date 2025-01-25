using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        Genericrepository<TblTestimonial> repo = new Genericrepository<TblTestimonial>();
        // GET: Testimonial
        public ActionResult Index()
        {
            var m = repo.List();
            return View(m);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            TblTestimonial t = repo.Find(x => x.TestimonialId == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            TblTestimonial t = repo.Find(x => x.TestimonialId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            TblTestimonial t = repo.Find(x => x.TestimonialId == p.TestimonialId);
            t.Title = p.Title;
            t.Comment = p.Comment;
            t.Name = p.Name;
            t.ImageUrl = p.ImageUrl;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}