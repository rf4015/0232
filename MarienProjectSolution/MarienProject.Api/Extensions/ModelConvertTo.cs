namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;
public static class ModelConvertTo
{
	public static object[] ConvertToModel(this SaveEmployeeDto employeeDto)
	{
		UserProfile userProfile = new UserProfile
		{
			UserName = employeeDto.UserName,
			UserPassaword = employeeDto.UserPassword,
			ProfileImage = employeeDto.ProfileImage,

		};
		Employee employee = new Employee
		{
			FirstNames = employeeDto.FirstNames,
			LastNames = employeeDto.LastNames,
			EmailAddress = employeeDto.EmailAddress,
			Dni = employeeDto.Dni,
			State = employeeDto.State,
			Phone = employeeDto.Phone,
			RoleId = employeeDto.RoleId
		};
		return new object[] { employee, userProfile };
	}
}
