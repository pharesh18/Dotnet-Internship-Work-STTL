using DataAccessLayer.DataAccess;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class StudentRepository:IStudentRepository
	{
		private readonly ThreeTierArchitectureStudentDbContext _context;

		public StudentRepository(ThreeTierArchitectureStudentDbContext context)
		{
			_context = context;
		}

		public List<StudentData> GetAllStudents()
		{
			var data = _context.Students.ToList();

			var allStudents = data.Select(s => new StudentData
			{
				Id = s.Id,
				Fname = s.Fname,
				Lname = s.Lname,
				Age = s.Age,
				Email = s.Email,
				Password = s.Password,
				Gender = s.Gender,

			}).ToList();

			return allStudents;
		}

		public StudentData GetStudentById(int id)
		{
			var data = _context.Students.FirstOrDefault(s => s.Id == id);
			var studentData = new StudentData
			{
				Id = data.Id,
				Fname = data.Fname,
				Lname = data.Lname,
				Age = data.Age,
				Email = data.Email,
				Password = data.Password,
				Gender = data.Gender,
			};
			return studentData;
		}

		public bool AddNewStudent(StudentData studentData)
		{
			var student = new Models.Student
			{
				Id = studentData.Id,
				Fname = studentData.Fname,
				Lname = studentData.Lname,
				Age = studentData.Age,
				Email = studentData.Email,
				Password = studentData.Password,
				Gender = studentData.Gender,
			};

			_context.Students.Add(student);
			int result = _context.SaveChanges();
			if (result == 0)
			{
				return false;
			}
			return true;
		}

		public bool DeleteStudentById(int id)
		{
			var student = _context.Students.Find(id);
			if (student != null)
			{
				_context.Students.Remove(student);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool UpdateStudentById(StudentData studentData)
		{
			var stu = _context.Students.Find(Convert.ToInt32(studentData.Id));
			if (stu != null)
			{
				_context.Entry(stu).State = EntityState.Detached;
				var student = new Models.Student
				{
					Id = studentData.Id,
					Fname = studentData.Fname,
					Lname = studentData.Lname,
					Age = studentData.Age,
					Email = studentData.Email,
					Password = studentData.Password,
					Gender = studentData.Gender,
				};

				_context.Students.Update(student);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
