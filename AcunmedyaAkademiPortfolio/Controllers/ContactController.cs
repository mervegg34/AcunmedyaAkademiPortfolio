using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ContactController : Controller
    {
        Genericrepository<TblContact> repo = new Genericrepository<TblContact>();
        // GET: Contact
        public ActionResult Index()
        {
            var y = repo.List();
            return View(y);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            TblContact p = repo.Find(x => x.ContactId == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContact t)
        {
            TblContact p = repo.Find(x => x.ContactId == t.ContactId);
            p.Address = t.Address;
            p.Email = t.Email;
            p.Phone = t.Phone;
            p.MapUrl = t.MapUrl;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}