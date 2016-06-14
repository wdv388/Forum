using Forum.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Forum.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TopicsController : Controller
    {
        private ForumDBContainer db = new ForumDBContainer();

        //
        // GET: /Topics/

        public ActionResult Index()
        {
            return View(db.TopicsНабор.ToList());
        }

        //
        // GET: /Topics/Details/5

        public ActionResult Details(int id = 0)
        {
            Topics topics = db.TopicsНабор.Find(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        //
        // GET: /Topics/Create

        public ActionResult Create()
        {
            ViewBag.AID = WebSecurity.CurrentUserName;
            return View();
        }

        //
        // POST: /Topics/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.TopicsНабор.Add(topics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topics);
        }

        //
        // GET: /Topics/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Topics topics = db.TopicsНабор.Find(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        //
        // POST: /Topics/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        //
        // GET: /Topics/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Topics topics = db.TopicsНабор.Find(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        //
        // POST: /Topics/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topics topics = db.TopicsНабор.Find(id);
            db.TopicsНабор.Remove(topics);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}