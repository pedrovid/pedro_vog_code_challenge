using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VogCodeChallenge.API.Errors;
using VogCodeChallenge.API.Models;
using VogCodeChallenge.API.UnitOfWork.Interfaces;

namespace VogCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUoW _unitOfWork;
        public EmployeeController(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Employee> ListAll()
        {
            return _unitOfWork.Employees.ListAll();
        }

        [HttpGet("department/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public IActionResult GetEmployeesForDepartment(int id)
        {
            Department department = _unitOfWork.Departments.GetById(id);

            if(department == null)
            {
                return NotFound(new ErrorResponse("There is no department with such ID"));
            }

            return Ok(_unitOfWork.Departments.GetById(id).Employees);
        }
    }
}
