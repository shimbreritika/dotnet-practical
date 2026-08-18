using Assignment19.Data;
using Assignment19.Model;
using Assignment19.Repository;

namespace Assignment19.Service
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext context;

        public CourseService(AppDbContext context)
        {
            this.context = context;
        }

        public Course GetCourse()
        {
            return context.Courses.FirstOrDefault();
        }

        public Course AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();

            return course;
        }

        public Course UpdateCourse(int id ,Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();

            return course;
        }

        public Course DeleteCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();

            return course;
        }
    }
}