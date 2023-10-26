using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Conversion
{
    public int ConversionId { get; set; }

    public int UnidadDeMedidaId { get; set; }

    public string? ConversionDescripcion { get; set; }

    public int? ConversionValor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual UnidadDeMedidum UnidadDeMedida { get; set; } = null!;
}
