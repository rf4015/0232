using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Serilog;

namespace MarienProject.Api.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly MarienPharmacyContext _dbFarmaciaContext;
		private readonly ILogger<EmployeeRepository> _logger; // Agregar el logger de Serilog

		public EmployeeRepository(MarienPharmacyContext dbFarmaciaContext, ILogger<EmployeeRepository> logger)
		{
			_dbFarmaciaContext = dbFarmaciaContext;
			_logger = logger;
		}
		public async Task<IEnumerable<Employee>> GetAllEmployees()
		{
			try
			{
				var employees = await _dbFarmaciaContext.Employees
									.Include(e => e.Role)
									.Include(e =>e.User).ToArrayAsync();
				return employees;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting all employees");
				return null;
			}
		}
		public async Task<Employee> GetEmployeeById(int id)
		{
			try
			{
				var employee = await _dbFarmaciaContext.Employees
									 .Include(e => e.Role).SingleOrDefaultAsync(e => e.Id == id);
				if (employee == null)
				{
					throw new Exception("Employee not found");
				}

				return employee;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting the employee by ID");
				return null;
			}
		}

		public async Task<bool> CreateEmployee(Employee employee)
		{
			try
			{
				_dbFarmaciaContext.Employees.Add(employee);
				await _dbFarmaciaContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred while creating the employee: ", ex.Message);
				return false;
			}
		}
		public async Task<bool> UpdateEmployeeById(Employee updatedEmployee)
		{
			Employee employee = await _dbFarmaciaContext.Employees.FirstOrDefaultAsync(e => e.Id == updatedEmployee.Id);

			if (employee != null)
			{
				try
				{
					employee.FirstNames = updatedEmployee.FirstNames;
					employee.LastNames = updatedEmployee.LastNames;
					employee.Phone = updatedEmployee.Phone;
					employee.Dni = updatedEmployee.Dni;
					employee.State = updatedEmployee.State;
					employee.EmailAddress = updatedEmployee.EmailAddress;
					//If we need other special method to update:(Password, Username or Rol)!!

					_dbFarmaciaContext.Entry(employee).State = EntityState.Modified; // Marcar la entidad como modificada
					await _dbFarmaciaContext.SaveChangesAsync();

					return true;
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while updating the employee by Id");
					return false;
				}
			}
			return false;
		}
		public async Task<bool> DeleteEmployeeById(int id)
		{
			var employee = await _dbFarmaciaContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

			if (employee != null)
			{
				try
				{
					_dbFarmaciaContext.Employees.Remove(employee);
					await _dbFarmaciaContext.SaveChangesAsync();
					return true;
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while deleting the employee by Id");
					return false;
				}
			}
			return false;
		}
	}
}
