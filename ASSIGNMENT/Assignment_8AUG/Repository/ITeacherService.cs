using Assignment19.Model;

namespace Assignment19.Repository
{
    public interface ITeacherService
    {
        List<Teacher> GetTeacher();

        Teacher GetTeacherById(int id);

        void UpdateTeacher(int id ,Teacher teacher);

        void  DeleteTeacher(int id);
    }
}
