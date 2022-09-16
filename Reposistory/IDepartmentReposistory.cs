using EmployeeCRUDWebAPI.Model_Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCRUDWebAPI.Reposistory
{
    public interface IDepartmentReposistory
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartmentByID(int ID);
        Task<Department>InsertDepartment(Department objDepartment);
        Task<Department> UpdateDepartment(Department objDepartment);
        bool DeleteDepartment(int ID);
    }
}
