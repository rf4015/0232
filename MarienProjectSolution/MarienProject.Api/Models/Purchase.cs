using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int InvoiceStatusId { get; set; }

    public virtual InvoiceStatus InvoiceStatus { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
