using Forum.Filters;
using Forum.Models;
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
    public class DiscusController : Controller
    {
        private ForumDBContainer db = new ForumDBContainer();

        //
        // GET: /Discus/

        public ActionResult Index()
        {
               
            var discusнабор = db.DiscusНабор.Include(d => d.Topics);
            //ViewBag.disandansw = db.DiscusНабор.Join(db.AnswerНабор, p => p.ID, c => c.DiscusID, (p, c) => new { Disc = p.Text, Ans = c.Text, AVT = p.Author }).ToList();
              return View(discusнабор.ToList());
            
            
        }
      
        public ActionResult IndexT(int? id)
        {
            var discusнабор = db.DiscusНабор.Where(t => t.TopicsID==id);

            ViewBag.TN = (from n in db.DiscusНабор
                          where n.TopicsID == id
                          select n.Topics.TopicName).FirstOrDefault();
            ViewBag.ID = id;
            ViewBag.disandansw = db.DiscusНабор.Join(db.AnswerНабор, p => p.ID, c => c.DiscusID, (p, c) => new { Disc = p.Text, Ans = c.Text, AVT = p.Author }).ToList();
            
            ViewBag.Answer = db.AnswerНабор.Where(t => t.DiscusID == id).ToList();
            return View(discusнабор.ToList());
        }
        //
        // GET: /Discus/Details/5
      
        public ActionResult Details(int id = 0)
        {
            Discus discus = db.DiscusНабор.Find(id);
            if (discus == null)
            {
                return HttpNotFound();
            }
            return View(discus);
        }

        //
        // GET: /Discus/Create

        public ActionResult Create(int ? id)
        {
            ViewBag.AID = WebSecurity.CurrentUserName;
          //  ViewBag.TopicsID = new SelectList(db.TopicsНабор, "ID", "TopicName");
            ViewBag.ID = id;
            return View();
        }

        //
        // POST: /Discus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Discus discus)
        {
            if (ModelState.IsValid)
            {
                db.DiscusНабор.Add(discus);
                db.SaveChanges();
                return RedirectToAction("IndexT", new { id = discus.TopicsID });
            }

            ViewBag.TopicsID = new SelectList(db.TopicsНабор, "ID", "TopicName", discus.TopicsID);
            return View(discus);
        }

        //
        // GET: /Discus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Discus discus = db.DiscusНабор.Find(id);
            if (discus == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicsID = new SelectList(db.TopicsНабор, "ID", "TopicName", discus.TopicsID);
            return View(discus);
        }

        //
        // POST: /Discus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Discus discus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicsID = new SelectList(db.TopicsНабор, "ID", "TopicName", discus.TopicsID);
            return View(discus);
        }

        //
        // GET: /Discus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Discus discus = db.DiscusНабор.Find(id);
            if (discus == null)
            {
                return HttpNotFound();
            }
            return View(discus);
        }

        //
        // POST: /Discus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discus discus = db.DiscusНабор.Find(id);
            db.DiscusНабор.Remove(discus);
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