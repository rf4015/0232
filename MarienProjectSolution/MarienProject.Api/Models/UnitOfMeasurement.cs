using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class UnitOfMeasurement
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Conversion> Conversions { get; set; } = new List<Conversion>();

    public virtual ICollection<StoredMedication> StoredMedications { get; set; } = new List<StoredMedication>();
}
