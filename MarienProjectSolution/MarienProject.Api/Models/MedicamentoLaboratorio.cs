using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicamentoLaboratorio
{
    public int MedicamentoLaboratorioId { get; set; }

    public string MedicamentoLaboratorioNombre { get; set; } = null!;

    public string MedicamentoLaboratorioEstado { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<DetalleMedicamento> DetalleMedicamentos { get; set; } = new List<DetalleMedicamento>();
}
