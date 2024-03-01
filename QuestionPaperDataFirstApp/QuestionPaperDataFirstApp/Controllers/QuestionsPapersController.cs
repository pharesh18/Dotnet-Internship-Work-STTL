using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionPaperDataFirstApp.Models;

namespace QuestionPaperDataFirstApp.Controllers
{
    public class QuestionsPapersController : Controller
    {
        private QuestionSystemEntities db = new QuestionSystemEntities();

        // GET: QuestionsPapers
        public ActionResult Index()
        {
            var userData = (QuestionPaperDataFirstApp.Models.User)Session["UserData"];
            if(Convert.ToString(userData.role) == "admin")
            {
                var questionPapers = db.QuestionsPapers.ToList();
                return View(questionPapers);
            }
            else if(Convert.ToString(userData.role) == "teacher")
            {
                int tchrid = userData.id;
                var questionPapers = db.QuestionsPapers.Where(q => q.userId == userData.id).ToList();
                return View(questionPapers);
            }else if (Convert.ToString(userData.role) == "student")
            {
                var questionPapers = db.QuestionsPapers.Where(q => q.status == "approved").ToList();
                return View(questionPapers);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: QuestionsPapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsPaper questionsPaper = db.QuestionsPapers.Find(id);
            if (questionsPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionsPaper);
        }

        // GET: QuestionsPapers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paperId,title,description,noOfQuestions,status,creation_date,userId")] QuestionsPaper questionsPaper)
        {
            if (ModelState.IsValid)
            {
                db.QuestionsPapers.Add(questionsPaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionsPaper);
        }

        // GET: QuestionsPapers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsPaper questionsPaper = db.QuestionsPapers.Find(id);
            if (questionsPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionsPaper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paperId,title,description,noOfQuestions,status,creation_date,userId")] QuestionsPaper questionsPaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionsPaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionsPaper);
        }

        // GET: QuestionsPapers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionsPaper questionsPaper = db.QuestionsPapers.Find(id);
            if (questionsPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionsPaper);
        }

        // POST: QuestionsPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionsPaper questionsPaper = db.QuestionsPapers.Find(id);
            db.QuestionsPapers.Remove(questionsPaper);
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
