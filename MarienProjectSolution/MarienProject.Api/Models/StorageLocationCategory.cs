using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class StorageLocationCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? StorageId { get; set; }

    public bool? State { get; set; }

    public virtual StorageCategory Storage { get; set; }

    public virtual ICollection<StoredMedication> StoredMedications { get; set; } = new List<StoredMedication>();
}
