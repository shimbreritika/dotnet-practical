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