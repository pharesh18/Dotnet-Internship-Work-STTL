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
    public class StudentController : Controller
    {
        private QuestionSystemEntities db = new QuestionSystemEntities();

        // GET: Student
        public ActionResult Index()
        {
            var userData = (QuestionPaperDataFirstApp.Models.User)Session["UserData"];
            var student = db.Users.Where(q => q.id == userData.id).ToList();
            return View(student);
        }

        public ActionResult StudentDashboard()
        {
            return RedirectToAction("Index", "QuestionsPapers");
        }

        public ActionResult Exam(int id)
        {
            var que = db.QuestionsPapers.Where(x => x.paperId == id).SingleOrDefault();
            ViewBag.title = que.title;
            ViewBag.description = que.description;
            ViewBag.totalQuestions = que.noOfQuestions;
            Session["pId"] = id;
            var data = db.Questions.Where(x => x.paperId == id).ToList();
            return View(data);
        }

        public ActionResult Score(string score)
        {
            var userData = (QuestionPaperDataFirstApp.Models.User)Session["UserData"];
            int pId = Convert.ToInt32(Session["pId"]);
            ViewBag.Score = Convert.ToInt32(score) - 138;
            var newAnswer = new Answer
            {
                paperId = pId,
                userId = Convert.ToInt32(userData.id),
                score = Convert.ToInt32(score) - 138
            };
            db.Answers.Add(newAnswer);
            db.SaveChanges();
            return View();
        }

        public ActionResult ExamHistory()
        {
            var userData = (QuestionPaperDataFirstApp.Models.User)Session["UserData"];
            var data = db.Answers.Where(x => x.userId == userData.id).ToList();
            return View(data);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,password,role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,password,role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
