namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;
public static class ModelConvertTo
{
	public static Employee ConvertToModel(this EmployeeDto employeeDto)
	{
		return new Employee
		{
			Id = employeeDto.Id,
			FirstNames = employeeDto.FirstNames,
			LastNames = employeeDto.LastNames,
			EmailAddress = employeeDto.EmailAddress,
			Dni = employeeDto.Dni,
			State = employeeDto.State,
			Phone = employeeDto.Phone,
			RoleId = employeeDto.RoleId
		};
	}
}
