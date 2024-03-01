using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionPaperDataFirstApp.Models;

namespace QuestionPaperDataFirstApp.Controllers
{
    public class QuestionsController : Controller
    {
        private QuestionSystemEntities db = new QuestionSystemEntities();

        // GET: Questions
        public ActionResult Index(int id, int? quiz)
        {
            //var questions = db.Questions.Include(q => q.QuestionsPaper);
            var questions = db.Questions.Where(q => q.paperId == id);
            Session["paperId"] = id;
            Session["quiz"] = quiz;
            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Create()
        {
            ViewBag.paperId = new SelectList(db.QuestionsPapers, "paperId", "title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "queId,question1,opt1,opt2,opt3,opt4,answer,paperId")] Question question)
        {
            if (ModelState.IsValid)
            {
                //int id = Convert.ToInt32(question.paperId);
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index", "Questions", new { id = Session["paperId"] });
            }

            ViewBag.paperId = new SelectList(db.QuestionsPapers, "paperId", "title", question.paperId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            //ViewBag.paperId = paperId;
            ViewBag.paperId = new SelectList(db.QuestionsPapers, "paperId", "title", question.paperId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "queId,question1,opt1,opt2,opt3,opt4,answer,paperId")] Question question)
        {
            if (ModelState.IsValid)
            {
                //int id = Convert.ToInt32(question.paperId);
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Questions", new { id = Session["paperId"] });
            }
            ViewBag.paperId = new SelectList(db.QuestionsPapers, "paperId", "title", question.paperId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            //ViewBag.paperId = paperId;
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            //int paperId = Convert.ToInt32(question.paperId);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index", "Questions", new { id = Session["paperId"] });
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
