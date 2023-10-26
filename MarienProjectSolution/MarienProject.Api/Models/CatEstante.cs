using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class CatEstante
{
    public int EstanteId { get; set; }

    public string EstanteNombre { get; set; } = null!;

    public bool? EstanteEstado { get; set; }

    public virtual ICollection<CatUbicacionEstante> CatUbicacionEstantes { get; set; } = new List<CatUbicacionEstante>();
}
