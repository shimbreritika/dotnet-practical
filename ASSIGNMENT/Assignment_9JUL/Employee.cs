using System;

abstract class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int LeaveBalance { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine("Employee ID : " + EmployeeId);
        Console.WriteLine("Name        : " + Name);
        Console.WriteLine("Department  : " + Department);
        Console.WriteLine("Leave Days  : " + LeaveBalance);
        Console.WriteLine("----------------------------");
    }

    public abstract void SetLeaveBalance();
}