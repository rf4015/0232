using MarienProject.Models.Dtos;

namespace MarienProject.Web.Services.Contracts
{
	public interface IEmployeeService
	{
        Task<List<EmployeeDto>> GetAllEmployee();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<bool> CreateEmployee(EmployeeDto employeeDto);
        Task<bool> UpdateEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int id);
	}
}
