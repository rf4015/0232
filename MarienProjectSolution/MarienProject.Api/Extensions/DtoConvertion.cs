namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

public static class DtoConvertion
{
	public static IEnumerable<EmployeeDto> ConvertToDto(this IEnumerable<Employee> employees)
	{
		return (from employee in employees
				select new EmployeeDto
				{
					Id = employee.Id,
					FirstNames = employee.FirstNames,
					LastNames = employee.LastNames,
					EmailAddress = employee.EmailAddress,
					Dni = employee.Dni,
					State = employee.State,
					Phone = employee.Phone,
					UserId = employee.User.Id, 
					UserName = employee.User.UserName,
					UserPassword = employee.User.UserPassaword,
					RoleId = employee.Role.Id,
					RolName = employee.Role.Name,
				}).ToList();
	}
	public static EmployeeDto ConvertToDto(this Employee employee)
	{
		return new EmployeeDto
		{
			Id = employee.Id,
			FirstNames = employee.FirstNames,
			LastNames = employee.LastNames,
			EmailAddress = employee.EmailAddress,
			Dni = employee.Dni,
			State = employee.State,
			Phone = employee.Phone,
			UserName = employee.User.UserName,
			UserPassword = employee.User.UserPassaword,
			RoleId = employee.Role.Id,
			RolName = employee.Role.Name,
		};
	}
}
