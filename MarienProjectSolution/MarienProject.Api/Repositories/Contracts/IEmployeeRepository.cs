using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts;

public interface IEmployeeRepository
{
	Task<IEnumerable<Employee>> GetAllEmployees();
	Task<Employee> GetEmployeeById(int id);
	Task<bool> CreateEmployee(Employee newEmployee, UserProfile userProfile);
	Task<bool> UpdateEmployeeById(int id, Employee employee, UserProfile userProfile);
	Task<bool> DeleteEmployeeById(int id);
}
