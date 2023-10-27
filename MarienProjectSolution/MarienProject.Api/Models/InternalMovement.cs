using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class InternalMovement
{
    public int Id { get; set; }

    public int StoredMedicationId { get; set; }

    public string? Description { get; set; }

    public string? Batch { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<MedicationInStock> MedicationInStocks { get; set; } = new List<MedicationInStock>();

    public virtual StoredMedication StoredMedication { get; set; } = null!;
}
