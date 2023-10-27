using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts;

public interface IEmployeeRepository
{
	Task<IEnumerable<Employee>> GetAllEmployees();
	Task<Employee> GetEmployeeById(int id);
	Task<bool> CreateEmployee(Employee newEmployee);
	Task<bool> UpdateEmployeeById(Employee updatedEmployee);
	Task<bool> DeleteEmployeeById(int id);
}
