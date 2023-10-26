namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

public static class DtoConvertion
{
	public static IEnumerable<EmployeeDto> ConvertToDto(this IEnumerable<Empleado> employees)
	{
		return (from employee in employees
				select new EmployeeDto
				{
					EmpleadoId = employee.EmpleadoId,
					EmpleadoNombres = employee.EmpleadoNombres,
					EmpleadoApellidos = employee.EmpleadoApellidos,
					EmpleadoCorreoElectronico = employee.EmpleadoCorreoElectronico,
					EmpleadoDni = employee.EmpleadoDni,
					EmpleadoEstado = employee.EmpleadoEstado,
					EmpleadoTelefono = employee.EmpleadoTelefono,
					EmpleadoNombreUsuario = employee.EmpleadoNombreUsuario,
					EmpleadoContraseña = employee.EmpleadoContraseña,
					RolId = employee.RolId,
					RolNombre = employee.Rol.RolNombre,
				});
	}
	public static EmployeeDto ConvertToDto(this Empleado employee)
	{
		return new EmployeeDto
		{
			EmpleadoId = employee.EmpleadoId,
			EmpleadoNombres = employee.EmpleadoNombres,
			EmpleadoApellidos = employee.EmpleadoApellidos,
			EmpleadoCorreoElectronico = employee.EmpleadoCorreoElectronico,
			EmpleadoDni = employee.EmpleadoDni,
			EmpleadoEstado = employee.EmpleadoEstado,
			EmpleadoTelefono = employee.EmpleadoTelefono,
			EmpleadoNombreUsuario = employee.EmpleadoNombreUsuario,
			EmpleadoContraseña = employee.EmpleadoContraseña,
			RolId = employee.RolId,
			RolNombre = employee.Rol.RolNombre,
		};
	}
}
