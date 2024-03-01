using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
	public interface IStudentService
	{
		List<StudentData> GetAllStudents();
		StudentData GetStudentById(int id);
		bool AddNewStudent(StudentData studentData);
		bool DeleteStudentById(int id);
		bool UpdateStudentById(StudentData studentData);
	}
}
