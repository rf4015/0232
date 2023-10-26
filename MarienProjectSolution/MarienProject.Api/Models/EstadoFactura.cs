using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class EstadoFactura
{
    public int EstadoFacturaId { get; set; }

    public string EstadoFacturaEstado { get; set; } = null!;

    public string? EstadoFacturaDescripcion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
