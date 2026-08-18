using Assignment19.Model;

namespace Assignment19.Repository
{
    public interface IStudentService
    {

        List<Student> GetStudent();

        Student GetStudentById(int id);

        Student AddStudent(Student student);

        Student UpdateStudent(int id ,Student student);

        Student DeleteStudent(int id);
    }
}
