using Assignment18.Data;
using Assignment18.Model;
using Assignment18.Respository;

namespace Assignment18.Service
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext context;

        public CourseService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = context.Courses.Find(id);

            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course? GetCourse(int id)
        {
            return context.Courses.Find(id);
        }

        public void UpdateCourse(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }
    }
}
