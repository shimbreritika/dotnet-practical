using Assignment17.Model;

namespace Assignment17.Service
{
    public class DepartmentService : IDepartmentService
    {
        private static List<Department> departments = new List<Department>()
        {
            new Department { Id = 1, Name = "HR", Code = "HR01", Status = "Active" },
            new Department { Id = 2, Name = "IT", Code = "IT01", Status = "Active" },
            new Department { Id = 3, Name = "Finance", Code = "FIN01", Status = "Active" },
            new Department { Id = 4, Name = "Sales", Code = "SAL01", Status = "Inactive" }
        };

        public List<Department> GetDepartments()
        {
            return departments;
        }

        public Department? GetDepartment(int id)
        {
            return departments.FirstOrDefault(d => d.Id == id);
        }

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public Department? UpdateDepartment(int id, Department department)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);

            if (dept != null)
            {
                dept.Name = department.Name;
                dept.Code = department.Code;
                dept.Status = department.Status;
            }

            return dept;
        }

        public bool DeleteDepartment(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);

            if (dept == null)
            {
                return false;
            }

            departments.Remove(dept);
            return true;


        }
    }
}
