using DataAccessLayer.DataAccess;
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThreeTierArchitecture.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public List<StudentData> GetAllStudentData()
		{
			return _studentService.GetAllStudents();
		}

		[HttpGet("{id}")]
		public StudentData GetStudentDataById(int id)
		{
			return _studentService.GetStudentById(id);
		}

		[HttpPost]
		public object AddNewStudent(StudentData studentData)
		{
			try
			{
				bool result = _studentService.AddNewStudent(studentData);
				if (result)
				{
					return new { error = false, status = 200, message = "Student Inserted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 200, message = "Student Not Inserted" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpDelete]
		public object DeleteStudentById(int id)
		{
			try
			{
				bool result = _studentService.DeleteStudentById(id);
				if (result)
				{
					return new { error = false, status = 200, message = "Student Deleted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Student Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpPut]
		public object UpdateStudentById(StudentData studentData)
		{
			try
			{
				bool result = _studentService.UpdateStudentById(studentData);
				if (result)
				{
					return new { error = false, status = 200, message = "Student Updated Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Student Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}
}