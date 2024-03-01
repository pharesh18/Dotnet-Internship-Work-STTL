using StudentsWebApi.Data_Access;

namespace StudentsWebApi.Interface
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
