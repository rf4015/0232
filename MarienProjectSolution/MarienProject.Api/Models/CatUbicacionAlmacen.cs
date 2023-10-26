using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class CatUbicacionAlmacen
{
    public int UbicacionId { get; set; }

    public string UbicacionNombre { get; set; } = null!;

    public int? UbicacionAlmacenId { get; set; }

    public bool? UbicacionEstado { get; set; }

    public virtual ICollection<MedicamentoAlmacenado> MedicamentoAlmacenados { get; set; } = new List<MedicamentoAlmacenado>();

    public virtual CatAlmacen? UbicacionAlmacen { get; set; }
}
