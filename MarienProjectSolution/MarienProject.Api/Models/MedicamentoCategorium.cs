using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicamentoCategorium
{
    public int MedicamentoCategoriaId { get; set; }

    public string MedicamentoCategoriaNombre { get; set; } = null!;

    public bool? MedicamentoCategoriaEstado { get; set; }

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
