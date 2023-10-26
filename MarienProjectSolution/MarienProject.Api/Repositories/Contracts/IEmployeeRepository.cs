using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts;

public interface IEmployeeRepository
{
	Task<IEnumerable<Empleado>> GetAllEmployees();
	Task<Empleado> GetEmployeeById(int id);
	Task<bool> CreateEmployee(Empleado newEmployee);
	Task<bool> UpdateEmployeeById(Empleado updatedEmployee);
	Task<bool> DeleteEmployeeById(int id);
}
