using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Medicamento
{
    public int MedicamentoId { get; set; }

    public string MedicamentoNombre { get; set; } = null!;

    public int MedicamentoCategoriaId { get; set; }

    public bool? MedicamentoEstado { get; set; }

    public virtual ICollection<DetalleMedicamento> DetalleMedicamentos { get; set; } = new List<DetalleMedicamento>();

    public virtual MedicamentoCategorium MedicamentoCategoria { get; set; } = null!;
}
