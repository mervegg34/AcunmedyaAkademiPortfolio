using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiPortfolio.Models;
using AcunmedyaAkademiPortfolio.Repositories;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        Genericrepository<TblMessage> repo = new Genericrepository<TblMessage>();
        public ActionResult Index()
        {
            var y = repo.List();
            return View(y);
        }

        public ActionResult DeleteMessage(int id)
        {
            TblMessage t = repo.Find(x => x.MessageId == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}