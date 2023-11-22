using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class SaleDetail
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int MedicationInStockId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public double Discount { get; set; }

    public double Tax { get; set; }

    public double Subtotal { get; set; }

    public double Total { get; set; }

    public virtual MedicationInStock MedicationInStock { get; set; }

    public virtual Sale Sale { get; set; }
}
