using Assignment17.Model;

namespace Assignment17.Service
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Rahul",
                LastName = "Sharma",
                Email = "rahul@gmail.com",
                MobileNumber = "9876543210",
                DateOfBirth = new DateTime(2000, 5, 10),
                Gender = "Male",
                Salary = 25000,
                DateOfJoining = new DateTime(2024, 1, 15),
                DepartmentId = 1,
                Designation = "Developer",
                Status = "Active"
            },

            new Employee
            {
                EmployeeId = 2,
                FirstName = "Priya",
                LastName = "Patil",
                Email = "priya@gmail.com",
                MobileNumber = "9876543211",
                DateOfBirth = new DateTime(2001, 3, 15),
                Gender = "Female",
                Salary = 30000,
                DateOfJoining = new DateTime(2024, 2, 20),
                DepartmentId = 2,
                Designation = "HR Executive",
                Status = "Active"
            }
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee? GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee? UpdateEmployee(int id, Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                emp.MobileNumber = employee.MobileNumber;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Gender = employee.Gender;
                emp.Salary = employee.Salary;
                emp.DateOfJoining = employee.DateOfJoining;
                emp.DepartmentId = employee.DepartmentId;
                emp.Designation = employee.Designation;
                emp.Status = employee.Status;
            }

            return emp;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp == null)
            {
                return false;
            }

            employees.Remove(emp);
            return true;
        }

        public List<Employee> SearchByName(string name)
        {
            return employees.Where(e =>
                e.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                e.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Employee> SearchByDepartment(int departmentId)
        {
            return employees.Where(e => e.DepartmentId == departmentId).ToList();
        }

        public Employee? SearchByEmail(string email)
        {
            return employees.FirstOrDefault(e =>
                e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public List<Employee> SearchByStatus(string status)
        {
            return employees.Where(e =>
                e.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}



