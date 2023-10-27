using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class StorageCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public virtual ICollection<StorageLocationCategory> StorageLocationCategories { get; set; } = new List<StorageLocationCategory>();
}
