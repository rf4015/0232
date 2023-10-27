using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicationDetail
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int MedicationLaboratoryId { get; set; }

    public int GenericMedicationNameId { get; set; }

    public string? Description { get; set; }

    public DateTime? Prescription { get; set; }

    public bool? State { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual GenericMedicationName GenericMedicationName { get; set; } = null!;

    public virtual Medication Medication { get; set; } = null!;

    public virtual MedicationLaboratory MedicationLaboratory { get; set; } = null!;

    public virtual ICollection<StoredMedication> StoredMedications { get; set; } = new List<StoredMedication>();
}
