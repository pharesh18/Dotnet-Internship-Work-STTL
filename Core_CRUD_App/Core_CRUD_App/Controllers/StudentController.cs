using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_CRUD_App.Models;
using Core_CRUD_App.Repository;

namespace Core_CRUD_App.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentRepository _studentRepository;
		public StudentController(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public IActionResult Index()
		{
			return View(_studentRepository.GetAllStudents());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			try
			{
				if (ModelState.IsValid == true && _studentRepository.CreateNewStudent(student))
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					return RedirectToAction("Error", "Student");
				}
			}catch(Exception ex) {
				return RedirectToAction("Error", "Student");
			}
		}

		public IActionResult Edit(int id)
		{
			try
			{
				var data = _studentRepository.GetStudentById(Convert.ToInt32(id));
				return View(data);
			}
			catch(Exception ex)
			{
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			try
			{
				bool result = _studentRepository.UpdateStudentDetails(student);
				if (result == true)
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					return RedirectToAction("Error", "Student");
				}
			}catch(Exception ex)
			{
				return RedirectToAction("Error", "Student");
			}
		}

		public IActionResult Delete(int id)
		{
			try
			{
				var data = _studentRepository.GetStudentById(Convert.ToInt32(id));
				return View(data);
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirm(int id)
		{
			try
			{
				var res = _studentRepository.DeleteStudentById(Convert.ToInt32(id));
				if (res == true)
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					return RedirectToAction("Error", "Student");
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Student");
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				var data = _studentRepository.GetStudentById(Convert.ToInt32(id));
				return View(data);
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Student");
			}
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
