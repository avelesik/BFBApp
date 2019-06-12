using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BFBApp.Models;

namespace BFBApp.Controllers
{
    public class TransactionsController : Controller
    {
        private ModelExchange db = new ModelExchange();
        // GET: Transactions
        public ActionResult _Index()
        {
            var transactions = db.Transactions.Include(t => t.Currencies).Include(t => t.Participants).Include(t => t.Participants1);
            return PartialView(transactions.ToList());
        }
        public ActionResult Dashboard()
        {
            var list = db.Transactions.ToList();
            List<string> relatitions=new List<string>();
            foreach(var item in list)
            {
                relatitions.Add(item.DateTime.Year+"-0"+ item.DateTime.Month+"-"+item.DateTime.Day);
            }

            ViewBag.REP = relatitions.Distinct().ToList();
            ViewBag.AGES1 = db.Transactions.Where(t => t.currency_Id == 1).Select(s => s.Price).ToList();
            ViewBag.AGES2 = db.Transactions.Where(t => t.currency_Id == 2).Select(s => s.Price).ToList();
            ViewBag.AGES3 = db.Transactions.Where(t => t.currency_Id == 3).Select(s => s.Price).ToList();
            return View();
        }
        public ActionResult DashboardAJAX()
        {
            var list = db.Transactions.ToList();
            List<string> relatitions = new List<string>();
            foreach (var item in list)
            {
                relatitions.Add(item.DateTime.Year + "-0" + item.DateTime.Month + "-" + item.DateTime.Day);
            }

            ViewBag.REP = relatitions.Distinct().ToList();
            ViewBag.AGES1 = db.Transactions.Where(t => t.currency_Id == 1).Select(s => s.Price).ToList();
            ViewBag.AGES2 = db.Transactions.Where(t => t.currency_Id == 2).Select(s => s.Price).ToList();
            ViewBag.AGES3 = db.Transactions.Where(t => t.currency_Id == 3).Select(s => s.Price).ToList();
            return View();
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
