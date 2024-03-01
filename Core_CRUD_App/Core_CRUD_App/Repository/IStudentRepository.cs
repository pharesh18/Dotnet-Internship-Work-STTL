using Core_CRUD_App.Models;

namespace Core_CRUD_App.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        bool DeleteStudentById(int id);
        bool CreateNewStudent(Student student);
        bool UpdateStudentDetails(Student student);
    }
}
