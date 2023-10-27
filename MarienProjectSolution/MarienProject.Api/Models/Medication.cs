﻿using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public bool? State { get; set; }

    public virtual MedicationCategory Category { get; set; } = null!;

    public virtual ICollection<MedicationDetail> MedicationDetails { get; set; } = new List<MedicationDetail>();
}
