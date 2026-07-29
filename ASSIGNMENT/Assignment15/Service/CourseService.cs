using Assignment15.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assignment15.Service
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course{Id=101, Title ="C#" ,Credits= 4,Duration=30},
            new Course{Id=102, Title ="Power BI" ,Credits= 6,Duration=65},
            new Course{Id=103, Title ="Python" ,Credits= 5,Duration=34},
            new Course{Id=104, Title ="JAVA" ,Credits= 4,Duration=90}
        };

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course GetById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public void Register(Course course)
        {
            courses.Add(course);
        }

        public void UpdateDuration(int id, int duration)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                course.Duration = duration;
            }
        }

        public void Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                courses.Remove(course);
            }
        }

    }
}
