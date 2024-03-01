using CodeFirstCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CodeFirstCrud.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Employee
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        public ActionResult AutoIndex()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        public ActionResult AutoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutoCreate(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Record Inserted Successfully!!')</script>";
                    //ModelState.Clear();
                    TempData["InsertMessage"] = "<script>alert('Record Inserted Successfully!!')</script>";
                    //TempData["InsertMessage"] = "Record Inserted Successfully!!";
                    return RedirectToAction("AutoIndex");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Record Not Inserted!!')</script>";
                }
            }
            return View();
        }

        public ActionResult AutoEdit(int id)
        {
            var row = db.Employees.Where(model => model.EMP_ID == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult AutoEdit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["EditMessage"] = "<script>alert('Record Updated Successfully!!')</script>";
                    return RedirectToAction("AutoIndex");
                }
                else
                {
                    ViewBag.EditMessage = "<script>alert('Record Not Updated!!')</script>";
                }
            }
            return View();
        }

        public ActionResult AutoDelete(int id)
        {
            var deleteRow = db.Employees.Where(model => model.EMP_ID == id).FirstOrDefault();
            return View(deleteRow);
        }

        [HttpPost]
        public ActionResult AutoDelete(int id, Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Remove(db.Employees.Where(model => model.EMP_ID == id).FirstOrDefault());
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Record Deleted Successfully!!')</script>";
                    return RedirectToAction("AutoIndex");
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Record Not Deleted!!')</script>";
                }
            }
            return View();
        }

        //public ActionResult AutoDelete(int id)
        //{
        //    Employee deleteRow = db.Employees.Find(id);
        //    return View(deleteRow);
        //}

        //[HttpPost, ActionName("AutoDelete")]
        //public ActionResult AutoDeleteConfirm(int deleteId)
        //{
        //    Employee emp = db.Employees.Find(deleteId);
        //    db.Employees.Remove(emp);
        //    db.SaveChanges();
        //    return RedirectToAction("AutoIndex");
        //}

        public ActionResult AutoDetails(int id)
        {
            var editRow = db.Employees.Where(model => model.EMP_ID == id).FirstOrDefault();
            return View(editRow);
        }
    }
}