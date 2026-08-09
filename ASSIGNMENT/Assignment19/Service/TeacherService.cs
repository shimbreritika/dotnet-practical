using Assignment19.Data;
using Assignment19.Model;
using Assignment19.Repository;

namespace Assignment19.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext context;

        public TeacherService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Teacher> GetTeacher()
        {
            return context.Teachers.ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            return context.Teachers.Find(id);
        }

        public void AddTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void UpdateTeacher(int id, Teacher teacher)
        {
            var existingTeacher = context.Teachers.Find(id);

            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Email = teacher.Email;

                context.SaveChanges();
            }
        }

        public void DeleteTeacher(int id)
        {
            var teacher = context.Teachers.Find(id);

            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }
    }
}