using Assignment17.Model;

namespace Assignment17.Service
{
    public interface IDepartmentService
    {

        List<Department> GetDepartments();

        Department? GetDepartment(int id);

        void AddDepartment(Department department);

        Department? UpdateDepartment(int id, Department department);

        bool DeleteDepartment(int id);

    }
}
