using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Ciudad
{
    public int CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
