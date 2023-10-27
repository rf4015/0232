using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int InvoiceStatusId { get; set; }

    public int DeliveryTypeId { get; set; }

    public int? EmployeeId { get; set; }

    public int? DeliveryEmployeeId { get; set; }

    public int? MunicipalityId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShippingDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Address { get; set; }

    public string? Residence { get; set; }

    public string? PostalCode { get; set; }

    public string? CreditCardNumber { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee? DeliveryEmployee { get; set; }

    public virtual DeliveryType DeliveryType { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual InvoiceStatus InvoiceStatus { get; set; } = null!;

    public virtual Municipality? Municipality { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
