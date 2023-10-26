using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Ventum
{
    public int VentaId { get; set; }

    public int ClienteId { get; set; }

    public int EstadoFacturaId { get; set; }

    public int TipoDeEntregaId { get; set; }

    public int? EmpleadoId { get; set; }

    public int? EmpleadoIdRepartidor { get; set; }

    public int? MunicipioId { get; set; }

    public DateTime? VentaFechaPedido { get; set; }

    public DateTime? VentaFechaEnvio { get; set; }

    public DateTime? VentaFechaEntrega { get; set; }

    public string? VentaDireccion { get; set; }

    public string? VentaVivienda { get; set; }

    public string? VentaCodigoPostal { get; set; }

    public string? VentaNumeroTarjeta { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleDeVentum> DetalleDeVenta { get; set; } = new List<DetalleDeVentum>();

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleado? EmpleadoIdRepartidorNavigation { get; set; }

    public virtual EstadoFactura EstadoFactura { get; set; } = null!;

    public virtual Municipio? Municipio { get; set; }

    public virtual TipoDeEntrega TipoDeEntrega { get; set; } = null!;
}
