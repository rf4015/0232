using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class ShelfLocationCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ShelfId { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<MedicationInStock> MedicationInStocks { get; set; } = new List<MedicationInStock>();

    public virtual ShelfCategory? Shelf { get; set; }
}
