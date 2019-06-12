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
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Currencies).Include(t => t.Participants).Include(t => t.Participants1);
            return View(transactions.ToList());
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
        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.currency_Id = new SelectList(db.Currencies, "Id", "Name");
            ViewBag.participant_new_Id = new SelectList(db.Participants, "Id", "Name");
            ViewBag.participant_old_Id = new SelectList(db.Participants, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Amount,DateTime,participant_new_Id,participant_old_Id,currency_Id")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transactions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.currency_Id = new SelectList(db.Currencies, "Id", "Name", transactions.currency_Id);
            ViewBag.participant_new_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_new_Id);
            ViewBag.participant_old_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_old_Id);
            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            ViewBag.currency_Id = new SelectList(db.Currencies, "Id", "Name", transactions.currency_Id);
            ViewBag.participant_new_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_new_Id);
            ViewBag.participant_old_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_old_Id);
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Amount,DateTime,participant_new_Id,participant_old_Id,currency_Id")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.currency_Id = new SelectList(db.Currencies, "Id", "Name", transactions.currency_Id);
            ViewBag.participant_new_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_new_Id);
            ViewBag.participant_old_Id = new SelectList(db.Participants, "Id", "Name", transactions.participant_old_Id);
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transactions transactions = db.Transactions.Find(id);
            db.Transactions.Remove(transactions);
            db.SaveChanges();
            return RedirectToAction("Index");
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
