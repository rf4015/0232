using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Compra
{
    public int CompraId { get; set; }

    public int ProveedorId { get; set; }

    public DateTime CompraFechaEntrega { get; set; }

    public int EstadoFacturaId { get; set; }

    public virtual ICollection<DetalleDeCompra> DetalleDeCompras { get; set; } = new List<DetalleDeCompra>();

    public virtual EstadoFactura EstadoFactura { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}
