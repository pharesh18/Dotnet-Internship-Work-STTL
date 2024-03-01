using BusinessLogicLayer.Interface;
using DataAccessLayer.DataAccess;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
	public class StudentService:IStudentService
	{
		private readonly IStudentRepository _studentRepository;

		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public List<StudentData> GetAllStudents()
		{
			return _studentRepository.GetAllStudents();
		}

		public StudentData GetStudentById(int id)
		{
			return _studentRepository.GetStudentById(id);
		}

		public bool AddNewStudent(StudentData studentData)
		{
			return _studentRepository.AddNewStudent(studentData);
		}

		public bool DeleteStudentById(int id)
		{
			return _studentRepository.DeleteStudentById(id);
		}

		public bool UpdateStudentById(StudentData studentData)
		{
			return _studentRepository.UpdateStudentById(studentData);
		}
	}
}
