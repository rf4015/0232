using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class PurchaseDetail
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int StoredMedicationId { get; set; }

    public int EmployeeId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public double Discount { get; set; }

    public double Tax { get; set; }

    public double Subtotal { get; set; }

    public double Total { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;

    public virtual StoredMedication StoredMedication { get; set; } = null!;
}
