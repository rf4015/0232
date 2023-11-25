using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicationInStock
{
    public int Id { get; set; }

    public int StoredMedicationId { get; set; }

    public int InternalMovementId { get; set; }

    public int? LocationId { get; set; }

    public int Stock { get; set; }

    public decimal SellingPrice { get; set; }

    public virtual InternalMovement InternalMovement { get; set; }

    public virtual ShelfLocationCategory Location { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual StoredMedication StoredMedication { get; set; }
}
