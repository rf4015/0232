using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class UnidadDeMedidum
{
    public int UnidadDeMedidaId { get; set; }

    public string? UnidadDeMedidaNombre { get; set; }

    public virtual ICollection<Conversion> Conversions { get; set; } = new List<Conversion>();

    public virtual ICollection<MedicamentoAlmacenado> MedicamentoAlmacenados { get; set; } = new List<MedicamentoAlmacenado>();
}
