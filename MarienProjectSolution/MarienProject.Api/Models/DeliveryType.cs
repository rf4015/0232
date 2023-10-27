using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class DeliveryType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
