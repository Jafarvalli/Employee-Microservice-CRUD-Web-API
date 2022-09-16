using EmployeeCRUDWebAPI.Model_Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCRUDWebAPI.Reposistory
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> InsertEmployee(Employee objEmployee);
        Task<Employee> UpdateEmployee(Employee objEmployee);
        bool DeleteEmployee(int ID);
    }
}
