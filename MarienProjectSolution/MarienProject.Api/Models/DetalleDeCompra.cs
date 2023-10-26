using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class DetalleDeCompra
{
    public int DetalleDeCompraId { get; set; }

    public int CompraId { get; set; }

    public int MedicamentoAlmacenadoId { get; set; }

    public int EmpleadoId { get; set; }

    public double DetalleDeCompraPrecio { get; set; }

    public int DetalleDeCompraCantidad { get; set; }

    public double DetalleDeCompraDescuento { get; set; }

    public double DetalleDeCompraIva { get; set; }

    public double DetalleDeCompraSubtotal { get; set; }

    public double DetalleDeCompraTotal { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual MedicamentoAlmacenado MedicamentoAlmacenado { get; set; } = null!;
}
