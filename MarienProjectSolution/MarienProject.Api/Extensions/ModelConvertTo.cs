namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;
public static class ModelConvertTo
{
	public static Empleado ConvertToModel(this EmployeeDto employeeDto)
	{
		return new Empleado
		{
			EmpleadoId = employeeDto.EmpleadoId,
			EmpleadoNombres = employeeDto.EmpleadoNombres,
			EmpleadoApellidos = employeeDto.EmpleadoApellidos,
			EmpleadoCorreoElectronico = employeeDto.EmpleadoCorreoElectronico,
			EmpleadoDni = employeeDto.EmpleadoDni,
			EmpleadoEstado = employeeDto.EmpleadoEstado,
			EmpleadoTelefono = employeeDto.EmpleadoTelefono,
			EmpleadoNombreUsuario = employeeDto.EmpleadoNombreUsuario,
			EmpleadoContraseña = employeeDto.EmpleadoContraseña,
			RolId = employeeDto.RolId,
		};
	}
}
