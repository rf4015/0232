using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Empleado
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

    public virtual ICollection<DetalleDeCompra> DetalleDeCompras { get; set; } = new List<DetalleDeCompra>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual ICollection<Ventum> VentumEmpleadoIdRepartidorNavigations { get; set; } = new List<Ventum>();

    public virtual ICollection<Ventum> VentumEmpleados { get; set; } = new List<Ventum>();
}
