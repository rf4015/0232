using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Serilog;
using Microsoft.Data.SqlClient;
using System.Data.Entity.Validation;

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
									 .Include(i => i.User)
									 .Include(e => e.Role)
									 .SingleOrDefaultAsync(i => i.Id == id);

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
		public async Task<bool> CreateEmployee(Employee employee, UserProfile userProfile)
		{
			using (var transaction = _dbFarmaciaContext.Database.BeginTransaction())
			{
				try
				{
					await ExecuteEmployeeProcedures(employee, userProfile, 1, null);
					transaction.Commit(); // Confirmar la transacción si todo ha ido bien
					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred while creating the employee: " + ex.Message);
					transaction.Rollback(); // Deshacer la transacción si hay un error
					return false;
				}
			}
		}
		public async Task<bool> UpdateEmployeeById(int id, Employee employee, UserProfile userProfile)
		{
			using (var transaction = _dbFarmaciaContext.Database.BeginTransaction())
			{
				try
				{
					await ExecuteEmployeeProcedures(employee, userProfile, 0, id);
					transaction.Commit(); // Confirmar la transacción si todo ha ido bien
					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred while updating the employee: " + ex.Message);
					transaction.Rollback(); // Deshacer la transacción si hay un error
					return false;
				}
			}
		}
		private async Task ExecuteEmployeeProcedures(Employee employee, UserProfile userProfile, int operation, int? id)
		{
			var firstNamesParam = new SqlParameter("@FirstNames", employee.FirstNames);
			var lastNamesParam = new SqlParameter("@LastNames", employee.LastNames);
			var emailAddressParam = new SqlParameter("@EmailAddress", employee.EmailAddress);
			var dniParam = new SqlParameter("@Dni", employee.Dni);
			var phoneParam = new SqlParameter("@Phone", employee.Phone);
			var roleIdParam = new SqlParameter("@RoleId", employee.RoleId);
			var stateParam = new SqlParameter("@State", employee.State);
			var userNameParam = new SqlParameter("@UserName", userProfile.UserName);
			var userPasswordParam = new SqlParameter("@UserPassword", userProfile.UserPassaword);
			var imageProfileParam = new SqlParameter("@ImageProfile", userProfile.ProfileImage);

			if(operation == 1)
			{
				await _dbFarmaciaContext.Database.ExecuteSqlRawAsync(
                "EXEC CreateEmployee @FirstNames, @LastNames, @EmailAddress, @Dni, @Phone, @RoleId, @State, @UserName, @UserPassword, @ImageProfile",
				firstNamesParam, lastNamesParam, emailAddressParam, dniParam, phoneParam, roleIdParam, stateParam, userNameParam, userPasswordParam, imageProfileParam);
			}
			else
			{
				var employeeIdParam = new SqlParameter("@EmployeeId",id);

				await _dbFarmaciaContext.Database.ExecuteSqlRawAsync(
				"EXEC UpdateEmployee @EmployeeId, @FirstNames, @LastNames, @EmailAddress, @Dni, @Phone, @RoleId, @State, @UserName, @UserPassword, @ImageProfile",
				employeeIdParam, firstNamesParam, lastNamesParam, emailAddressParam, dniParam, phoneParam, roleIdParam, stateParam, userNameParam, userPasswordParam, imageProfileParam);
			}

			await _dbFarmaciaContext.SaveChangesAsync();
		}
		public async Task<bool> DeleteEmployeeById(int id)
		{
            using (var transaction = _dbFarmaciaContext.Database.BeginTransaction())
            {
                try
                {
                    var employeeIdParam = new SqlParameter("@Id", id);

                    await _dbFarmaciaContext.Database.ExecuteSqlRawAsync(
                    "EXEC DeleteEmployee @Id", employeeIdParam);
                    transaction.Commit(); // Confirmar la transacción si todo ha ido bien

                    await _dbFarmaciaContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while deleting the employee: " + ex.Message);
                    transaction.Rollback(); // Deshacer la transacción si hay un error
                    return false;
                }
            }
		}
	}
}
