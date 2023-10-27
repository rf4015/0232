using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class StoredMedication
{
    public int Id { get; set; }

    public int MedicationDetailId { get; set; }

    public int SupplierId { get; set; }

    public int? UnitMeasurementId { get; set; }

    public int? LocationId { get; set; }

    public string? Batch { get; set; }

    public int Stock { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal SellingPrice { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? ExpeditionDate { get; set; }

    public string? ExpiryWarning { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<InternalMovement> InternalMovements { get; set; } = new List<InternalMovement>();

    public virtual StorageLocationCategory? Location { get; set; }

    public virtual MedicationDetail MedicationDetail { get; set; } = null!;

    public virtual ICollection<MedicationInStock> MedicationInStocks { get; set; } = new List<MedicationInStock>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual UnitOfMeasurement? UnitMeasurement { get; set; }
}
