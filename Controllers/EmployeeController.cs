using EmployeeCRUDWebAPI.Model_Entities;
using EmployeeCRUDWebAPI.Reposistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeCRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        private readonly IDepartmentReposistory _department;
        public EmployeeController(IEmployeeRepository employee, IDepartmentReposistory department)
        {
            _employee = employee;
            _department = department;
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetEmployees());
        }
        [HttpGet]
        [Route("GetEmployeeByID/{ID}")]
        public async Task<IActionResult>GetEmpByID(int ID)
        {
            return Ok(await _employee.GetEmployeeByID(ID));
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult>Post(Employee emp)
        {
            var result=await _employee.InsertEmployee(emp);
            if (result.EmployeeID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Employee Added Successfully");
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult>Put(Employee emp)
        {
            await _employee.UpdateEmployee(emp);
            return Ok("Employee Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        //[HttpDelete("{ID}")]
        public JsonResult Delete(int ID)
        {
            var resuly=_employee.DeleteEmployee(ID);
            return new JsonResult("Employee Deleted Successfully");
        }
    }
}
