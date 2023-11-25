using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstNames { get; set; }

    public string LastNames { get; set; }

    public string Phone { get; set; }

    public string EmailAddress { get; set; }

    public string Dni { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Role Role { get; set; }

    public virtual ICollection<Sale> SaleDeliveryEmployees { get; set; } = new List<Sale>();

    public virtual ICollection<Sale> SaleEmployees { get; set; } = new List<Sale>();

    public virtual UserProfile User { get; set; }
}
