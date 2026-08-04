using Assignment17.Model;

namespace Assignment17.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee? GetEmployee(int id);

        void AddEmployee(Employee employee);

        Employee? UpdateEmployee(int id, Employee employee);

        bool DeleteEmployee(int id);

        List<Employee> SearchByName(string name);

        List<Employee> SearchByDepartment(int departmentId);

        Employee? SearchByEmail(string email);

        List<Employee> SearchByStatus(string status);

    }
}
