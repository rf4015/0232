using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Rol
{
    public int RolId { get; set; }

    public string RolNombre { get; set; } = null!;

    public string? RolDescripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
