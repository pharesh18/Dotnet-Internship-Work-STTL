using Microsoft.AspNetCore.Mvc;
using ThreeTierArchitectureUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace ThreeTierArchitectureUI.Controllers
{
	public class StudentController : Controller
	{
		Uri baseAddress = new Uri("http://localhost:5148/api/Student");
		private readonly HttpClient _client;

		public StudentController()
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
		}

        [HttpGet]
        public IActionResult Index()
		{
			List<StudentModel> studentList = new List<StudentModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				studentList = JsonConvert.DeserializeObject<List<StudentModel>>(data);
			}
			return View(studentList);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(StudentModel model)
		{
			try
			{
				string data = JsonConvert.SerializeObject(model);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					TempData["error"] = "Something Went Wrong, Please try again!!";
					return RedirectToAction("Error", "Student");
				}
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			StudentModel student = new StudentModel();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				student = JsonConvert.DeserializeObject<StudentModel>(data);
			}
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(StudentModel model)
		{
			try
			{
				string data = JsonConvert.SerializeObject(model);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = _client.PutAsync(_client.BaseAddress, content).Result;

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					TempData["error"] = "Something Went Wrong, Please try again!!";
					return RedirectToAction("Error", "Student");
				}
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			try
			{
				StudentModel student = new StudentModel();
				HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

				if (response.IsSuccessStatusCode)
				{
					string data = response.Content.ReadAsStringAsync().Result;
					student = JsonConvert.DeserializeObject<StudentModel>(data);
				}
				return View(student);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirm(int id)
		{
			try
			{
				HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "?id=" + id).Result;

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Student");
				}
				else
				{
					TempData["error"] = "Something Went Wrong, Please try again!!";
					return RedirectToAction("Error", "Student");
				}
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("Error", "Student");
			}
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			StudentModel student = new StudentModel();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				student = JsonConvert.DeserializeObject<StudentModel>(data);
			}
			return View(student);
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
