using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Model;

namespace WebApiTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentAPIController : ControllerBase
	{

		private readonly List<StudentModel> students = new List<StudentModel>()
		{
			new StudentModel(1, "Haresh", "Prajapati", "haresh@gmail.com", 21, "Male"),
			new StudentModel(2, "Manav", "Patel", "manav@gmail.com", 22, "Male"),
		};

		[HttpGet]
		public object getAllStudents()
		{
			return new { error = false, status = 200, message = "success", data = students };
		}

		[HttpGet("{id}")]
		public object getStudentById(int id)
		{
			try
			{
				if (students.Any(students => students.Id == id))
				{
					return new { error = false, status = 200, message = "success", data = students.FirstOrDefault(student => student.Id == id) };
				}
				else
				{
					return new { error = false, status = 404, message = "Not found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}
}
