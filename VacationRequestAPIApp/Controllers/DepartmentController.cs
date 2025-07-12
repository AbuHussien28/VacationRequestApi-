using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationRequestAPIApp.DTOs.Department;
using VacationRequestAPIApp.Interfaces;

namespace VacationRequestAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        [EndpointSummary("Get all departments")]
        [EndpointDescription("Retrieves a list of all departments in the system.")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await departmentService.GetAllDepartment();
            return Ok(departments);
        }
        [HttpPost]
        [EndpointSummary("Create a new department")]
        [EndpointDescription("Creates a new department in the system with validation for required fields.")]
        public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await departmentService.AddDepartmentToSystem(departmentCreateDto);
            return Ok("Department created successfully");
        }
        [HttpPut]
        [EndpointSummary("Update an existing department")]
        [EndpointDescription("Updates an existing department's details in the system with validation for required fields.")]
        public async Task<IActionResult> Update(DepartmentUpdateDto departmentUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await departmentService.UpdateDepartment(departmentUpdateDto);
            return Ok("Department updated successfully");
        }
        [HttpDelete("{id}")]
        [EndpointSummary("Delete a department")]
        [EndpointDescription("Deletes a department from the system by its ID with validation for valid ID.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid department ID");
            await departmentService.DeleteDepartment(id);
            return Ok("Department deleted successfully");
        }
    }
}
