using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class ShelfCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public virtual ICollection<ShelfLocationCategory> ShelfLocationCategories { get; set; } = new List<ShelfLocationCategory>();
}
