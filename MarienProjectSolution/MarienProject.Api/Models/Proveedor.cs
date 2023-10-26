using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Proveedor
{
    public int ProveedorId { get; set; }

    public string ProveedorNombre { get; set; } = null!;

    public string? ProveedorDni { get; set; }

    public string? ProveedorEmail { get; set; }

    public int? ProveedorTelefono { get; set; }

    public bool? ProveedorEstado { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<MedicamentoAlmacenado> MedicamentoAlmacenados { get; set; } = new List<MedicamentoAlmacenado>();
}
