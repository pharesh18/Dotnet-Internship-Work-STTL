using QuestionPaperDataFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionPaperDataFirstApp.Controllers
{
    public class HomeController : Controller
    {
        private QuestionSystemEntities db = new QuestionSystemEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = db.Users.FirstOrDefault(usr => usr.email == model.Username && usr.password == model.Password);
            if (user != null)
            {
                //Session["UserRole"] = Convert.ToString(user.role);
                Session["UserData"] = user;
                if (user.role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.role == "teacher")
                {
                    return RedirectToAction("TeacherDashboard", "Teacher");
                }
                else
                {
                    return RedirectToAction("StudentDashboard", "Student");
                }
            }
            else
            {
                if (model.Username == null)
                {
                    TempData["AlertMessage"] = "<script>alert('Username is required!!')</script>";
                }
                else if (model.Password == null)
                {
                    TempData["AlertMessage"] = "<script>alert('Password is required!!')</script>";
                }
                else
                {
                    TempData["AlertMessage"] = "<script>alert('Wrong Email or Password!!')</script>";
                }
                return Login();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}