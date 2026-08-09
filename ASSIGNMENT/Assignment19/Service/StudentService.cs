using Assignment19.Data;
using Assignment19.Model;
using Assignment19.Repository;

namespace Assignment19.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Student> GetStudent()
        {
            return context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public Student AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

            return student;
        }

        public Student UpdateStudent(int id, Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();

            return student;
        }

        public Student DeleteStudent(int id)
        {
            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }

            return student;
        }
    }
}