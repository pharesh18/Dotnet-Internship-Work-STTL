using Core_CRUD_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_CRUD_App.Repository
{
	public class StudentRepository : IStudentRepository
	{
		private readonly CoreCrudAppContext _context;
		public StudentRepository(CoreCrudAppContext context)
		{
			_context = context;
		}
		public List<Student> GetAllStudents()
		{
			return _context.Students.ToList();
		}

		public Student GetStudentById(int id)
		{
			var data = _context.Students.Find(id);
			if (data == null)
			{
				throw new Exception();
			}
			else
			{
				return data;
			}
		}

		public bool DeleteStudentById(int id)
		{
			var student = _context.Students.Find(id);
			if (student == null)
			{
				throw new Exception();
			}
			else
			{
				_context.Students.Remove(student);
				_context.SaveChanges();
				return true;
			}
		}

		public bool CreateNewStudent(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return true;
		}

		public bool UpdateStudentDetails(Student student)
		{
			//var result = _context.Students.Find(student.Id);
			//if(result == null)
			//{
			//	throw new Exception();
			//}
			//else
			//{
			_context.Students.Update(student);
			_context.SaveChanges();
			return true;
			//}
		}
	}
}