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
    public class AccessionRegistersController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: AccessionRegisters
        public ActionResult Index()
        {
            return View(db.AccessionRegister.ToList());
        }

        // GET: AccessionRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRegister accessionRegister = db.AccessionRegister.Find(id);
            if (accessionRegister == null)
            {
                return HttpNotFound();
            }
            return View(accessionRegister);
        }

        // GET: AccessionRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessionRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessionId,DateOfReceipt,Source,Price")] AccessionRegister accessionRegister)
        {
            if (ModelState.IsValid)
            {
                db.AccessionRegister.Add(accessionRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessionRegister);
        }

        // GET: AccessionRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRegister accessionRegister = db.AccessionRegister.Find(id);
            if (accessionRegister == null)
            {
                return HttpNotFound();
            }
            return View(accessionRegister);
        }

        // POST: AccessionRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessionId,DateOfReceipt,Source,Price")] AccessionRegister accessionRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessionRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessionRegister);
        }

        // GET: AccessionRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessionRegister accessionRegister = db.AccessionRegister.Find(id);
            if (accessionRegister == null)
            {
                return HttpNotFound();
            }
            return View(accessionRegister);
        }

        // POST: AccessionRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessionRegister accessionRegister = db.AccessionRegister.Find(id);
            db.AccessionRegister.Remove(accessionRegister);
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
