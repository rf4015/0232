using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Serilog;

namespace MarienProject.Api.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly DbFarmaciaContext _dbFarmaciaContext;
		private readonly ILogger<EmployeeRepository> _logger; // Agregar el logger de Serilog

		public EmployeeRepository(DbFarmaciaContext dbFarmaciaContext, ILogger<EmployeeRepository> logger)
		{
			_dbFarmaciaContext = dbFarmaciaContext;
			_logger = logger;
		}
		public async Task<IEnumerable<Empleado>> GetAllEmployees()
		{
			try
			{
				var employees = await _dbFarmaciaContext.Empleados
									.Include(e => e.Rol).ToArrayAsync();
				return employees;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting all employees");
				return null;
			}
		}
		public async Task<Empleado> GetEmployeeById(int id)
		{
			try
			{
				var employee = await _dbFarmaciaContext.Empleados
									 .Include(e => e.Rol).SingleOrDefaultAsync(e => e.EmpleadoId == id);
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

		public async Task<bool> CreateEmployee(Empleado employee)
		{
			try
			{
				_dbFarmaciaContext.Empleados.Add(employee);
				await _dbFarmaciaContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred while creating the employee: ", ex.Message);
				return false;
			}
		}
		public async Task<bool> UpdateEmployeeById(Empleado updatedEmployee)
		{
			Empleado employee = await _dbFarmaciaContext.Empleados.FirstOrDefaultAsync(e => e.EmpleadoId == updatedEmployee.EmpleadoId);

			if (employee != null)
			{
				try
				{
					employee.EmpleadoNombres = updatedEmployee.EmpleadoNombres;
					employee.EmpleadoTelefono = updatedEmployee.EmpleadoTelefono;
					employee.EmpleadoDni = updatedEmployee.EmpleadoDni;
					employee.EmpleadoEstado = updatedEmployee.EmpleadoEstado;
					employee.EmpleadoCorreoElectronico = updatedEmployee.EmpleadoCorreoElectronico;
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
			var employee = await _dbFarmaciaContext.Empleados.FirstOrDefaultAsync(e => e.EmpleadoId == id);

			if (employee != null)
			{
				try
				{
					_dbFarmaciaContext.Empleados.Remove(employee);
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
