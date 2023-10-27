using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class InvoiceStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
