using MarienProject.Api.Extentions;
using MarienProject.Api.Repositories;
using MarienProject.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Microsoft.Data.SqlClient;
using MarienProject.Api.Repositories.Contracts;

namespace MarienProject.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly ILogger<EmployeeController> _logger;
		public EmployeeController(IEmployeeRepository empleadoRepository, ILogger<EmployeeController> logger)
		{
			_employeeRepository = empleadoRepository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
		{
			try
			{
				var employees = await _employeeRepository.GetAllEmployees();
				if (employees == null)
				{
					return NotFound();
				}
				else
				{
					var employeeDtos = employees.ConvertToDto();
					return Ok(employeeDtos);
				}
			}
			catch (SqlException ex)
			{
				_logger.LogError(ex, "Error retrieving data from the database");
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An unexpected error occurred");
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
		{
			try
			{
				var employee = await _employeeRepository.GetEmployeeById(id);
				if (employee == null)
				{
					return NotFound(id);
				}
				else
				{
					var employeeDto = employee.ConvertToDto();
					return Ok(employeeDto);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving employee data by ID");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<bool>> CreateEmployee(EmployeeDto employeeDto)
		{
			try
			{
				var employee = employeeDto.ConvertToModel();
				var createStaus = await _employeeRepository.CreateEmployee(employee);
				if (createStaus == false)
				{
					return NoContent();
				}
				else
				{
					return Ok(createStaus);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating an employee");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<bool>> DeleteEmployee(int id)
		{
			try
			{
				var deleteStatus = await _employeeRepository.DeleteEmployeeById(id);
				if (deleteStatus == false)
				{
					return NotFound();
				}
				else
				{
					return Ok(deleteStatus);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while deleting an employee");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPatch("{id:int}")]
		public async Task<ActionResult<bool>> UpdateEmployee(EmployeeDto employeeDto)
		{
			try
			{
				var employee = employeeDto.ConvertToModel();
				var updateStatus = await _employeeRepository.UpdateEmployeeById(employee);
				if (updateStatus == false)
				{
					return NotFound();
				}
				else
				{
					return Ok(updateStatus);
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating an employee");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
