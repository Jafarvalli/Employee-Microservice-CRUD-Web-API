using EmployeeCRUDWebAPI.Model_Entities;
using EmployeeCRUDWebAPI.Reposistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeCRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentReposistory _department;
        public DepartmentController(IDepartmentReposistory department)
        {
            _department = department;
        }
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _department.GetDepartment());
        }
        [HttpGet]
        [Route("GetDepartmentByID/{ID}")]
        public async Task<IActionResult> GetDeptById(int ID)
        {
            return Ok(await _department.GetDepartmentByID(ID));
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(Department dep)
        {
            var result=await _department.InsertDepartment(dep);
            if (result.DepartmentID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Department Added Successfully");
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult>Put(Department dep)
        {
            await _department.UpdateDepartment(dep);
            return Ok("Department Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{ID}")]
        [Route("DeleteDepartment")]
        public JsonResult Delete(int ID)
        {
            _department.DeleteDepartment(ID);
            return new JsonResult("Department Deleted Successfully");
        }


    }
}
