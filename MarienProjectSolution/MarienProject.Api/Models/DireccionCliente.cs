using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class DireccionCliente
{
    public int DireccionClienteId { get; set; }

    public int ClienteId { get; set; }

    public int MunicipioId { get; set; }

    public string DireccionClienteDireccion { get; set; } = null!;

    public string DireccionClienteVivienda { get; set; } = null!;

    public string? DireccionClienteCodigoPostal { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Municipio Municipio { get; set; } = null!;
}
