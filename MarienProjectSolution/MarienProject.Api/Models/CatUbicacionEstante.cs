using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class CatUbicacionEstante
{
    public int UbicacionId { get; set; }

    public string UbicacionNombre { get; set; } = null!;

    public int? UbicacionEstanteId { get; set; }

    public bool? UbicacionEstado { get; set; }

    public virtual ICollection<MedicamentoEnStock> MedicamentoEnStocks { get; set; } = new List<MedicamentoEnStock>();

    public virtual CatEstante? UbicacionEstante { get; set; }
}
