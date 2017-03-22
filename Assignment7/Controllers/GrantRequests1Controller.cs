using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment7.Models;

namespace Assignment7.Controllers
{
    public class GrantRequests1Controller : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();

        // GET: GrantRequests1
        public ActionResult Index()
        {
            var grantRequests = db.GrantRequests.Include(g => g.Person);
            return View(grantRequests.ToList());
        }

        // GET: GrantRequests1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequests.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            return View(grantRequest);
        }

        // GET: GrantRequests1/Create
        public ActionResult Create()
        {
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName");
            return View();
        }

        // POST: GrantRequests1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrantRequestKey,GrantRequestDate,PersonKey,GrantTypeKey,GrantRequestExplanation,GrantRequestAmount")] GrantRequest grantRequest)
        {
            if (ModelState.IsValid)
            {
                db.GrantRequests.Add(grantRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // GET: GrantRequests1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequests.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // POST: GrantRequests1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrantRequestKey,GrantRequestDate,PersonKey,GrantTypeKey,GrantRequestExplanation,GrantRequestAmount")] GrantRequest grantRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", grantRequest.PersonKey);
            return View(grantRequest);
        }

        // GET: GrantRequests1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantRequest grantRequest = db.GrantRequests.Find(id);
            if (grantRequest == null)
            {
                return HttpNotFound();
            }
            return View(grantRequest);
        }

        // POST: GrantRequests1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantRequest grantRequest = db.GrantRequests.Find(id);
            db.GrantRequests.Remove(grantRequest);
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
