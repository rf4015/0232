using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos
{
	public class EmployeeDto
	{
		public int EmpleadoId { get; set; }

		public int RolId { get; set; }

		public string EmpleadoNombres { get; set; } = null!;

		public string EmpleadoApellidos { get; set; } = null!;

		public string EmpleadoTelefono { get; set; } = null!;

		public string EmpleadoDni { get; set; } = null!;

		public string EmpleadoCorreoElectronico { get; set; } = null!;

		public string EmpleadoNombreUsuario { get; set; } = null!;

		public string EmpleadoContraseña { get; set; } = null!;

		public bool? EmpleadoEstado { get; set; }

		public string RolNombre { get; set; } = null!;
	}
}
