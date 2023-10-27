using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstNames { get; set; } = null!;

    public string LastNames { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual UserProfile? User { get; set; }
}
