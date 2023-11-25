using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicationCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
}
