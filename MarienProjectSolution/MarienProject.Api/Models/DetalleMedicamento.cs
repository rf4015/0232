using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class DetalleMedicamento
{
    public int DetalleMedicamentoId { get; set; }

    public int MedicamentoId { get; set; }

    public int MedicamentoLaboratorioId { get; set; }

    public int MedicamentoNombreGenericoId { get; set; }

    public string? DetalleMedicamentoDescripcion { get; set; }

    public DateTime? DetalleMedicamentoPrescripcion { get; set; }

    public bool? DetalleMedicamentoEstado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Medicamento Medicamento { get; set; } = null!;

    public virtual ICollection<MedicamentoAlmacenado> MedicamentoAlmacenados { get; set; } = new List<MedicamentoAlmacenado>();

    public virtual MedicamentoLaboratorio MedicamentoLaboratorio { get; set; } = null!;

    public virtual MedicamentoNombreGenerico MedicamentoNombreGenerico { get; set; } = null!;
}
