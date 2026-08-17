using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Task 1
        List<Employee> employees = new List<Employee>();

        PermanentEmployee e1 = new PermanentEmployee
        {
            EmployeeId = 101,
            Name = "Rohan",
            Department = "HR"
        };
        e1.SetLeaveBalance();

        ContractEmployee e2 = new ContractEmployee
        {
            EmployeeId = 102,
            Name = "Priya",
            Department = "IT"
        };
        e2.SetLeaveBalance();

        PermanentEmployee e3 = new PermanentEmployee
        {
            EmployeeId = 103,
            Name = "Amit",
            Department = "Finance"
        };
        e3.SetLeaveBalance();

        ContractEmployee e4 = new ContractEmployee
        {
            EmployeeId = 104,
            Name = "Neha",
            Department = "Sales"
        };
        e4.SetLeaveBalance();

        employees.Add(e1);
        employees.Add(e2);
        employees.Add(e3);
        employees.Add(e4);


        // Task 2
        Console.WriteLine("===== ALL EMPLOYEE DETAILS =====");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }


        // Task 3
        List<LeaveRequest> leaveRequests = new List<LeaveRequest>();

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 1,
            EmployeeId = 101,
            NumberOfDays = 3,
            Reason = "Medical"
        });

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 2,
            EmployeeId = 103,
            NumberOfDays = 5,
            Reason = "Vacation"
        });

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 3,
            EmployeeId = 104,
            NumberOfDays = 2,
            Reason = "Personal"
        });


        // Task 4
        Console.WriteLine("\n===== LEAVE REQUESTS =====");

        foreach (LeaveRequest leave in leaveRequests)
        {
            leave.DisplayLeave();
        }


        // Task 5
        Console.WriteLine("\n===== PERMANENT EMPLOYEES =====");

        foreach (Employee emp in employees)
        {
            if (emp is PermanentEmployee)
            {
                emp.DisplayDetails();
            }
        }


        // Task 6
        Console.WriteLine("\n===== EMPLOYEE WITH ID 103 =====");

        foreach (Employee emp in employees)
        {
            if (emp.EmployeeId == 103)
            {
                emp.DisplayDetails();
                break;
            }
        }


        // Task 7
        Console.WriteLine("Total Employees : " + employees.Count);


        // Task 8
        Console.WriteLine("Total Leave Requests : " + leaveRequests.Count);
    }
}
