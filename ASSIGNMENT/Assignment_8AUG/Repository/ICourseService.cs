using Assignment19.Model;

namespace Assignment19.Repository
{
    public interface ICourseService
    {
        Course GetCourse();

        Course AddCourse(Course course);

        Course UpdateCourse(int id ,Course course);

        Course DeleteCourse(Course course);


    }
}
