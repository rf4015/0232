using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicamentoAlmacenado
{
    public int MedicamentoAlmacenadoId { get; set; }

    public int DetalleMedicamentoId { get; set; }

    public int ProveedorId { get; set; }

    public int? AlmcUnidadMedidaId { get; set; }

    public int? AlmcUbicacionId { get; set; }

    public string? MedicamentoAlmacenadoLote { get; set; }

    public int MedicamentoAlmacenadoExistencias { get; set; }

    public decimal MedicamentoAlmacenadoPrecioDeCompra { get; set; }

    public decimal MedicamentoAlmacenadoPrecioDeVenta { get; set; }

    public DateTime? MedicamentoAlmacenadoFechaDeVencimiento { get; set; }

    public DateTime? MedicamentoAlmacenadoFechaDeExpedicion { get; set; }

    public string? MedicamentoAlmacenadoAdvertenciaDeVencimiento { get; set; }

    public string MedicamentoAlmacenadoEstado { get; set; } = null!;

    public virtual CatUbicacionAlmacen? AlmcUbicacion { get; set; }

    public virtual UnidadDeMedidum? AlmcUnidadMedida { get; set; }

    public virtual ICollection<DetalleDeCompra> DetalleDeCompras { get; set; } = new List<DetalleDeCompra>();

    public virtual DetalleMedicamento DetalleMedicamento { get; set; } = null!;

    public virtual ICollection<MedicamentoEnStock> MedicamentoEnStocks { get; set; } = new List<MedicamentoEnStock>();

    public virtual ICollection<MovimientoInterno> MovimientoInternos { get; set; } = new List<MovimientoInterno>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
