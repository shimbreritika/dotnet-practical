using Assignment15.Model;

namespace Assignment15.Service
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Register(Course course);
        void UpdateDuration(int id, int duration);
        void Delete(int  id);

    }
}
