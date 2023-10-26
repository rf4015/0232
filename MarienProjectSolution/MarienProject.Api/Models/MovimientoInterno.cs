using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MovimientoInterno
{
    public int MovimientoInternoId { get; set; }

    public int MedicamentoAlmacenadoId { get; set; }

    public string? MovimientoInternoDescripcion { get; set; }

    public string? MovimientoInternoLote { get; set; }

    public DateTime? MovimientoInternoFecha { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual MedicamentoAlmacenado MedicamentoAlmacenado { get; set; } = null!;

    public virtual ICollection<MedicamentoEnStock> MedicamentoEnStocks { get; set; } = new List<MedicamentoEnStock>();
}
