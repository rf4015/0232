using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public string NotesPrescription { get; set; }

    public bool? State { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<StoredMedication> StoredMedications { get; set; } = new List<StoredMedication>();
}
