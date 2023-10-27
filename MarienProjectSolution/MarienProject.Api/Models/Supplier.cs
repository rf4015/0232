using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<StoredMedication> StoredMedications { get; set; } = new List<StoredMedication>();
}
