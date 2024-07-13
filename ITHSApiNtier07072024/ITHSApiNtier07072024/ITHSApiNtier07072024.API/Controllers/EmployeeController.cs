using ITHSApiNtier07072024.Entities;
using ITHSApiNtier07072024.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHSApiNtier07072024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeServices employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = employeeServices;
        }





        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployees()
        {
            var employees = employeeServices.GetAllEmployees();
            if (employees is not null)
                return Ok(employees);
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var employee = await employeeServices.GetEmployeesById(id);
            if (employee != null)
                return Ok(employee);
            else
                return NotFound(); // 404 Not Found Status Code. Herhangi bir data döndürülmeyecek.

            //return Ok(await _employeeService.GetEmployeeByID(id));
        }

        [HttpGet]
        [Route("[action]/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var employee = employeeServices.GetEmployeesByDepartment(department);
            if (employee.Count > 0)
                return Ok(employee);
            else
                return NotFound();

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = employeeServices.CreateEmployee(employee);
            return CreatedAtAction("GetEmployeeByID", new { id = createdEmployee.ID }, createdEmployee);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            return Ok(employeeServices.UpdateEmployee(employee));
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            employeeServices.DeleteEmployee(id);
            return Ok("Personel Silindi...");
        }


    }
}