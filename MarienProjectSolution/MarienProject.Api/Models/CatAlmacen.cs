using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class CatAlmacen
{
    public int AlmacenId { get; set; }

    public string AlmacenNombre { get; set; } = null!;

    public bool? AlmacenEstado { get; set; }

    public virtual ICollection<CatUbicacionAlmacen> CatUbicacionAlmacens { get; set; } = new List<CatUbicacionAlmacen>();
}
