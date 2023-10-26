using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class DetalleDeVentum
{
    public int DetalleDeVentaId { get; set; }

    public int VentaId { get; set; }

    public int MedicamentoEnStockId { get; set; }

    public double DetalleDeVentaPrecio { get; set; }

    public int DetalleDeVentaCantidad { get; set; }

    public double DetalleDeVentaDescuento { get; set; }

    public double DetalleDeVentaIva { get; set; }

    public double DetalleDeVentaSubtotal { get; set; }

    public double DetalleDeVentaTotal { get; set; }

    public virtual MedicamentoEnStock MedicamentoEnStock { get; set; } = null!;

    public virtual Ventum Venta { get; set; } = null!;
}
