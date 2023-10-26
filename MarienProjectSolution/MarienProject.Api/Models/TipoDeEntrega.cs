using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class TipoDeEntrega
{
    public int TipoDeEntregaId { get; set; }

    public string TipoDeEntregaTipoEntrega { get; set; } = null!;

    public string? TipoDeEntregaDescripcion { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
