using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        ToDoItemContext db = new ToDoItemContext();
        public ActionResult Index()
        {
            var data = db.ToDoItems.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoItem td)
        {
            if (ModelState.IsValid == true)
            {
                db.ToDoItems.Add(td);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Task Added!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Task not added!!')</script>";
                }
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var row = db.ToDoItems.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(ToDoItem e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["EditMessage"] = "<script>alert('Task Updated Successfully!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.EditMessage = "<script>alert('Task Not Updated!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var deleteRow = db.ToDoItems.Where(model => model.Id == id).FirstOrDefault();
            return View(deleteRow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, ToDoItem e)
        {
            db.ToDoItems.Remove(db.ToDoItems.Where(model => model.Id == id).FirstOrDefault());
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Task Deleted Successfully!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Task Not Deleted!!')</script>";
            }
            return View();
        }

        public ActionResult Complete()
        {
            var completedTasks = db.ToDoItems.Where(model => model.IsCompleted == true).ToList();
            return View(completedTasks);
        }

        public ActionResult Incomplete()
        {
            var completedTasks = db.ToDoItems.Where(model => model.IsCompleted == false).ToList(); ;
            return View(completedTasks);
        }
    }
}