using DataAccessLayer.DataAccess;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
	public interface IStudentRepository
	{
		List<StudentData> GetAllStudents();
		StudentData GetStudentById(int id);
		bool AddNewStudent(StudentData studentData);
		bool DeleteStudentById(int id);
		bool UpdateStudentById(StudentData studentData);
	}
}
