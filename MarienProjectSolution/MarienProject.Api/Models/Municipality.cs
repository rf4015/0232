using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Municipality
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Name { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
