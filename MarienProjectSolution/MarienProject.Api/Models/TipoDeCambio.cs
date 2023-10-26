using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class TipoDeCambio
{
    public int MonedaId { get; set; }

    public DateTime? TipoDeCambioFecha { get; set; }

    public double TipoDeCambioValorCompra { get; set; }

    public double TipoDeCambioValorventa { get; set; }

    public virtual Monedum Moneda { get; set; } = null!;
}
