using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Municipio
{
    public int MunicipioId { get; set; }

    public int CiudadId { get; set; }

    public string? MunicipioNombre { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual ICollection<DireccionCliente> DireccionClientes { get; set; } = new List<DireccionCliente>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
