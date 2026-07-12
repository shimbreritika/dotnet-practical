using System;
using System.Collections.Generic;
using System.Linq;

abstract class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Department { get; set; }

    public List<Course> EnrolledCourses = new List<Course>();

    public abstract double CalculateFee();

    public int TotalCredits()
    {
        return EnrolledCourses.Sum(c => c.Credits);
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Student ID : " + StudentId);
        Console.WriteLine("Name       : " + StudentName);
        Console.WriteLine("Department : " + Department);
        Console.WriteLine("Type       : " + GetType().Name);

        Console.WriteLine("Courses :");

        if (EnrolledCourses.Count == 0)
        {
            Console.WriteLine("No Courses Registered");
        }
        else
        {
            foreach (Course c in EnrolledCourses)
            {
                Console.WriteLine(c.CourseId + " - " + c.CourseName + " (" + c.Credits + " Credits)");
            }
        }

        Console.WriteLine("Total Credits : " + TotalCredits());
        Console.WriteLine("Total Fee     : " + CalculateFee());
        Console.WriteLine("--------------------------------");
    }
}

class RegularStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 1000;
    }
}

class ScholarshipStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 500;
    }
}

class PartTimeStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 800;
    }
}

class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }
}

class Program
{
    static List<Student> students = new List<Student>();
    static List<Course> courses = new List<Course>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== STUDENT COURSE MANAGEMENT =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("5. View Courses");
            Console.WriteLine("6. Register Course");
            Console.WriteLine("7. Display Student Details");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    SearchStudent();
                    break;

                case 4:
                    AddCourse();
                    break;

                case 5:
                    ViewCourses();
                    break;

                case 6:
                    RegisterCourse();
                    break;

                case 7:
                    DisplayStudent();
                    break;

                case 8:
                    Console.WriteLine("Thank You...");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void RegisterStudent()
    {
        Console.Write("Student ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (students.Any(s => s.StudentId == id))
        {
            Console.WriteLine("Student ID already exists.");
            return;
        }

        Console.Write("Student Name : ");
        string name = Console.ReadLine();

        Console.Write("Department : ");
        string dept = Console.ReadLine();

        Console.WriteLine("1.Regular");
        Console.WriteLine("2.Scholarship");
        Console.WriteLine("3.PartTime");

        Console.Write("Choose Type : ");
        int type = Convert.ToInt32(Console.ReadLine());

        Student s;

        if (type == 1)
            s = new RegularStudent();
        else if (type == 2)
            s = new ScholarshipStudent();
        else
            s = new PartTimeStudent();

        s.StudentId = id;
        s.StudentName = name;
        s.Department = dept;

        students.Add(s);

        Console.WriteLine("Student Registered Successfully.");
    }

    static void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No Students.");
            return;
        }

        foreach (Student s in students)
        {
            Console.WriteLine(s.StudentId + " - " + s.StudentName);
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID : ");

        int id = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == id);

        if (s == null)
        {
            Console.WriteLine("Student Not Found.");
        }
        else
        {
            s.Display();
        }
    }

    static void AddCourse()
    {
        Console.Write("Course ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (courses.Any(c => c.CourseId == id))
        {
            Console.WriteLine("Course ID already exists.");
            return;
        }

        Console.Write("Course Name : ");
        string name = Console.ReadLine();

        Console.Write("Credits : ");
        int credits = Convert.ToInt32(Console.ReadLine());

        courses.Add(new Course()
        {
            CourseId = id,
            CourseName = name,
            Credits = credits
        });

        Console.WriteLine("Course Added.");
    }

    static void ViewCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No Courses.");
            return;
        }

        foreach (Course c in courses)
        {
            Console.WriteLine(c.CourseId + " " + c.CourseName + " Credits : " + c.Credits);
        }
    }

    static void RegisterCourse()
    {
        Console.Write("Student ID : ");
        int sid = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == sid);

        if (s == null)
        {
            Console.WriteLine("Student Not Found.");
            return;
        }

        if (s.EnrolledCourses.Count >= 5)
        {
            Console.WriteLine("Maximum 5 Courses Allowed.");
            return;
        }

        Console.Write("Course ID : ");
        int cid = Convert.ToInt32(Console.ReadLine());

        Course c = courses.Find(x => x.CourseId == cid);

        if (c == null)
        {
            Console.WriteLine("Course Not Found.");
            return;
        }

        if (s.EnrolledCourses.Any(x => x.CourseId == cid))
        {
            Console.WriteLine("Course Already Registered.");
            return;
        }

        s.EnrolledCourses.Add(c);

        Console.WriteLine("Course Registered Successfully.");
    }

    static void DisplayStudent()
    {
        Console.Write("Student ID : ");

        int id = Convert.ToInt32(Console.ReadLine());

        Student s = students.Find(x => x.StudentId == id);

        if (s == null)
        {
            Console.WriteLine("Student Not Found.");
            return;
        }

        s.Display();
    }
}