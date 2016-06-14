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
    public class AnswerController : Controller
    {
        private ForumDBContainer db = new ForumDBContainer();

        //
        // GET: /Answer/

        public ActionResult Index()
        {
            var answerнабор = db.AnswerНабор.Include(a => a.Discus);
            return View(answerнабор.ToList());
        }
        public ActionResult IndexT(int? id)
        {
         //   var answerнабор = db.AnswerНабор.Where(a => a.Discus.TopicsID == id).Include(b=>b.Discus);
            var ans = db.AnswerНабор.Where(a => a.DiscusID== id);
            return View(ans.ToList());
        }
        //
        // GET: /Answer/Details/5

        public ActionResult Details(int id = 0)
        {
            Answer answer = db.AnswerНабор.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //
        // GET: /Answer/Create

        public ActionResult Create(int ? id,int ? idt)
        {
            ViewBag.AID = WebSecurity.CurrentUserName;
            ViewBag.ID = id;
            ViewBag.TOP = idt;
            ViewBag.DiscusID = new SelectList(db.DiscusНабор, "ID", "Text");
            return View();
        }

        //
        // POST: /Answer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Answer answer,int ? Topics)
        {
            if (ModelState.IsValid)
            {
                db.AnswerНабор.Add(answer);
                db.SaveChanges();
                return RedirectToAction("IndexT", "Discus", new {id= Topics });
            }

            ViewBag.DiscusID = new SelectList(db.DiscusНабор, "ID", "Text", answer.DiscusID);
            return View(answer);
        }

        //
        // GET: /Answer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Answer answer = db.AnswerНабор.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscusID = new SelectList(db.DiscusНабор, "ID", "Text", answer.DiscusID);
            return View(answer);
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscusID = new SelectList(db.DiscusНабор, "ID", "Text", answer.DiscusID);
            return View(answer);
        }

        //
        // GET: /Answer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Answer answer = db.AnswerНабор.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //
        // POST: /Answer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.AnswerНабор.Find(id);
            db.AnswerНабор.Remove(answer);
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