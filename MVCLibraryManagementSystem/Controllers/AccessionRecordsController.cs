using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLibraryManagementSystem.DAL;
using MVCLibraryManagementSystem.Models;

namespace MVCLibraryManagementSystem.Controllers
{
    public class AccessionRecordsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: AccessionRecords
        public ActionResult Index()
        {
            return View(db.AccessionRecords.ToList());
        }

        // GET: AccessionRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRecord accessionRecord = db.AccessionRecords.Find(id);
            if (accessionRecord == null)
            {
                return HttpNotFound();
            }
            return View(accessionRecord);
        }

        // GET: AccessionRecords/Create
        public ActionResult Create(int? itemid)
        {
            ViewBag.Item = db.Items.Where(d => d.ItemId == itemid).First();
            return View();
        }

        // POST: AccessionRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessionRecordId,DateOfReceipt,Source,Price,Item")] AccessionRecord accessionRecord)
        {
            if (ModelState.IsValid)
            {
                db.AccessionRecords.Add(accessionRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessionRecord);
        }

        // GET: AccessionRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRecord accessionRecord = db.AccessionRecords.Find(id);
            if (accessionRecord == null)
            {
                return HttpNotFound();
            }
            return View(accessionRecord);
        }

        // POST: AccessionRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessionRecordId,DateOfReceipt,Source,Price")] AccessionRecord accessionRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessionRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessionRecord);
        }

        // GET: AccessionRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRecord accessionRecord = db.AccessionRecords.Find(id);
            if (accessionRecord == null)
            {
                return HttpNotFound();
            }
            return View(accessionRecord);
        }

        // POST: AccessionRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessionRecord accessionRecord = db.AccessionRecords.Find(id);
            db.AccessionRecords.Remove(accessionRecord);
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
