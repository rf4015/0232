using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicamentoEnStock
{
    public int MedicamentoEnStockId { get; set; }

    public int MedicamentoAlmacenadoId { get; set; }

    public int MovimientoInternoId { get; set; }

    public int? StckUbicacionId { get; set; }

    public int MedicamentoEnStockExistencias { get; set; }

    public decimal MedicamentoEnStockPrecioDeVenta { get; set; }

    public virtual ICollection<DetalleDeVentum> DetalleDeVenta { get; set; } = new List<DetalleDeVentum>();

    public virtual MedicamentoAlmacenado MedicamentoAlmacenado { get; set; } = null!;

    public virtual MovimientoInterno MovimientoInterno { get; set; } = null!;

    public virtual CatUbicacionEstante? StckUbicacion { get; set; }
}
