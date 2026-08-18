using Assignment18.Model;

namespace Assignment18.Respository
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course? GetCourse(int id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);
   
}
}
